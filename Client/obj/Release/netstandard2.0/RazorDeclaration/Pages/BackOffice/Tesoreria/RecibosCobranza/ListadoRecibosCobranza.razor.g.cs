#pragma checksum "C:\Users\agust\source\repos\SurcosBlazor\Client\Pages\BackOffice\Tesoreria\RecibosCobranza\ListadoRecibosCobranza.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "d1353dc9bc77313d0955c46c87f41a4236cb8068"
// <auto-generated/>
#pragma warning disable 1591
#pragma warning disable 0414
#pragma warning disable 0649
#pragma warning disable 0169

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
#line 5 "C:\Users\agust\source\repos\SurcosBlazor\Client\Pages\BackOffice\Tesoreria\RecibosCobranza\ListadoRecibosCobranza.razor"
           [Authorize(Roles = "Admin, Tesoreria")]

#line default
#line hidden
    [Microsoft.AspNetCore.Components.LayoutAttribute(typeof(BackOfficeLayout))]
    [Microsoft.AspNetCore.Components.RouteAttribute("/BackOffice/Tesoreria/ListadoRecibosCobranza")]
    public partial class ListadoRecibosCobranza : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
        }
        #pragma warning restore 1998
#line 64 "C:\Users\agust\source\repos\SurcosBlazor\Client\Pages\BackOffice\Tesoreria\RecibosCobranza\ListadoRecibosCobranza.razor"
       
    public List<ReciboCobranzas> recibosCobranza { get; set; }
    private int paginaActual = 1;
    private int paginasTotales;
    private HttpResponseWrapper<List<ReciboCobranzas>> responseHttp;




    public int cantidadDeRegistrosAMostrar { get; set; } = 25;
    public int registrosTotales { get; set; }

    protected override async Task OnInitializedAsync()
    {


        await ListarRecibos();


    }

    public async Task ListarRecibos()
    {
        responseHttp = await repositorio.Get<List<ReciboCobranzas>>($"api/reciboCobranza?pagina={paginaActual}&cantidadDeRegistros={cantidadDeRegistrosAMostrar}");
        if (!responseHttp.Error)
        {
            recibosCobranza = responseHttp.Response;

            registrosTotales = int.Parse(responseHttp.HttpResponseMessage.Headers.GetValues("conteo").FirstOrDefault());

            paginasTotales = int.Parse(responseHttp.HttpResponseMessage.Headers.GetValues("totalPaginas").FirstOrDefault());

        }


    }
    private async Task paginaSeleccionada(int pagina)
    {
        paginaActual = pagina;
        await ListarRecibos();
    }


#line default
#line hidden
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private NavigationManager uri { get; set; }
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private IRepositorio repositorio { get; set; }
    }
}
#pragma warning restore 1591
