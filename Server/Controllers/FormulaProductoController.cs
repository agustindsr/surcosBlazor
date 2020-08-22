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
    public class FormulaProductoController : ControllerBase
    {
        private readonly WebApiDbContext _context;

        public FormulaProductoController(WebApiDbContext context)
        {
            _context = context;
        }

        // GET: api/FormulaProducto
        [HttpGet]
        public async Task<ActionResult<IEnumerable<FormulaProducto>>> GetFormulaProducto()
        {
            return await _context.FormulaProducto.Include(x=>x.DetallesFormula).ToListAsync();
        }

        [HttpGet("CostoFormula")]
        public async Task<ActionResult<decimal>> GetCostoFormulaProducto(int FormulaId)
        {
            List<DetalleFormula> detalles =await _context.detalleFormula.Include(x => x.ProductoPresentacion).ThenInclude(x => x.PresentacionProducto).Where(x => x.FormulaProductoId == FormulaId).ToListAsync();
            return detalles.Sum(x => x.ProductoPresentacion.costo * (x.ProductoPresentacion.PresentacionProducto != null ? (x.cantidad / x.ProductoPresentacion.PresentacionProducto.cantidad) : 0));
        }

        // GET: api/FormulaProducto/5
        [HttpGet("{id}")]
        public async Task<ActionResult<FormulaProducto>> GetFormulaProducto(int id)
        {
            var formulaProducto = await _context.FormulaProducto.Include(x => x.DetallesFormula).FirstOrDefaultAsync(x => x.Id == id);

            if (formulaProducto == null)
            {
                return NotFound();
            }

            return formulaProducto;
        }

        // PUT: api/FormulaProducto/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFormulaProducto(int id, FormulaProducto formulaProducto)
        {
            if (id != formulaProducto.Id)
            {
                return BadRequest();
            }
            _context.Entry(formulaProducto).State = EntityState.Modified;

            foreach (DetalleFormula detalle in formulaProducto.DetallesFormula) {
                if (detalle.Id == 0) {
                    _context.Entry(detalle).State = EntityState.Added;
                }
                else
                {
                    _context.Entry(detalle).State = EntityState.Modified;
                }
              
            }

            var detallesId = formulaProducto.DetallesFormula.Select(x => x.Id).ToList();
            var detallesABorrar = _context.detalleFormula.Where(x => !detallesId.Contains(x.Id) && x.FormulaProductoId == formulaProducto.Id).ToList();
            _context.detalleFormula.RemoveRange(detallesABorrar);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FormulaProductoExists(id))
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

        // POST: api/FormulaProducto
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<FormulaProducto>> PostFormulaProducto(FormulaProducto formulaProducto)
        {
            try
            {
                formulaProducto.DetallesFormula.ForEach(x => {
                    x.ProductoPresentacion.PresentacionProducto = null;

                    _context.Entry(x.ProductoPresentacion).State = EntityState.Unchanged;
                _context.Entry(x.ProductoPresentacion.Producto).State = EntityState.Unchanged;
            });
            _context.FormulaProducto.Add(formulaProducto);

           

           
                await _context.SaveChangesAsync();

            }
            catch (Exception ex)
            {

                throw;
            }

            return CreatedAtAction("GetFormulaProducto", new { id = formulaProducto.Id }, formulaProducto);
        }

        // DELETE: api/FormulaProducto/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<FormulaProducto>> DeleteFormulaProducto(int id)
        {
            var formulaProducto = await _context.FormulaProducto.FindAsync(id);
            if (formulaProducto == null)
            {
                return NotFound();
            }

            _context.FormulaProducto.Remove(formulaProducto);
            await _context.SaveChangesAsync();

            return formulaProducto;
        }

        private bool FormulaProductoExists(int id)
        {
            return _context.FormulaProducto.Any(e => e.Id == id);
        }
    }
}
