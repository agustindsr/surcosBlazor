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
    public class TipoListaPrecioCategoriaClienteController : ControllerBase
    {
        private readonly WebApiDbContext _context;

        public TipoListaPrecioCategoriaClienteController(WebApiDbContext context)
        {
            _context = context;
        }

        // GET: api/TipoListaPrecioCategoriaCliente
        [HttpGet]
        public async Task<ActionResult<List<TipoListaPrecioCategoriaCliente>>> Get([FromQuery] Paginacion paginacion, int tipoListaPrecioId, int cantidadDeRegistros)
        {
            try
            {
                var queryable = _context.TipoListaPrecioCategoriaCliente.Include(x => x.CategoriaCliente).AsQueryable();
                if (cantidadDeRegistros != 0)
                {
                    paginacion.CantidadRegistros = cantidadDeRegistros;
                }

                if (tipoListaPrecioId != 0)
                {
                    queryable = queryable.Where(x => x.TipoListaPrecioId == tipoListaPrecioId).AsQueryable();
                }
                await HttpContext.InsertarParametrosPaginacionEnRespuesta(queryable, paginacion.CantidadRegistros);
                List<TipoListaPrecioCategoriaCliente> tipoListaPrecioCategoriaClientes = await queryable.Paginar(paginacion).ToListAsync();
                return tipoListaPrecioCategoriaClientes;
            }
            catch (Exception ex)
            {

                throw;
            }

        }

        // GET: api/TipoListaPrecioCategoriaCliente/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TipoListaPrecioCategoriaCliente>> GetTipoListaPrecioCategoriaCliente(int id)
        {
            var tipoListaPrecioCategoriaCliente = await _context.TipoListaPrecioCategoriaCliente.FindAsync(id);

            if (tipoListaPrecioCategoriaCliente == null)
            {
                return NotFound();
            }

            return tipoListaPrecioCategoriaCliente;
        }

        // PUT: api/TipoListaPrecioCategoriaCliente/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTipoListaPrecioCategoriaCliente(int id, TipoListaPrecioCategoriaCliente tipoListaPrecioCategoriaCliente)
        {
            if (id != tipoListaPrecioCategoriaCliente.Id)
            {
                return BadRequest();
            }

            _context.Entry(tipoListaPrecioCategoriaCliente).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TipoListaPrecioCategoriaClienteExists(id))
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

        // POST: api/TipoListaPrecioCategoriaCliente
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<TipoListaPrecioCategoriaCliente>> PostTipoListaPrecioCategoriaCliente(TipoListaPrecioCategoriaCliente tipoListaPrecioCategoriaCliente)
        {
            _context.TipoListaPrecioCategoriaCliente.Add(tipoListaPrecioCategoriaCliente);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTipoListaPrecioCategoriaCliente", new { id = tipoListaPrecioCategoriaCliente.Id }, tipoListaPrecioCategoriaCliente);
        }

        // DELETE: api/TipoListaPrecioCategoriaCliente/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<TipoListaPrecioCategoriaCliente>> DeleteTipoListaPrecioCategoriaCliente(int id)
        {
            var tipoListaPrecioCategoriaCliente = await _context.TipoListaPrecioCategoriaCliente.FindAsync(id);
            if (tipoListaPrecioCategoriaCliente == null)
            {
                return NotFound();
            }

            _context.TipoListaPrecioCategoriaCliente.Remove(tipoListaPrecioCategoriaCliente);
            await _context.SaveChangesAsync();

            return tipoListaPrecioCategoriaCliente;
        }

        private bool TipoListaPrecioCategoriaClienteExists(int id)
        {
            return _context.TipoListaPrecioCategoriaCliente.Any(e => e.Id == id);
        }
    }
}
