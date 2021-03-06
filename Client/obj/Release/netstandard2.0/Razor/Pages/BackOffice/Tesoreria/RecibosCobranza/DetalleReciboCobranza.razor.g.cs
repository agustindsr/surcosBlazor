#pragma checksum "C:\Users\agust\source\repos\SurcosBlazor\Client\Pages\BackOffice\Tesoreria\RecibosCobranza\DetalleReciboCobranza.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "3ed4c7eb3636ec963fee4013649eb68cb7f5cde9"
// <auto-generated/>
#pragma warning disable 1591
namespace SurcosBlazor.Client.Pages.BackOffice.Tesoreria.RecibosCobranza
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
#line 9 "C:\Users\agust\source\repos\SurcosBlazor\Client\Pages\BackOffice\Tesoreria\RecibosCobranza\DetalleReciboCobranza.razor"
           [Authorize(Roles = "Admin, Tesoreria")]

#line default
#line hidden
    [Microsoft.AspNetCore.Components.LayoutAttribute(typeof(BackOfficeLayout))]
    [Microsoft.AspNetCore.Components.RouteAttribute("/BackOffice/Tesoreria/DetalleReciboCobranza/{Id:int}")]
    public partial class DetalleReciboCobranza : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
#line 11 "C:\Users\agust\source\repos\SurcosBlazor\Client\Pages\BackOffice\Tesoreria\RecibosCobranza\DetalleReciboCobranza.razor"
 if (cargando)
{

#line default
#line hidden
            __builder.AddContent(0, "    ");
            __builder.OpenComponent<SurcosBlazor.Client.Shared.Loading>(1);
            __builder.CloseComponent();
            __builder.AddMarkupContent(2, "\r\n");
#line 14 "C:\Users\agust\source\repos\SurcosBlazor\Client\Pages\BackOffice\Tesoreria\RecibosCobranza\DetalleReciboCobranza.razor"
}

#line default
#line hidden
            __builder.OpenElement(3, "nav");
            __builder.AddAttribute(4, "aria-label", "breadcrumb");
            __builder.AddMarkupContent(5, "\r\n    ");
            __builder.OpenElement(6, "ol");
            __builder.AddAttribute(7, "class", "breadcrumb");
            __builder.AddMarkupContent(8, "\r\n        ");
            __builder.OpenElement(9, "li");
            __builder.AddAttribute(10, "class", "breadcrumb-item");
            __builder.AddAttribute(11, "onclick", Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Web.MouseEventArgs>(this, 
#line 17 "C:\Users\agust\source\repos\SurcosBlazor\Client\Pages\BackOffice\Tesoreria\RecibosCobranza\DetalleReciboCobranza.razor"
                                                () => uri.NavigateTo("BackOffice/Tesoreria")

#line default
#line hidden
            ));
            __builder.AddContent(12, "Tesoreria");
            __builder.CloseElement();
            __builder.AddMarkupContent(13, "\r\n        ");
            __builder.OpenElement(14, "li");
            __builder.AddAttribute(15, "class", "breadcrumb-item");
            __builder.AddAttribute(16, "onclick", Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Web.MouseEventArgs>(this, 
#line 18 "C:\Users\agust\source\repos\SurcosBlazor\Client\Pages\BackOffice\Tesoreria\RecibosCobranza\DetalleReciboCobranza.razor"
                                                () => uri.NavigateTo("BackOffice/Tesoreria/ListadoRecibosCobranza")

#line default
#line hidden
            ));
            __builder.AddContent(17, "Recibos de Cobranza");
            __builder.CloseElement();
            __builder.AddMarkupContent(18, "\r\n        ");
            __builder.OpenElement(19, "li");
            __builder.AddAttribute(20, "class", "breadcrumb-item active");
            __builder.AddAttribute(21, "aria-current", "page");
            __builder.AddAttribute(22, "onclick", Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Web.MouseEventArgs>(this, 
#line 19 "C:\Users\agust\source\repos\SurcosBlazor\Client\Pages\BackOffice\Tesoreria\RecibosCobranza\DetalleReciboCobranza.razor"
                                                                           () => uri.NavigateTo($"BackOffice/Tesoreria/DetalleReciboCobranza/{Id}")

#line default
#line hidden
            ));
            __builder.AddContent(23, "Detalle Recibo Cobranza");
            __builder.CloseElement();
            __builder.AddMarkupContent(24, "\r\n    ");
            __builder.CloseElement();
            __builder.AddMarkupContent(25, "\r\n");
            __builder.CloseElement();
            __builder.AddMarkupContent(26, "\r\n");
            __builder.AddMarkupContent(27, "<h2>Detalle Recibo Cobranza</h2>\r\n\r\n");
