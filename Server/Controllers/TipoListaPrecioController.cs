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
    public class TipoListaPrecioController : ControllerBase
    {
        private readonly WebApiDbContext _context;

        public TipoListaPrecioController(WebApiDbContext context)
        {
            _context = context;
        }

        // GET: api/TipoListaDePrecio
        [HttpGet]
        public async Task<ActionResult<List<TipoListaPrecio>>> Get([FromQuery] Paginacion paginacion, int cantidadDeRegistros, string filtro)
        {
            try
            {
                var queryable = _context.tipoListaPrecio.AsQueryable();
                if (cantidadDeRegistros != 0)
                {
                    paginacion.CantidadRegistros = cantidadDeRegistros;
                }
                if (!string.IsNullOrWhiteSpace(filtro))
                {
                    queryable = queryable.Where(x => x.nombre.Contains(filtro)).AsQueryable();
                }
                await HttpContext.InsertarParametrosPaginacionEnRespuesta(queryable, paginacion.CantidadRegistros);
                List<TipoListaPrecio> tipoListaPrecios = await queryable.Paginar(paginacion).ToListAsync();
                return tipoListaPrecios;
            }
            catch (Exception ex)
            {

                throw;
            }
        }
        [HttpGet("DisponiblesParaCrearListaPrecios")]
        public async Task<ActionResult<List<TipoListaPrecio>>> GetDisponibles()
        {
            try
            {

                List<TipoListaPrecio> tipoListaPrecios = await _context.tipoListaPrecio.Include(x => x.ListasPrecios).Where(x => x.ListasPrecios.Count() == 0).ToListAsync();
                return tipoListaPrecios;
            }
            catch (Exception ex)
            {

                throw;
            }
        }
        // GET: api/TipoListaDePrecio/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TipoListaPrecio>> GetTipoListaPrecio(int id)
        {
            var tipoListaPrecio = await _context.tipoListaPrecio
                .Include(x => x.TipoListaPrecioProvincias)
                .Include(x => x.TipoListaPrecioCategoriaClientes)
                .FirstOrDefaultAsync(x => x.Id == id);

            tipoListaPrecio.TipoListaPrecioCategoriaClientes.ForEach(x => { x = _context.TipoListaPrecioCategoriaCliente.Include(w => w.CategoriaCliente).FirstOrDefault(y => y.Id == x.Id); });
            tipoListaPrecio.TipoListaPrecioProvincias.ForEach(x => { x = _context.TipoListaPrecioProvincia.Include(w => w.Provincia).FirstOrDefault(y => y.Id == x.Id); });

            if (tipoListaPrecio == null)
            {
                return NotFound();
            }

            return tipoListaPrecio;
        }

        // PUT: api/TipoListaDePrecio/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTipoListaPrecio(int id, TipoListaPrecio tipoListaPrecio)
        {
            if (id != tipoListaPrecio.Id)
            {
                return BadRequest();
            }

            _context.Entry(tipoListaPrecio).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TipoListaPrecioExists(id))
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

        // POST: api/TipoListaDePrecio
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<TipoListaPrecio>> PostTipoListaPrecio(TipoListaPrecio tipoListaPrecio)
        {
            _context.tipoListaPrecio.Add(tipoListaPrecio);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTipoListaPrecio", new { id = tipoListaPrecio.Id }, tipoListaPrecio);
        }

        // DELETE: api/TipoListaDePrecio/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<TipoListaPrecio>> DeleteTipoListaPrecio(int id)
        {
            var tipoListaPrecio = await _context.tipoListaPrecio.FindAsync(id);
            if (tipoListaPrecio == null)
            {
                return NotFound();
            }

            _context.tipoListaPrecio.Remove(tipoListaPrecio);
            await _context.SaveChangesAsync();

            return tipoListaPrecio;
        }

        private bool TipoListaPrecioExists(int id)
        {
            return _context.tipoListaPrecio.Any(e => e.Id == id);
        }
    }
}
