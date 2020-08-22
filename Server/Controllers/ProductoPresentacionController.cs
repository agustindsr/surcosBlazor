using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
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
    public class ProductoPresentacionController : ControllerBase
    {
        private readonly WebApiDbContext _context;

        public ProductoPresentacionController(WebApiDbContext context)
        {
            _context = context;
        }

        // GET: api/ProductoPresentacion
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductoPresentacion>>> GetproductoPresentaciones(int ProductoId)
        {
            var queryble = _context.productoPresentacion.AsQueryable();
            if (ProductoId != 0)
            {
                queryble = queryble.Where(x => x.ProductoId == ProductoId).AsQueryable();
            }
            queryble =  queryble.Include(x=> x.PresentacionProducto).Include(x => x.Proveedor)
                .Include(x=>x.FormulaProducto)
                    .ThenInclude(y=> y.DetallesFormula)
                .Include(x => x.Producto)
                    .ThenInclude(y=>y.CategoriaProducto)
                .OrderBy(x=>x.PresentacionProducto.cantidad).AsQueryable();
           
            List<ProductoPresentacion> resulst = await queryble.ToListAsync();
            resulst.ForEach((x) => { if (x.esFormulado && x.FormulaProducto != null) { x.FormulaProducto.DetallesFormula =  GetdetalleFormula(x.FormulaProducto.Id); } });

            return resulst;
        }
        [HttpGet("productoPresentacionBasicas")]
        public async Task<ActionResult<IEnumerable<ProductoPresentacion>>> productoPresentacionProducto(int productoId)
        {
            return  await _context.productoPresentacion.Where(x => x.ProductoId == productoId).Include(x => x.Producto).Include(x => x.PresentacionProducto).OrderBy(x => x.PresentacionProducto.cantidad).ToListAsync();
          
        }
            [HttpGet("productoPresentacion")]
        public async Task<ActionResult<ProductoPresentacion>> GetproductoPresentacionesUnica(int productoPresentacionId)
        {
            var queryble = _context.productoPresentacion.Where(x => x.Id == productoPresentacionId)
                .Include(x => x.PresentacionProducto).Include(x => x.Proveedor)
                .Include(x => x.FormulaProducto)
                    .ThenInclude(y => y.DetallesFormula)
                .Include(x => x.Producto)
                    .ThenInclude(y => y.CategoriaProducto)
                .OrderBy(x => x.PresentacionProducto.cantidad).AsQueryable();
           
           ProductoPresentacion productoPresentacion = await queryble.FirstOrDefaultAsync();
             if (productoPresentacion.esFormulado && productoPresentacion.FormulaProducto != null) { 
                productoPresentacion.FormulaProducto.DetallesFormula = GetdetalleFormula(productoPresentacion.FormulaProducto.Id); 
            }
        

            return productoPresentacion;
        }
        [HttpGet("ProductosPresentacionPorProveedor")]
        public async Task<ActionResult<IEnumerable<ProductoPresentacion>>> GetproductoPresentacionesPorProveedor(int ProveedorId, string filtro)
        {
            var queryble = _context.productoPresentacion.Where(x => x.ProveedorId == ProveedorId && x.Producto.nombre.Contains(filtro))
                .Include(x => x.PresentacionProducto)
                .Include(x => x.FormulaProducto)
                    .ThenInclude(y => y.DetallesFormula)
                .Include(x => x.Producto)
                    .ThenInclude(y => y.CategoriaProducto)
                .OrderBy(x => x.PresentacionProducto.cantidad).AsQueryable();
            
            List<ProductoPresentacion> resulst = await queryble.ToListAsync();
            resulst.ForEach((x) => { if (x.esFormulado && x.FormulaProducto != null) { x.FormulaProducto.DetallesFormula = GetdetalleFormula(x.FormulaProducto.Id); } });

            return resulst;
        }
        [HttpGet("ProductosNoFormulados")]
        public async Task<ActionResult<IEnumerable<ProductoPresentacion>>> GetProductosConCostoFijo()
        {
            var queryble = _context.productoPresentacion.Where(x => !x.esFormulado)
                .Include(x => x.PresentacionProducto).Include(x => x.Proveedor)
                .Include(x => x.Producto)
                    .ThenInclude(y => y.CategoriaProducto).OrderByDescending(x => x.Producto.CategoriaProducto.clasificacion).ThenBy(x => x.Producto.CategoriaProducto.nombre).ThenBy(x => x.Producto.nombre)
                .ThenBy(x => x.PresentacionProducto.cantidad).AsQueryable();
          
            List<ProductoPresentacion> resulst = await queryble.ToListAsync();

            return resulst;
        }
        [HttpGet("ProductosFormulados")]
        public async Task<ActionResult<IEnumerable<ProductoPresentacion>>> GetProductosFormulados()
        {
            var queryble = _context.productoPresentacion.Where(x => x.esFormulado)
                .Include(x => x.PresentacionProducto).Include(x => x.Proveedor)
                .Include(x => x.Producto)
                    .ThenInclude(y => y.CategoriaProducto).OrderByDescending(x => x.Producto.CategoriaProducto.clasificacion).ThenBy(x => x.Producto.CategoriaProducto.nombre).ThenBy(x => x.Producto.nombre)
                .ThenBy(x => x.PresentacionProducto.cantidad).AsQueryable();

            List<ProductoPresentacion> resulst = await queryble.ToListAsync();

            return resulst;
        }
        [HttpGet("productoParaInventario")]
        public async Task<ActionResult<IEnumerable<ProductoPresentacion>>> GetproductoPresentacionesInventario()
        {

            return await _context.productoPresentacion.Include(x => x.Producto).Include(x => x.PresentacionProducto).ToListAsync(); ;
        }
        [HttpGet("ListaPrecios")]
        public async Task<ActionResult<IEnumerable<ProductoPresentacion>>> GetproductoPresentacionesListaPrecios()
        {
            var queryble = _context.productoPresentacion.Include(x => x.Producto).ThenInclude(y => y.CategoriaProducto)
                .Where(x => x.Producto.CategoriaProducto != null && !x.Producto.CategoriaProducto.nombre.Contains("_"))
                .Include(x => x.PresentacionProducto).Include(x => x.FormulaProducto)
                .OrderBy(x => x.PresentacionProducto.cantidad).AsQueryable();

            List<ProductoPresentacion> resulst = await queryble.ToListAsync();
            return resulst;
        }

        public List<DetalleFormula> GetdetalleFormula(int FormulaId)
        {
            var queryble = _context.detalleFormula.Include(x => x.ProductoPresentacion).ThenInclude(y => y.PresentacionProducto)
                                                    .Include(x => x.ProductoPresentacion).ThenInclude(y => y.Producto).AsQueryable();
            if (FormulaId != 0)
            {
                queryble = queryble.Where(x => x.FormulaProductoId == FormulaId).AsQueryable();

            }
            List<DetalleFormula> detalles =  queryble.ToList();
            return detalles;
        }

        [HttpGet("ProductosFormula")]
        public async Task<ActionResult<List<ProductoPresentacion>>> Get([FromQuery] Paginacion paginacion, int cantidadDeRegistros, string filtro)
        {
            var queryable = _context.productoPresentacion.Include(x=>x.Producto).Include(x=>x.PresentacionProducto).Where(x=>x.esFormulado == false).AsQueryable();
            if (cantidadDeRegistros != 0)
            {
                paginacion.CantidadRegistros = cantidadDeRegistros;
            }
            if (!string.IsNullOrWhiteSpace(filtro))
            {
                queryable = queryable.Where(x => x.Producto.nombre.Contains(filtro)).AsQueryable();
            }
            await HttpContext.InsertarParametrosPaginacionEnRespuesta(queryable, paginacion.CantidadRegistros);
            return await queryable.Paginar(paginacion).ToListAsync();
        }

        // GET: api/ProductoPresentacion/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductoPresentacion>> GetProductoPresentacion(int id)
        {
            var productoPresentacion = await _context.productoPresentaciones.Include(x => x.PresentacionProducto).Include(x => x.Proveedor)
                .Include(x => x.FormulaProducto).ThenInclude(x => x.DetallesFormula).Include(x => x.Producto).FirstOrDefaultAsync(x=>x.Id == id);

            if (productoPresentacion == null)
            {
                return NotFound();
            }

            return productoPresentacion;
        }

        // PUT: api/ProductoPresentacion/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProductoPresentacion(int id, ProductoPresentacion productoPresentacion)
        {
            if (id != productoPresentacion.Id)
            {
                return BadRequest();
            }

            _context.Entry(productoPresentacion).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductoPresentacionExists(id))
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

        // POST: api/ProductoPresentacion
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<ProductoPresentacion>> PostProductoPresentacion(ProductoPresentacion productoPresentacion)
        {

            _context.productoPresentaciones.Add(productoPresentacion);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProductoPresentacion", new { id = productoPresentacion.Id }, productoPresentacion);
        }

        [HttpPost("ModificarCostos")]
        public async Task<ActionResult<List<ProductoPresentacion>>> ModificarCostos(List<ProductoPresentacion> productosPresentacion)
        {
            productosPresentacion.ForEach(x => _context.Entry(x).State = EntityState.Modified);
            await _context.SaveChangesAsync();

            return productosPresentacion;
        }
        // DELETE: api/ProductoPresentacion/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ProductoPresentacion>> DeleteProductoPresentacion(int id)
        {
            var productoPresentacion = await _context.productoPresentaciones.Include(x => x.FormulaProducto).FirstOrDefaultAsync(x=> x.Id ==id);
            if (productoPresentacion == null)
            {
                return NotFound();
            }
            List<DetalleFormula> detalles = await _context.detalleFormula.Include(x => x.FormulaProducto).ThenInclude(x => x.ProductoPresentacion).Where(x => x.ProductoPresentacionId == id && x.FormulaProducto.ProductoPresentacion.enabled == true).ToListAsync();
            if ( detalles.Count() > 0) {

                return NotFound("No se puede borrar este producto ya que una o varias formulas lo utilizan");
                //throw new ArgumentException("No se puede borrar este producto ya que una o varias formulas lo utilizan");

            }

            _context.productoPresentaciones.Remove(productoPresentacion);
         
            await _context.SaveChangesAsync();

            return productoPresentacion;
        }

        private bool ProductoPresentacionExists(int id)
        {
            return _context.productoPresentaciones.Any(e => e.Id == id);
        }
    }
}
