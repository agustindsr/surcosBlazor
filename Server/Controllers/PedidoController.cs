using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using BlazorPeliculas.Server.Helpers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.Internal;
using SurcosBlazor.Server.Context;
using SurcosBlazor.Server.Helpers;
using SurcosBlazor.Shared;
using SurcosBlazor.Shared.Entidades;
using SurcosBlazor.Shared.Entidades.Informes.InformesVentas;
using SurcosBlazor.Shared.Informes.InformesVentas;

namespace SurcosBlazor.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PedidoController : ControllerBase
    {
        private readonly WebApiDbContext _context;
        public PedidoController(WebApiDbContext context)
        {
            _context = context;
        }

        // GET: api/Pedido
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
        [HttpGet]
        public async Task<ActionResult<List<Pedido>>> Get([FromQuery] Paginacion paginacion,
                                                            int cantidadDeRegistros,
                                                            string filtro,
                                                            string userName,
                                                            int vendedorId,
                                                            int provinciaId,
                                                            int estadoPedidoId,
                                                            int tipoListaPrecioId)
        {
            try
            {
                var userVendedoresId = _context.userVendedor.Where(x => x.userName == userName).Select(x => x.VendedorId);
                var queryable = _context.pedido.Where(x => userVendedoresId.Contains(x.VendedorId))
                                                .Include(x => x.Domicilio.Provincia)
                                                .Include(x => x.Domicilio.Departamento)
                                                .Include(x => x.Cliente)
                                                    .ThenInclude(x => x.Categoria)
                                                .Include(x => x.EstadoPedido)
                                                .Include(x => x.ListaPrecios)
                                                    .ThenInclude(x => x.TipoListaPrecio)
                                                .Include(x => x.Vendedor).OrderByDescending(x => x.fecha).AsQueryable();
                if (vendedorId != 0)
                {
                    queryable = queryable.Where(x => x.VendedorId == vendedorId).AsQueryable();
                }
                if (provinciaId != 0)
                {
                    queryable = queryable.Where(x => x.Domicilio.ProvinciaId == provinciaId).AsQueryable();
                }
                if (estadoPedidoId != 0)
                {
                    queryable = queryable.Where(x => x.EstadoPedidoId == estadoPedidoId).AsQueryable();
                }
                if (tipoListaPrecioId != 0)
                {
                    queryable = queryable.Where(x => x.ListaPrecios.TipoListaPrecioId == tipoListaPrecioId).AsQueryable();
                }
                if (cantidadDeRegistros != 0)
                {
                    paginacion.CantidadRegistros = cantidadDeRegistros;
                }
                //if (!string.IsNullOrWhiteSpace(filtro))
                //{
                //    queryable = queryable.Where(x => x..Contains(filtro)).AsQueryable();
                //}
                await HttpContext.InsertarParametrosPaginacionEnRespuesta(queryable, paginacion.CantidadRegistros);
                var listadoPedido = await queryable.Paginar(paginacion).ToListAsync();
                return listadoPedido;

            }
            catch (Exception ex)
            {

                throw;

            }

        }

        [HttpGet("PedidosPendienteDeEntrega")]
        public async Task<ActionResult<List<Pedido>>> PedidosPendienteDeEntrega([FromQuery] Paginacion paginacion,
                                                          int cantidadDeRegistros,
                                                          int vendedorId, int diaEntrega, int mesEntrega, int añoEntrega)
        {
            try
            {
                DateTime fechaEntrega = new DateTime(añoEntrega, mesEntrega, diaEntrega);

                var queryable = _context.pedido.Where(x => x.VendedorId == vendedorId && x.EstadoPedidoId == 2 && x.fechaEntrega.Date == fechaEntrega.Date)
                                                .Include(x => x.Domicilio.Provincia)
                                                .Include(x => x.Domicilio.Departamento)
                                               .OrderByDescending(x => x.Domicilio.Provincia.nombre).ThenBy(x => x.Domicilio.Departamento.nombre).AsQueryable();

                if (cantidadDeRegistros != 0)
                {
                    paginacion.CantidadRegistros = cantidadDeRegistros;
                }


                await HttpContext.InsertarParametrosPaginacionEnRespuesta(queryable, paginacion.CantidadRegistros);
                var listadoPedido = await queryable.Paginar(paginacion).ToListAsync();
                return listadoPedido;

            }
            catch (Exception ex)
            {

                throw;

            }

        }

        [HttpGet("PedidosPendienteDeProducir")]
        public async Task<ActionResult<List<Pedido>>> PedidosPendienteDeProducir([FromQuery] Paginacion paginacion,
                                                        int cantidadDeRegistros,
                                                        int vendedorId, int diaEntrega, int mesEntrega, int añoEntrega)
        {
            try
            {
                DateTime fechaEntrega = new DateTime(añoEntrega, mesEntrega, diaEntrega);

                var queryable = _context.pedido.Where(x => x.VendedorId == vendedorId && (x.EstadoPedidoId == 2 || x.EstadoPedidoId == 1)&& x.fechaEntrega.Date == fechaEntrega.Date)
                                                .Include(x => x.EstadoPedido)
                                               .OrderBy(x => x.fecha).AsQueryable();

                if (cantidadDeRegistros != 0)
                {
                    paginacion.CantidadRegistros = cantidadDeRegistros;
                }


                await HttpContext.InsertarParametrosPaginacionEnRespuesta(queryable, paginacion.CantidadRegistros);
                var listadoPedido = await queryable.Paginar(paginacion).ToListAsync();
                return listadoPedido;

            }
            catch (Exception ex)
            {

                throw;

            }

        }
        [HttpGet("pedidosCliente")]
        public async Task<ActionResult<List<Pedido>>> GetPedidoCliente([FromQuery] Paginacion paginacion,
                                                            int cantidadDeRegistros,
                                                            int clienteId,
                                                            int vendedorId,
                                                            int estadoPedidoId,
                                                            int tipoListaPrecioId)
        {
            try
            {
               
                var queryable = _context.pedido.Where(x => x.ClienteId == clienteId)
                                                .Include(x => x.Domicilio.Provincia)
                                                .Include(x => x.Domicilio.Departamento)
                                                .Include(x => x.Cliente)
                                                    .ThenInclude(x => x.Categoria)
                                                .Include(x => x.EstadoPedido)
                                                .Include(x => x.ListaPrecios)
                                                    .ThenInclude(x => x.TipoListaPrecio)
                                                .Include(x => x.Vendedor).OrderByDescending(x => x.fecha).AsQueryable();
                if (vendedorId != 0)
                {
                    queryable = queryable.Where(x => x.VendedorId == vendedorId).AsQueryable();
                }
               
                if (estadoPedidoId != 0)
                {
                    queryable = queryable.Where(x => x.EstadoPedidoId == estadoPedidoId).AsQueryable();
                }
                if (tipoListaPrecioId != 0)
                {
                    queryable = queryable.Where(x => x.ListaPrecios.TipoListaPrecioId == tipoListaPrecioId).AsQueryable();
                }
                if (cantidadDeRegistros != 0)
                {
                    paginacion.CantidadRegistros = cantidadDeRegistros;
                }
                //if (!string.IsNullOrWhiteSpace(filtro))
                //{
                //    queryable = queryable.Where(x => x..Contains(filtro)).AsQueryable();
                //}
                await HttpContext.InsertarParametrosPaginacionEnRespuesta(queryable, paginacion.CantidadRegistros);
                var listadoPedido = await queryable.Paginar(paginacion).ToListAsync();
                return listadoPedido;

            }
            catch (Exception ex)
            {

                throw;

            }

        }
        [HttpGet("CambiarEstadoPedido")]
        public async Task CambiarEstadoPedido(int pedidoId, int estadoId) {

            Pedido pedido = await _context.pedido.FindAsync(pedidoId);
            pedido.EstadoPedidoId = estadoId;
            await _context.SaveChangesAsync();
        }
        [HttpGet("InformeGeneralVentasVenta")]
        public async Task<InformeGeneralVentas> InformeGeneralVentasVenta([FromQuery] Paginacion paginacion,
                                                            string userName,
                                                            DateTime fechaDesde,
                                                            DateTime fechaHasta, int provinciaId, int vendedorId
                                                           )
        {
            try
            {
                fechaDesde = new DateTime(fechaDesde.Year, fechaDesde.Month,fechaDesde.Day, 0,0,0, fechaDesde.Kind);
                fechaHasta = new DateTime(fechaHasta.Year, fechaHasta.Month, fechaHasta.Day, 23, 59, 59, fechaHasta.Kind);

                InformeGeneralVentas informeVentas = new InformeGeneralVentas();

                //INFORMES PEDIDOS POR VENDEDOR
                List<InformePedidosVendedores> pedidoPorVendedor = new List<InformePedidosVendedores>();

                 var queryablePedidos =  _context.pedido.Where(x => x.fecha >= fechaDesde && x.fecha <= fechaHasta)
                                                .Include(x => x.Vendedor).AsQueryable();
                if (vendedorId != 0) {
                    queryablePedidos = queryablePedidos.Where(x => x.VendedorId == vendedorId).AsQueryable();
                }
                if (provinciaId != 0) {
                    queryablePedidos = queryablePedidos.Where(x => x.Domicilio.ProvinciaId == provinciaId).AsQueryable();
                }

                 var pedidos = await queryablePedidos.ToListAsync();
                var datosInforme = pedidos.Select(x => new InformePedidosVendedores { total = x.total, vendedor = x.Vendedor.nombre }).ToList();

                informeVentas.cantidadPEDPEN = pedidos.Count(x => x.EstadoPedidoId == 1);
                informeVentas.cantidadPEDCON = pedidos.Count(x => x.EstadoPedidoId == 2);
                informeVentas.cantidadPEDANU = pedidos.Count(x => x.EstadoPedidoId == 3);
                informeVentas.cantidadPEDENT = pedidos.Count(x => x.EstadoPedidoId == 4);

                var vendedores =  datosInforme.Select(x => x.vendedor).Distinct().ToList();

                vendedores.ForEach(x =>
                {
                    informeVentas.InformePedidosVendedores.Add(new InformePedidosVendedores
                    {
                        vendedor = x,
                        total = datosInforme.Where(y => y.vendedor == x).Sum(y => y.total)
                    });

                });


                //INFORME VENTAS POR LOCALIDAD
                var queryableComprobantes =  _context.factura.
                                                    Include(x => x.Domicilio.Provincia)
                                                    .Include(x => x.Domicilio.Departamento).Include(x => x.ListaPrecios).ThenInclude(x => x.TipoListaPrecio)
                                                    .Where(x => x.fecha >= fechaDesde
                                                                    && x.fecha <= fechaHasta)
                                                                   .AsQueryable();

                if (vendedorId != 0)
                {
                    queryableComprobantes = queryableComprobantes.Where(x => x.VendedorId == vendedorId).AsQueryable();
                }
                if (provinciaId != 0)
                {
                    queryableComprobantes = queryableComprobantes.Where(x => x.Domicilio.ProvinciaId == provinciaId).AsQueryable();
                }

                var ComprobantesVentas = await queryableComprobantes.ToListAsync();
                informeVentas.cantidadFAC = ComprobantesVentas.Count(x => x.TipoComprobanteId == 1);
                informeVentas.cantidadND = ComprobantesVentas.Count(x => x.TipoComprobanteId == 2);
                informeVentas.cantidadNC = ComprobantesVentas.Count(x => x.TipoComprobanteId == 3);

                informeVentas.totalFAC = ComprobantesVentas.Where(x => x.TipoComprobanteId == 1).Sum(x => x.totalComprobante);
                informeVentas.totalND = ComprobantesVentas.Where(x => x.TipoComprobanteId == 2).Sum(x => x.totalComprobante);
                informeVentas.totalNC = ComprobantesVentas.Where(x => x.TipoComprobanteId == 3).Sum(x => x.totalComprobante);

                foreach (Factura comprobante in ComprobantesVentas) {
                    if (informeVentas.InformeVentasPorLocalidad.Where(x => x.localidad == comprobante.Domicilio.Departamento.nombre).Count() == 0)
                    {
                        if (comprobante.TipoComprobanteId == 1 || comprobante.TipoComprobanteId == 2)
                        {
                            informeVentas.InformeVentasPorLocalidad.Add(new InformeVentasPorLocalidad { provincia = comprobante.Domicilio.Provincia.nombre, localidad = comprobante.Domicilio.Departamento.nombre, total = comprobante.totalComprobante });
                        }
                        else
                        {
                            informeVentas.InformeVentasPorLocalidad.Add(new InformeVentasPorLocalidad { provincia = comprobante.Domicilio.Provincia.nombre, localidad = comprobante.Domicilio.Departamento.nombre, total = -1 * comprobante.totalComprobante });

                        }

                    }
                    else {
                        informeVentas.InformeVentasPorLocalidad.FirstOrDefault(x => x.localidad == comprobante.Domicilio.Departamento.nombre);
                        if (comprobante.TipoComprobanteId == 1 || comprobante.TipoComprobanteId == 2)
                        {
                            informeVentas.InformeVentasPorLocalidad.FirstOrDefault(x => x.localidad == comprobante.Domicilio.Departamento.nombre).total += comprobante.totalComprobante;
                        }
                        else
                        {
                            informeVentas.InformeVentasPorLocalidad.FirstOrDefault(x => x.localidad == comprobante.Domicilio.Departamento.nombre).total -= comprobante.totalComprobante;

                        }

                    }

                  
                }


                //VENTAS POR DIA
                TimeSpan restaFechas = fechaHasta - fechaDesde;
                int dias = restaFechas.Days + 1;
                List<string> listasPrecios = await _context.listaPrecios.Include(x => x.TipoListaPrecio).Select(x => x.TipoListaPrecio.nombre).ToListAsync();

                for (int j = 0; j < listasPrecios.Count; j++)
                {
                    
                    informeVentas.informeTotalVentasPorListaPrecios.Add(new InformeTotalVentasPorListaPrecios
                    {
                        total = ComprobantesVentas.Where(x => x.ListaPrecios.TipoListaPrecio.nombre == listasPrecios[j]).Sum(x => x.totalComprobante),
                        lista = listasPrecios[j]
                    });


                    informeVentas.informeTotalGanancias.Add(new InformeTotalGananciasPorLista
                    {
                        total = ComprobantesVentas.Where(x => x.ListaPrecios.TipoListaPrecio.nombre == listasPrecios[j]).Sum(x => x.totalComprobante - x.costoTotal),
                        lista = listasPrecios[j]
                    });
                }
               
               

                for (int i = 0; i < dias; i++) {
                    DateTime fechaDesde1 = new DateTime(fechaDesde.Year, fechaDesde.Month, fechaDesde.Day, 0, 0, 0, fechaDesde.Kind).AddDays(i);
                    DateTime fechaHasta1 = fechaDesde1.AddDays(1);

                    InformeGananciasPorListaPrecios gananciasPorListaPrecios = new InformeGananciasPorListaPrecios { fecha = fechaDesde1.Date };
                    InformeVentasPorListaPrecios ventasPorListaPrecios = new InformeVentasPorListaPrecios { fecha = fechaDesde1.Date };


                    for (int j = 0; j < listasPrecios.Count; j++) 
                    {
                        decimal total = 0.00M;
                        decimal totalVentas = 0.00M;
                        List<Factura> comprobantes = ComprobantesVentas.Where(x => x.fecha >= fechaDesde1 && x.fecha < fechaHasta1 && x.ListaPrecios.TipoListaPrecio.nombre == listasPrecios[j]).ToList();

                        foreach (Factura comprobante in comprobantes)
                        {
                            if (comprobante.TipoComprobanteId == 3)
                            {
                                total -= comprobante.totalComprobante - comprobante.costoTotal;
                            }
                            else {
                                total += comprobante.totalComprobante - comprobante.costoTotal;

                            }

                        }

                        foreach (Factura comprobante in comprobantes)
                        {
                            if (comprobante.TipoComprobanteId == 3)
                            {
                                totalVentas -= comprobante.totalComprobante;
                            }
                            else
                            {
                                totalVentas += comprobante.totalComprobante;

                            }

                        }
                        gananciasPorListaPrecios.valores.Add(new valores { nombreLista = listasPrecios[j], importe = total });
                        ventasPorListaPrecios.valores.Add(new valores2 { nombreLista = listasPrecios[j], importe = totalVentas });

                    }
                    informeVentas.informeGananciasPorListaPrecios.Add(gananciasPorListaPrecios);
                    informeVentas.informeVentasPorListaPrecios.Add(ventasPorListaPrecios);

                };
                return informeVentas;

            }
            catch (Exception ex)
            {

                throw;

            }
        }
        // GET: api/Pedido/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Pedido>> GetPedido(int id)
        {
            var pedido = await _context.pedido.Include(x => x.Domicilio.Provincia)
                                                .Include(x => x.Domicilio.Departamento)
                                                .Include(x => x.Domicilio)
                                                .Include(x => x.Cliente)
                                                    .ThenInclude(x => x.Categoria)
                                                    .Include(x => x.Cliente)
                                                    .ThenInclude(x => x.Domicilio).IgnoreQueryFilters()
                                                .Include(x => x.EstadoPedido)
                                                .Include(x => x.ListaPrecios)
                                                    .ThenInclude(x => x.TipoListaPrecio)
                                                .Include(x => x.Vendedor).Include(x => x.detallePedido).FirstOrDefaultAsync(x => x.Id == id);
            for (int i = 0; i < pedido.detallePedido.Count; i++)
            {
                pedido.detallePedido[i] = _context.detallePedido.Include(x => x.ProductoPresentacion)
                    .ThenInclude(x => x.Producto).IgnoreQueryFilters()
                    .Include(x => x.ProductoPresentacion)
                    .ThenInclude(x => x.PresentacionProducto).FirstOrDefault(x => x.Id == pedido.detallePedido[i].Id);
            }

            if (pedido == null)
            {
                return NotFound();
            }

            return pedido;
        }

        [HttpGet("GetDetallePedido")]
        public async Task<ActionResult<List<DetallePedido>>> GetDetallePedido(int pedidoId)
        {
            var detalles = await  _context.detallePedido.Where(x => x.PedidoId == pedidoId).Include(x => x.ProductoPresentacion)
                    .ThenInclude(x => x.Producto).IgnoreQueryFilters()
                    .Include(x => x.ProductoPresentacion)
                    .ThenInclude(x => x.PresentacionProducto).ToListAsync();
                              

            return detalles;
        }
        // PUT: api/Pedido/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPedido(int id, Pedido pedido)
        {
            if (id != pedido.Id)
            {
                return BadRequest();
            }
            if (CheckListarDePrecios(pedido.ClienteId, pedido.Domicilio.ProvinciaId, pedido.ListaPreciosId).Result)
            {

            }
            else
            {

                return BadRequest("La lista de precios que usted esta usando no está habilitada para este cliente o caducado");

            }

            pedido.Cliente = null;
            pedido.EstadoPedido = null;
            pedido.Vendedor = null;
            pedido.detallePedido.ForEach(x => x.ProductoPresentacion = null);
            pedido.Domicilio.Departamento = null;
            pedido.Domicilio.Provincia = null;
            pedido.ListaPrecios = null;


          
            foreach (DetallePedido detallePedido in pedido.detallePedido)
            {
                if (detallePedido.Id != 0)
                {
                    _context.Entry(detallePedido).State = EntityState.Modified;
                }
                else
                {
                    _context.Entry(detallePedido).State = EntityState.Added;

                }
            }

            var detalleIds = pedido.detallePedido.Select(x => x.Id).ToList();
            var detallesABorrar = _context.detallePedido.Where(x => !detalleIds.Contains(x.Id) && x.PedidoId == pedido.Id).ToList();
            _context.detallePedido.RemoveRange(detallesABorrar);


            _context.Entry(pedido.Domicilio).State = EntityState.Modified;
            _context.Entry(pedido).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                if (!PedidoExists(id))
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



        // POST: api/Pedido
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Pedido>> PostPedido(Pedido pedido)
        {
            // Chequeamos que la lista de precios que este usando sea valida;
            if (CheckListarDePrecios(pedido.ClienteId, pedido.Domicilio.ProvinciaId, pedido.ListaPreciosId).Result)
            {

            }
            else
            {

                return BadRequest("La lista de precios que usted esta usando no está habilitada para este cliente o caducado");

            }
            //Chequeamos si los precios coinciden con los de la lista
            foreach (DetallePedido detallePedido in pedido.detallePedido)
            {
                DetalleListaPrecios detalleLista = _context.detalleListaPrecios
                                             .Single(x => x.ListaPreciosId == pedido.ListaPreciosId && x.ProductoPresentacionId == detallePedido.ProductoPresentacionId);
                detallePedido.costo = detalleLista.precioCosto;
                if (!pedido.hechoPorAdmin) { 
                
                if (detallePedido.precioUnitario == detalleLista.precioUnitarioFinal)
                {

                }
                else
                {
                    return BadRequest($"El precio del {detallePedido.ProductoPresentacion.Producto.nombre}, {detallePedido.ProductoPresentacion.PresentacionProducto.nombre} está desactualizado por favor eliminalo de tu carrito y vuelva a agregarlo");

                }
                }
            }
            pedido.costoTotal = pedido.detallePedido.Sum(x => x.costo);
            try
            {
                string vendedorEmail = pedido.Vendedor.email;
                string Detallepedido = "";
                string direccionDeEntrga = $"<h4>Será entregado el día {pedido.fechaEntrega.ToString("dd/MM")} por {pedido.Vendedor.nombre} en el domicilio {pedido.Domicilio.calle} {pedido.Domicilio.numero} de {pedido.Domicilio.Departamento.nombre}, {pedido.Domicilio.Provincia.nombre}</h4>";
                pedido.detallePedido.ForEach(x => { Detallepedido += $"<div style='margin:0px 5px'>   " +
                                                                        $"<strong style='margin:0px 5px'>{ x.cantidad}</strong>  <img src='{ x.ProductoPresentacion.Producto.Foto}' style='height:25px;width:25px;margin:0px 5px'>{ x.ProductoPresentacion.Producto.nombre}, { x.ProductoPresentacion.PresentacionProducto.nombre}  ${x.precioUnitario}" +
                                                                        $"</div>"; });
                Detallepedido += $"<h2>Total ${pedido.total}</h2>";
                pedido.Cliente = null;
                pedido.Vendedor = null;
                pedido.detallePedido.ForEach(x => x.ProductoPresentacion = null);
                pedido.Domicilio.Departamento = null;
                pedido.Domicilio.Provincia = null;
                pedido.EstadoPedidoId = 1;
                pedido.ListaPrecios = null;
                _context.pedido.Add(pedido);
                await _context.SaveChangesAsync();

                
                SendEmail.Send($"<h2>Gracias por realizar tu pedido</h2>{direccionDeEntrga}{Detallepedido}","Surcos Pedidos",pedido.emailCliente);
                SendEmail.Send($"<h2>Te han realizado un nuevo pedido </h2>{direccionDeEntrga}{Detallepedido}", "Surcos Pedidos", vendedorEmail);

                return CreatedAtAction("GetPedido", new { id = pedido.Id }, pedido);
            }
            catch (Exception ex)
            {
                return BadRequest("Ocurrió un error y no se pudo crear el pedido");

            }

        }
        [HttpGet("CheckListarDePrecios")]
        public async Task<bool> CheckListarDePrecios(int? clienteId = 0, int? provinciaId = 0, int listaId = 0)
        {
            int categoriaId = 0;

            try
            {
                if (clienteId != 0 && clienteId != null)
                {

                    categoriaId = Convert.ToInt32(_context.cliente.IgnoreQueryFilters().FirstOrDefault(x => x.Id == clienteId).CategoriaClienteId);
                }
                List<int> TipoListaPrecioId = await _context.TipoListaPrecioCategoriaCliente.Where(x => x.CategoriaClienteId == categoriaId).Select(x => x.TipoListaPrecioId).ToListAsync();
                TipoListaPrecioId.AddRange(await _context.TipoListaPrecioProvincia.Where(x => x.ProvinciaId == provinciaId).Select(x => x.TipoListaPrecioId).ToListAsync());

                TipoListaPrecioId = TipoListaPrecioId.Distinct().ToList();

                List<int> listasPreciosIds = await _context.listaPrecios
                                                                .Where(x => TipoListaPrecioId.Contains((int)(x.TipoListaPrecioId)) && x.vigente == true)
                                                                .Select(x => x.Id)
                                                                .ToListAsync();

                return listasPreciosIds.Contains(listaId);
            }
            catch (Exception ex) { throw; }
        }
        // DELETE: api/Pedido/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Pedido>> DeletePedido(int id)
        {
            var pedido = await _context.pedido.FindAsync(id);
            if (pedido == null)
            {
                return NotFound();
            }

            _context.pedido.Remove(pedido);
            await _context.SaveChangesAsync();

            return pedido;
        }

        private bool PedidoExists(int id)
        {
            return _context.pedido.Any(e => e.Id == id);
        }
    }
}
