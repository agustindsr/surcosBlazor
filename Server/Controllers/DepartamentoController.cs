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
    public class DepartamentoController : ControllerBase
    {
        private readonly WebApiDbContext _context;

        public DepartamentoController(WebApiDbContext context)
        {
            _context = context;
        }

        // GET: api/Departamento
        [HttpGet]
        public async Task<ActionResult<List<Departamento>>> Get([FromQuery] Paginacion paginacion, int cantidadDeRegistros,string filtro, int provinciaId, bool includeProvincia)
        {
            var queryable = _context.departamento.AsQueryable();
            if (includeProvincia) {
                queryable = queryable.Include(x => x.Provincia);
            }
            if (cantidadDeRegistros != 0)
            {
                paginacion.CantidadRegistros = cantidadDeRegistros;
            }
            if (provinciaId != 0) {
                queryable = queryable.Where(x => x.ProvinciaId == provinciaId);
            }
            if (!string.IsNullOrWhiteSpace(filtro))
            {
                queryable = queryable.Where(x => x.nombre.Contains(filtro)).AsQueryable();
            }


            await HttpContext.InsertarParametrosPaginacionEnRespuesta(queryable, paginacion.CantidadRegistros);
            return await queryable.Paginar(paginacion).ToListAsync();
           
        }
        [HttpGet("DepartamentosDeVendedor")]
        public async Task<ActionResult<List<Departamento>>> GetDepartamentoDeVendedor(int vendedorId)
        {
            var departamentos = await _context.vendedorDepartamento.Where(x => x.VendedorId == vendedorId).Include(x => x.departamento).ThenInclude(x => x.Provincia).Select(x => x.departamento).ToListAsync() ;

           

            return departamentos;
        }
        // GET: api/Departamento/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Departamento>> GetDepartamento(int id)
        {
            var departamento = await _context.departamento.FindAsync(id);

            if (departamento == null)
            {
                return NotFound();
            }

            return departamento;
        }
        [HttpGet("getByName")]
        public async Task<ActionResult<Departamento>> GetDepartamentoByName(string departamentoNombre)
        {
            Departamento departamento = await _context.departamento.FirstAsync(x => x.nombre == departamentoNombre && x.eCommerce);


            if (departamento == null)
            {
                return null;
            }

            return departamento;
        }
        // PUT: api/Departamento/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDepartamento(int id, Departamento departamento)
        {
            if (id != departamento.Id)
            {
                return BadRequest();
            }

            _context.Entry(departamento).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DepartamentoExists(id))
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

        // POST: api/Departamento
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Departamento>> PostDepartamento(Departamento departamento)
        {
            _context.departamento.Add(departamento);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDepartamento", new { id = departamento.Id }, departamento);
        }

        // DELETE: api/Departamento/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Departamento>> DeleteDepartamento(int id)
        {
            var departamento = await _context.departamento.FindAsync(id);
            if (departamento == null)
            {
                return NotFound();
            }

            _context.departamento.Remove(departamento);
            await _context.SaveChangesAsync();

            return departamento;
        }

        private bool DepartamentoExists(int id)
        {
            return _context.departamento.Any(e => e.Id == id);
        }
    }
}
