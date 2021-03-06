#pragma checksum "C:\Users\agust\source\repos\SurcosBlazor\Client\Pages\BackOffice\Configuracion\ListaDePreciosC\ListaDePreciosDetalle.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "96272ed3cc094d489262288230efbb1d53de6e64"
// <auto-generated/>
#pragma warning disable 1591
namespace SurcosBlazor.Client.Pages.BackOffice.Configuracion.ListaDePreciosC
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Components;
#line 1 "C:\Users\agust\source\repos\SurcosBlazor\Client\_Imports.razor"
using System.Net.Http;

#line default
#line hidden
#line 2 "C:\Users\agust\source\repos\SurcosBlazor\Client\_Imports.razor"
using Microsoft.AspNetCore.Components.Forms;

#line default
#line hidden
#line 3 "C:\Users\agust\source\repos\SurcosBlazor\Client\_Imports.razor"
using Microsoft.AspNetCore.Components.Routing;

#line default
#line hidden
#line 4 "C:\Users\agust\source\repos\SurcosBlazor\Client\_Imports.razor"
using Microsoft.AspNetCore.Components.Web;

#line default
#line hidden
#line 5 "C:\Users\agust\source\repos\SurcosBlazor\Client\_Imports.razor"
using Microsoft.JSInterop;

#line default
#line hidden
#line 6 "C:\Users\agust\source\repos\SurcosBlazor\Client\_Imports.razor"
using SurcosBlazor.Client;

#line default
#line hidden
#line 7 "C:\Users\agust\source\repos\SurcosBlazor\Client\_Imports.razor"
using SurcosBlazor.Client.Shared;

#line default
#line hidden
#line 9 "C:\Users\agust\source\repos\SurcosBlazor\Client\_Imports.razor"
using Microsoft.AspNetCore.Components.Authorization;

#line default
#line hidden
#line 10 "C:\Users\agust\source\repos\SurcosBlazor\Client\_Imports.razor"
using SurcosBlazor.Client.Helpers;

#line default
#line hidden
#line 11 "C:\Users\agust\source\repos\SurcosBlazor\Client\_Imports.razor"
using SurcosBlazor.Shared.Entidades;

#line default
#line hidden
#line 12 "C:\Users\agust\source\repos\SurcosBlazor\Client\_Imports.razor"
using SurcosBlazor.Shared;

#line default
#line hidden
#line 13 "C:\Users\agust\source\repos\SurcosBlazor\Client\_Imports.razor"
using SurcosBlazor.Client.Repositorio;

#line default
#line hidden
#line 14 "C:\Users\agust\source\repos\SurcosBlazor\Client\_Imports.razor"
using Microsoft.AspNetCore.Authorization;

#line default
#line hidden
#line 15 "C:\Users\agust\source\repos\SurcosBlazor\Client\_Imports.razor"
using Blazored.Toast;

#line default
#line hidden
#line 16 "C:\Users\agust\source\repos\SurcosBlazor\Client\_Imports.razor"
using Blazored.Toast.Services;

#line default
#line hidden
#line 5 "C:\Users\agust\source\repos\SurcosBlazor\Client\Pages\BackOffice\Configuracion\ListaDePreciosC\ListaDePreciosDetalle.razor"
           [Authorize(Roles = "Admin, Configuracion")]

