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
    public class InventarioController : ControllerBase
    {
        private readonly WebApiDbContext _context;

        public InventarioController(WebApiDbContext context)
        {
            _context = context;
        }

        // GET: api/Inventario
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Inventario>>> Getinventario()
        {
            return await _context.inventario.Include(x => x.ProductoPresentacion.Producto)
                .Include(x => x.ProductoPresentacion.PresentacionProducto)
                .Include(x => x.Deposito).ToListAsync();
        }
        [HttpGet("InventarioValorizado")]
        public async Task<decimal> InventarioValorizado()
        {
            List<Inventario> inventarios = await _context.inventario.Include(x => x.ProductoPresentacion).ThenInclude(x => x.FormulaProducto).ThenInclude(x => x.DetallesFormula).ToListAsync();

            decimal valor = 0.00M;
            foreach (Inventario inventario in inventarios) {
                if (inventario.ProductoPresentacion.esFormulado)
                {
                    valor += (inventario.ProductoPresentacion.FormulaProducto?._total * inventario.cantidadUnidadesEnExistencia)?? 0.00M;
                }
                else
                {
                    valor += inventario.ProductoPresentacion.costo * inventario.cantidadUnidadesEnExistencia;

                }

            }
          


            return valor;
        }
        [HttpGet("InventarioPorDeposito")]
        public async Task<ActionResult<List<Inventario>>> GetInventarioPorDeposito([FromQuery] Paginacion paginacion, int depositoId, int cantidadDeRegistros, string filtro)
        {
            var queryable = _context.inventario
                                            .Include(x => x.ProductoPresentacion.Producto)
                                            .Include(x => x.ProductoPresentacion.PresentacionProducto).Where(x => x.DepositoId == depositoId)
                                            .OrderBy(x => x.ProductoPresentacion.Producto.nombre).AsQueryable();
            if (cantidadDeRegistros != 0)
            {
                paginacion.CantidadRegistros = cantidadDeRegistros;
            }
            if (!string.IsNullOrWhiteSpace(filtro))
            {
                queryable = queryable.Where(x => x.ProductoPresentacion.Producto.nombre.Contains(filtro)).AsQueryable();
            }
            await HttpContext.InsertarParametrosPaginacionEnRespuesta(queryable, paginacion.CantidadRegistros);
            return await queryable.Paginar(paginacion).ToListAsync();
        }

        [HttpGet("DetalleInventario")]
        public async Task<ActionResult<Inventario>> ObtenerInventario(int productoId, int depositoId)
        {
            Inventario inventario;
            try
            {
                inventario = await _context.inventario.Include(x => x.ProductoPresentacion.PresentacionProducto).Include(x => x.ProductoPresentacion.Producto)
              .Include(x => x.Deposito)
              .FirstAsync(x => x.DepositoId == depositoId && x.ProductoPresentacionId == productoId);
                return inventario;
            }
            catch (Exception ex)
            {
                return new Inventario();
            }
        }
        // GET: api/Inventario/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Inventario>> GetInventario(int id)
        {
            var inventario = await _context.inventario.Include(x => x.ProductoPresentacion.PresentacionProducto).Include(x => x.ProductoPresentacion.Producto)
              .Include(x => x.Deposito)
              .FirstAsync(x => x.Id == id);

            if (inventario == null)
            {
                return NotFound();
            }

            return inventario;
        }

        // PUT: api/Inventario/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutInventario(int id, Inventario inventario)
        {
            if (id != inventario.Id)
            {
                return BadRequest();
            }

            _context.Entry(inventario).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!InventarioExists(id))
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

        // POST: api/Inventario
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Inventario>> PostInventario(Inventario inventario)
        {
            _context.inventario.Add(inventario);
            await _context.SaveChangesAsync();

            _context.movimientoInventario.Add(new MovimientoInventario() { entra = true, InventarioId = inventario.Id, cantidadUnidadesMovida = 0 });

            await _context.SaveChangesAsync();

            return CreatedAtAction("ObtenerInventario", new { depositoId = inventario.DepositoId, productoPresentacionId = inventario.ProductoPresentacionId });
        }

        // DELETE: api/Inventario/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Inventario>> DeleteInventario(int id)
        {
            var inventario = await _context.inventario.FindAsync(id);
            if (inventario == null)
            {
                return NotFound();
            }

            _context.inventario.Remove(inventario);
            await _context.SaveChangesAsync();

            return inventario;
        }

        private bool InventarioExists(int id)
        {
            return _context.inventario.Any(e => e.Id == id);
        }
    }
}
