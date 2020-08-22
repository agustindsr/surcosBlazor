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
    public class BannerController : ControllerBase
    {
        private readonly WebApiDbContext _context;
        private readonly IAlmacenadorDeArchivos almacenadorDeArchivos;

        public BannerController(WebApiDbContext context, IAlmacenadorDeArchivos _almacenadorDeArchivos)
        {
            _context = context;
            almacenadorDeArchivos = _almacenadorDeArchivos;

        }

        // GET: api/Banner
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Banner>>> Getbanner([FromQuery] Paginacion paginacion, int cantidadDeRegistros)
        {
            var queryable = _context.banner.OrderBy(x => x.orden).AsQueryable();
            if (cantidadDeRegistros != 0)
            {
                paginacion.CantidadRegistros = cantidadDeRegistros;
            }
            await HttpContext.InsertarParametrosPaginacionEnRespuesta(queryable, paginacion.CantidadRegistros);
            List<Banner> banners = await queryable.Paginar(paginacion).ToListAsync();
            return banners;
        }

        // GET: api/Banner/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Banner>> GetBanner(int id)
        {
            var banner = await _context.banner.FindAsync(id);

            if (banner == null)
            {
                return NotFound();
            }

            return banner;
        }

        // PUT: api/Banner/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBanner(int id, Banner banner)
        {
            if (id != banner.Id)
            {
                return BadRequest();
            }
            string rutaActualImagen = _context.banner.Where(x => x.Id == id).Select(x => x.Foto).ToList()[0];
            if (rutaActualImagen != banner.Foto)
            {
                var fotoImagen = Convert.FromBase64String(banner.Foto);
                banner.Foto = await almacenadorDeArchivos.EditarArchivo(fotoImagen,
                    "jpg", "banners", rutaActualImagen);
            }

            _context.Entry(banner).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BannerExists(id))
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

        // POST: api/Banner
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Banner>> PostBanner(Banner banner)
        {
            if (!string.IsNullOrWhiteSpace(banner.Foto))
            {
                var fotoBanner = Convert.FromBase64String(banner.Foto);
                banner.Foto = await almacenadorDeArchivos.GuardarArchivo(fotoBanner, "jpg", "banners");
            }
            _context.banner.Add(banner);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBanner", new { id = banner.Id }, banner);
        }

        // DELETE: api/Banner/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Banner>> DeleteBanner(int id)
        {
            var banner = await _context.banner.FindAsync(id);
            if (banner == null)
            {
                return NotFound();
            }

            _context.banner.Remove(banner);
            await _context.SaveChangesAsync();

            return banner;
        }

        private bool BannerExists(int id)
        {
            return _context.banner.Any(e => e.Id == id);
        }
    }
}
