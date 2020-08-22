using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SurcosBlazor.Server.Context;
using SurcosBlazor.Shared.Entidades;

namespace SurcosBlazor.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TipoComprobanteController : ControllerBase
    {
        private readonly WebApiDbContext _context;

        public TipoComprobanteController(WebApiDbContext context)
        {
            _context = context;
        }

        // GET: api/TipoComprobante
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TipoComprobante>>> GettipoComprobante()
        {
            return await _context.tipoComprobante.ToListAsync();
        }

        // GET: api/TipoComprobante/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TipoComprobante>> GetTipoComprobante(int id)
        {
            var tipoComprobante = await _context.tipoComprobante.FindAsync(id);

            if (tipoComprobante == null)
            {
                return NotFound();
            }

            return tipoComprobante;
        }

        // PUT: api/TipoComprobante/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTipoComprobante(int id, TipoComprobante tipoComprobante)
        {
            if (id != tipoComprobante.Id)
            {
                return BadRequest();
            }

            _context.Entry(tipoComprobante).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TipoComprobanteExists(id))
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

        // POST: api/TipoComprobante
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<TipoComprobante>> PostTipoComprobante(TipoComprobante tipoComprobante)
        {
            _context.tipoComprobante.Add(tipoComprobante);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTipoComprobante", new { id = tipoComprobante.Id }, tipoComprobante);
        }

        // DELETE: api/TipoComprobante/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<TipoComprobante>> DeleteTipoComprobante(int id)
        {
            var tipoComprobante = await _context.tipoComprobante.FindAsync(id);
            if (tipoComprobante == null)
            {
                return NotFound();
            }

            _context.tipoComprobante.Remove(tipoComprobante);
            await _context.SaveChangesAsync();

            return tipoComprobante;
        }

        private bool TipoComprobanteExists(int id)
        {
            return _context.tipoComprobante.Any(e => e.Id == id);
        }
    }
}
