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
    public class UnidadController : ControllerBase
    {
        private readonly WebApiDbContext _context;

        public UnidadController(WebApiDbContext context)
        {
            _context = context;
        }

        // GET: api/Unidad
        [HttpGet]
        public async Task<ActionResult<List<Unidad>>> Get([FromQuery] Paginacion paginacion, int cantidadDeRegistros, string filtro)
        {
            var queryable = _context.unidad.AsQueryable();
          
            if (cantidadDeRegistros != 0)
            {
                paginacion.CantidadRegistros = cantidadDeRegistros;
            }
     
            if (!string.IsNullOrWhiteSpace(filtro))
            {
                queryable = queryable.Where(x => x.nombre.Contains(filtro)).AsQueryable();
            }


            await HttpContext.InsertarParametrosPaginacionEnRespuesta(queryable, paginacion.CantidadRegistros);
            return await queryable.Paginar(paginacion).ToListAsync();

        }


        // GET: api/Unidad/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Unidad>> GetUnidad(int id)
        {
            var unidad = await _context.unidad.FindAsync(id);

            if (unidad == null)
            {
                return NotFound();
            }

            return unidad;
        }

        // PUT: api/Unidad/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUnidad(int id, Unidad unidad)
        {
            if (id != unidad.Id)
            {
                return BadRequest();
            }

            _context.Entry(unidad).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UnidadExists(id))
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

        // POST: api/Unidad
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Unidad>> PostUnidad(Unidad unidad)
        {
            _context.unidad.Add(unidad);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUnidad", new { id = unidad.Id }, unidad);
        }

        // DELETE: api/Unidad/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Unidad>> DeleteUnidad(int id)
        {
            var unidad = await _context.unidad.FindAsync(id);
            if (unidad == null)
            {
                return NotFound();
            }

            _context.unidad.Remove(unidad);
            await _context.SaveChangesAsync();

            return unidad;
        }

        private bool UnidadExists(int id)
        {
            return _context.unidad.Any(e => e.Id == id);
        }
    }
}
