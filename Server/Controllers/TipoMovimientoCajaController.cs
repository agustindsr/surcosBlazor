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
    public class TipoMovimientoCajaController : ControllerBase
    {
        private readonly WebApiDbContext _context;

        public TipoMovimientoCajaController(WebApiDbContext context)
        {
            _context = context;
        }

        // GET: api/TipoMovimientoCaja
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TipoMovimientoCaja>>> Get([FromQuery] Paginacion paginacion, int cantidadDeRegistros, string filtro)
        {
            try
            {
                var queryable = _context.tipoMovimientoCaja.AsQueryable();
                if (cantidadDeRegistros != 0)
                {
                    paginacion.CantidadRegistros = cantidadDeRegistros;
                }
                if (!string.IsNullOrWhiteSpace(filtro))
                {
                    queryable = queryable.Where(x => x.nombre.Contains(filtro)).AsQueryable();
                }
                await HttpContext.InsertarParametrosPaginacionEnRespuesta(queryable, paginacion.CantidadRegistros);
                List<TipoMovimientoCaja> tiposMovimientoCaja = await queryable.Paginar(paginacion).ToListAsync();
                return tiposMovimientoCaja;
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        // GET: api/TipoMovimientoCaja/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TipoMovimientoCaja>> GetTipoMovimientoCaja(int id)
        {
            var tipoMovimientoCaja = await _context.tipoMovimientoCaja.FindAsync(id);

            if (tipoMovimientoCaja == null)
            {
                return NotFound();
            }

            return tipoMovimientoCaja;
        }

        // PUT: api/TipoMovimientoCaja/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTipoMovimientoCaja(int id, TipoMovimientoCaja tipoMovimientoCaja)
        {
            if (id != tipoMovimientoCaja.Id)
            {
                return BadRequest();
            }

            _context.Entry(tipoMovimientoCaja).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TipoMovimientoCajaExists(id))
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

        // POST: api/TipoMovimientoCaja
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<TipoMovimientoCaja>> PostTipoMovimientoCaja(TipoMovimientoCaja tipoMovimientoCaja)
        {
            _context.tipoMovimientoCaja.Add(tipoMovimientoCaja);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTipoMovimientoCaja", new { id = tipoMovimientoCaja.Id }, tipoMovimientoCaja);
        }

        // DELETE: api/TipoMovimientoCaja/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<TipoMovimientoCaja>> DeleteTipoMovimientoCaja(int id)
        {
            var tipoMovimientoCaja = await _context.tipoMovimientoCaja.FindAsync(id);
            if (tipoMovimientoCaja == null)
            {
                return NotFound();
            }

            _context.tipoMovimientoCaja.Remove(tipoMovimientoCaja);
            await _context.SaveChangesAsync();

            return tipoMovimientoCaja;
        }

        private bool TipoMovimientoCajaExists(int id)
        {
            return _context.tipoMovimientoCaja.Any(e => e.Id == id);
        }
    }
}
