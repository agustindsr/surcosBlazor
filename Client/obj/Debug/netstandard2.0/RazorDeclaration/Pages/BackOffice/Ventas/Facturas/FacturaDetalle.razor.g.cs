#pragma checksum "C:\Users\agust\source\repos\SurcosBlazor\Client\Pages\BackOffice\Ventas\Facturas\FacturaDetalle.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "4a0d8c7dd6178e9888e0d09f207d879234ef9f26"
// <auto-generated/>
#pragma warning disable 1591
#pragma warning disable 0414
#pragma warning disable 0649
#pragma warning disable 0169

namespace SurcosBlazor.Client.Pages.BackOffice.Ventas.Facturas
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
#line 9 "C:\Users\agust\source\repos\SurcosBlazor\Client\Pages\BackOffice\Ventas\Facturas\FacturaDetalle.razor"
           [Authorize(Roles = "Admin, Ventas")]

#line default
#line hidden
    [Microsoft.AspNetCore.Components.LayoutAttribute(typeof(BackOfficeLayout))]
    [Microsoft.AspNetCore.Components.RouteAttribute("/BackOffice/Ventas/Comprobante/{Id:int}")]
    public partial class FacturaDetalle : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
        }
        #pragma warning restore 1998
#line 184 "C:\Users\agust\source\repos\SurcosBlazor\Client\Pages\BackOffice\Ventas\Facturas\FacturaDetalle.razor"
       
    [Parameter]
    public int Id { get; set; }
    public Factura factura { get; set; }
    public string userName { get; set; }
    public System.Security.Claims.ClaimsPrincipal User { get; set; }



    public ListaPrecios lista { get; set; }

    protected override async Task OnParametersSetAsync()
    {
        if (Id != 0)
        {
            factura = await http.GetJsonAsync<Factura>($"api/Factura/{Id}");
            await ActualizarMapa();
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




    public async Task ActualizarMapa()
    {
        if (factura.Domicilio.numero != 0 && !string.IsNullOrWhiteSpace(factura.Domicilio.calle) && factura.Domicilio.Provincia != null && factura.Domicilio.Departamento != null && !string.IsNullOrWhiteSpace(factura.Domicilio.Departamento.nombre) && !string.IsNullOrWhiteSpace(factura.Domicilio.Provincia.nombre))
        {
            List<decimal> coords = await js.InvokeAsync<List<decimal>>("buscarCoordenadas", $"{factura.Domicilio.numero}+{factura.Domicilio.calle}+{factura.Domicilio.Departamento.nombre}+{factura.Domicilio.Provincia.nombre}+Argentina", "mapaFacturaForm");
            factura.Domicilio.latitud = coords[0];
            factura.Domicilio.longitud = coords[1];

        }
        else
        {
            Console.WriteLine("No estan todos los campos completos");
        }
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