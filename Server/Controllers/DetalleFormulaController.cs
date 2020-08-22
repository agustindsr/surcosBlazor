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
    public class DetalleFormulaController : ControllerBase
    {
        private readonly WebApiDbContext _context;

        public DetalleFormulaController(WebApiDbContext context)
        {
            _context = context;
        }

        // GET: api/DetalleFormula
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DetalleFormula>>> GetdetalleFormula(int FormulaId)
        {
            var queryble = _context.detalleFormula.Include(x => x.ProductoPresentacion).ThenInclude(y => y.PresentacionProducto)
                                                    .Include(x=> x.ProductoPresentacion).ThenInclude(y=> y.Producto).AsQueryable();
            if (FormulaId != 0) {
                queryble = queryble.Where(x => x.FormulaProductoId == FormulaId).AsQueryable();
            
            }
            List<DetalleFormula> detalles = await queryble.ToListAsync();
            return detalles;
        }

        // GET: api/DetalleFormula/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DetalleFormula>> GetDetalleFormula(int id)
        {
            var detalleFormula = await _context.detalleFormula.FindAsync(id);

            if (detalleFormula == null)
            {
                return NotFound();
            }

            return detalleFormula;
        }

        // PUT: api/DetalleFormula/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDetalleFormula(int id, DetalleFormula detalleFormula)
        {
            if (id != detalleFormula.Id)
            {
                return BadRequest();
            }

            _context.Entry(detalleFormula).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DetalleFormulaExists(id))
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

        // POST: api/DetalleFormula
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<DetalleFormula>> PostDetalleFormula(DetalleFormula detalleFormula)
        {
            _context.detalleFormula.Add(detalleFormula);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDetalleFormula", new { id = detalleFormula.Id }, detalleFormula);
        }

        // DELETE: api/DetalleFormula/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<DetalleFormula>> DeleteDetalleFormula(int id)
        {
            var detalleFormula = await _context.detalleFormula.FindAsync(id);
            if (detalleFormula == null)
            {
                return NotFound();
            }

            _context.detalleFormula.Remove(detalleFormula);
            await _context.SaveChangesAsync();

            return detalleFormula;
        }

        private bool DetalleFormulaExists(int id)
        {
            return _context.detalleFormula.Any(e => e.Id == id);
        }
    }
}
