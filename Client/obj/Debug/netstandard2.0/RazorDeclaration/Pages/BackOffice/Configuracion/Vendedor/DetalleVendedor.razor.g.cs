#pragma checksum "C:\Users\agust\source\repos\SurcosBlazor\Client\Pages\BackOffice\Configuracion\Vendedor\DetalleVendedor.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "b3b1cb385c027f451fc8265ff74893337c8fafb2"
// <auto-generated/>
#pragma warning disable 1591
#pragma warning disable 0414
#pragma warning disable 0649
#pragma warning disable 0169

namespace SurcosBlazor.Client.Pages.BackOffice.Configuracion.Vendedor
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
#line 8 "C:\Users\agust\source\repos\SurcosBlazor\Client\Pages\BackOffice\Configuracion\Vendedor\DetalleVendedor.razor"
using SurcosBlazor.Client.Repositorio;

#line default
#line hidden
#line 2 "C:\Users\agust\source\repos\SurcosBlazor\Client\Pages\BackOffice\Configuracion\Vendedor\DetalleVendedor.razor"
           [Authorize(Roles = "Admin, Configuracion")]

#line default
#line hidden
    [Microsoft.AspNetCore.Components.LayoutAttribute(typeof(BackOfficeLayout))]
    [Microsoft.AspNetCore.Components.RouteAttribute("/BackOffice/Configuraciones/Vendedor/{Id:int}")]
    public partial class DetalleVendedor : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
        }
        #pragma warning restore 1998
#line 140 "C:\Users\agust\source\repos\SurcosBlazor\Client\Pages\BackOffice\Configuracion\Vendedor\DetalleVendedor.razor"
       
    [Parameter]
    public int Id { get; set; } = 0;
    public string formulario { get; set; } = "";
    public Vendedor vendedor { get; set; }
    public Provincia provincia { get; set; }
    public VendedorDepartamento vendedorDepartamento { get; set; }

    public TablaGenerica<VendedorDepartamento> tablaGenerica { get; set; }
    protected override async Task OnInitializedAsync()
    {
        await ListarVendedor();
    }

    public async Task ListarVendedor()
    {
        var responseHttp = await repositorio.Get<Vendedor>($"api/vendedor/{Id}");
        if (!responseHttp.Error)
        {
            vendedor = responseHttp.Response;
        }

    }
    public async Task<List<Provincia>> buscarProvinciasInputTypeAHead(string seachText)
    {

        return await http.GetJsonAsync<List<Provincia>>($"api/provincia/?filtro={seachText}&cantidadDeRegistros=15");
    }


    public async Task EliminarVendedor(Vendedor vendedor)
    {
        vendedor.enabled = false;
        await http.PutJsonAsync($"api/vendedor/{vendedor.Id}", vendedor);
        this.vendedor = null;

    }

    public async Task EliminarVendedorDepartamento(VendedorDepartamento vendedorDepartamento)
    {


        await http.DeleteAsync($"api/vendedordepartamento/{vendedorDepartamento.Id}");
        await ListarVendedor();

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


#line default
#line hidden
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private IRepositorio repositorio { get; set; }
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private IJSRuntime js { get; set; }
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private NavigationManager uri { get; set; }
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private HttpClient http { get; set; }
    }
}
#pragma warning restore 1591
