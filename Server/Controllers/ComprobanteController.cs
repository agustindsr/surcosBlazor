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
    public class ComprobanteController : ControllerBase
    {
        private readonly WebApiDbContext _context;

        public ComprobanteController(WebApiDbContext context)
        {
            _context = context;
        }

        // GET: api/Comprobante
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Comprobante>>> Getcomprobante()
        {
            return await _context.comprobante.ToListAsync();
        }

        // GET: api/Comprobante/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Comprobante>> GetComprobante(int id)
        {
            var comprobante = await _context.comprobante.FindAsync(id);

            if (comprobante == null)
            {
                return NotFound();
            }

            return comprobante;
        }

        // PUT: api/Comprobante/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutComprobante(int id, Comprobante comprobante)
        {
            if (id != comprobante.Id)
            {
                return BadRequest();
            }

            _context.Entry(comprobante).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ComprobanteExists(id))
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

        // POST: api/Comprobante
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Comprobante>> PostComprobante(Comprobante comprobante)
        {
            _context.comprobante.Add(comprobante);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetComprobante", new { id = comprobante.Id }, comprobante);
        }

        // DELETE: api/Comprobante/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Comprobante>> DeleteComprobante(int id)
        {
            var comprobante = await _context.comprobante.FindAsync(id);
            if (comprobante == null)
            {
                return NotFound();
            }

            _context.comprobante.Remove(comprobante);
            await _context.SaveChangesAsync();

            return comprobante;
        }

        private bool ComprobanteExists(int id)
        {
            return _context.comprobante.Any(e => e.Id == id);
        }
    }
}
