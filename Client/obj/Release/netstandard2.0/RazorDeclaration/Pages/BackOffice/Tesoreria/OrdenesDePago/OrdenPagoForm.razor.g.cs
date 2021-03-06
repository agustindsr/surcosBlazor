#pragma checksum "C:\Users\agust\source\repos\SurcosBlazor\Client\Pages\BackOffice\Tesoreria\OrdenesDePago\OrdenPagoForm.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "75c7c56999ab06ed22bced9b95bdc56eccac1592"
// <auto-generated/>
#pragma warning disable 1591
#pragma warning disable 0414
#pragma warning disable 0649
#pragma warning disable 0169

namespace SurcosBlazor.Client.Pages.BackOffice.Tesoreria.OrdenesDePago
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
#line 8 "C:\Users\agust\source\repos\SurcosBlazor\Client\Pages\BackOffice\Tesoreria\OrdenesDePago\OrdenPagoForm.razor"
           [Authorize(Roles = "Admin, Tesoreria")]

#line default
#line hidden
    [Microsoft.AspNetCore.Components.LayoutAttribute(typeof(BackOfficeLayout))]
    [Microsoft.AspNetCore.Components.RouteAttribute("/BackOffice/Tesoreria/OrdenPago")]
    public partial class OrdenPagoForm : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
        }
        #pragma warning restore 1998
#line 169 "C:\Users\agust\source\repos\SurcosBlazor\Client\Pages\BackOffice\Tesoreria\OrdenesDePago\OrdenPagoForm.razor"
       
    public OrdenPago ordenPago { get; set; }
    public List<FacturaCompras> facturasPendientes { get; set; } = new List<FacturaCompras>();
    public System.Security.Claims.ClaimsPrincipal User { get; set; }
    public string userName { get; set; }
    public List<Caja> cajas { get; set; }
    public bool cargando { get; set; }
    protected override async Task OnInitializedAsync()
    {

        ordenPago = new OrdenPago { movimientosCaja = new List<MovimientoCaja>(), Imputaciones = new List<ImputacionComprobantesCompra>() };

        var authState = await authStateProvider.GetAuthenticationStateAsync();
        User = authState.User;
        userName = User.Identity.Name;
        await ListarCajas();
    }


    public async Task ListarCajas()
    {
        cajas = await http.GetJsonAsync<List<Caja>>($"api/caja/cajasHabilitadas?userName={userName}");

    }

    public async Task<List<Proveedor>> buscarProveedores(string name)
    {
        return await http.GetJsonAsync<List<Proveedor>>($"api/proveedor?cantidadDeRegistros=25&filtro={name}");
    }

    public async Task proveedorSeleccionado(Proveedor proveedor)
    {
        ordenPago.Proveedor = proveedor;
        ordenPago.ProveedorId = proveedor.Id;
        await BuscarComprobantesPendientes();
        this.StateHasChanged();
    }
    public async Task BuscarComprobantesPendientes()
    {

        facturasPendientes = await http.GetJsonAsync<List<FacturaCompras>>($"api/facturaCompra/facturasPorProveedorParaRecibo?proveedorId={ordenPago.ProveedorId}");
    }


    public async Task CrearOrdenPago()
    {
        ordenPago.Proveedor.Domicilio = null;
        if (ordenPago.Imputaciones.Count > 0)
        {
            ordenPago.EstadoReciboId = 1;
        }
        else
        {
            ordenPago.EstadoReciboId = 2;

        }
        ordenPago.totalImputado = ordenPago.Imputaciones.Sum(x => x.totalImputado);
        var respuesta = await repositorio.Post("api/OrdenPago", ordenPago);
        cargando = false;

        if (!respuesta.Error)
        {
            uri.NavigateTo($"/BackOffice/Tesoreria/ListadoOrdenesPago");
            toastService.ShowSuccess("Se creó correctamente el ordenPago");
        }
        else
        {
            toastService.ShowError(respuesta.HttpResponseMessage.Content.ReadAsStringAsync().Result);
        }
    }

#line default
#line hidden
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private NavigationManager uri { get; set; }
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private IToastService toastService { get; set; }
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private IRepositorio repositorio { get; set; }
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private AuthenticationStateProvider authStateProvider { get; set; }
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private HttpClient http { get; set; }
    }
}
#pragma warning restore 1591
