#pragma checksum "C:\Users\agust\source\repos\SurcosBlazor\Client\Pages\BackOffice\Compras\FacturasCompras\FacturaComprasDetalle.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "81698630d080ef23ce59a6ae26db14de16082ead"
// <auto-generated/>
#pragma warning disable 1591
namespace SurcosBlazor.Client.Pages.BackOffice.Compras.FacturasCompras
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
#line 9 "C:\Users\agust\source\repos\SurcosBlazor\Client\Pages\BackOffice\Compras\FacturasCompras\FacturaComprasDetalle.razor"
           [Authorize(Roles = "Admin, Compras")]

#line default
#line hidden
    [Microsoft.AspNetCore.Components.LayoutAttribute(typeof(BackOfficeLayout))]
    [Microsoft.AspNetCore.Components.RouteAttribute("/BackOffice/Compras/ComprobanteCompras/{Id:int}")]
    public partial class FacturaComprasDetalle : Microsoft.AspNetCore.Components.ComponentBase
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
#line 14 "C:\Users\agust\source\repos\SurcosBlazor\Client\Pages\BackOffice\Compras\FacturasCompras\FacturaComprasDetalle.razor"
                                                ()=>uri.NavigateTo("BackOffice/Compras")

#line default
#line hidden
            ));
            __builder.AddContent(9, "Compras");
            __builder.CloseElement();
            __builder.AddMarkupContent(10, "\r\n        ");
            __builder.OpenElement(11, "li");
            __builder.AddAttribute(12, "class", "breadcrumb-item");
            __builder.AddAttribute(13, "onclick", Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Web.MouseEventArgs>(this, 
#line 15 "C:\Users\agust\source\repos\SurcosBlazor\Client\Pages\BackOffice\Compras\FacturasCompras\FacturaComprasDetalle.razor"
                                                ()=>uri.NavigateTo("BackOffice/Compras/ListadoComprobantes")

#line default
#line hidden
            ));
            __builder.AddContent(14, "Listado Comprobantes");
            __builder.CloseElement();
            __builder.AddMarkupContent(15, "\r\n        ");
            __builder.OpenElement(16, "li");
            __builder.AddAttribute(17, "class", "breadcrumb-item active");
            __builder.AddAttribute(18, "aria-current", "page");
            __builder.AddAttribute(19, "onclick", Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Web.MouseEventArgs>(this, 
#line 16 "C:\Users\agust\source\repos\SurcosBlazor\Client\Pages\BackOffice\Compras\FacturasCompras\FacturaComprasDetalle.razor"
                                                                           ()=>uri.NavigateTo($"BackOffice/Compras/ComprobanteCompras/{Id}")

#line default
#line hidden
            ));
            __builder.AddContent(20, "Detalle Comprobante");
            __builder.CloseElement();
            __builder.AddMarkupContent(21, "\r\n    ");
            __builder.CloseElement();
            __builder.AddMarkupContent(22, "\r\n");
            __builder.CloseElement();
            __builder.AddMarkupContent(23, "\r\n");
            __builder.AddMarkupContent(24, "<h2>Comprobante de Compra</h2>\r\n");