#line default
#line hidden
    [Microsoft.AspNetCore.Components.LayoutAttribute(typeof(BackOfficeLayout))]
    [Microsoft.AspNetCore.Components.RouteAttribute("/BackOffice/Configuraciones/DetalleListaPrecios/{ListaPreciosId:int}")]
    public partial class ListaDePreciosDetalle : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
            __builder.OpenElement(0, "nav");
            __builder.AddAttribute(1, "aria-label", "breadcrumb");
            __builder.AddMarkupContent(2, "\r\n    ");
            __builder.OpenElement(3, "ol");
            __builder.AddAttribute(4, "class", "breadcrumb");
            __builder.AddMarkupContent(5, "\r\n        ");
            __builder.OpenElement(6, "li");
            __builder.AddAttribute(7, "class", "breadcrumb-item");
            __builder.AddAttribute(8, "onclick", Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Web.MouseEventArgs>(this, 
#line 11 "C:\Users\agust\source\repos\SurcosBlazor\Client\Pages\BackOffice\Configuracion\ListaDePreciosC\ListaDePreciosDetalle.razor"
                                                ()=>uri.NavigateTo("/BackOffice/Configuraciones")

#line default
#line hidden
            ));
            __builder.AddContent(9, "Configuraciones");
            __builder.CloseElement();
            __builder.AddMarkupContent(10, "\r\n        ");
            __builder.OpenElement(11, "li");
            __builder.AddAttribute(12, "class", "breadcrumb-item");
            __builder.AddAttribute(13, "onclick", Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Web.MouseEventArgs>(this, 
#line 12 "C:\Users\agust\source\repos\SurcosBlazor\Client\Pages\BackOffice\Configuracion\ListaDePreciosC\ListaDePreciosDetalle.razor"
                                                ()=>uri.NavigateTo("/BackOffice/Configuraciones/ListaListaPrecios")

#line default
#line hidden
            ));
            __builder.AddContent(14, "Listas Precios");
            __builder.CloseElement();
            __builder.AddMarkupContent(15, "\r\n        ");
            __builder.OpenElement(16, "li");
            __builder.AddAttribute(17, "class", "breadcrumb-item active");
            __builder.AddAttribute(18, "aria-current", "page");
            __builder.AddAttribute(19, "onclick", Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Web.MouseEventArgs>(this, 
#line 13 "C:\Users\agust\source\repos\SurcosBlazor\Client\Pages\BackOffice\Configuracion\ListaDePreciosC\ListaDePreciosDetalle.razor"
                                                                           ()=>uri.NavigateTo("/BackOffice/Configuraciones/DetalleListaPrecios")

#line default
#line hidden
            ));
            __builder.AddContent(20, "Detalle Lista Precios");
            __builder.CloseElement();
            __builder.AddMarkupContent(21, "\r\n    ");
            __builder.CloseElement();
            __builder.AddMarkupContent(22, "\r\n");
            __builder.CloseElement();
            __builder.AddMarkupContent(23, "\r\n");
            __builder.OpenElement(24, "div");
            __builder.AddAttribute(25, "class", true);
            __builder.AddMarkupContent(26, "\r\n");
