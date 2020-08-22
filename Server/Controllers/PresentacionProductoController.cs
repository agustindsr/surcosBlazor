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
    public class PresentacionProductoController : ControllerBase
    {
        private readonly WebApiDbContext _context;

        public PresentacionProductoController(WebApiDbContext context)
        {
            _context = context;
        }

        // GET: api/PresentacionProducto
        [HttpGet]
        public async Task<ActionResult<List<PresentacionProducto>>> Get([FromQuery] Paginacion paginacion, int cantidadDeRegistros, string filtro)
        {
            try
            {
                var queryable = _context.presentacionProducto.Include(x =>x.Unidad).AsQueryable();
                if (cantidadDeRegistros != 0)
                {
                    paginacion.CantidadRegistros = cantidadDeRegistros;
                }
                if (!string.IsNullOrWhiteSpace(filtro))
                {
                    queryable = queryable.Where(x => x.nombre.Contains(filtro)).AsQueryable();
                }
                await HttpContext.InsertarParametrosPaginacionEnRespuesta(queryable, paginacion.CantidadRegistros);
                List<PresentacionProducto> presentacionProductos = await queryable.Paginar(paginacion).ToListAsync();
                return presentacionProductos;
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        // GET: api/PresentacionProducto/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PresentacionProducto>> GetPresentacionProducto(int id)
        {
            var presentacionProducto = await _context.presentacionProducto.FindAsync(id);

            if (presentacionProducto == null)
            {
                return NotFound();
            }

            return presentacionProducto;
        }

        // PUT: api/PresentacionProducto/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPresentacionProducto(int id, PresentacionProducto presentacionProducto)
        {
            if (id != presentacionProducto.Id)
            {
                return BadRequest();
            }

            _context.Entry(presentacionProducto).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PresentacionProductoExists(id))
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

        // POST: api/PresentacionProducto
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<PresentacionProducto>> PostPresentacionProducto(PresentacionProducto presentacionProducto)
        {
            _context.presentacionProducto.Add(presentacionProducto);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPresentacionProducto", new { id = presentacionProducto.Id }, presentacionProducto);
        }

        // DELETE: api/PresentacionProducto/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<PresentacionProducto>> DeletePresentacionProducto(int id)
        {
            var presentacionProducto = await _context.presentacionProducto.FindAsync(id);
            if (presentacionProducto == null)
            {
                return NotFound();
            }

            _context.presentacionProducto.Remove(presentacionProducto);
            await _context.SaveChangesAsync();

            return presentacionProducto;
        }

        private bool PresentacionProductoExists(int id)
        {
            return _context.presentacionProducto.Any(e => e.Id == id);
        }
    }
}
