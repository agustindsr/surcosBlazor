#pragma checksum "C:\Users\agust\source\repos\SurcosBlazor\Client\Pages\ECommerce\VendedorPerfil.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "01c0f1fe0f453637d570407d01fbf647a3137ad2"
// <auto-generated/>
#pragma warning disable 1591
#pragma warning disable 0414
#pragma warning disable 0649
#pragma warning disable 0169

namespace SurcosBlazor.Client.Pages.ECommerce
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
#line 4 "C:\Users\agust\source\repos\SurcosBlazor\Client\Pages\ECommerce\VendedorPerfil.razor"
using SurcosBlazor.Client.Repositorio;

#line default
#line hidden
    [Microsoft.AspNetCore.Components.LayoutAttribute(typeof(BackOfficeLayout))]
    public partial class VendedorPerfil : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
        }
        #pragma warning restore 1998
#line 117 "C:\Users\agust\source\repos\SurcosBlazor\Client\Pages\ECommerce\VendedorPerfil.razor"
       

    public string formulario { get; set; } = "";
    public Vendedor vendedor { get; set; }
    public Provincia provincia { get; set; }
    public VendedorDepartamento vendedorDepartamento { get; set; }
    public List<Vendedor> vendedores { get; set; }
    public TablaGenerica<VendedorDepartamento> tablaGenerica { get; set; }
    [Parameter] public string userName { get; set; }

    public async Task ListarVendedores()
    {
        var respuesta = await repositorio.Get<List<Vendedor>>($"api/vendedor/vendedoresHabilitados?userName={userName}");
        if (!respuesta.Error)
        {
            vendedores = respuesta.Response;
            if (vendedores.Count > 0)
            {
                vendedor = vendedores[0];
                await ListarVendedor();
            }
        }
        this.StateHasChanged();

    }
    public async Task ListarVendedor()
    {
        var responseHttp = await repositorio.Get<Vendedor>($"api/vendedor/{vendedor.Id}");
        if (!responseHttp.Error)
        {
            vendedor = responseHttp.Response;
        }
        this.StateHasChanged();
    }




    public Vendedor ElementoSeleccionado(Vendedor prov)
    {

        vendedor = prov;
        this.StateHasChanged();
        return vendedor;
    }


    public VendedorDepartamento VendedorDepartamentoSeleccionado(VendedorDepartamento vendedorDepartamento)
    {
        this.vendedorDepartamento = vendedorDepartamento;
        return vendedorDepartamento;
    }
    public async Task ToggleModal(string id)
    {
        await js.InvokeAsync<object>("ModalToggle", id);
    }

#line default
#line hidden
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private IRepositorio repositorio { get; set; }
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private IJSRuntime js { get; set; }
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private HttpClient http { get; set; }
    }
}
#pragma warning restore 1591