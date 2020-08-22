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
    public class ProductoController : ControllerBase
    {
        private readonly WebApiDbContext _context;
        private readonly IAlmacenadorDeArchivos almacenadorDeArchivos;

        public ProductoController(WebApiDbContext context, IAlmacenadorDeArchivos _almacenadorDeArchivos)
        {
            _context = context;
            almacenadorDeArchivos = _almacenadorDeArchivos;

        }

        // GET: api/Producto
        [HttpGet]
        public async Task<ActionResult<List<Producto>>> Get([FromQuery] Paginacion paginacion, int cantidadDeRegistros, string filtro)
        {
            var queryable = _context.producto.Include(x => x.CategoriaProducto).OrderBy(x=>x.nombre).AsQueryable();
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

        // GET: api/Producto/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Producto>> GetProducto(int id)
        {
            var producto = await _context.producto.Include(x => x.CategoriaProducto).FirstOrDefaultAsync(x => x.Id == id);

            if (producto == null)
            {
                return NotFound();
            }

            return producto;
        }

        // PUT: api/Producto/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProducto(int id, Producto producto)
        {
            if (id != producto.Id)
            {
                return BadRequest();
            }

            string rutaActualImagen = _context.producto.Where(x => x.Id == id).Select(x => x.Foto).ToList()[0];


            if (rutaActualImagen != producto.Foto)
            {
                var fotoImagen = Convert.FromBase64String(producto.Foto);
                producto.Foto = await almacenadorDeArchivos.EditarArchivo(fotoImagen,
                    "jpg", "productos", rutaActualImagen);

            }


            _context.Entry(producto).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductoExists(id))
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
        // POST: api/Producto
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Producto>> PostProducto(Producto producto)
        {
            if (!string.IsNullOrWhiteSpace(producto.Foto))
            {
                var fotoProducto = Convert.FromBase64String(producto.Foto);
                producto.Foto = await almacenadorDeArchivos.GuardarArchivo(fotoProducto, "jpg", "productos");
            }
            _context.producto.Add(producto);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProducto", new { id = producto.Id }, producto);
        }

        // DELETE: api/Producto/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Producto>> DeleteProducto(int id)
        {
            var producto = await _context.producto.Include(x => x.productoPresentaciones).FirstOrDefaultAsync(x => x.Id == id);
            if (producto == null)
            {
                return NotFound();
            }

            _context.producto.Remove(producto);
            producto.productoPresentaciones.ForEach(x => _context.Entry(x).State = EntityState.Deleted);
            await _context.SaveChangesAsync();

            return producto;
        }

        private bool ProductoExists(int id)
        {
            return _context.producto.Any(e => e.Id == id);
        }
    }
}
