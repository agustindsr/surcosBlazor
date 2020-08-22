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
    public class MovimientoCajaController : ControllerBase
    {
        private readonly WebApiDbContext _context;

        public MovimientoCajaController(WebApiDbContext context)
        {
            _context = context;
        }

        // GET: api/MovimientoCaja
        [HttpGet]
        public async Task<ActionResult<List<MovimientoCaja>>> GetMovimientosCaja([FromQuery] Paginacion paginacion, int cantidadDeRegistros, int cajaId)
        {
            try
            {
                var queryable = _context.movimientoCaja.Include(x => x.TipoMovimientoCaja).Include(x => x.OrdenPago).Include(x => x.ReciboCobranzas).OrderByDescending(x => x.fecha).AsQueryable();
                if (cantidadDeRegistros != 0)
                {
                    paginacion.CantidadRegistros = cantidadDeRegistros;
                }
                if (cajaId != 0)
                {
                    queryable = queryable.Where(x => x.CajaId == cajaId).AsQueryable();
                }
                await HttpContext.InsertarParametrosPaginacionEnRespuesta(queryable, paginacion.CantidadRegistros);
                List<MovimientoCaja> movimientosInventario = await queryable.Paginar(paginacion).ToListAsync();
                return movimientosInventario;
            }
            catch (Exception ex)
            {

                throw;
            }
        }
        // GET: api/MovimientoCaja/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MovimientoCaja>> GetMovimientoCaja(int id)
        {
            var movimientoCaja = await _context.movimientoCaja.FindAsync(id);

            if (movimientoCaja == null)
            {
                return NotFound();
            }

            return movimientoCaja;
        }

        // PUT: api/MovimientoCaja/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMovimientoCaja(int id, MovimientoCaja movimientoCaja)
        {
            if (id != movimientoCaja.Id)
            {
                return BadRequest();
            }

            _context.Entry(movimientoCaja).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MovimientoCajaExists(id))
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

        // POST: api/MovimientoCaja
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<MovimientoCaja>> PostMovimientoCaja(MovimientoCaja movimientoCaja)
        {
            Caja cajaDb = await _context.caja.FirstAsync(x => x.Id == movimientoCaja.CajaId);
            if (movimientoCaja.entra)
            {
                cajaDb.saldo += movimientoCaja.totalMovimiento;

            }
            else if (movimientoCaja.sale)
            {

                cajaDb.saldo -= movimientoCaja.totalMovimiento;

            }
            movimientoCaja.TipoMovimientoCaja = null;
            movimientoCaja.Caja = null;
            _context.movimientoCaja.Add(movimientoCaja);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMovimientoCaja", new { id = movimientoCaja.Id }, movimientoCaja);
        }

        // DELETE: api/MovimientoCaja/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<MovimientoCaja>> DeleteMovimientoCaja(int id)
        {
            var movimientoCaja = await _context.movimientoCaja.FindAsync(id);
            if (movimientoCaja == null)
            {
                return NotFound();
            }

            _context.movimientoCaja.Remove(movimientoCaja);
            await _context.SaveChangesAsync();

            return movimientoCaja;
        }

        private bool MovimientoCajaExists(int id)
        {
            return _context.movimientoCaja.Any(e => e.Id == id);
        }
    }
}
