using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
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
    public class FacturaController : ControllerBase
    {
        private readonly WebApiDbContext _context;

        public FacturaController(WebApiDbContext context)
        {   
            _context = context;
        }
        [HttpGet("vendedoresHabilitados")]
        public async Task<ActionResult<List<Vendedor>>> GetVendedoresHabilitados(string userName)
        {
            try
            {
                var userVendedoresId = _context.userVendedor.Where(x => x.userName == userName).Select(x => x.VendedorId);
                var vendedores = await _context.vendedor.Where(x => userVendedoresId.Contains(x.Id)).ToListAsync();


                //if (!string.IsNullOrWhiteSpace(filtro))
                //{
                //    queryable = queryable.Where(x => x..Contains(filtro)).AsQueryable();
                //}

                return vendedores;

            }
            catch (Exception ex)
            {

                throw;

            }
        }
        // GET: api/Factura
        [HttpGet]
        public async Task<ActionResult<List<Factura>>> Get([FromQuery] Paginacion paginacion,
                                                            int cantidadDeRegistros,
                                                            string filtro,
                                                            string userName,
                                                            int vendedorId,
                                                            int provinciaId,
                                                            int estadoFacturaId,
                                                            int tipoListaPrecioId,
                                                             int depositoId,
                                                              int tipoComprobanteId, int clienteId)
        {
            try
            {
                var userVendedoresId = _context.userVendedor.Where(x => x.userName == userName).Select(x => x.VendedorId);
                var queryable = _context.factura.Where(x => userVendedoresId.Contains((int)x.VendedorId))
                                                .Include(x => x.Domicilio.Provincia)
                                                .Include(x => x.Domicilio.Departamento)
                                                .Include(x => x.Cliente)
                                                    .ThenInclude(x => x.Categoria)
                                                .Include(x => x.EstadoFactura)
                                                .Include(x => x.TipoComprobante)
                                                .Include(x => x.Deposito)
                                                .Include(x => x.ListaPrecios)
                                                    .ThenInclude(x => x.TipoListaPrecio)
                                                .Include(x => x.Vendedor).OrderByDescending(x => x.fecha).AsQueryable();
                if (vendedorId != 0)
                {
                    queryable = queryable.Where(x => x.VendedorId == vendedorId).AsQueryable();
                }
                if (provinciaId != 0)
                {
                    queryable = queryable.Where(x => x.Domicilio.ProvinciaId == provinciaId).AsQueryable();
                }
                if (estadoFacturaId != 0)
                {
                    queryable = queryable.Where(x => x.EstadoFacturaId == estadoFacturaId).AsQueryable();
                }
                if (tipoListaPrecioId != 0)
                {
                    queryable = queryable.Where(x => x.ListaPrecios.TipoListaPrecioId == tipoListaPrecioId).AsQueryable();
                }
                if (cantidadDeRegistros != 0)
                {
                    paginacion.CantidadRegistros = cantidadDeRegistros;
                }
                if (depositoId != 0)
                {
                    queryable = queryable.Where(x => x.DepositoId == depositoId).AsQueryable();
                }
                if (clienteId != 0)
                {
                    queryable = queryable.Where(x => x.ClienteId == clienteId).AsQueryable();
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

       

        [HttpGet("facturasPorCliente")]
        public async Task<ActionResult<List<Factura>>> GetFacturasPorCliente(
                                                              int clienteId)
        {
            try
            {
                var listadoFactura = await _context.factura.Where(x => x.ClienteId == clienteId).Include(x => x.TipoComprobante).Include(x => x.EstadoFactura).OrderByDescending(x=>x.fecha).ToListAsync();
                
                return listadoFactura;

            }
            catch (Exception ex)
            {

                throw;

            }

        }
        [HttpGet("facturasPorClienteParaRecibo")]
        public async Task<ActionResult<List<Factura>>> GetFacturasPorClienteParaRecibo(
                                                            int clienteId)
        {
            try
            {
                var listadoFactura = await _context.factura.Where(x => x.ClienteId == clienteId && x.TipoComprobanteId == 1 && x.EstadoFacturaId == 1).Include(x => x.TipoComprobante).Include(x => x.EstadoFactura).OrderByDescending(x => x.fecha).ToListAsync();

                return listadoFactura;

            }
            catch (Exception ex)
            {

                throw;

            }

        }

        // GET: api/Factura/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Factura>> GetFactura(int id)
        {
            var factura = await _context.factura.Include(x => x.Domicilio.Provincia)
                                               .Include(x => x.Domicilio.Departamento)
                                               .Include(x => x.Domicilio)
                                               .Include(x => x.Cliente)
                                                   .ThenInclude(x => x.Categoria)
                                                   .Include(x => x.Cliente)
                                                   .ThenInclude(x => x.Domicilio).IgnoreQueryFilters()
                                               .Include(x => x.EstadoFactura)
                                               .Include(x => x.ListaPrecios)
                                                    .ThenInclude(x => x.TipoListaPrecio)
                                               .Include(x => x.Deposito)
                                               .Include(x => x.TipoComprobante)
                                               .Include(x => x.Vendedor).Include(x => x.detallesFactura).FirstOrDefaultAsync(x => x.Id == id);
            for (int i = 0; i < factura.detallesFactura.Count; i++)
            {
                factura.detallesFactura[i] = _context.detalleFactura.Include(x => x.ProductoPresentacion)
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
        // PUT: api/Factura/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFactura(int id, Factura factura)
        {
            if (id != factura.Id)
            {
                return BadRequest();
            }

            _context.Entry(factura).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FacturaExists(id))
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

        // POST: api/Factura
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
       

        [HttpPost]
        public async Task<ActionResult<Factura>> PostFactura(Factura factura)
        {
            try
            {
                //CREAMOS LA FACTURA
                factura.Cliente = null;
                factura.Deposito = null;
                factura.detallesFactura.ForEach(x => x.ProductoPresentacion = null);
                factura.TipoComprobante = null;
                factura.Vendedor = null;
                factura.ListaPrecios = null;
                factura.EstadoFactura = null;
                factura.EstadoFacturaId = (await _context.estadoFactura.FirstOrDefaultAsync(x => x.nombre == "PEN")).Id;
                factura.Domicilio.Provincia = null;
                factura.Domicilio.Departamento = null;

                //CREAMOS EL CÓDIGO.
                int cantidadDeFacturas = await _context.factura.IgnoreQueryFilters()
                                                        .Where(x => x.TipoComprobanteId == factura.TipoComprobanteId && x.DepositoId == factura.DepositoId)
                                                         .CountAsync() + 1;
                int aux = 8 - cantidadDeFacturas.ToString().Length;
                string cerosDeRelleno = "";
                for (int i = 0; i < aux; i++) {
                    cerosDeRelleno += "0";
                }
                factura.codigo = $"0000{factura.DepositoId}-{cerosDeRelleno}{cantidadDeFacturas}";

                _context.factura.Add(factura);
                await _context.SaveChangesAsync();
                // BUSCAMOS LA FACTURA EN LA BASE DE DATOS
                factura = await _context.factura
                                        .Include(x => x.TipoComprobante)
                                        .Include(x => x.detallesFactura)
                                        .Include(x => x.TipoComprobante)
                                        .FirstOrDefaultAsync(x => x.Id == factura.Id);

                // Saldo del cliente.
                Cliente clienteDb = await _context.cliente.FindAsync(factura.ClienteId);
                if (factura.TipoComprobante.nombre == "FAC" || factura.TipoComprobante.nombre == "ND")
                {
                    clienteDb.saldoCC += factura.totalComprobante;
                }
                else if (factura.TipoComprobante.nombre == "NC")
                {
                    clienteDb.saldoCC -= factura.totalComprobante;
                }
                factura.Cliente = null;
                _context.Entry(clienteDb).State = EntityState.Modified;

                //CREACION DE MOVIMIENTOS DE STOCK.
                foreach (DetalleFactura detalle in factura.detallesFactura)
                {
                    bool existeInventario = false;
                    Inventario inventarioDb = _context.inventario.Include(x => x.MovimientosInventario).FirstOrDefault(x => x.DepositoId == factura.DepositoId && x.ProductoPresentacionId == detalle.ProductoPresentacionId);
                    if (inventarioDb == null)
                    {
                        inventarioDb = new Inventario { DepositoId = factura.DepositoId, ProductoPresentacionId = detalle.ProductoPresentacionId, MovimientosInventario = new List<MovimientoInventario>() };
                        _context.inventario.Add(inventarioDb);
                        existeInventario = false;
                    }
                    else {
                        existeInventario = true;
                    }


                    if (factura.TipoComprobante.nombre == "NC")
                    {
                        inventarioDb.cantidadUnidadesEnExistencia += detalle.cantidad;
                    }
                    else
                    {
                        inventarioDb.cantidadUnidadesEnExistencia -= detalle.cantidad;

                    }

                    inventarioDb.MovimientosInventario.Add(new MovimientoInventario
                    {
                        cantidadUnidadesMovida = detalle.cantidad,
                        entra = (factura.TipoComprobante.nombre == "NC") ? true : false,
                        sale = (!(factura.TipoComprobante.nombre == "NC")) ? true : false,
                        descripcion = $"<span>[VENTA] <a href='/BackOffice/Ventas/Factura/{factura.Id}'>{((factura.TipoComprobante.nombre == "NC") ? "NC" : (factura.TipoComprobante.nombre == "FAC" ? "FAC" : "ND"))} {factura.codigo}</a></span>",

                    });
                    if (existeInventario)
                    {
                        _context.Entry(inventarioDb).State = EntityState.Modified;
                    }
                    else {
                        _context.Entry(inventarioDb).State = EntityState.Added;

                    }

                }
                _context.Entry(factura).State = EntityState.Unchanged;
                await _context.SaveChangesAsync();

                return CreatedAtAction("GetFactura", new { id = factura.Id }, factura);
            }
            catch (Exception ex)
            {

                throw;
            }
          
        }

        // DELETE: api/Factura/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Factura>> DeleteFactura(int id)
        {
            var factura = await _context.factura.FindAsync(id);
            if (factura == null)
            {
                return NotFound();
            }

            _context.factura.Remove(factura);
            await _context.SaveChangesAsync();

            return factura;
        }

        private bool FacturaExists(int id)
        {
            return _context.factura.Any(e => e.Id == id);
        }
    }
}
