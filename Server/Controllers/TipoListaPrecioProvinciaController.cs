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
    public class TipoListaPrecioProvinciaController : ControllerBase
    {
        private readonly WebApiDbContext _context;

        public TipoListaPrecioProvinciaController(WebApiDbContext context)
        {
            _context = context;
        }

        // GET: api/TipoListaPrecioProvincia
        [HttpGet]
        public async Task<ActionResult<List<TipoListaPrecioProvincia>>> Get([FromQuery] Paginacion paginacion, int tipoListaPrecioId, int cantidadDeRegistros)
        {
            try
            {
                var queryable = _context.TipoListaPrecioProvincia.Include(x => x.Provincia).AsQueryable();
                if (cantidadDeRegistros != 0)
                {
                    paginacion.CantidadRegistros = cantidadDeRegistros;
                }

                if (tipoListaPrecioId != 0)
                {
                    queryable = queryable.Where(x => x.TipoListaPrecioId == tipoListaPrecioId).AsQueryable();
                }
                await HttpContext.InsertarParametrosPaginacionEnRespuesta(queryable, paginacion.CantidadRegistros);
                List<TipoListaPrecioProvincia> tipoListaPrecioProvincias = await queryable.Paginar(paginacion).ToListAsync();
                return tipoListaPrecioProvincias;
            }
            catch (Exception ex)
            {

                throw;
            }

        }

        // GET: api/TipoListaPrecioProvincia/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TipoListaPrecioProvincia>> GetTipoListaPrecioProvincia(int id)
        {
            var tipoListaPrecioProvincia = await _context.TipoListaPrecioProvincia.FindAsync(id);

            if (tipoListaPrecioProvincia == null)
            {
                return NotFound();
            }

            return tipoListaPrecioProvincia;
        }

        // PUT: api/TipoListaPrecioProvincia/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTipoListaPrecioProvincia(int id, TipoListaPrecioProvincia tipoListaPrecioProvincia)
        {
            if (id != tipoListaPrecioProvincia.Id)
            {
                return BadRequest();
            }

            _context.Entry(tipoListaPrecioProvincia).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TipoListaPrecioProvinciaExists(id))
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

        // POST: api/TipoListaPrecioProvincia
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<TipoListaPrecioProvincia>> PostTipoListaPrecioProvincia(TipoListaPrecioProvincia tipoListaPrecioProvincia)
        {
            _context.TipoListaPrecioProvincia.Add(tipoListaPrecioProvincia);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTipoListaPrecioProvincia", new { id = tipoListaPrecioProvincia.Id }, tipoListaPrecioProvincia);
        }

        // DELETE: api/TipoListaPrecioProvincia/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<TipoListaPrecioProvincia>> DeleteTipoListaPrecioProvincia(int id)
        {
            var tipoListaPrecioProvincia = await _context.TipoListaPrecioProvincia.FindAsync(id);
            if (tipoListaPrecioProvincia == null)
            {
                return NotFound();
            }

            _context.TipoListaPrecioProvincia.Remove(tipoListaPrecioProvincia);
            await _context.SaveChangesAsync();

            return tipoListaPrecioProvincia;
        }

        private bool TipoListaPrecioProvinciaExists(int id)
        {
            return _context.TipoListaPrecioProvincia.Any(e => e.Id == id);
        }
    }
}
