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
    public class ProvinciaController : ControllerBase
    {
        private readonly WebApiDbContext _context;

        public ProvinciaController(WebApiDbContext context)
        {
            _context = context;
        }

        // GET: api/Provincia
        [HttpGet]
        public async Task<ActionResult<List<Provincia>>> Get([FromQuery] Paginacion paginacion,  int cantidadDeRegistros,string filtro)
        
        {
            try
            {
                var queryable = _context.provincias.AsQueryable();
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
            catch (Exception ex)
            {

                throw;
            }
        
        }


        // GET: api/Provincia/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Provincia>> GetProvincia(int id)
        {
            Provincia provincia = await _context.provincias.FirstAsync(x => x.Id == id);
           
    
            if (provincia == null)
            {
                return NotFound();
            }

            return provincia;
        }
        [HttpGet("getByName")]
        public async Task<ActionResult<Provincia>> GetProvinciaByName(string provinciaNombre)
        {
            Provincia provincia = await _context.provincias.FirstAsync(x => x.nombre == provinciaNombre && x.eCommerce);


            if (provincia == null)
            {
                return null;
            }

            return provincia;
        }
        // PUT: api/Provincia/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProvincia(int id, Provincia provincia)
        {
            if (id != provincia.Id)
            {
                return BadRequest();
            }

            _context.Entry(provincia).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProvinciaExists(id))
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

        // POST: api/Provincia
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Provincia>> PostProvincia(Provincia provincia)
        {
            _context.provincias.Add(provincia);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProvincia", new { id = provincia.Id }, provincia);
        }

        // DELETE: api/Provincia/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Provincia>> DeleteProvincia(int id)
        {
            var provincia = await _context.provincias.FindAsync(id);
            if (provincia == null)
            {
                return NotFound();
            }

            _context.provincias.Remove(provincia);
            await _context.SaveChangesAsync();

            return provincia;
        }

        private bool ProvinciaExists(int id)
        {
            return _context.provincias.Any(e => e.Id == id);
        }
    }
}