#line 17 "C:\Users\agust\source\repos\SurcosBlazor\Client\Pages\BackOffice\Configuracion\ListaDePreciosC\ListaDePreciosDetalle.razor"
     if (ListaPrecios != null)
    {

#line default
#line hidden
            __builder.AddContent(27, "        ");
            __builder.AddMarkupContent(28, "<div><h2>LISTA DE PRECIOS</h2></div>\r\n");
            __builder.AddContent(29, "        ");
            __builder.OpenElement(30, "div");
            __builder.AddAttribute(31, "class", "col-md-12 row mx-0");
            __builder.AddMarkupContent(32, "\r\n            ");
            __builder.OpenElement(33, "div");
            __builder.AddAttribute(34, "class", "col-md-4 my-2");
            __builder.AddMarkupContent(35, "\r\n\r\n\r\n                ");
            __builder.OpenElement(36, "div");
            __builder.AddAttribute(37, "class", "mt-3");
            __builder.AddMarkupContent(38, "<strong>Tipo de Lista de Precios:</strong> ");
            __builder.AddContent(39, 
#line 25 "C:\Users\agust\source\repos\SurcosBlazor\Client\Pages\BackOffice\Configuracion\ListaDePreciosC\ListaDePreciosDetalle.razor"
                                                                              ListaPrecios.TipoListaPrecio.nombre

#line default
#line hidden
            );
            __builder.CloseElement();
            __builder.AddMarkupContent(40, "\r\n                ");
            __builder.OpenElement(41, "div");
            __builder.AddAttribute(42, "class", "mt-3");
            __builder.AddMarkupContent(43, "<strong>Fecha creación:</strong> ");
            __builder.AddContent(44, 
#line 26 "C:\Users\agust\source\repos\SurcosBlazor\Client\Pages\BackOffice\Configuracion\ListaDePreciosC\ListaDePreciosDetalle.razor"
                                                                    ListaPrecios.fecha.ToString("dddd, dd MMMM yyyy HH:mm:ss")

#line default
#line hidden
            );
            __builder.CloseElement();
            __builder.AddMarkupContent(45, "\r\n                ");
            __builder.OpenElement(46, "div");
            __builder.AddAttribute(47, "class", "mt-3");
            __builder.AddMarkupContent(48, "<strong>Estado:</strong> ");
            __builder.AddContent(49, 
#line 27 "C:\Users\agust\source\repos\SurcosBlazor\Client\Pages\BackOffice\Configuracion\ListaDePreciosC\ListaDePreciosDetalle.razor"
                                                             ListaPrecios.vigente ?"VIGENTE" : "OBSOLETA"

#line default
#line hidden
            );
            __builder.AddContent(50, " ");
            __builder.CloseElement();
            __builder.AddMarkupContent(51, "\r\n\r\n\r\n\r\n\r\n\r\n            ");
            __builder.CloseElement();
            __builder.AddMarkupContent(52, "\r\n\r\n\r\n            ");
            __builder.OpenElement(53, "div");
            __builder.AddAttribute(54, "class", "col-md-4 my-2");
            __builder.AddMarkupContent(55, "\r\n                ");
            __builder.OpenElement(56, "div");
            __builder.AddAttribute(57, "class", "col-md-12 px-0 mt-3");
            __builder.AddMarkupContent(58, "\r\n");
#line 38 "C:\Users\agust\source\repos\SurcosBlazor\Client\Pages\BackOffice\Configuracion\ListaDePreciosC\ListaDePreciosDetalle.razor"
                     if (ListaPrecios.TipoListaPrecio != null)
                    {

#line default
#line hidden
            __builder.AddContent(59, "                        ");
            __builder.AddMarkupContent(60, "<strong>Mínimo de compra:</strong> ");
            __builder.OpenElement(61, "span");
            __builder.AddContent(62, "$ ");
            __builder.AddContent(63, 
#line 40 "C:\Users\agust\source\repos\SurcosBlazor\Client\Pages\BackOffice\Configuracion\ListaDePreciosC\ListaDePreciosDetalle.razor"
                                                                    ListaPrecios.TipoListaPrecio.minimoDeCompra

#line default
#line hidden
            );
            __builder.CloseElement();
            __builder.AddMarkupContent(64, "\r\n");
#line 41 "C:\Users\agust\source\repos\SurcosBlazor\Client\Pages\BackOffice\Configuracion\ListaDePreciosC\ListaDePreciosDetalle.razor"
                    }

#line default
#line hidden
            __builder.AddContent(65, "                ");
            __builder.CloseElement();
            __builder.AddMarkupContent(66, "\r\n                ");
            __builder.OpenElement(67, "div");
            __builder.AddAttribute(68, "class", "col-md-12 px-0 mt-2");
            __builder.AddMarkupContent(69, "\r\n                    ");
            __builder.AddMarkupContent(70, "<strong>Clasificación</strong> ");
            __builder.OpenElement(71, "span");
            __builder.AddContent(72, 
#line 44 "C:\Users\agust\source\repos\SurcosBlazor\Client\Pages\BackOffice\Configuracion\ListaDePreciosC\ListaDePreciosDetalle.razor"
                                                          ListaPrecios.clasificacion

#line default
#line hidden
            );
            __builder.CloseElement();
            __builder.AddMarkupContent(73, "\r\n                ");
            __builder.CloseElement();
            __builder.AddMarkupContent(74, "\r\n                ");
            __builder.OpenElement(75, "div");
            __builder.AddAttribute(76, "class", "col-md-12 px-0 mt-3");
            __builder.AddMarkupContent(77, "\r\n\r\n                    ");
            __builder.AddMarkupContent(78, "<strong>Cantidad de productos:</strong> ");
            __builder.OpenElement(79, "span");
            __builder.AddContent(80, 
#line 48 "C:\Users\agust\source\repos\SurcosBlazor\Client\Pages\BackOffice\Configuracion\ListaDePreciosC\ListaDePreciosDetalle.razor"
                                                                   ListaPrecios.DetalleListaPrecios.Count()

#line default
#line hidden
            );
            __builder.CloseElement();
            __builder.AddMarkupContent(81, "\r\n\r\n                ");
            __builder.CloseElement();
            __builder.AddMarkupContent(82, "\r\n            ");
            __builder.CloseElement();
            __builder.AddMarkupContent(83, "\r\n            ");
            __builder.AddMarkupContent(84, "<div class=\"col-md-4\">\r\n                <img src=\"img/LOGO 2019.png\" style=\"width:200px\">\r\n            </div>\r\n        ");
            __builder.CloseElement();
            __builder.AddMarkupContent(85, "\r\n        ");
            __Blazor.SurcosBlazor.Client.Pages.BackOffice.Configuracion.ListaDePreciosC.ListaDePreciosDetalle.TypeInference.CreateListadoGenerico_0(__builder, 86, 87, 
#line 56 "C:\Users\agust\source\repos\SurcosBlazor\Client\Pages\BackOffice\Configuracion\ListaDePreciosC\ListaDePreciosDetalle.razor"
                                  categorias

#line default
#line hidden
            , 88, (__builder2) => {
                __builder2.AddMarkupContent(89, "\r\n\r\n");
#line 59 "C:\Users\agust\source\repos\SurcosBlazor\Client\Pages\BackOffice\Configuracion\ListaDePreciosC\ListaDePreciosDetalle.razor"
                 foreach (CategoriaProducto categoria in categorias)
                {

#line default
#line hidden
                __builder2.AddContent(90, "                    ");
                __builder2.OpenElement(91, "div");
                __builder2.AddAttribute(92, "class", "my-4");
                __builder2.AddMarkupContent(93, "\r\n                        ");
                __builder2.OpenElement(94, "div");
                __builder2.AddAttribute(95, "class", "mb-2 py-2 px-4 text-white font-weight-bold rounded");
                __builder2.AddAttribute(96, "style", "background:linear-gradient(90deg, #E88525, rgba(230,230,230,.8) 50%)");
                __builder2.AddMarkupContent(97, "\r\n                            ");
                __builder2.OpenElement(98, "h2");
                __builder2.AddAttribute(99, "class", "my-0 py-0 px-4 mx-4");
                __builder2.AddContent(100, 
#line 63 "C:\Users\agust\source\repos\SurcosBlazor\Client\Pages\BackOffice\Configuracion\ListaDePreciosC\ListaDePreciosDetalle.razor"
                                                             categoria.nombre.ToUpper()

#line default
#line hidden
                );
                __builder2.CloseElement();
                __builder2.AddMarkupContent(101, "\r\n                        ");
                __builder2.CloseElement();
                __builder2.AddMarkupContent(102, "\r\n                        ");
                __builder2.OpenElement(103, "div");
                __builder2.AddAttribute(104, "class", "px-0");
                __builder2.AddMarkupContent(105, "\r\n");
#line 66 "C:\Users\agust\source\repos\SurcosBlazor\Client\Pages\BackOffice\Configuracion\ListaDePreciosC\ListaDePreciosDetalle.razor"
                             foreach (Producto producto in productos.Where(x => x.CategoriaProductoId == categoria.Id).ToList())
                            {


#line default
#line hidden
                __builder2.AddContent(106, "                                ");
                __builder2.OpenElement(107, "div");
                __builder2.AddAttribute(108, "class", "col-md-12 row mx-0 px-0 border my-1");
                __builder2.AddMarkupContent(109, "\r\n                                    ");
                __builder2.OpenElement(110, "div");
                __builder2.AddAttribute(111, "class", "col-md-2 mx-0 px-auto bg-white");
                __builder2.AddMarkupContent(112, "\r\n                                        ");
                __builder2.OpenElement(113, "div");
                __builder2.AddAttribute(114, "class", "col-md-12 px-0 mx-0 my-2 text-center");
                __builder2.OpenElement(115, "strong");
                __builder2.AddContent(116, 
#line 71 "C:\Users\agust\source\repos\SurcosBlazor\Client\Pages\BackOffice\Configuracion\ListaDePreciosC\ListaDePreciosDetalle.razor"
                                                                                                   producto.nombre?.ToUpper()

#line default
#line hidden
                );
                __builder2.CloseElement();
                __builder2.CloseElement();
                __builder2.AddMarkupContent(117, "\r\n                                        ");
                __builder2.OpenElement(118, "img");
                __builder2.AddAttribute(119, "src", 
#line 72 "C:\Users\agust\source\repos\SurcosBlazor\Client\Pages\BackOffice\Configuracion\ListaDePreciosC\ListaDePreciosDetalle.razor"
                                                   producto.Foto

#line default
#line hidden
                );
                __builder2.AddAttribute(120, "style", "width:150px; height:150px");
                __builder2.CloseElement();
                __builder2.AddMarkupContent(121, "\r\n                                    ");
                __builder2.CloseElement();
                __builder2.AddMarkupContent(122, "\r\n                                    ");
                __builder2.OpenElement(123, "div");
                __builder2.AddAttribute(124, "class", "col-md-10 px-0 mx-0");
                __builder2.AddMarkupContent(125, "\r\n                                        ");
                __builder2.AddMarkupContent(126, @"<div class=""col-md-12 row mx-0 bg-dark text-white font-weight-bold"">
                                            <div class=""col-md-2 mx-0 px-0 text-center"">Presentacion</div>
                                            <div class=""col-md-2 mx-0 px-0  text-center"">Costo</div>

                                            <div class=""col-md-2 mx-0 px-0  text-center""> MarkUp</div>
                                            <div class=""col-md-2 mx-0 px-0  text-center""> Descuento</div>
                                            <div class=""col-md-2 mx-0 px-0  text-center"">Precio Venta</div>
                                            <div class=""col-md-1 mx-0 px-0  text-center""> Margen</div>


                                        </div>
");
#line 86 "C:\Users\agust\source\repos\SurcosBlazor\Client\Pages\BackOffice\Configuracion\ListaDePreciosC\ListaDePreciosDetalle.razor"
                                         foreach (ProductoPresentacion productoPresentacion in productoPresentaciones.Where(x => x.ProductoId == producto.Id).ToList())
                                        {
                                            DetalleListaPrecios detalle = ListaPrecios.DetalleListaPrecios.FirstOrDefault(x => x.ProductoPresentacionId == productoPresentacion.Id);


#line default
#line hidden
                __builder2.AddContent(127, "                                            ");
                __builder2.OpenElement(128, "div");
                __builder2.AddAttribute(129, "class", "col-md-12 row mx-0 px-0 py-1 border-bottom ");
                __builder2.AddMarkupContent(130, "\r\n                                                ");
                __builder2.OpenElement(131, "div");
                __builder2.AddAttribute(132, "class", "col-md-2 mx-0 px-0 my-auto");
                __builder2.OpenElement(133, "h4");
                __builder2.AddAttribute(134, "class", "text-center m-0");
                __builder2.OpenElement(135, "strong");
                __builder2.AddContent(136, 
#line 91 "C:\Users\agust\source\repos\SurcosBlazor\Client\Pages\BackOffice\Configuracion\ListaDePreciosC\ListaDePreciosDetalle.razor"
                                                                                                                             productoPresentacion.PresentacionProducto.nombre

#line default
#line hidden
                );
                __builder2.CloseElement();
                __builder2.CloseElement();
                __builder2.CloseElement();
                __builder2.AddMarkupContent(137, "\r\n\r\n                                                ");
                __builder2.OpenElement(138, "div");
                __builder2.AddAttribute(139, "class", "col-md-2 p-1 ");
                __builder2.AddMarkupContent(140, "\r\n                                                    ");
                __builder2.OpenElement(141, "h4");
                __builder2.AddAttribute(142, "class", "text-center m-0");
                __builder2.AddContent(143, "$ ");
                __builder2.OpenElement(144, "strong");
                __builder2.AddContent(145, 
#line 94 "C:\Users\agust\source\repos\SurcosBlazor\Client\Pages\BackOffice\Configuracion\ListaDePreciosC\ListaDePreciosDetalle.razor"
                                                                                           detalle.precioCosto

#line default
#line hidden
                );
                __builder2.CloseElement();
                __builder2.CloseElement();
                __builder2.AddMarkupContent(146, "\r\n                                                ");
                __builder2.CloseElement();
                __builder2.AddMarkupContent(147, "\r\n                                                ");
                __builder2.OpenElement(148, "div");
                __builder2.AddAttribute(149, "class", "col-md-2 px-1 text-center");
                __builder2.AddMarkupContent(150, "\r\n\r\n                                                    ");
                __builder2.OpenElement(151, "strong");
                __builder2.AddContent(152, 
#line 98 "C:\Users\agust\source\repos\SurcosBlazor\Client\Pages\BackOffice\Configuracion\ListaDePreciosC\ListaDePreciosDetalle.razor"
                                                             detalle.porcentajeRentabilidad

#line default
#line hidden
                );
                __builder2.AddContent(153, "%");
                __builder2.CloseElement();
                __builder2.AddMarkupContent(154, "\r\n                                                ");
                __builder2.CloseElement();
                __builder2.AddMarkupContent(155, "\r\n                                                ");
                __builder2.OpenElement(156, "div");
                __builder2.AddAttribute(157, "class", "col-md-2 px-1 text-center");
                __builder2.AddMarkupContent(158, "\r\n                                                    ");
                __builder2.AddContent(159, 
#line 101 "C:\Users\agust\source\repos\SurcosBlazor\Client\Pages\BackOffice\Configuracion\ListaDePreciosC\ListaDePreciosDetalle.razor"
                                                     detalle.porcentajeDescuento

#line default
#line hidden
                );
                __builder2.AddMarkupContent(160, "%\r\n                                                ");
                __builder2.CloseElement();
                __builder2.AddMarkupContent(161, "\r\n                                                ");
                __builder2.OpenElement(162, "div");
                __builder2.AddAttribute(163, "class", "col-md-2 px-1 text-center");
                __builder2.AddMarkupContent(164, "\r\n                                                    $");
                __builder2.AddContent(165, 
#line 104 "C:\Users\agust\source\repos\SurcosBlazor\Client\Pages\BackOffice\Configuracion\ListaDePreciosC\ListaDePreciosDetalle.razor"
                                                      detalle.precioUnitarioFinal

#line default
#line hidden
                );
                __builder2.AddMarkupContent(166, "\r\n                                                ");
                __builder2.CloseElement();
                __builder2.AddMarkupContent(167, "\r\n                                                ");
                __builder2.OpenElement(168, "div");
                __builder2.AddAttribute(169, "class", "col-md-1 px-1 text-center");
                __builder2.AddMarkupContent(170, "\r\n                                                    ");
                __builder2.OpenElement(171, "strong");
                __builder2.AddMarkupContent(172, "\r\n                                                        ");
                __builder2.AddContent(173, 
#line 108 "C:\Users\agust\source\repos\SurcosBlazor\Client\Pages\BackOffice\Configuracion\ListaDePreciosC\ListaDePreciosDetalle.razor"
                                                          detalle.precioUnitarioFinal != 0.00M ? ((1 - (detalle.precioCosto / detalle.precioUnitarioFinal)) * 100).ToString("0.##") : "0.00"

#line default
#line hidden
                );
                __builder2.AddMarkupContent(174, "%\r\n                                                    ");
                __builder2.CloseElement();
                __builder2.AddMarkupContent(175, "\r\n\r\n\r\n                                                ");
                __builder2.CloseElement();
                __builder2.AddMarkupContent(176, "\r\n\r\n\r\n\r\n                                            ");
                __builder2.CloseElement();
                __builder2.AddMarkupContent(177, "\r\n");
#line 117 "C:\Users\agust\source\repos\SurcosBlazor\Client\Pages\BackOffice\Configuracion\ListaDePreciosC\ListaDePreciosDetalle.razor"

                                        }

#line default
#line hidden
                __builder2.AddContent(178, "                                    ");
                __builder2.CloseElement();
                __builder2.AddMarkupContent(179, "\r\n                                ");
                __builder2.CloseElement();
                __builder2.AddMarkupContent(180, "\r\n");
#line 121 "C:\Users\agust\source\repos\SurcosBlazor\Client\Pages\BackOffice\Configuracion\ListaDePreciosC\ListaDePreciosDetalle.razor"
                            }

#line default
#line hidden
                __builder2.AddMarkupContent(181, "\r\n                        ");
                __builder2.CloseElement();
                __builder2.AddMarkupContent(182, "\r\n\r\n                    ");
                __builder2.CloseElement();
                __builder2.AddMarkupContent(183, "\r\n");
#line 126 "C:\Users\agust\source\repos\SurcosBlazor\Client\Pages\BackOffice\Configuracion\ListaDePreciosC\ListaDePreciosDetalle.razor"

                }

#line default
#line hidden
                __builder2.AddContent(184, "            ");
            }
            );
            __builder.AddMarkupContent(185, "\r\n");
#line 130 "C:\Users\agust\source\repos\SurcosBlazor\Client\Pages\BackOffice\Configuracion\ListaDePreciosC\ListaDePreciosDetalle.razor"
    }

#line default
#line hidden
            __builder.CloseElement();
        }
        #pragma warning restore 1998