#line 24 "C:\Users\agust\source\repos\SurcosBlazor\Client\Pages\BackOffice\Tesoreria\RecibosCobranza\DetalleReciboCobranza.razor"
 if (recibo != null)
{



#line default
#line hidden
            __builder.AddContent(28, "    ");
            __builder.OpenElement(29, "div");
            __builder.AddAttribute(30, "class", "p-4");
            __builder.AddAttribute(31, "style", "box-shadow:1px 1px 3px #323232");
            __builder.AddMarkupContent(32, "\r\n        ");
            __builder.OpenElement(33, "div");
            __builder.AddAttribute(34, "class", "d-flex justify-content-end");
            __builder.OpenElement(35, "div");
            __builder.AddAttribute(36, "class", "btn btn-sm btn-outline-danger");
            __builder.AddAttribute(37, "style", "cursor:pointer");
            __builder.AddAttribute(38, "onclick", Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Web.MouseEventArgs>(this, 
#line 29 "C:\Users\agust\source\repos\SurcosBlazor\Client\Pages\BackOffice\Tesoreria\RecibosCobranza\DetalleReciboCobranza.razor"
                                                                                                                              async()=> { await ToggleModal("eliminarConfirm"); }

#line default
#line hidden
            ));
            __builder.AddContent(39, "Eliminar");
            __builder.CloseElement();
            __builder.CloseElement();
            __builder.AddMarkupContent(40, "\r\n        ");
            __builder.OpenElement(41, "div");
            __builder.AddAttribute(42, "class", "col-md-12 row mx-0");
            __builder.AddMarkupContent(43, "\r\n            ");
            __builder.OpenElement(44, "div");
            __builder.AddAttribute(45, "class", "form-group col-md-6");
            __builder.AddMarkupContent(46, "\r\n                ");
            __builder.AddMarkupContent(47, "<label>Cliente</label>\r\n\r\n                ");
            __builder.OpenElement(48, "div");
            __builder.OpenElement(49, "h2");
            __builder.OpenElement(50, "strong");
            __builder.AddAttribute(51, "class", "badge");
            __builder.AddContent(52, "#");
            __builder.AddContent(53, 
#line 34 "C:\Users\agust\source\repos\SurcosBlazor\Client\Pages\BackOffice\Tesoreria\RecibosCobranza\DetalleReciboCobranza.razor"
                                                 recibo.ClienteId

#line default
#line hidden
            );
            __builder.AddContent(54, " ");
            __builder.AddContent(55, 
#line 34 "C:\Users\agust\source\repos\SurcosBlazor\Client\Pages\BackOffice\Tesoreria\RecibosCobranza\DetalleReciboCobranza.razor"
                                                                   recibo.Cliente.nombre

#line default
#line hidden
            );
            __builder.AddContent(56, ", ");
            __builder.AddContent(57, 
#line 34 "C:\Users\agust\source\repos\SurcosBlazor\Client\Pages\BackOffice\Tesoreria\RecibosCobranza\DetalleReciboCobranza.razor"
                                                                                           recibo.Cliente.apellido

#line default
#line hidden
            );
            __builder.CloseElement();
            __builder.CloseElement();
            __builder.CloseElement();
            __builder.AddMarkupContent(58, "\r\n\r\n            ");
            __builder.CloseElement();
            __builder.AddMarkupContent(59, "\r\n            ");
            __builder.OpenElement(60, "div");
            __builder.AddAttribute(61, "class", "col-md-6");
            __builder.AddMarkupContent(62, "\r\n                ");
            __builder.AddMarkupContent(63, "<label>Fecha</label>\r\n                ");
            __builder.OpenElement(64, "strong");
            __builder.AddContent(65, 
#line 39 "C:\Users\agust\source\repos\SurcosBlazor\Client\Pages\BackOffice\Tesoreria\RecibosCobranza\DetalleReciboCobranza.razor"
                         recibo.fecha.ToString("dd/MM/yyyy HH:mm")

#line default
#line hidden
            );
            __builder.CloseElement();
            __builder.AddMarkupContent(66, "\r\n            ");
            __builder.CloseElement();
            __builder.AddMarkupContent(67, "\r\n        ");
            __builder.CloseElement();
            __builder.AddMarkupContent(68, "\r\n    ");
            __builder.CloseElement();
            __builder.AddMarkupContent(69, "\r\n    ");
            __builder.OpenElement(70, "div");
            __builder.AddAttribute(71, "class", "my-2");
            __builder.AddMarkupContent(72, "\r\n        ");
            __builder.AddMarkupContent(73, @"<ul class=""nav nav-pills mb-3"" id=""pills-tab"" role=""tablist"">
            <li class=""nav-item"">
                <a class=""nav-link active"" id=""pills-imputaciones-tab"" data-toggle=""pill"" href=""#pills-imputaciones"" role=""tab"" aria-controls=""pills-imputaciones"" aria-selected=""true"">Imputaciones</a>
            </li>
            <li class=""nav-item mx-3"">
                <a class=""nav-link"" id=""pills-tesoreria-tab"" data-toggle=""pill"" href=""#pills-tesoreria"" role=""tab"" aria-controls=""pills-tesoreria"" aria-selected=""false"">Movimientos de Tesorería</a>
            </li>
        </ul>

        ");
            __builder.OpenElement(74, "div");
            __builder.AddAttribute(75, "class", "tab-content bg-light rounded");
            __builder.AddAttribute(76, "id", "pills-tabContent");
            __builder.AddMarkupContent(77, "\r\n            ");
            __builder.OpenElement(78, "div");
            __builder.AddAttribute(79, "class", "tab-pane fade show active");
            __builder.AddAttribute(80, "id", "pills-imputaciones");
            __builder.AddAttribute(81, "role", "tabpanel");
            __builder.AddAttribute(82, "aria-labelledby", "pills-imputaciones-tab");
            __builder.AddMarkupContent(83, "\r\n                ");
            __builder.OpenElement(84, "div");
            __builder.AddAttribute(85, "class", true);
            __builder.AddAttribute(86, "style", "box-shadow:1px 1px 3px #323232");
            __builder.AddMarkupContent(87, "\r\n                    ");
            __builder.OpenElement(88, "table");
            __builder.AddAttribute(89, "class", "table table-sm table-striped");
            __builder.AddMarkupContent(90, "\r\n                        ");
            __builder.AddMarkupContent(91, @"<thead>
                            <tr>
                                <th>Número de comprobante</th>
                                <th>Estado</th>
                                <th>Total Comprobante</th>
                                <th>Total Imputado</th>
                            </tr>
                        </thead>
                        ");
            __builder.OpenElement(92, "tbody");
            __builder.AddMarkupContent(93, "\r\n");
#line 66 "C:\Users\agust\source\repos\SurcosBlazor\Client\Pages\BackOffice\Tesoreria\RecibosCobranza\DetalleReciboCobranza.razor"
                             foreach (ImputacionComprobantesVenta imputacion in recibo.Imputaciones)
                            {

#line default
#line hidden
            __builder.AddContent(94, "                                ");
            __builder.OpenElement(95, "tr");
            __builder.AddMarkupContent(96, "\r\n\r\n                                    ");
            __builder.OpenElement(97, "td");
            __builder.AddContent(98, 
#line 70 "C:\Users\agust\source\repos\SurcosBlazor\Client\Pages\BackOffice\Tesoreria\RecibosCobranza\DetalleReciboCobranza.razor"
                                         imputacion.FacturaVenta.codigo

#line default
#line hidden
            );
            __builder.CloseElement();
            __builder.AddMarkupContent(99, "\r\n                                    ");
            __builder.OpenElement(100, "td");
            __builder.AddContent(101, 
#line 71 "C:\Users\agust\source\repos\SurcosBlazor\Client\Pages\BackOffice\Tesoreria\RecibosCobranza\DetalleReciboCobranza.razor"
                                         imputacion.FacturaVenta.EstadoFactura.nombre

#line default
#line hidden
            );
            __builder.CloseElement();
            __builder.AddMarkupContent(102, "\r\n                                    ");
            __builder.OpenElement(103, "td");
            __builder.AddContent(104, "$");
            __builder.AddContent(105, 
#line 72 "C:\Users\agust\source\repos\SurcosBlazor\Client\Pages\BackOffice\Tesoreria\RecibosCobranza\DetalleReciboCobranza.razor"
                                          imputacion.FacturaVenta.totalComprobante

#line default
#line hidden
            );
            __builder.CloseElement();
            __builder.AddMarkupContent(106, "\r\n                                    ");
            __builder.OpenElement(107, "td");
            __builder.AddMarkupContent(108, "\r\n                                        $ ");
            __builder.AddContent(109, 
#line 74 "C:\Users\agust\source\repos\SurcosBlazor\Client\Pages\BackOffice\Tesoreria\RecibosCobranza\DetalleReciboCobranza.razor"
                                           imputacion.totalImputado

#line default
#line hidden
            );
            __builder.AddMarkupContent(110, "\r\n                                    ");
            __builder.CloseElement();
            __builder.AddMarkupContent(111, "\r\n                                ");
            __builder.CloseElement();
            __builder.AddMarkupContent(112, "\r\n");
#line 77 "C:\Users\agust\source\repos\SurcosBlazor\Client\Pages\BackOffice\Tesoreria\RecibosCobranza\DetalleReciboCobranza.razor"
                            }

#line default
#line hidden
            __builder.AddContent(113, "                        ");
            __builder.CloseElement();
            __builder.AddMarkupContent(114, "\r\n                    ");
            __builder.CloseElement();
            __builder.AddMarkupContent(115, "\r\n\r\n\r\n\r\n                ");
            __builder.CloseElement();
            __builder.AddMarkupContent(116, "\r\n            ");
            __builder.CloseElement();
            __builder.AddMarkupContent(117, "\r\n            ");
            __builder.OpenElement(118, "div");
            __builder.AddAttribute(119, "class", "tab-pane fade");
            __builder.AddAttribute(120, "id", "pills-tesoreria");
            __builder.AddAttribute(121, "role", "tabpanel");
            __builder.AddAttribute(122, "aria-labelledby", "pills-tesoreria-tab");
            __builder.AddMarkupContent(123, "\r\n\r\n                ");
            __builder.OpenElement(124, "div");
            __builder.AddAttribute(125, "class", true);
            __builder.AddAttribute(126, "style", "box-shadow:1px 1px 3px #323232");
            __builder.AddMarkupContent(127, "\r\n                    ");
            __builder.OpenElement(128, "table");
            __builder.AddAttribute(129, "class", "table table-sm");
            __builder.AddMarkupContent(130, "\r\n                        ");
            __builder.AddMarkupContent(131, "<thead>\r\n                            <tr>\r\n                                <th>Caja</th>\r\n                                <th>Importe</th>\r\n                            </tr>\r\n                        </thead>\r\n");
#line 95 "C:\Users\agust\source\repos\SurcosBlazor\Client\Pages\BackOffice\Tesoreria\RecibosCobranza\DetalleReciboCobranza.razor"
                         foreach (MovimientoCaja movimientoCaja in recibo.movimientosCaja)
                        {

#line default
#line hidden
            __builder.AddContent(132, "                            ");
            __builder.OpenElement(133, "tr");
            __builder.AddMarkupContent(134, "\r\n                                ");
            __builder.OpenElement(135, "td");
            __builder.AddMarkupContent(136, "\r\n                                    ");
            __builder.AddContent(137, 
#line 99 "C:\Users\agust\source\repos\SurcosBlazor\Client\Pages\BackOffice\Tesoreria\RecibosCobranza\DetalleReciboCobranza.razor"
                                     movimientoCaja.Caja.nombre

#line default
#line hidden
            );
            __builder.AddMarkupContent(138, "\r\n                                ");
            __builder.CloseElement();
            __builder.AddMarkupContent(139, "\r\n                                ");
            __builder.OpenElement(140, "td");
            __builder.AddMarkupContent(141, "\r\n                                    $");
            __builder.AddContent(142, 
#line 102 "C:\Users\agust\source\repos\SurcosBlazor\Client\Pages\BackOffice\Tesoreria\RecibosCobranza\DetalleReciboCobranza.razor"
                                      movimientoCaja.totalMovimiento

#line default
#line hidden
            );
            __builder.AddMarkupContent(143, "\r\n                                ");
            __builder.CloseElement();
            __builder.AddMarkupContent(144, "\r\n\r\n                            ");
            __builder.CloseElement();
            __builder.AddMarkupContent(145, "\r\n");
#line 106 "C:\Users\agust\source\repos\SurcosBlazor\Client\Pages\BackOffice\Tesoreria\RecibosCobranza\DetalleReciboCobranza.razor"
                        }

#line default
#line hidden
            __builder.AddContent(146, "                    ");
            __builder.CloseElement();
            __builder.AddMarkupContent(147, "\r\n                ");
            __builder.CloseElement();
            __builder.AddMarkupContent(148, "\r\n            ");
            __builder.CloseElement();
            __builder.AddMarkupContent(149, "\r\n        ");
            __builder.CloseElement();
            __builder.AddMarkupContent(150, "\r\n\r\n\r\n    ");
            __builder.CloseElement();
            __builder.AddMarkupContent(151, "\r\n");
            __builder.AddContent(152, "    ");
            __builder.OpenElement(153, "div");
            __builder.AddAttribute(154, "class", "p-4");
            __builder.AddAttribute(155, "style", "box-shadow:1px 1px 3px #323232");
            __builder.AddMarkupContent(156, "\r\n");
#line 116 "C:\Users\agust\source\repos\SurcosBlazor\Client\Pages\BackOffice\Tesoreria\RecibosCobranza\DetalleReciboCobranza.razor"
         if (true)
        {
            decimal diferencia = recibo.movimientosCaja.Sum(x => x.totalMovimiento) - recibo.Imputaciones.Sum(x => x.totalImputado);

#line default
#line hidden
            __builder.AddContent(157, "            ");
            __builder.OpenElement(158, "div");
            __builder.AddAttribute(159, "class", "col-md-12");
            __builder.AddMarkupContent(160, "<strong>Total imputado:</strong>$ ");
            __builder.AddContent(161, 
#line 119 "C:\Users\agust\source\repos\SurcosBlazor\Client\Pages\BackOffice\Tesoreria\RecibosCobranza\DetalleReciboCobranza.razor"
                                                                      recibo.Imputaciones.Sum(x => x.totalImputado)

#line default
#line hidden
            );
            __builder.AddContent(162, " ");
            __builder.CloseElement();
            __builder.AddMarkupContent(163, "\r\n            ");
            __builder.OpenElement(164, "div");
            __builder.AddAttribute(165, "class", "col-md-12");
            __builder.AddMarkupContent(166, "<strong>Total pagado:</strong>$ ");
            __builder.AddContent(167, 
#line 120 "C:\Users\agust\source\repos\SurcosBlazor\Client\Pages\BackOffice\Tesoreria\RecibosCobranza\DetalleReciboCobranza.razor"
                                                                    recibo.movimientosCaja.Sum(x => x.totalMovimiento)

#line default
#line hidden
            );
            __builder.AddContent(168, " ");
            __builder.CloseElement();
            __builder.AddMarkupContent(169, "\r\n            ");
            __builder.OpenElement(170, "div");
            __builder.AddAttribute(171, "class", "col-md-12" + " " + (
#line 121 "C:\Users\agust\source\repos\SurcosBlazor\Client\Pages\BackOffice\Tesoreria\RecibosCobranza\DetalleReciboCobranza.razor"
                                    diferencia > 0 ? "text-success" : ""

#line default
#line hidden
            ));
            __builder.AddMarkupContent(172, "<strong>A cuenta: </strong>$  ");
            __builder.AddContent(173, 
#line 121 "C:\Users\agust\source\repos\SurcosBlazor\Client\Pages\BackOffice\Tesoreria\RecibosCobranza\DetalleReciboCobranza.razor"
                                                                                                           diferencia > 0 ? diferencia : 0.00M

#line default
#line hidden
            );
            __builder.CloseElement();
            __builder.AddMarkupContent(174, "\r\n            ");
            __builder.OpenElement(175, "div");
            __builder.AddAttribute(176, "class", "col-md-12" + " " + (
#line 122 "C:\Users\agust\source\repos\SurcosBlazor\Client\Pages\BackOffice\Tesoreria\RecibosCobranza\DetalleReciboCobranza.razor"
                                    diferencia < 0 ? "text-danger" : ""

#line default
#line hidden
            ));
            __builder.AddMarkupContent(177, "<strong>Diferencia: </strong>$  ");
            __builder.AddContent(178, 
#line 122 "C:\Users\agust\source\repos\SurcosBlazor\Client\Pages\BackOffice\Tesoreria\RecibosCobranza\DetalleReciboCobranza.razor"
                                                                                                            diferencia < 0 ? diferencia : 0.00M

#line default
#line hidden
            );
            __builder.CloseElement();
            __builder.AddMarkupContent(179, "\r\n");
#line 123 "C:\Users\agust\source\repos\SurcosBlazor\Client\Pages\BackOffice\Tesoreria\RecibosCobranza\DetalleReciboCobranza.razor"
        }

#line default
#line hidden
            __builder.AddContent(180, "    ");
            __builder.CloseElement();
            __builder.AddMarkupContent(181, "\r\n");
            __builder.AddContent(182, "    ");
            __builder.OpenComponent<SurcosBlazor.Client.Shared.ModalConfirm>(183);
            __builder.AddAttribute(184, "confirmFunc", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Microsoft.AspNetCore.Components.EventCallback>(Microsoft.AspNetCore.Components.EventCallback.Factory.Create(this, 
#line 126 "C:\Users\agust\source\repos\SurcosBlazor\Client\Pages\BackOffice\Tesoreria\RecibosCobranza\DetalleReciboCobranza.razor"
                                 async()=> { cargando = true; await eliminar(); }

#line default
#line hidden
            )));
            __builder.AddAttribute(185, "modalId", "eliminarConfirm");
            __builder.CloseComponent();
            __builder.AddMarkupContent(186, "\r\n");
#line 129 "C:\Users\agust\source\repos\SurcosBlazor\Client\Pages\BackOffice\Tesoreria\RecibosCobranza\DetalleReciboCobranza.razor"
}

#line default
#line hidden
        }
        #pragma warning restore 1998
#line 132 "C:\Users\agust\source\repos\SurcosBlazor\Client\Pages\BackOffice\Tesoreria\RecibosCobranza\DetalleReciboCobranza.razor"
       
    public ReciboCobranzas recibo { get; set; }
    [Parameter] public int Id { get; set; }
    public bool cargando { get; set; }
    protected override async Task OnInitializedAsync()
    {
        if (Id != 0)
        {
            recibo = await http.GetJsonAsync<ReciboCobranzas>($"api/recibocobranza/{Id}");
        }
        else
        {
            recibo = await http.GetJsonAsync<ReciboCobranzas>($"api/recibocobranza/0");
        }

    }

    public async Task eliminar()
    {

        var respuesta = await repositorio.Delete($"api/ReciboCobranza/{recibo.Id}");
        cargando = false;
        await ToggleModal("eliminarConfirm");

        

#line default
#line hidden
#line 156 "C:\Users\agust\source\repos\SurcosBlazor\Client\Pages\BackOffice\Tesoreria\RecibosCobranza\DetalleReciboCobranza.razor"
         if (!respuesta.Error)
        {
            uri.NavigateTo("/BackOffice/Tesoreria");
            toastService.ShowSuccess("Se eliminó correctamente");
        }
        else
        {

            toastService.ShowError(respuesta.HttpResponseMessage.Content.ReadAsStringAsync().Result);

        }

#line default
#line hidden
#line 166 "C:\Users\agust\source\repos\SurcosBlazor\Client\Pages\BackOffice\Tesoreria\RecibosCobranza\DetalleReciboCobranza.razor"
         

    }

    public async Task ToggleModal(string id)
    {
        await js.InvokeVoidAsync("ModalToggle", id);
    }


#line default
#line hidden
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private IJSRuntime js { get; set; }
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private NavigationManager uri { get; set; }
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private IToastService toastService { get; set; }
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private IRepositorio repositorio { get; set; }
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private AuthenticationStateProvider authStateProvider { get; set; }
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private HttpClient http { get; set; }
    }
}
#pragma warning restore 1591
