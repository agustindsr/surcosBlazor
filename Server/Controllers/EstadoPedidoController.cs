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
    public class EstadoPedidoController : ControllerBase
    {
        private readonly WebApiDbContext _context;

        public EstadoPedidoController(WebApiDbContext context)
        {
            _context = context;
        }

        // GET: api/EstadoPedido
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EstadoPedido>>> GetestadoPedido()
        {
            return await _context.estadoPedido.ToListAsync();
        }

        // GET: api/EstadoPedido/5
        [HttpGet("{id}")]
        public async Task<ActionResult<EstadoPedido>> GetEstadoPedido(int id)
        {
            var estadoPedido = await _context.estadoPedido.FindAsync(id);

            if (estadoPedido == null)
            {
                return NotFound();
            }

            return estadoPedido;
        }

        // PUT: api/EstadoPedido/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEstadoPedido(int id, EstadoPedido estadoPedido)
        {
            if (id != estadoPedido.Id)
            {
                return BadRequest();
            }

            _context.Entry(estadoPedido).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EstadoPedidoExists(id))
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

        // POST: api/EstadoPedido
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<EstadoPedido>> PostEstadoPedido(EstadoPedido estadoPedido)
        {
            _context.estadoPedido.Add(estadoPedido);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEstadoPedido", new { id = estadoPedido.Id }, estadoPedido);
        }

        // DELETE: api/EstadoPedido/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<EstadoPedido>> DeleteEstadoPedido(int id)
        {
            var estadoPedido = await _context.estadoPedido.FindAsync(id);
            if (estadoPedido == null)
            {
                return NotFound();
            }

            _context.estadoPedido.Remove(estadoPedido);
            await _context.SaveChangesAsync();

            return estadoPedido;
        }

        private bool EstadoPedidoExists(int id)
        {
            return _context.estadoPedido.Any(e => e.Id == id);
        }
    }
}