#line 134 "C:\Users\agust\source\repos\SurcosBlazor\Client\Pages\BackOffice\Configuracion\ListaDePreciosC\ListaDePreciosDetalle.razor"
       
    [Parameter] public int ListaPreciosId { get; set; }
    public List<ProductoPresentacion> productoPresentaciones { get; set; }
    public List<CategoriaProducto> categorias { get; set; }
    public List<Producto> productos { get; set; }
    public ListaPrecios ListaPrecios { get; set; }
    protected override async Task OnParametersSetAsync()
    {
        if (ListaPreciosId != 0)
        {

            ListaPrecios = await http.GetJsonAsync<ListaPrecios>($"api/ListaPrecios/{ListaPreciosId}");
            ListarProductosPresentacion();

            productos = productoPresentaciones.Select(x => x.Producto).Distinct().ToList();

            categorias = productos.Select(x => x.CategoriaProducto).Distinct().ToList();
        }
    }


    public void ListarProductosPresentacion()
    {
        productoPresentaciones = ListaPrecios.DetalleListaPrecios.Select(x => x.ProductoPresentacion).ToList();

    }







#line default
#line hidden
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private NavigationManager uri { get; set; }
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private IToastService toastService { get; set; }
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private IJSRuntime js { get; set; }
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private HttpClient http { get; set; }
    }
}
namespace __Blazor.SurcosBlazor.Client.Pages.BackOffice.Configuracion.ListaDePreciosC.ListaDePreciosDetalle
{
    #line hidden
    internal static class TypeInference
    {
        public static void CreateListadoGenerico_0<T>(global::Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder, int seq, int __seq0, global::System.Collections.Generic.List<T> __arg0, int __seq1, global::Microsoft.AspNetCore.Components.RenderFragment __arg1)
        {
        __builder.OpenComponent<global::SurcosBlazor.Client.Shared.ListadoGenerico<T>>(seq);
        __builder.AddAttribute(__seq0, "listado", __arg0);
        __builder.AddAttribute(__seq1, "HayRegistros", __arg1);
        __builder.CloseComponent();
        }
    }
}
#pragma warning restore 1591
