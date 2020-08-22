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
    public class DepositoController : ControllerBase
    {
        private readonly WebApiDbContext _context;

        public DepositoController(WebApiDbContext context)
        {
            _context = context;
        }

        // GET: api/Deposito
        [HttpGet]
        public async Task<ActionResult<List<Deposito>>> Get([FromQuery] Paginacion paginacion, int cantidadDeRegistros, string filtro)
        {
            var queryable = _context.deposito
                   .AsQueryable();

            
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
        [HttpGet("depositosHabilitados")]
        public async Task<ActionResult<List<Deposito>>> GetDepositosHabilitados(string userName)
        {
            try
            {
                var userDepositosId = _context.userDeposito.Where(x => x.userName == userName).Select(x => x.DepositoId);
                var depositos = await _context.deposito.Where(x => userDepositosId.Contains(x.Id)).ToListAsync();


                //if (!string.IsNullOrWhiteSpace(filtro))
                //{
                //    queryable = queryable.Where(x => x..Contains(filtro)).AsQueryable();
                //}

                return depositos;

            }
            catch (Exception ex)
            {

                throw;

            }
        }
        // GET: api/Deposito/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Deposito>> GetDeposito(int id)
        {
            var deposito = await _context.deposito.FindAsync(id);

            if (deposito == null)
            {
                return NotFound();
            }

            return deposito;
        }

        // PUT: api/Deposito/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDeposito(int id, Deposito deposito)
        {
            if (id != deposito.Id)
            {
                return BadRequest();
            }

            _context.Entry(deposito).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DepositoExists(id))
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

        // POST: api/Deposito
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Deposito>> PostDeposito(Deposito deposito)
        {
            _context.deposito.Add(deposito);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDeposito", new { id = deposito.Id }, deposito);
        }

        // DELETE: api/Deposito/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Deposito>> DeleteDeposito(int id)
        {
            var deposito = await _context.deposito.FindAsync(id);
            if (deposito == null)
            {
                return NotFound();
            }

            _context.deposito.Remove(deposito);
            await _context.SaveChangesAsync();

            return deposito;
        }

        private bool DepositoExists(int id)
        {
            return _context.deposito.Any(e => e.Id == id);
        }
    }
}
