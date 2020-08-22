using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlazorPeliculas.Server.Helpers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SurcosBlazor.Server.Context;
using SurcosBlazor.Server.Helpers;
using SurcosBlazor.Shared;
using SurcosBlazor.Shared.Entidades;

namespace SurcosBlazor.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdenPagoController : ControllerBase
    {
        private readonly WebApiDbContext _context;

        public OrdenPagoController(WebApiDbContext context)
        {
            _context = context;
        }

        // GET: api/OrdenPago
        [HttpGet]
        public async Task<ActionResult<IEnumerable<OrdenPago>>> GetordenPago([FromQuery] Paginacion paginacion, int cantidadDeRegistros)
        {
            var queryable = _context.ordenPago.Include(x => x.EstadoRecibo).Include(x => x.Proveedor).OrderByDescending(x => x.fecha).AsQueryable();
            if (cantidadDeRegistros != 0)
            {
                paginacion.CantidadRegistros = cantidadDeRegistros;
            }
            await HttpContext.InsertarParametrosPaginacionEnRespuesta(queryable, paginacion.CantidadRegistros);
            return await queryable.Paginar(paginacion).ToListAsync();
        }

        // GET: api/OrdenPago/5
        [HttpGet("{id}")]
        public async Task<ActionResult<OrdenPago>> GetOrdenPago(int id)
        {
            var ordenPago = await _context.ordenPago.Include(x => x.Proveedor).Include(x => x.Imputaciones).Include(x => x.movimientosCaja).FirstOrDefaultAsync(x => x.Id == id);

            if (ordenPago == null)
            {
                return NotFound();
            }
            foreach (MovimientoCaja movimiento in ordenPago.movimientosCaja)
            {

                movimiento.Caja = await _context.caja.FindAsync(movimiento.CajaId);
            }
            foreach (ImputacionComprobantesCompra imputacion in ordenPago.Imputaciones)
            {

                imputacion.FacturaCompras = await _context.facturaCompra.Include(x => x.EstadoFactura).FirstOrDefaultAsync(x => x.Id == imputacion.FacturaComprasId);
            }
            return ordenPago;
        }

        // PUT: api/OrdenPago/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        

        // POST: api/OrdenPago
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<OrdenPago>> PostOrdenPago(OrdenPago ordenPago)
        {
            try
            {
                List<ImputacionComprobantesCompra> imputaciones = ordenPago.Imputaciones;
                List<MovimientoCaja> movimientoCajas = ordenPago.movimientosCaja;
                Proveedor proveedor = ordenPago.Proveedor;
                ordenPago.Proveedor = null;
                ordenPago.Imputaciones = null;
                ordenPago.movimientosCaja = null;

                _context.ordenPago.Add(ordenPago);
                proveedor.saldoCC += ordenPago.totalComprobante;
                _context.Entry(proveedor).State = EntityState.Modified;
                await _context.SaveChangesAsync();

                foreach (ImputacionComprobantesCompra imputacion in imputaciones)
                {

                    imputacion.OrdenPagoId = ordenPago.Id;
                    _context.Entry(imputacion).State = EntityState.Added;

                    imputacion.FacturaCompras.totalCancelado += imputacion.totalImputado;
                    if (imputacion.FacturaCompras.totalCancelado == imputacion.FacturaCompras.totalComprobante)
                    {
                        imputacion.FacturaCompras.EstadoFacturaId = 2;
                    }
                    _context.Entry(imputacion.FacturaCompras).State = EntityState.Modified;

                    await _context.SaveChangesAsync();
                }

                foreach (MovimientoCaja movimientoCaja in movimientoCajas)
                {

                    movimientoCaja.OrdenPagoId = ordenPago.Id;
                    movimientoCaja.entra = false;
                    movimientoCaja.sale = true;
                    _context.Entry(movimientoCaja).State = EntityState.Added;

                    movimientoCaja.Caja.saldo -= movimientoCaja.totalMovimiento;
                    _context.Entry(movimientoCaja.Caja).State = EntityState.Modified;


                    await _context.SaveChangesAsync();

                }

                return CreatedAtAction("GetOrdenPago", new { id = ordenPago.Id }, ordenPago);
            }
            catch (Exception es)
            {

                throw;
            }
        }

        // DELETE: api/OrdenPago/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<OrdenPago>> DeleteOrdenPago(int id)
        {
            var ordenPago = await _context.ordenPago.Include(x => x.Imputaciones).Include(x => x.movimientosCaja).FirstOrDefaultAsync(x => x.Id == id);
            if (ordenPago == null)
            {
                return NotFound();
            }

            foreach (MovimientoCaja movimientoCaja in ordenPago.movimientosCaja)
            {
                Caja caja = await _context.caja.FindAsync(movimientoCaja.CajaId);
                caja.saldo += movimientoCaja.totalMovimiento;
                _context.Entry(caja).State = EntityState.Modified;
                _context.Entry(movimientoCaja).State = EntityState.Deleted;
            }
            foreach (ImputacionComprobantesCompra imputacion in ordenPago.Imputaciones)
            {
                FacturaCompras factura = await _context.facturaCompra.FindAsync(imputacion.FacturaComprasId);
                factura.totalCancelado -= imputacion.totalImputado;
                factura.EstadoFacturaId = 1;
                _context.Entry(factura).State = EntityState.Modified;
                _context.Entry(imputacion).State = EntityState.Deleted;
            }

            Proveedor proveedor = await _context.Proveedor.FindAsync(ordenPago.ProveedorId);
            proveedor.saldoCC -= ordenPago.totalComprobante;
            _context.Entry(proveedor).State = EntityState.Modified;
            _context.ordenPago.Remove(ordenPago);
            await _context.SaveChangesAsync();

            return ordenPago;
        }
        [HttpGet("OrdenesDePagoProveedor")]
        public async Task<ActionResult<List<OrdenPago>>> GetOrdenesDePagoProveedor(
                                                            int proveedorId)
        {
            try
            {
                var listadoOrdenes = await _context.ordenPago.Where(x => x.ProveedorId == proveedorId).Include(x => x.EstadoRecibo).ToListAsync();

                return listadoOrdenes;

            }
            catch (Exception ex)
            {

                throw;

            }

        }
        private bool OrdenPagoExists(int id)
        {
            return _context.ordenPago.Any(e => e.Id == id);
        }
    }
}
