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
    public class ClienteController : ControllerBase
    {
        private readonly WebApiDbContext _context;

        public ClienteController(WebApiDbContext context)
        {
            _context = context;
        }

        // GET: api/Cliente
        [HttpGet]
        public async Task<ActionResult<List<Cliente>>> Get([FromQuery] Paginacion paginacion, int cantidadDeRegistros, string filtro, int provinciaId, int departamentoId)
        {
            var queryable = _context.cliente.Include(x => x.Domicilio)
                    .ThenInclude(x => x.Departamento)
                    .Include(x => x.Domicilio)
                    .ThenInclude(x => x.Provincia)
                              .Include(x => x.Categoria).AsQueryable();

            if (provinciaId != 0) {
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
                queryable = queryable.Where(x => x.nombre.Contains(filtro)).AsQueryable();
            }


            await HttpContext.InsertarParametrosPaginacionEnRespuesta(queryable, paginacion.CantidadRegistros);
            return await queryable.Paginar(paginacion).ToListAsync();

        }
        [HttpGet("ClientePorZonaVendedor")]
        public async Task<ActionResult<List<Cliente>>> ClientePorZonaVendedor([FromQuery] Paginacion paginacion, int cantidadDeRegistros, string filtro, bool admin, int vendedorId)
        {
            try
            {

                var queryable = _context.cliente.Include(x => x.Domicilio)
                    .ThenInclude(x => x.Departamento)
                    .Include(x => x.Domicilio)
                    .ThenInclude(x => x.Provincia)
                              .Include(x => x.Categoria).AsQueryable();

            if (!admin)
            {
                List<int> ZonasHabilitadasIds = _context.vendedorDepartamento.Where(x => x.VendedorId == vendedorId).Select(x => x.DepartamentoId).ToList();
                queryable = queryable.Where(x => ZonasHabilitadasIds.Contains((int)x.Domicilio.DepartamentoId)).AsQueryable();
            }

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

        [HttpGet("saldoClientes")]
        public async Task<decimal> GetSaldoClientes() {
            return _context.cliente.Sum(x => x.saldoCC);
           
        }

        // GET: api/Cliente/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Cliente>> GetCliente(int id)
        {
            var cliente = await _context.cliente
                .Include(x => x.Domicilio)
                    .ThenInclude(x => x.Departamento)
                    .Include(x => x.Domicilio)
                    .ThenInclude(x => x.Provincia).Include(x => x.Categoria)
                .FirstOrDefaultAsync(x => x.Id == id);

            if (cliente == null)
            {
                return NotFound();
            }

            return cliente;
        }
        [HttpGet("porEmail")]
        public async Task<ActionResult<Cliente>> GetCliente(string email)
        {
            var cliente = await _context.cliente.FirstOrDefaultAsync(x => x.email == email);

            if (cliente == null)
            {
                return NotFound();
            }

            return cliente;
        }

        // PUT: api/Cliente/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCliente(int id, Cliente cliente)
        {
            if (id != cliente.Id)
            {
                return BadRequest();
            }
            if (cliente.Domicilio.Id == 0)
            {
                _context.Entry(cliente.Domicilio).State = EntityState.Added;
            }
            else {
                _context.Entry(cliente.Domicilio).State = EntityState.Modified;
            }
            _context.Entry(cliente).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ClienteExists(id))
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

        // POST: api/Cliente
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Cliente>> PostCliente(Cliente cliente)
        {
            _context.cliente.Add(cliente);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCliente", new { id = cliente.Id }, cliente);
        }

        // DELETE: api/Cliente/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Cliente>> DeleteCliente(int id)
        {
            var cliente = await _context.cliente.FindAsync(id);
            if (cliente == null)
            {
                return NotFound();
            }

            _context.cliente.Remove(cliente);
            await _context.SaveChangesAsync();

            return cliente;
        }

        private bool ClienteExists(int id)
        {
            return _context.cliente.Any(e => e.Id == id);
        }
    }
}
