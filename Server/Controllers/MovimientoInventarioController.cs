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
    public class MovimientoInventarioController : ControllerBase
    {
        private readonly WebApiDbContext _context;

        public MovimientoInventarioController(WebApiDbContext context)
        {
            _context = context;
        }

        // GET: api/MovimientoInventario
        [HttpGet]
        public async Task<ActionResult<List<MovimientoInventario>>> GetMovimientosInventario([FromQuery] Paginacion paginacion, int cantidadDeRegistros, int inventarioId)
        {
            try
            {
                var queryable = _context.movimientoInventario.Include(x => x.OrdenProduccion).OrderByDescending(x => x.fecha).AsQueryable();
                if (cantidadDeRegistros != 0)
                {
                    paginacion.CantidadRegistros = cantidadDeRegistros;
                }
                if (inventarioId != 0)
                {
                    queryable = queryable.Where(x => x.InventarioId == inventarioId).AsQueryable();
                }
                await HttpContext.InsertarParametrosPaginacionEnRespuesta(queryable, paginacion.CantidadRegistros);
                List<MovimientoInventario> movimientosInventario = await queryable.Paginar(paginacion).ToListAsync();
                return movimientosInventario;
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        // GET: api/MovimientoInventario/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MovimientoInventario>> GetMovimientoInventario(int id)
        {
            var movimientoInventario = await _context.movimientoInventario.FindAsync(id);

            if (movimientoInventario == null)
            {
                return NotFound();
            }

            return movimientoInventario;
        }

        // PUT: api/MovimientoInventario/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMovimientoInventario(int id, MovimientoInventario movimientoInventario)
        {
            if (id != movimientoInventario.Id)
            {
                return BadRequest();
            }

            _context.Entry(movimientoInventario).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MovimientoInventarioExists(id))
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

        // POST: api/MovimientoInventario
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<MovimientoInventario>> PostMovimientoInventario(MovimientoInventario movimientoInventario)
         {
            try
            {
                if (movimientoInventario.InventarioId == 0)
                {
                    movimientoInventario.Inventario.Deposito = null;
                    movimientoInventario.Inventario.ProductoPresentacion = null;

                    _context.inventario.Add(movimientoInventario.Inventario);
                    await _context.SaveChangesAsync();
                    movimientoInventario.InventarioId = movimientoInventario.Inventario.Id;
                }
                Inventario inventarioDb = await _context.inventario.FirstAsync(x => x.Id == movimientoInventario.InventarioId);
                if (movimientoInventario.entra)
                {
                    inventarioDb.cantidadUnidadesEnExistencia += movimientoInventario.cantidadUnidadesMovida;

                }
                else if (movimientoInventario.sale) {

                    inventarioDb.cantidadUnidadesEnExistencia -= movimientoInventario.cantidadUnidadesMovida;

                }
                movimientoInventario.Inventario = null;

                _context.Entry(inventarioDb).State = EntityState.Modified;
                _context.movimientoInventario.Add(movimientoInventario);
                
                await _context.SaveChangesAsync();

                return CreatedAtAction("GetMovimientoInventario", new { id = movimientoInventario.Id }, movimientoInventario);
            }
            catch (Exception ex)
            {

                throw;
            }
           
        }
       

        private bool MovimientoInventarioExists(int id)
        {
            return _context.movimientoInventario.Any(e => e.Id == id);
        }
    }

}
