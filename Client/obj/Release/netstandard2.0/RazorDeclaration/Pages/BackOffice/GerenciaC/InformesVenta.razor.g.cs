#pragma checksum "C:\Users\agust\source\repos\SurcosBlazor\Client\Pages\BackOffice\GerenciaC\InformesVenta.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "d2b0ede8a643b81f9acfa1aa6f6e1dc3e3269e39"
// <auto-generated/>
#pragma warning disable 1591
#pragma warning disable 0414
#pragma warning disable 0649
#pragma warning disable 0169

namespace SurcosBlazor.Client.Pages.BackOffice.GerenciaC
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
#line 4 "C:\Users\agust\source\repos\SurcosBlazor\Client\Pages\BackOffice\GerenciaC\InformesVenta.razor"
using SurcosBlazor.Shared.Entidades.Informes.InformesVentas;

#line default
#line hidden
    public partial class InformesVenta : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
        }
        #pragma warning restore 1998
#line 162 "C:\Users\agust\source\repos\SurcosBlazor\Client\Pages\BackOffice\GerenciaC\InformesVenta.razor"
           
        public string userName { get; set; }
        public DateTime fechaDesde { get; set; } = DateTime.Now.AddDays((-1 * DateTime.Now.Day) + 1);
        public DateTime fechaHasta { get; set; } = DateTime.Now;
        public List<Vendedor> vendedores { get; set; } = new List<Vendedor>();
        public List<Provincia> provincias { get; set; } = new List<Provincia>();

        public InformeGeneralVentas informeVentas { get; set; }
        public Provincia provincia { get; set; }
        public Vendedor vendedor { get; set; }
        protected override async Task OnInitializedAsync()
        {

            var authState = await authStateProvider.GetAuthenticationStateAsync();
            userName = authState.User.Identity.Name;
            vendedores = await http.GetJsonAsync<List<Vendedor>>($"api/vendedor");
            provincias = await http.GetJsonAsync<List<Provincia>>($"api/provincia");

        }

        public async Task armarInforme()
        {
            int provinciaId = provincia == null ? 0 : provincia.Id;
            int vendedorId = vendedor == null ? 0 : vendedor.Id;

            informeVentas = await http.GetJsonAsync<InformeGeneralVentas>($"api/pedido/InformeGeneralVentasVenta?userName={userName}&fechaDesde={fechaDesde.ToString("MM/dd/yyyy")}&fechaHasta={fechaHasta.ToString("MM/dd/yyyy")}&provinciaId={provinciaId}&vendedorId={vendedorId}");
            await js.InvokeVoidAsync("graficoVendedores", informeVentas.InformePedidosVendedores, "pedidoPorVendededor");
            await js.InvokeVoidAsync("ventasPorZona", informeVentas.InformeVentasPorLocalidad.OrderBy(x => x.provincia).ThenBy(x => x.localidad).ThenByDescending(x => x.total), "ventasPorZona");
            await js.InvokeVoidAsync("graficoGananciaPorListaPrecios", informeVentas.informeGananciasPorListaPrecios, "gananciasPorLista");
            await js.InvokeVoidAsync("graficoGananciaPorListaPrecios", informeVentas.informeVentasPorListaPrecios, "ventasPorLista");
            await js.InvokeVoidAsync("gananciasPorLista", informeVentas.informeTotalVentasPorListaPrecios, "totalVentasPorLista");
            await js.InvokeVoidAsync("gananciasPorLista", informeVentas.informeTotalGanancias, "totalGanadoPorLista");


        }

    

#line default
#line hidden
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private HttpClient http { get; set; }
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private AuthenticationStateProvider authStateProvider { get; set; }
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private IJSRuntime js { get; set; }
    }
}
#pragma warning restore 1591
