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
    public class VendedorDepartamentoController : ControllerBase
    {
        private readonly WebApiDbContext _context;

        public VendedorDepartamentoController(WebApiDbContext context)
        {
            _context = context;
        }

        // GET: api/VendedorDepartamento
        [HttpGet]
        public async Task<ActionResult<List<VendedorDepartamento>>> Get([FromQuery] Paginacion paginacion, int vendedorId,int cantidadDeRegistros)
        {
            try
            {
                var queryable = _context.vendedorDepartamento.Include(x => x.departamento).ThenInclude(x => x.Provincia).AsQueryable();
                if (cantidadDeRegistros != 0)
                {
                    paginacion.CantidadRegistros = cantidadDeRegistros;
                }

                if (vendedorId != 0) {
                    queryable = queryable.Where(x => x.VendedorId == vendedorId).AsQueryable();
                }
                await HttpContext.InsertarParametrosPaginacionEnRespuesta(queryable, paginacion.CantidadRegistros);
                List<VendedorDepartamento> vendedorDepartamentos = await queryable.Paginar(paginacion).ToListAsync();
                return vendedorDepartamentos;
            }
            catch (Exception ex)
            {

                throw;
            }

        }

        // GET: api/VendedorDepartamento/5
        [HttpGet("{id}")]
        public async Task<ActionResult<VendedorDepartamento>> GetVendedorDepartamento(int id)
        {
            var vendedorDepartamento = await _context.vendedorDepartamento.FindAsync(id);

            if (vendedorDepartamento == null)
            {
                return NotFound();
            }

            return vendedorDepartamento;
        }
        [HttpGet("DiasQueTrabaja")]
        public async Task<ActionResult<List<DateTime>>> GetDiasQueTrabaja(int vendedorId, int departamentoId)
        {
            var vendedorDepartamento = await _context.vendedorDepartamento.FirstOrDefaultAsync(x => x.VendedorId == vendedorId && x.DepartamentoId == departamentoId);

            var FechaActual = DateTime.Now.AddDays(1);
            List<DateTime> diasQueTrabaja = new List<DateTime>();
            for (int i = 0; i < 10; i++) {
                var fechaIteracion = FechaActual.AddDays(i);
                string diaDeLaSemana = fechaIteracion.ToString("dddd").ToLower();

                //LUNES
                if ((diaDeLaSemana == "monday" || diaDeLaSemana == "lunes") && vendedorDepartamento.entregaLunes) {
                    diasQueTrabaja.Add(fechaIteracion);
                }
                if ((diaDeLaSemana == "tuesday" || diaDeLaSemana == "martes") && vendedorDepartamento.entregaMartes)
                {
                    diasQueTrabaja.Add(fechaIteracion);
                }
                if ((diaDeLaSemana == "wednesday" || diaDeLaSemana == "miércoles") && vendedorDepartamento.entregaMiercoles)
                {
                    diasQueTrabaja.Add(fechaIteracion);
                }
                if ((diaDeLaSemana == "thursday" || diaDeLaSemana == "jueves") && vendedorDepartamento.entregaJueves)
                {
                    diasQueTrabaja.Add(fechaIteracion);
                }
                if ((diaDeLaSemana == "friday" || diaDeLaSemana == "viernes") && vendedorDepartamento.entregaViernes)
                {
                    diasQueTrabaja.Add(fechaIteracion);
                }
                if ((diaDeLaSemana == "saturday" || diaDeLaSemana == "sábado") && vendedorDepartamento.entregaSabado)
                {
                    diasQueTrabaja.Add(fechaIteracion);
                }
                if ((diaDeLaSemana == "sunday" || diaDeLaSemana == "domingo") && vendedorDepartamento.entregaDomingo)
                {
                    diasQueTrabaja.Add(fechaIteracion);
                }
            }
            if (vendedorDepartamento == null)
            {
                return NotFound();
            }

            return diasQueTrabaja;
        }
        // PUT: api/VendedorDepartamento/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutVendedorDepartamento(int id, VendedorDepartamento vendedorDepartamento)
        {
            if (id != vendedorDepartamento.Id)
            {
                return BadRequest();
            }

            _context.Entry(vendedorDepartamento).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VendedorDepartamentoExists(id))
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

        // POST: api/VendedorDepartamento
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<VendedorDepartamento>> PostVendedorDepartamento(VendedorDepartamento vendedorDepartamento)
        {
            _context.vendedorDepartamento.Add(vendedorDepartamento);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetVendedorDepartamento", new { id = vendedorDepartamento.Id }, vendedorDepartamento);
        }

        // DELETE: api/VendedorDepartamento/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<VendedorDepartamento>> DeleteVendedorDepartamento(int id)
        {
            var vendedorDepartamento = await _context.vendedorDepartamento.FindAsync(id);
            if (vendedorDepartamento == null)
            {
                return NotFound();
            }

            _context.vendedorDepartamento.Remove(vendedorDepartamento);
            await _context.SaveChangesAsync();

            return vendedorDepartamento;
        }

        private bool VendedorDepartamentoExists(int id)
        {
            return _context.vendedorDepartamento.Any(e => e.Id == id);
        }
    }
}
