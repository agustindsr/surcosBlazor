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
    public class ReciboCobranzaController : ControllerBase
    {
        private readonly WebApiDbContext _context;

        public ReciboCobranzaController(WebApiDbContext context)
        {
            _context = context;
        }

        // GET: api/ReciboCobranza
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ReciboCobranzas>>> GetreciboCobranzas([FromQuery] Paginacion paginacion, int cantidadDeRegistros)
        {
            var queryable = _context.reciboCobranzas.Include(x => x.EstadoRecibo).Include(x => x.Cliente).OrderByDescending(x => x.fecha).AsQueryable();
            if (cantidadDeRegistros != 0)
            {
                paginacion.CantidadRegistros = cantidadDeRegistros;
            }
            await HttpContext.InsertarParametrosPaginacionEnRespuesta(queryable, paginacion.CantidadRegistros);
            return await queryable.Paginar(paginacion).ToListAsync();
        }
        // GET: api/ReciboCobranza/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ReciboCobranzas>> GetReciboCobranzas(int id)
        {
            try
            {
                ReciboCobranzas reciboCobranzas;
               
                    reciboCobranzas = await _context.reciboCobranzas.Include(x => x.Cliente).Include(x => x.Imputaciones).Include(x => x.movimientosCaja).FirstOrDefaultAsync(x => x.Id == id);
              
              


                if (reciboCobranzas == null)
                {
                    return NotFound();
                }
                foreach (MovimientoCaja movimiento in reciboCobranzas.movimientosCaja)
                {

                    movimiento.Caja = await _context.caja.FindAsync(movimiento.CajaId);
                }
                foreach (ImputacionComprobantesVenta imputacion in reciboCobranzas.Imputaciones)
                {

                    imputacion.FacturaVenta = await _context.factura.Include(x => x.EstadoFactura).FirstOrDefaultAsync(x => x.Id == imputacion.FacturaVentasId);
                }
                return reciboCobranzas;
            }
            catch (Exception ex)
            {

                throw;
            }
            
        }

        // PUT: api/ReciboCobranza/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
    
        [HttpGet("RecibosPorCliente")]
        public async Task<ActionResult<List<ReciboCobranzas>>> GetReciboPorCliente(
                                                             int clienteId)
        {
            try
            {
                var listadoRecibos = await _context.reciboCobranzas.Where(x => x.ClienteId == clienteId).Include(x => x.EstadoRecibo).ToListAsync();

                return listadoRecibos;

            }
            catch (Exception ex)
            {

                throw;

            }

        }
        // POST: api/ReciboCobranza
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<ReciboCobranzas>> PostReciboCobranzas(ReciboCobranzas reciboCobranzas)
        {
            try
            {
                List<ImputacionComprobantesVenta> imputaciones = reciboCobranzas.Imputaciones;
                List<MovimientoCaja> movimientoCajas = reciboCobranzas.movimientosCaja;
                Cliente cliente = reciboCobranzas.Cliente;
                reciboCobranzas.Cliente = null;
                reciboCobranzas.Imputaciones = null;
                reciboCobranzas.movimientosCaja = null;

                _context.reciboCobranzas.Add(reciboCobranzas);
                cliente.saldoCC -= reciboCobranzas.totalComprobante;
                _context.Entry(cliente).State = EntityState.Modified;
                await _context.SaveChangesAsync();

                foreach (ImputacionComprobantesVenta imputacion in imputaciones) {

                    imputacion.ReciboCobranzasId = reciboCobranzas.Id;
                    _context.Entry(imputacion).State = EntityState.Added;

                    imputacion.FacturaVenta.totalCancelado += imputacion.totalImputado;
                    if (imputacion.FacturaVenta.totalCancelado == imputacion.FacturaVenta.totalComprobante) {
                        imputacion.FacturaVenta.EstadoFacturaId = 2;
                    }
                    _context.Entry(imputacion.FacturaVenta).State = EntityState.Modified;

                   await _context.SaveChangesAsync();
                }

                foreach (MovimientoCaja movimientoCaja in movimientoCajas) {

                    movimientoCaja.ReciboCobranzasId = reciboCobranzas.Id;
                    movimientoCaja.entra = true;
                    movimientoCaja.sale = false;
                    _context.Entry(movimientoCaja).State = EntityState.Added;

                    movimientoCaja.Caja.saldo += movimientoCaja.totalMovimiento;
                    _context.Entry(movimientoCaja.Caja).State = EntityState.Modified;

                    
                    await _context.SaveChangesAsync();

                }


                return CreatedAtAction("GetReciboCobranzas", new { id = reciboCobranzas.Id }, reciboCobranzas);
            }
            catch (Exception es)
            {

                throw;
            }
           
        }

        // DELETE: api/ReciboCobranza/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ReciboCobranzas>> DeleteReciboCobranzas(int id)
        {
            var reciboCobranzas = await _context.reciboCobranzas.Include(x => x.Imputaciones).Include(x => x.movimientosCaja).FirstOrDefaultAsync(x => x.Id == id);
            if (reciboCobranzas == null)
            {
                return NotFound();
            }

            foreach (MovimientoCaja movimientoCaja in reciboCobranzas.movimientosCaja) {
                Caja caja = await _context.caja.FindAsync(movimientoCaja.CajaId);
                caja.saldo -= movimientoCaja.totalMovimiento;
                _context.Entry(caja).State = EntityState.Modified;
                _context.Entry(movimientoCaja).State = EntityState.Deleted;
            }
            foreach (ImputacionComprobantesVenta imputacion in reciboCobranzas.Imputaciones)
            {
                Factura factura = await _context.factura.FindAsync(imputacion.FacturaVentasId);
                factura.totalCancelado -= imputacion.totalImputado;
                factura.EstadoFacturaId = 1;
                _context.Entry(factura).State = EntityState.Modified;
                _context.Entry(imputacion).State = EntityState.Deleted;
            }

            Cliente cliente = await _context.cliente.FindAsync(reciboCobranzas.ClienteId);
            cliente.saldoCC += reciboCobranzas.totalComprobante;
            _context.Entry(cliente).State = EntityState.Modified;
            _context.reciboCobranzas.Remove(reciboCobranzas);
            await _context.SaveChangesAsync();

            return reciboCobranzas;
        }

        private bool ReciboCobranzasExists(int id)
        {
            return _context.reciboCobranzas.Any(e => e.Id == id);
        }
    }
}
