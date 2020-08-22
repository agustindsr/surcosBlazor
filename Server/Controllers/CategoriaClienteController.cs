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
    public class CategoriaClienteController : ControllerBase
    {
        private readonly WebApiDbContext _context;

        public CategoriaClienteController(WebApiDbContext context)
        {
            _context = context;
        }

        // GET: api/CategoriaCliente
        [HttpGet]
        public async Task<ActionResult<List<CategoriaCliente>>> Get([FromQuery] Paginacion paginacion, int cantidadDeRegistros, string filtro)
        {
            try
            {
                var queryable = _context.categoriaCliente.AsQueryable();
                if (cantidadDeRegistros != 0)
                {
                    paginacion.CantidadRegistros = cantidadDeRegistros;
                }
                if (!string.IsNullOrWhiteSpace(filtro))
                {
                    queryable = queryable.Where(x => x.nombre.Contains(filtro)).AsQueryable();
                }
                await HttpContext.InsertarParametrosPaginacionEnRespuesta(queryable, paginacion.CantidadRegistros);
                List<CategoriaCliente> categoriaClientes = await queryable.Paginar(paginacion).ToListAsync();
                return categoriaClientes;
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        // GET: api/CategoriaCliente/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CategoriaCliente>> GetCategoriaCliente(int id)
        {
            var categoriaCliente = await _context.categoriaCliente.FindAsync(id);

            if (categoriaCliente == null)
            {
                return NotFound();
            }

            return categoriaCliente;
        }

        // PUT: api/CategoriaCliente/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCategoriaCliente(int id, CategoriaCliente categoriaCliente)
        {
            if (id != categoriaCliente.Id)
            {
                return BadRequest();
            }

            _context.Entry(categoriaCliente).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CategoriaClienteExists(id))
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

        // POST: api/CategoriaCliente
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<CategoriaCliente>> PostCategoriaCliente(CategoriaCliente categoriaCliente)
        {
            _context.categoriaCliente.Add(categoriaCliente);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCategoriaCliente", new { id = categoriaCliente.Id }, categoriaCliente);
        }

        // DELETE: api/CategoriaCliente/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<CategoriaCliente>> DeleteCategoriaCliente(int id)
        {
            var categoriaCliente = await _context.categoriaCliente.FindAsync(id);
            if (categoriaCliente == null)
            {
                return NotFound();
            }

            _context.categoriaCliente.Remove(categoriaCliente);
            await _context.SaveChangesAsync();

            return categoriaCliente;
        }

        private bool CategoriaClienteExists(int id)
        {
            return _context.categoriaCliente.Any(e => e.Id == id);
        }
    }
}
