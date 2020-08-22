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
    public class CategoriaProductoController : ControllerBase
    {
        private readonly WebApiDbContext _context;

        public CategoriaProductoController(WebApiDbContext context)
        {
            _context = context;
        }

        // GET: api/CategoriaProducto
        [HttpGet]
        public async Task<ActionResult<List<CategoriaProducto>>> Get([FromQuery] Paginacion paginacion, int cantidadDeRegistros, string filtro)
        {
            try
            {
                var queryable = _context.categoriaProducto.AsQueryable();
                if (cantidadDeRegistros != 0)
                {
                    paginacion.CantidadRegistros = cantidadDeRegistros;
                }
                if (!string.IsNullOrWhiteSpace(filtro))
                {
                    queryable = queryable.Where(x => x.nombre.Contains(filtro)).AsQueryable();
                }
                await HttpContext.InsertarParametrosPaginacionEnRespuesta(queryable, paginacion.CantidadRegistros);
                List<CategoriaProducto> categoriaProductos = await queryable.Paginar(paginacion).ToListAsync();
                return categoriaProductos;
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        // GET: api/CategoriaProducto/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CategoriaProducto>> GetCategoriaProducto(int id)
        {
            var categoriaProducto = await _context.categoriaProducto.FindAsync(id);

            if (categoriaProducto == null)
            {
                return NotFound();
            }

            return categoriaProducto;
        }

        // PUT: api/CategoriaProducto/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCategoriaProducto(int id, CategoriaProducto categoriaProducto)
        {
            if (id != categoriaProducto.Id)
            {
                return BadRequest();
            }

            _context.Entry(categoriaProducto).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CategoriaProductoExists(id))
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

        // POST: api/CategoriaProducto
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<CategoriaProducto>> PostCategoriaProducto(CategoriaProducto categoriaProducto)
        {
            _context.categoriaProducto.Add(categoriaProducto);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCategoriaProducto", new { id = categoriaProducto.Id }, categoriaProducto);
        }

        // DELETE: api/CategoriaProducto/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<CategoriaProducto>> DeleteCategoriaProducto(int id)
        {
            var categoriaProducto = await _context.categoriaProducto.FindAsync(id);
            if (categoriaProducto == null)
            {
                return NotFound();
            }

            _context.categoriaProducto.Remove(categoriaProducto);
            await _context.SaveChangesAsync();

            return categoriaProducto;
        }

        private bool CategoriaProductoExists(int id)
        {
            return _context.categoriaProducto.Any(e => e.Id == id);
        }
    }
}
