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
    public class ListaPreciosController : ControllerBase
    {
        private readonly WebApiDbContext _context;

        public ListaPreciosController(WebApiDbContext context)
        {
            _context = context;
        }

        // GET: api/ListaPrecios
        [HttpGet]
        public async Task<ActionResult<List<ListaPrecios>>> Get([FromQuery] Paginacion paginacion, int cantidadDeRegistros, bool vigentes = true)
        {
            try
            {
                var queryable = _context.listaPrecios.Include(x => x.TipoListaPrecio).AsQueryable();
                if (cantidadDeRegistros != 0)
                {
                    paginacion.CantidadRegistros = cantidadDeRegistros;
                }
                if (vigentes)
                {
                    queryable = queryable.Where(x => x.vigente == true).AsQueryable();
                }
                await HttpContext.InsertarParametrosPaginacionEnRespuesta(queryable, paginacion.CantidadRegistros);
                List<ListaPrecios> listaPrecios = await queryable.Paginar(paginacion).ToListAsync();
                return listaPrecios;
            }
            catch (Exception ex)
            {

                throw;
            }
        }
        [HttpGet("ListaPrecioEcommerce")]
        public async Task<ActionResult<List<ListaPrecios>>> GetListasECommerce(int provinciaId = 0, int clienteId = 0)
        {
            int categoriaId = 0;

            try
            {
                if (clienteId != 0 && clienteId != null)
                {

                    categoriaId = Convert.ToInt32(_context.cliente.IgnoreQueryFilters().FirstOrDefault(x => x.Id == clienteId).CategoriaClienteId);
                }
                List<int> TipoListaPrecioId = await _context.TipoListaPrecioCategoriaCliente.Where(x => x.CategoriaClienteId == categoriaId).Select(x => x.TipoListaPrecioId).ToListAsync();
                TipoListaPrecioId.AddRange(await _context.TipoListaPrecioProvincia.Where(x => x.ProvinciaId == provinciaId).Select(x => x.TipoListaPrecioId).ToListAsync());

                TipoListaPrecioId = TipoListaPrecioId.Distinct().ToList();

                List<ListaPrecios> listasPrecios = await _context.listaPrecios
                                                                .Where(x => TipoListaPrecioId.Contains((int)(x.TipoListaPrecioId)) && x.vigente == true)
                                                                .Include(x => x.TipoListaPrecio)
                                                                .OrderByDescending(x => x.clasificacion)
                                                                .ToListAsync();

                return listasPrecios;
            }
            catch (Exception ex)
            {

                throw;
            }
        }
       
        // GET: api/ListaPrecios/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ListaPrecios>> GetListaPrecios(int id)
        {
            var listaPrecios = await _context.listaPrecios.Include(x => x.TipoListaPrecio).Include(x => x.DetalleListaPrecios).FirstOrDefaultAsync(x => x.Id == id);
            var detallesId = listaPrecios.DetalleListaPrecios.Select(x => x.Id);
            if (listaPrecios != null)
            {

                listaPrecios.DetalleListaPrecios = await _context.detalleListaPrecios.Where(x => detallesId.Contains(x.Id))
                                                                       .Include(w => w.ProductoPresentacion)
                                                                           .ThenInclude(z => z.PresentacionProducto)
                                                                        .Include(w => w.ProductoPresentacion)
                                                                           .ThenInclude(z => z.Producto).ThenInclude(y => y.CategoriaProducto).ToListAsync();

            }


            return listaPrecios;
        }

        [HttpGet("getPrecioProducto")]
        public async Task<ActionResult<decimal>> GetPrecioProducto(int productoId, int listaId)
        {
            var detalle = await _context.detalleListaPrecios.Where(x => x.ProductoPresentacionId == productoId && x.ListaPreciosId == listaId).FirstOrDefaultAsync();

            if (detalle == null)
            {
                return NotFound("Este producto no existe en esta lista de precios");
            }

            return detalle.precioUnitarioFinal;
        }


        // PUT: api/ListaPrecios/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutListaPrecios(int id, ListaPrecios listaPrecios)
        {
            if (id != listaPrecios.Id)
            {
                return BadRequest();
            }

            _context.Entry(listaPrecios).State = EntityState.Modified;
            listaPrecios.DetalleListaPrecios.ForEach(x =>
            {
                if (x.Id == 0)
                {
                    _context.Entry(x).State = EntityState.Added;
                }
                else
                {
                    _context.Entry(x).State = EntityState.Modified;

                }
            });
            var detallesId = listaPrecios.DetalleListaPrecios.Select(x => x.Id).ToList();
            var detallesABorrar = _context.detalleListaPrecios.Where(x => !detallesId.Contains(x.Id) && x.ListaPreciosId == listaPrecios.Id).ToList();
            _context.detalleListaPrecios.RemoveRange(detallesABorrar);

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ListaPreciosExists(id))
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

        // POST: api/ListaPrecios
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<ListaPrecios>> PostListaPrecios(ListaPrecios listaPrecios)
        {
            _context.listaPrecios.Add(listaPrecios);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetListaPrecios", new { id = listaPrecios.Id }, listaPrecios);
        }

        // DELETE: api/ListaPrecios/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ListaPrecios>> DeleteListaPrecios(int id)
        {
            var listaPrecios = await _context.listaPrecios.FindAsync(id);
            if (listaPrecios == null)
            {
                return NotFound();
            }

            _context.listaPrecios.Remove(listaPrecios);
            await _context.SaveChangesAsync();

            return listaPrecios;
        }

        private bool ListaPreciosExists(int id)
        {
            return _context.listaPrecios.Any(e => e.Id == id);
        }
    }
}
