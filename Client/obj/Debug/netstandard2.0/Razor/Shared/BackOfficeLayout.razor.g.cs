#pragma checksum "C:\Users\agust\source\repos\SurcosBlazor\Client\Shared\BackOfficeLayout.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "638f679212a6eac9a77f636589a7517164843d39"
// <auto-generated/>
#pragma warning disable 1591
namespace SurcosBlazor.Client.Shared
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
    public partial class BackOfficeLayout : LayoutComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
            __builder.AddMarkupContent(0, "<style>\r\n        body {\r\n            overflow-y: auto !important;\r\n        }\r\n    </style>\r\n");
            __builder.OpenComponent<Microsoft.AspNetCore.Components.Authorization.AuthorizeView>(1);
            __builder.AddAttribute(2, "Roles", "Admin, Administrativo, Logistica, Produccion");
            __builder.AddAttribute(3, "Authorized", (Microsoft.AspNetCore.Components.RenderFragment<Microsoft.AspNetCore.Components.Authorization.AuthenticationState>)((context) => (__builder2) => {
                __builder2.AddMarkupContent(4, "\r\n        ");
                __builder2.OpenElement(5, "div");
                __builder2.AddAttribute(6, "class", "sidebar" + " " + (
#line 10 "C:\Users\agust\source\repos\SurcosBlazor\Client\Shared\BackOfficeLayout.razor"
                              toggleNavBar ? "toggle" : ""

#line default
#line hidden
                ));
                __builder2.AddMarkupContent(7, "\r\n            ");
                __builder2.OpenElement(8, "div");
                __builder2.AddAttribute(9, "class", "toggleNavBar" + " " + (
#line 11 "C:\Users\agust\source\repos\SurcosBlazor\Client\Shared\BackOfficeLayout.razor"
                                       toggleNavBar ? "toggle" : ""

#line default
#line hidden
                ));
                __builder2.AddAttribute(10, "onclick", Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Web.MouseEventArgs>(this, 
#line 11 "C:\Users\agust\source\repos\SurcosBlazor\Client\Shared\BackOfficeLayout.razor"
                                                                                  ()=>toggleNavBar = !toggleNavBar

#line default
#line hidden
                ));
                __builder2.AddMarkupContent(11, "\r\n                ");
                __builder2.OpenElement(12, "i");
                __builder2.AddAttribute(13, "class", 
#line 12 "C:\Users\agust\source\repos\SurcosBlazor\Client\Shared\BackOfficeLayout.razor"
                            toggleNavBar ? "fas fa-stream":"fas fa-bars"

#line default
#line hidden
                );
                __builder2.CloseElement();
                __builder2.AddMarkupContent(14, "\r\n            ");
                __builder2.CloseElement();
                __builder2.AddMarkupContent(15, "\r\n\r\n            ");
                __builder2.OpenComponent<SurcosBlazor.Client.Shared.NavMenu>(16);
                __builder2.CloseComponent();
                __builder2.AddMarkupContent(17, "\r\n            ");
                __builder2.OpenElement(18, "div");
                __builder2.AddAttribute(19, "class", "pl-1 enlacesLogin");
                __builder2.AddMarkupContent(20, "\r\n                ");
                __builder2.OpenComponent<SurcosBlazor.Client.Shared.EnlacesLogin>(21);
                __builder2.CloseComponent();
                __builder2.AddMarkupContent(22, "\r\n            ");
                __builder2.CloseElement();
                __builder2.AddMarkupContent(23, "\r\n        ");
                __builder2.CloseElement();
                __builder2.AddMarkupContent(24, "\r\n\r\n        ");
                __builder2.OpenElement(25, "div");
                __builder2.AddAttribute(26, "class", "main");
                __builder2.AddMarkupContent(27, "\r\n            ");
                __builder2.OpenElement(28, "div");
                __builder2.AddAttribute(29, "class", "content px-4");
                __builder2.AddMarkupContent(30, "\r\n                ");
                __builder2.AddContent(31, 
#line 23 "C:\Users\agust\source\repos\SurcosBlazor\Client\Shared\BackOfficeLayout.razor"
                 Body

#line default
#line hidden
                );
                __builder2.AddMarkupContent(32, "\r\n            ");
                __builder2.CloseElement();
                __builder2.AddMarkupContent(33, "\r\n        ");
                __builder2.CloseElement();
                __builder2.AddMarkupContent(34, "\r\n        ");
                __builder2.OpenComponent<Blazored.Toast.BlazoredToasts>(35);
                __builder2.AddAttribute(36, "IconType", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Blazored.Toast.IconType?>(
#line 26 "C:\Users\agust\source\repos\SurcosBlazor\Client\Shared\BackOfficeLayout.razor"
                                  IconType.FontAwesome

#line default
#line hidden
                ));
                __builder2.AddAttribute(37, "SuccessClass", "success-toast-override");
                __builder2.AddAttribute(38, "Timeout", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Int32>(
#line 28 "C:\Users\agust\source\repos\SurcosBlazor\Client\Shared\BackOfficeLayout.razor"
                                 5

#line default
#line hidden
                ));
                __builder2.AddAttribute(39, "SuccessIcon", "fa fa-check");
                __builder2.AddAttribute(40, "ErrorIcon", "fa fa-times");
                __builder2.AddAttribute(41, "InfoIcon", "fa fa-info");
                __builder2.AddAttribute(42, "WarningIcon", "fa fa-warning");
                __builder2.CloseComponent();
                __builder2.AddMarkupContent(43, "\r\n    ");
            }
            ));
            __builder.AddAttribute(44, "NotAuthorized", (Microsoft.AspNetCore.Components.RenderFragment<Microsoft.AspNetCore.Components.Authorization.AuthenticationState>)((context) => (__builder2) => {
                __builder2.AddMarkupContent(45, "\r\n        ");
                __builder2.AddMarkupContent(46, "<h2 style=\"text-align:center;\">Ups no estás autorizado! <a href=\"/\">Volver</a></h2>\r\n    ");
            }
            ));
            __builder.CloseComponent();
        }
        #pragma warning restore 1998
#line 39 "C:\Users\agust\source\repos\SurcosBlazor\Client\Shared\BackOfficeLayout.razor"
      
    public bool toggleNavBar { get; set; } = false;

#line default
#line hidden
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private NavigationManager uri { get; set; }
    }
}
#pragma warning restore 1591