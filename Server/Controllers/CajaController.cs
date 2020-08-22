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
    public class CajaController : ControllerBase
    {
        private readonly WebApiDbContext _context;

        public CajaController(WebApiDbContext context)
        {
            _context = context;
        }

        // GET: api/Caja
        [HttpGet]
        public async Task<ActionResult<List<Caja>>> GetCaja([FromQuery] Paginacion paginacion, int cantidadDeRegistros, string filtro)
        {
            var queryable = _context.caja
                                            .OrderBy(x => x.nombre).AsQueryable();
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
        // GET: api/Caja/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Caja>> GetCaja(int id)
        {
            var caja = await _context.caja.FindAsync(id);

            if (caja == null)
            {
                return NotFound();
            }

            return caja;
        }
        [HttpGet("saldoCajas")]
        public async Task<decimal> GetSaldoCajas()
        {
            return _context.caja.Sum(x => x.saldo);

        }
        // PUT: api/Caja/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCaja(int id, Caja caja)
        {
            if (id != caja.Id)
            {
                return BadRequest();
            }

            _context.Entry(caja).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CajaExists(id))
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
        [HttpGet("cajasHabilitadas")]
        public async Task<ActionResult<List<Caja>>> GetCajasHabilitados(string userName)
        {
            try
            {
                var userCajasId = _context.userCaja.Where(x => x.userName == userName).Select(x => x.CajaId);
                var cajas = await _context.caja.Where(x => userCajasId.Contains(x.Id)).ToListAsync();


                //if (!string.IsNullOrWhiteSpace(filtro))
                //{
                //    queryable = queryable.Where(x => x..Contains(filtro)).AsQueryable();
                //}

                return cajas;

            }
            catch (Exception ex)
            {

                throw;

            }
        }
        // POST: api/Caja
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Caja>> PostCaja(Caja caja)
        {
            _context.caja.Add(caja);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCaja", new { id = caja.Id }, caja);
        }

        // DELETE: api/Caja/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Caja>> DeleteCaja(int id)
        {
            var caja = await _context.caja.FindAsync(id);
            if (caja == null)
            {
                return NotFound();
            }

            _context.caja.Remove(caja);
            await _context.SaveChangesAsync();

            return caja;
        }

        private bool CajaExists(int id)
        {
            return _context.caja.Any(e => e.Id == id);
        }
    }
}
