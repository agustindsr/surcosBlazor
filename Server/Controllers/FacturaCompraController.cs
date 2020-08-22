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
    public class FacturaCompraController : ControllerBase
    {
        private readonly WebApiDbContext _context;

        public FacturaCompraController(WebApiDbContext context)
        {
            _context = context;
        }

        // GET: api/FacturaCompra
        [HttpGet]
        public async Task<ActionResult<List<FacturaCompras>>> Get([FromQuery] Paginacion paginacion,
                                                            int cantidadDeRegistros,
                                                            string filtro,
                                                            int estadoFacturaId,
                                                             int depositoId,
                                                              int tipoComprobanteId)
        {
            try
            {
                var queryable = _context.facturaCompra
                                                .Include(x => x.Proveedor)
                                                .Include(x => x.EstadoFactura)
                                                .Include(x => x.TipoComprobante)
                                                .Include(x => x.Deposito)
                                                .OrderByDescending(x => x.fecha).AsQueryable();
             
                if (estadoFacturaId != 0)
                {
                    queryable = queryable.Where(x => x.EstadoFacturaId == estadoFacturaId).AsQueryable();
                }
                
                if (cantidadDeRegistros != 0)
                {
                    paginacion.CantidadRegistros = cantidadDeRegistros;
                }
                if (depositoId != 0)
                {
                    queryable = queryable.Where(x => x.DepositoId == depositoId).AsQueryable();
                }
                if (tipoComprobanteId != 0)
                {
                    queryable = queryable.Where(x => x.TipoComprobanteId == tipoComprobanteId).AsQueryable();
                }
                if (cantidadDeRegistros != 0)
                {
                    paginacion.CantidadRegistros = cantidadDeRegistros;
                }
                //if (!string.IsNullOrWhiteSpace(filtro))
                //{
                //    queryable = queryable.Where(x => x..Contains(filtro)).AsQueryable();
                //}
                await HttpContext.InsertarParametrosPaginacionEnRespuesta(queryable, paginacion.CantidadRegistros);
                var listadoFactura = await queryable.Paginar(paginacion).ToListAsync();
                return listadoFactura;

            }
            catch (Exception ex)
            {

                throw;

            }

        }
        [HttpGet("facturasPorProveedorParaRecibo")]
        public async Task<ActionResult<List<FacturaCompras>>> GetFacturasPorProveedorParaRecibo(
                                                           int proveedorId)
        {
            try
            {
                var listadoFactura = await _context.facturaCompra.Where(x => x.ProveedorId == proveedorId && x.TipoComprobanteId == 1 && x.EstadoFacturaId == 1).Include(x => x.TipoComprobante).Include(x => x.EstadoFactura).OrderByDescending(x => x.fecha).ToListAsync();

                return listadoFactura;

            }
            catch (Exception ex)
            {

                throw;

            }

        }
        [HttpGet("facturasPorProveedor")]
        public async Task<ActionResult<List<FacturaCompras>>> GetFacturasPorProveedor(
                                                              int proveedorId)
        {
            try
            {
                var listadoFactura = await _context.facturaCompra.Where(x => x.ProveedorId == proveedorId).Include(x => x.TipoComprobante).Include(x => x.EstadoFactura).OrderByDescending(x => x.fecha).ToListAsync();

                return listadoFactura;

            }
            catch (Exception ex)
            {

                throw;

            }

        }
        // GET: api/FacturaCompra/5
        [HttpGet("{id}")]
        public async Task<ActionResult<FacturaCompras>> GetFacturaCompras(int id)
        {
            var factura = await _context.facturaCompra
                                               
                                                .Include(x => x.Proveedor)
                                                .Include(x => x.EstadoFactura)
                                                .Include(x => x.Deposito)
                                                .Include(x => x.TipoComprobante)
                                                .Include(x => x.detallesFactura).FirstOrDefaultAsync(x => x.Id == id);
            for (int i = 0; i < factura.detallesFactura.Count; i++)
            {
                factura.detallesFactura[i] = _context.detalleFacturaCompras.Include(x => x.ProductoPresentacion)
                    .ThenInclude(x => x.Producto).IgnoreQueryFilters()
                    .Include(x => x.ProductoPresentacion)
                    .ThenInclude(x => x.PresentacionProducto).FirstOrDefault(x => x.Id == factura.detallesFactura[i].Id);
            }

            if (factura == null)
            {
                return NotFound();
            }

            return factura;
        }

        // PUT: api/FacturaCompra/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFacturaCompras(int id, FacturaCompras facturaCompras)
        {
            if (id != facturaCompras.Id)
            {
                return BadRequest();
            }

            _context.Entry(facturaCompras).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FacturaComprasExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/FacturaCompra
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<FacturaCompras>> PostFacturaCompras(FacturaCompras facturaCompras)
        {
            try
            {
                //CREAMOS LA FACTURA
                facturaCompras.Proveedor = null;
                facturaCompras.Deposito = null;
                facturaCompras.detallesFactura.ForEach(x => x.ProductoPresentacion = null);
                facturaCompras.TipoComprobante = null;
              
                facturaCompras.EstadoFactura = null;
                facturaCompras.EstadoFacturaId = (await _context.estadoFactura.FirstOrDefaultAsync(x => x.nombre == "PEN")).Id;
                

                //CREAMOS EL CÓDIGO.
                int cantidadDeFacturas = await _context.facturaCompra.IgnoreQueryFilters()
                                                        .Where(x => x.TipoComprobanteId == facturaCompras.TipoComprobanteId  && x.DepositoId == facturaCompras.DepositoId)
                                                         .CountAsync() + 1;
                int aux = 8 - cantidadDeFacturas.ToString().Length;
                string cerosDeRelleno = "";
                for (int i = 0; i < aux; i++)
                {
                    cerosDeRelleno += "0";
                }
                facturaCompras.codigo = $"0000{facturaCompras.DepositoId}-{cerosDeRelleno}{cantidadDeFacturas}";

                _context.facturaCompra.Add(facturaCompras);
                await _context.SaveChangesAsync();

                // BUSCAMOS LA FACTURA EN LA BASE DE DATOS
               FacturaCompras facturaComprasDb = await _context.facturaCompra
                                        .Include(x => x.TipoComprobante)
                                        .Include(x => x.detallesFactura)
                                        .Include(x => x.TipoComprobante)
                                        .FirstOrDefaultAsync(x => x.Id == facturaCompras.Id);

                // Saldo del cliente.
                Proveedor proveedorDb = await _context.Proveedor.FindAsync(facturaComprasDb.ProveedorId);
                if (facturaComprasDb.TipoComprobante.nombre == "FAC" || facturaComprasDb.TipoComprobante.nombre == "ND")
                {
                    proveedorDb.saldoCC -= facturaComprasDb.totalComprobante;
                }
                else if (facturaComprasDb.TipoComprobante.nombre == "NC")
                {
                    proveedorDb.saldoCC += facturaComprasDb.totalComprobante;
                }
                facturaComprasDb.Proveedor = null;
                _context.Entry(proveedorDb).State = EntityState.Modified;

                //CREACION DE MOVIMIENTOS DE STOCK.
                foreach (DetalleFacturaCompras detalle in facturaComprasDb.detallesFactura)
                {
                    bool existeInventario = false;

                    Inventario inventarioDb = _context.inventario.Include(x => x.MovimientosInventario).FirstOrDefault(x => x.DepositoId == facturaComprasDb.DepositoId && x.ProductoPresentacionId == detalle.ProductoPresentacionId);
                    if (inventarioDb == null)
                    {
                        inventarioDb = new Inventario { DepositoId = facturaComprasDb.DepositoId, ProductoPresentacionId = detalle.ProductoPresentacionId, MovimientosInventario = new List<MovimientoInventario>() };
                        _context.inventario.Add(inventarioDb);
                        existeInventario = false;
                    }
                    else
                    {
                        existeInventario = true;
                    }
                    //

                    if (facturaComprasDb.TipoComprobante.nombre == "NC")
                    {
                        inventarioDb.cantidadUnidadesEnExistencia -= detalle.cantidad;
                    }
                    else
                    {
                        inventarioDb.cantidadUnidadesEnExistencia += detalle.cantidad;

                    }
                    _context.Entry(inventarioDb).State = EntityState.Modified;
                    inventarioDb.MovimientosInventario.Add(new MovimientoInventario
                    {
                        cantidadUnidadesMovida = detalle.cantidad,
                        entra = (facturaComprasDb.TipoComprobante.nombre == "NC") ? false : true,
                        sale = (!(facturaComprasDb.TipoComprobante.nombre == "NC")) ? false : true,
                        descripcion = $"<span>[COMPRA] <a href='/BackOffice/Compras/FacturaCompras/{facturaComprasDb.Id}'>{((facturaComprasDb.TipoComprobante.nombre == "NC") ? "NC" : (facturaComprasDb.TipoComprobante.nombre == "FAC" ? "FAC" : "ND"))} {facturaComprasDb.codigo}</a></span>",
                    });

                    if (existeInventario)
                    {
                        _context.Entry(inventarioDb).State = EntityState.Modified;
                    }
                    else
                    {
                        _context.Entry(inventarioDb).State = EntityState.Added;
                    }

                }

                _context.Entry(facturaCompras).State = EntityState.Unchanged;
                await _context.SaveChangesAsync();
                return CreatedAtAction("GetFactura", new { id = facturaComprasDb.Id }, facturaComprasDb);
            }
            catch (Exception ex)
            {

                throw;
            }

        }

        // DELETE: api/FacturaCompra/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<FacturaCompras>> DeleteFacturaCompras(int id)
        {
            var facturaCompras = await _context.facturaCompra.FindAsync(id);
            if (facturaCompras == null)
            {
                return NotFound();
            }

            _context.facturaCompra.Remove(facturaCompras);
            await _context.SaveChangesAsync();

            return facturaCompras;
        }

        private bool FacturaComprasExists(int id)
        {
            return _context.facturaCompra.Any(e => e.Id == id);
        }
    }
}
