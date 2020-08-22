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
    public class OrdenProduccionController : ControllerBase
    {
        private readonly WebApiDbContext _context;

        public OrdenProduccionController(WebApiDbContext context)
        {
            _context = context;
        }

        // GET: api/OrdenProduccion
        [HttpGet]
        public async Task<ActionResult<IEnumerable<OrdenProduccion>>> GetordenProduccion([FromQuery] Paginacion paginacion, int cantidadDeRegistros)
        {
            var queryable = _context.ordenProduccion.Include(x => x.EstadoOrdenProduccion).Include(x => x.Deposito).OrderByDescending(x => x.fecha).AsQueryable();
            if (cantidadDeRegistros != 0)
            {
                paginacion.CantidadRegistros = cantidadDeRegistros;
            }
            await HttpContext.InsertarParametrosPaginacionEnRespuesta(queryable, paginacion.CantidadRegistros);
            return await queryable.Paginar(paginacion).ToListAsync();
        }

        // GET: api/OrdenProduccion/5
        [HttpGet("{id}")]
        public async Task<ActionResult<OrdenProduccion>> GetOrdenProduccion(int id)
        {
            var ordenProduccion = await _context.ordenProduccion.Include(x => x.Deposito).Include(x => x.detallesOrdenProduccion).FirstOrDefaultAsync(x => x.Id == id);

            ordenProduccion.detallesOrdenProduccion.ForEach((z) => z = _context.detallesOrdenProduccion
                                                                                    .Include(x => x.ProductoPresentacion)
                                                                                    .ThenInclude(x => x.Producto)
                                                                                    .Include(x => x.ProductoPresentacion)
                                                                                    .ThenInclude(x => x.PresentacionProducto)
                                                                                    .FirstOrDefault(y => y.Id == z.Id));
            if (ordenProduccion == null)
            {
                return NotFound();
            }

            return ordenProduccion;
        }

        // PUT: api/OrdenProduccion/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOrdenProduccion(int id, OrdenProduccion ordenProduccion)
        {
            if (id != ordenProduccion.Id)
            {
                return BadRequest();
            }

            _context.Entry(ordenProduccion).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OrdenProduccionExists(id))
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

        // POST: api/OrdenProduccion
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<OrdenProduccion>> PostOrdenProduccion(OrdenProduccion ordenProduccion)
        {
            try
            {
                ordenProduccion.Deposito = null;
                ordenProduccion.detallesOrdenProduccion.ForEach(x => x.ProductoPresentacion = null);

                _context.ordenProduccion.Add(ordenProduccion);
                ordenProduccion.EstadoOrdenProduccionId = 1;
                await _context.SaveChangesAsync();



                ordenProduccion = await _context.ordenProduccion
                                           .Include(x => x.detallesOrdenProduccion)
                                           .FirstOrDefaultAsync(x => x.Id == ordenProduccion.Id);


                foreach (DetalleOrdenProduccion detalle in ordenProduccion.detallesOrdenProduccion)
                {
                    Inventario inventarioDb = _context.inventario.FirstOrDefault(x => x.DepositoId == ordenProduccion.DepositoId && x.ProductoPresentacionId == detalle.ProductoPresentacionId);
                    if (inventarioDb == null)
                    {
                        inventarioDb = new Inventario { DepositoId = ordenProduccion.DepositoId, ProductoPresentacionId = detalle.ProductoPresentacionId };
                        _context.inventario.Add(inventarioDb);
                        await _context.SaveChangesAsync();
                    }
                    //

                    inventarioDb.cantidadUnidadesEnExistencia += detalle.cantidad;

                    _context.Entry(inventarioDb).State = EntityState.Modified;

                    MovimientoInventario movimiento = new MovimientoInventario
                    {
                        cantidadUnidadesMovida = detalle.cantidad,
                        entra = true,
                        sale = false,
                        InventarioId = inventarioDb.Id,
                        OrdenProduccionId = ordenProduccion.Id

                    };
                    _context.Entry(movimiento).State = EntityState.Added;

                }
                _context.Entry(ordenProduccion).State = EntityState.Unchanged;
                await _context.SaveChangesAsync();

                return CreatedAtAction("GetOrdenProduccion", new { id = ordenProduccion.Id }, ordenProduccion);
            }
            catch (Exception ex)
            {

                throw;
            }
          
        }

        // DELETE: api/OrdenProduccion/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<OrdenProduccion>> DeleteOrdenProduccion(int id)
        {
            try
            {
                List<MovimientoInventario> movimientoInventarios = await _context.movimientoInventario.Where(x => x.OrdenProduccionId == id).ToListAsync() ;
                var ordenProduccion = await _context.ordenProduccion.FirstOrDefaultAsync(x => x.Id == id);

                if (ordenProduccion == null)
                {
                    return NotFound();
                }

                foreach (MovimientoInventario movimientoInventario in movimientoInventarios)
                {
                    Inventario inventario = await _context.inventario.FindAsync(movimientoInventario.InventarioId);
                    inventario.cantidadUnidadesEnExistencia -= movimientoInventario.cantidadUnidadesMovida;
                    _context.Entry(inventario).State = EntityState.Modified;
                    _context.Entry(movimientoInventario).State = EntityState.Deleted;
                }


                _context.Entry(ordenProduccion).State = EntityState.Deleted;
                await _context.SaveChangesAsync();

                return ordenProduccion;
            }
            catch (Exception)
            {

                throw;
            }
        }

        private bool OrdenProduccionExists(int id)
        {
            return _context.ordenProduccion.Any(e => e.Id == id);
        }
    }
}
