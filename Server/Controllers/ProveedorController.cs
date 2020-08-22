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
    public class ProveedorController : ControllerBase
    {
        private readonly WebApiDbContext _context;

        public ProveedorController(WebApiDbContext context)
        {
            _context = context;
        }

        // GET: api/Proveedor
        [HttpGet]
        public async Task<ActionResult<List<Proveedor>>> Get([FromQuery] Paginacion paginacion, int cantidadDeRegistros, string filtro, int provinciaId, int departamentoId)
        {
            var queryable = _context.Proveedor.Include(x => x.Domicilio)
                    .ThenInclude(x => x.Departamento)
                    .Include(x => x.Domicilio)
                    .ThenInclude(x => x.Provincia)
                             .AsQueryable();

            if (provinciaId != 0)
            {
                queryable = queryable.Where(x => x.Domicilio.ProvinciaId == provinciaId).AsQueryable();
            }
            if (departamentoId != 0)
            {
                queryable = queryable.Where(x => x.Domicilio.DepartamentoId == departamentoId).AsQueryable();
            }
            if (cantidadDeRegistros != 0)
            {
                paginacion.CantidadRegistros = cantidadDeRegistros;
            }

            if (!string.IsNullOrWhiteSpace(filtro))
            {
                queryable = queryable.Where(x => x.razonSocial.Contains(filtro)).AsQueryable();
            }


            await HttpContext.InsertarParametrosPaginacionEnRespuesta(queryable, paginacion.CantidadRegistros);
            return await queryable.Paginar(paginacion).ToListAsync();

        }
        // GET: api/Proveedor/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Proveedor>> GetProveedor(int id)
        {
            var proveedor = await _context.Proveedor
                .Include(x => x.Domicilio)
                    .ThenInclude(x => x.Departamento)
                    .Include(x => x.Domicilio)
                    .ThenInclude(x => x.Provincia)
                .FirstOrDefaultAsync(x => x.Id == id);

            if (proveedor == null)
            {
                return NotFound();
            }

            return proveedor;
        }
        [HttpGet("saldoProveedores")]
        public async Task<decimal> GetSaldoProveedores()
        {
            return _context.Proveedor.Sum(x => x.saldoCC);

        }
        // PUT: api/Proveedor/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProveedor(int id, Proveedor proveedor)
        {
            if (id != proveedor.Id)
            {
                return BadRequest();
            }

            _context.Entry(proveedor).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProveedorExists(id))
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

        // POST: api/Proveedor
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Proveedor>> PostProveedor(Proveedor proveedor)
        {
            _context.Proveedor.Add(proveedor);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProveedor", new { id = proveedor.Id }, proveedor);
        }

        // DELETE: api/Proveedor/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Proveedor>> DeleteProveedor(int id)
        {
            var proveedor = await _context.Proveedor.FindAsync(id);
            if (proveedor == null)
            {
                return NotFound();
            }

            _context.Proveedor.Remove(proveedor);
            await _context.SaveChangesAsync();

            return proveedor;
        }

        private bool ProveedorExists(int id)
        {
            return _context.Proveedor.Any(e => e.Id == id);
        }
    }
}