#line 20 "C:\Users\agust\source\repos\SurcosBlazor\Client\Pages\BackOffice\Compras\FacturasCompras\FacturaComprasDetalle.razor"
 if (factura != null)
{

#line default
#line hidden
            __builder.AddContent(25, "    ");
            __builder.OpenElement(26, "div");
            __builder.AddAttribute(27, "class", "row col-md-12 my-3 mx-0 p-2");
            __builder.AddAttribute(28, "style", "box-shadow:1px 1px 3px #323232");
            __builder.AddMarkupContent(29, "\r\n\r\n        ");
            __builder.OpenElement(30, "div");
            __builder.AddAttribute(31, "class", "col-md-12 mx-0 my-4 px-0 row d-flex justify-content-between");
            __builder.AddMarkupContent(32, "\r\n            ");
            __builder.OpenElement(33, "h3");
            __builder.OpenElement(34, "strong");
            __builder.AddAttribute(35, "class", "text-info");
            __builder.AddContent(36, 
#line 25 "C:\Users\agust\source\repos\SurcosBlazor\Client\Pages\BackOffice\Compras\FacturasCompras\FacturaComprasDetalle.razor"
                                           factura.TipoComprobante.nombre

#line default
#line hidden
            );
            __builder.AddContent(37, " ");
            __builder.AddContent(38, 
#line 25 "C:\Users\agust\source\repos\SurcosBlazor\Client\Pages\BackOffice\Compras\FacturasCompras\FacturaComprasDetalle.razor"
                                                                           factura.codigo

#line default
#line hidden
            );
            __builder.CloseElement();
            __builder.CloseElement();
            __builder.AddMarkupContent(39, "\r\n            ");
            __builder.OpenElement(40, "div");
            __builder.AddAttribute(41, "class", "col-md-3 mx-0 px-2");
            __builder.AddMarkupContent(42, "\r\n                ");
            __builder.AddMarkupContent(43, "<strong>Estado: </strong>");
            __builder.OpenElement(44, "span");
            __builder.AddContent(45, 
#line 27 "C:\Users\agust\source\repos\SurcosBlazor\Client\Pages\BackOffice\Compras\FacturasCompras\FacturaComprasDetalle.razor"
                                                factura.EstadoFactura.nombre

#line default
#line hidden
            );
            __builder.CloseElement();
            __builder.AddMarkupContent(46, "\r\n            ");
            __builder.CloseElement();
            __builder.AddMarkupContent(47, "\r\n        ");
            __builder.CloseElement();
            __builder.AddMarkupContent(48, "\r\n        ");
            __builder.OpenElement(49, "div");
            __builder.AddAttribute(50, "class", "col-md-12 mx-0 px-0 row my-2");
            __builder.AddMarkupContent(51, "\r\n\r\n            ");
            __builder.OpenElement(52, "div");
            __builder.AddAttribute(53, "class", "col-md-3  mx-0 px-2");
            __builder.AddMarkupContent(54, "\r\n                ");
            __builder.AddMarkupContent(55, "<strong>Depósito: </strong>");
            __builder.OpenElement(56, "span");
            __builder.AddContent(57, 
#line 33 "C:\Users\agust\source\repos\SurcosBlazor\Client\Pages\BackOffice\Compras\FacturasCompras\FacturaComprasDetalle.razor"
                                                  factura.Deposito.nombre

#line default
#line hidden
            );
            __builder.CloseElement();
            __builder.AddMarkupContent(58, "\r\n            ");
            __builder.CloseElement();
            __builder.AddMarkupContent(59, "\r\n            ");
            __builder.OpenElement(60, "div");
            __builder.AddAttribute(61, "class", "col-md-3  mx-0 px-2");
            __builder.AddMarkupContent(62, "\r\n                ");
            __builder.AddMarkupContent(63, "<strong>Fecha Comprobante: </strong>");
            __builder.OpenElement(64, "span");
            __builder.AddMarkupContent(65, "\r\n                    ");
            __builder.AddContent(66, 
#line 37 "C:\Users\agust\source\repos\SurcosBlazor\Client\Pages\BackOffice\Compras\FacturasCompras\FacturaComprasDetalle.razor"
                     factura.fecha.ToString("yyyy-MM-dd HH:mm")

#line default
#line hidden
            );
            __builder.AddMarkupContent(67, "\r\n                ");
            __builder.CloseElement();
            __builder.AddMarkupContent(68, "\r\n\r\n            ");
            __builder.CloseElement();
            __builder.AddMarkupContent(69, "\r\n\r\n\r\n        ");
            __builder.CloseElement();
            __builder.AddMarkupContent(70, "\r\n\r\n        ");
            __builder.AddMarkupContent(71, "<h3 class=\"border-bottom mt-3 text-info\"><strong>Proveedor</strong></h3>\r\n\r\n        ");
            __builder.OpenElement(72, "div");
            __builder.AddAttribute(73, "class", "row col-md-12 mx-0 my-1 px-2 align-items-center");
            __builder.AddMarkupContent(74, "\r\n            ");
            __builder.OpenElement(75, "div");
            __builder.AddAttribute(76, "class", "col-md-5 mx-0 pl-0");
            __builder.AddMarkupContent(77, "\r\n\r\n                ");
            __builder.AddMarkupContent(78, "<strong>Razón Social: </strong>\r\n\r\n\r\n                ");
            __builder.OpenElement(79, "a");
            __builder.AddAttribute(80, "href", 
#line 54 "C:\Users\agust\source\repos\SurcosBlazor\Client\Pages\BackOffice\Compras\FacturasCompras\FacturaComprasDetalle.razor"
                          $"/BackOffice/Compras/Proveedor/{factura.ProveedorId}"

#line default
#line hidden
            );
            __builder.AddContent(81, "#");
            __builder.AddContent(82, 
#line 54 "C:\Users\agust\source\repos\SurcosBlazor\Client\Pages\BackOffice\Compras\FacturasCompras\FacturaComprasDetalle.razor"
                                                                                    factura.ProveedorId

#line default
#line hidden
            );
            __builder.AddContent(83, " ");
            __builder.AddContent(84, 
#line 54 "C:\Users\agust\source\repos\SurcosBlazor\Client\Pages\BackOffice\Compras\FacturasCompras\FacturaComprasDetalle.razor"
                                                                                                         factura.Proveedor.razonSocial

#line default
#line hidden
            );
            __builder.CloseElement();
            __builder.AddMarkupContent(85, "\r\n\r\n\r\n\r\n            ");
            __builder.CloseElement();
            __builder.AddMarkupContent(86, "\r\n\r\n\r\n\r\n\r\n        ");
            __builder.CloseElement();
            __builder.AddMarkupContent(87, "\r\n\r\n    ");
            __builder.CloseElement();
            __builder.AddMarkupContent(88, "\r\n");
            __builder.AddContent(89, "    ");
            __builder.OpenElement(90, "div");
            __builder.AddAttribute(91, "class", "detallesFactura my-4");
            __builder.AddMarkupContent(92, "\r\n        ");
            __builder.OpenElement(93, "div");
            __builder.AddAttribute(94, "class", "col-md-12 row mx-0 p-2 d-flex justify-content-between align-items-center my-2");
            __builder.AddAttribute(95, "style", "background: linear-gradient(90deg, #262626, #213154);color:white;border-radius:5px;");
            __builder.AddMarkupContent(96, "\r\n            ");
            __builder.OpenElement(97, "h3");
            __builder.AddContent(98, "Productos (");
            __builder.AddContent(99, 
#line 72 "C:\Users\agust\source\repos\SurcosBlazor\Client\Pages\BackOffice\Compras\FacturasCompras\FacturaComprasDetalle.razor"
                            factura.detallesFactura.Count()

#line default
#line hidden
            );
            __builder.AddContent(100, ")");
            __builder.CloseElement();
            __builder.AddMarkupContent(101, "\r\n\r\n        ");
            __builder.CloseElement();
            __builder.AddMarkupContent(102, "\r\n        ");
            __builder.OpenElement(103, "table");
            __builder.AddAttribute(104, "class", "table table-sm d-xs-block");
            __builder.AddAttribute(105, "style", "overflow-x:auto;");
            __builder.AddMarkupContent(106, "\r\n            ");
            __builder.AddMarkupContent(107, @"<thead>
                <tr class=""bg-dark text-white p-1 rounded"">
                    <th>Producto</th>
                    <th>Presentacion</th>
                    <th>Cantidad</th>
                    <th>Precio Unitario</th>
                    <th>Total</th>
                </tr>
            </thead>
            ");
            __builder.OpenElement(108, "tbody");
            __builder.AddMarkupContent(109, "\r\n\r\n");
#line 87 "C:\Users\agust\source\repos\SurcosBlazor\Client\Pages\BackOffice\Compras\FacturasCompras\FacturaComprasDetalle.razor"
                 foreach (DetalleFacturaCompras detallesFactura in factura.detallesFactura)
                {

#line default
#line hidden
            __builder.AddContent(110, "                    ");
            __builder.OpenElement(111, "tr");
            __builder.AddAttribute(112, "class", true);
            __builder.AddMarkupContent(113, "\r\n                        ");
            __builder.OpenElement(114, "td");
            __builder.AddMarkupContent(115, "\r\n\r\n\r\n                            ");
            __builder.OpenElement(116, "div");
            __builder.OpenElement(117, "img");
            __builder.AddAttribute(118, "class", "mx-2");
            __builder.AddAttribute(119, "src", 
#line 93 "C:\Users\agust\source\repos\SurcosBlazor\Client\Pages\BackOffice\Compras\FacturasCompras\FacturaComprasDetalle.razor"
                                                         detallesFactura.ProductoPresentacion.Producto.Foto

#line default
#line hidden
            );
            __builder.AddAttribute(120, "style", "height:20px; width:20px;border-radius:50%;");
            __builder.CloseElement();
            __builder.AddContent(121, 
#line 93 "C:\Users\agust\source\repos\SurcosBlazor\Client\Pages\BackOffice\Compras\FacturasCompras\FacturaComprasDetalle.razor"
                                                                                                                                                                   detallesFactura.ProductoPresentacion.Producto.nombre.ToUpper()

#line default
#line hidden
            );
            __builder.CloseElement();
            __builder.AddMarkupContent(122, "\r\n\r\n\r\n                        ");
            __builder.CloseElement();
            __builder.AddMarkupContent(123, "\r\n\r\n                        ");
            __builder.OpenElement(124, "td");
            __builder.AddMarkupContent(125, "\r\n\r\n\r\n                            ");
            __builder.OpenElement(126, "strong");
            __builder.AddContent(127, " ");
            __builder.AddContent(128, 
#line 101 "C:\Users\agust\source\repos\SurcosBlazor\Client\Pages\BackOffice\Compras\FacturasCompras\FacturaComprasDetalle.razor"
                                      detallesFactura.ProductoPresentacion.PresentacionProducto.nombre

#line default
#line hidden
            );
            __builder.CloseElement();
            __builder.AddMarkupContent(129, "\r\n                        ");
            __builder.CloseElement();
            __builder.AddMarkupContent(130, "\r\n\r\n                        ");
            __builder.OpenElement(131, "td");
            __builder.AddContent(132, 
#line 104 "C:\Users\agust\source\repos\SurcosBlazor\Client\Pages\BackOffice\Compras\FacturasCompras\FacturaComprasDetalle.razor"
                             detallesFactura.cantidad

#line default
#line hidden
            );
            __builder.CloseElement();
            __builder.AddMarkupContent(133, "\r\n\r\n                        ");
            __builder.OpenElement(134, "td");
            __builder.AddContent(135, 
#line 106 "C:\Users\agust\source\repos\SurcosBlazor\Client\Pages\BackOffice\Compras\FacturasCompras\FacturaComprasDetalle.razor"
                             detallesFactura.precioUnitario

#line default
#line hidden
            );
            __builder.CloseElement();
            __builder.AddMarkupContent(136, "\r\n\r\n                        ");
            __builder.OpenElement(137, "td");
            __builder.AddContent(138, "$");
            __builder.AddContent(139, 
#line 108 "C:\Users\agust\source\repos\SurcosBlazor\Client\Pages\BackOffice\Compras\FacturasCompras\FacturaComprasDetalle.razor"
                               detallesFactura.precioUnitario * detallesFactura.cantidad

#line default
#line hidden
            );
            __builder.CloseElement();
            __builder.AddMarkupContent(140, "\r\n                    ");
            __builder.CloseElement();
            __builder.AddMarkupContent(141, "\r\n");
#line 110 "C:\Users\agust\source\repos\SurcosBlazor\Client\Pages\BackOffice\Compras\FacturasCompras\FacturaComprasDetalle.razor"
                }

#line default
#line hidden
            __builder.AddContent(142, "                ");
            __builder.OpenElement(143, "tr");
            __builder.AddAttribute(144, "class", "bg-dark text-white rounded");
            __builder.AddMarkupContent(145, "\r\n                    <th colspan=\"4\"></th>\r\n\r\n                    ");
            __builder.OpenElement(146, "th");
            __builder.AddAttribute(147, "class", true);
            __builder.AddMarkupContent(148, "<strong>Total:</strong> $");
            __builder.AddContent(149, 
#line 114 "C:\Users\agust\source\repos\SurcosBlazor\Client\Pages\BackOffice\Compras\FacturasCompras\FacturaComprasDetalle.razor"
                                                           factura.totalComprobante

#line default
#line hidden
            );
            __builder.CloseElement();
            __builder.AddMarkupContent(150, "\r\n                ");
            __builder.CloseElement();
            __builder.AddMarkupContent(151, "\r\n            ");
            __builder.CloseElement();
            __builder.AddMarkupContent(152, "\r\n\r\n        ");
            __builder.CloseElement();
            __builder.AddMarkupContent(153, "\r\n    ");
            __builder.CloseElement();
            __builder.AddMarkupContent(154, "\r\n");
#line 120 "C:\Users\agust\source\repos\SurcosBlazor\Client\Pages\BackOffice\Compras\FacturasCompras\FacturaComprasDetalle.razor"

}

#line default
#line hidden
        }
        #pragma warning restore 1998
#line 122 "C:\Users\agust\source\repos\SurcosBlazor\Client\Pages\BackOffice\Compras\FacturasCompras\FacturaComprasDetalle.razor"
       
    [Parameter]
    public int Id { get; set; }
    public FacturaCompras factura { get; set; }
    public string userName { get; set; }
    public System.Security.Claims.ClaimsPrincipal User { get; set; }



    public ListaPrecios lista { get; set; }

    protected override async Task OnParametersSetAsync()
    {
        if (Id != 0)
        {
            factura = await http.GetJsonAsync<FacturaCompras>($"api/FacturaCompra/{Id}");
        }
    }



    protected override async Task OnInitializedAsync()
    {
        var authState = await authStateProvider.GetAuthenticationStateAsync();
        User = authState.User;
        userName = User.Identity.Name;
    }

    public async Task ToggleModal(string id)
    {

        await js.InvokeAsync<object>("ModalToggle", id);
    }











#line default
#line hidden
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private NavigationManager uri { get; set; }
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private IToastService toastService { get; set; }
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private IRepositorio repositorio { get; set; }
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private AuthenticationStateProvider authStateProvider { get; set; }
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private HttpClient http { get; set; }
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private IJSRuntime js { get; set; }
    }
}
#pragma warning restore 1591
