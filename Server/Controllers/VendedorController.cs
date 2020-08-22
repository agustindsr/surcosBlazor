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
    public class VendedorController : ControllerBase
    {
        private readonly WebApiDbContext _context;
        private readonly IAlmacenadorDeArchivos almacenadorDeArchivos;
        public VendedorController(WebApiDbContext context, IAlmacenadorDeArchivos _almacenadorDeArchivos)
        {
            _context = context;
            almacenadorDeArchivos = _almacenadorDeArchivos;
        }

        // GET: api/Vendedor
        [HttpGet]
        public async Task<ActionResult<List<Vendedor>>> Get([FromQuery] Paginacion paginacion, int cantidadDeRegistros, string filtro)
        {
            try
            {
                var queryable = _context.vendedor.AsQueryable();
                if (cantidadDeRegistros != 0)
                {
                    paginacion.CantidadRegistros = cantidadDeRegistros;
                }
                if (!string.IsNullOrWhiteSpace(filtro))
                {
                    queryable = queryable.Where(x => x.nombre.Contains(filtro)).AsQueryable();
                }

                await HttpContext.InsertarParametrosPaginacionEnRespuesta(queryable, paginacion.CantidadRegistros);
                List<Vendedor> vendedores = await queryable.Paginar(paginacion).ToListAsync();
                return vendedores;
            }
            catch (Exception ex)
            {

                throw;
            }

        }

        // GET: api/Vendedor/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Vendedor>> GetVendedor(int id)
        {
            var vendedor = await _context.vendedor.FindAsync(id);

            if (vendedor == null)
            {
                return NotFound();
            }

            return vendedor;
        }

        [HttpGet("VendedorEcommerce")]
        public async Task<ActionResult<List<Vendedor>>> GetVendedoresDepartamento(int departamendoId)
        {
            var vendedoresId = _context.vendedorDepartamento.Where(x => x.DepartamentoId == departamendoId).Select(x => x.VendedorId).ToList();
            var vendedores = await _context.vendedor.Where(x => vendedoresId.Contains(x.Id) && x.eCommerce).Include(x => x.VendedorDepartamento)
                .OrderByDescending(x => x.clasificacion).ThenBy(x => x.nombre).ToListAsync();

            if (vendedores == null)
            {
                return NotFound();
            }

            return vendedores;
        }
        [HttpGet("vendedoresHabilitados")]
        public async Task<ActionResult<List<Vendedor>>> GetVendedoresHabilitados(string userName)
        {
            try
            {
                var userVendedoresId = _context.userVendedor.Where(x => x.userName == userName).Select(x => x.VendedorId);
                var vendedores = await _context.vendedor.Where(x => userVendedoresId.Contains(x.Id)).ToListAsync();


                //if (!string.IsNullOrWhiteSpace(filtro))
                //{
                //    queryable = queryable.Where(x => x..Contains(filtro)).AsQueryable();
                //}

                return vendedores;

            }
            catch (Exception ex)
            {

                throw;

            }
        }

        // PUT: api/Vendedor/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutVendedor(int id, Vendedor vendedor)
        {
            if (id != vendedor.Id)
            {
                return BadRequest();
            }


            string rutaActualImagen = _context.vendedor.Where(x => x.Id == id).Select(x => x.Foto).ToList()[0];
            if (rutaActualImagen != vendedor.Foto)
            {
                var fotoImagen = Convert.FromBase64String(vendedor.Foto);
                vendedor.Foto = await almacenadorDeArchivos.EditarArchivo(fotoImagen,
                    "jpg", "vendedores", rutaActualImagen);
            }


            _context.Entry(vendedor).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VendedorExists(id))
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

        // POST: api/Vendedor
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Vendedor>> PostVendedor(Vendedor vendedor)
        {
            if (!string.IsNullOrWhiteSpace(vendedor.Foto))
            {
                var fotoPersona = Convert.FromBase64String(vendedor.Foto);
                vendedor.Foto = await almacenadorDeArchivos.GuardarArchivo(fotoPersona, "jpg", "vendedores");
            }
            _context.vendedor.Add(vendedor);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetVendedor", new { id = vendedor.Id }, vendedor);
        }

        // DELETE: api/Vendedor/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Vendedor>> DeleteVendedor(int id)
        {
            var vendedor = await _context.vendedor.FindAsync(id);
            if (vendedor == null)
            {
                return NotFound();
            }

            _context.vendedor.Remove(vendedor);
            await _context.SaveChangesAsync();

            return vendedor;
        }

        private bool VendedorExists(int id)
        {
            return _context.vendedor.Any(e => e.Id == id);
        }
    }
}
