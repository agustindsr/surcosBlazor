#pragma checksum "C:\Users\agust\source\repos\SurcosBlazor\Client\Pages\BackOffice\Configuracion\ListaDePreciosC\ListaPreciosForm.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "67f428649296ebec656d660faeda18899ddd31c0"
// <auto-generated/>
#pragma warning disable 1591
#pragma warning disable 0414
#pragma warning disable 0649
#pragma warning disable 0169

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
#line 4 "C:\Users\agust\source\repos\SurcosBlazor\Client\Pages\BackOffice\Configuracion\ListaDePreciosC\ListaPreciosForm.razor"
           [Authorize(Roles = "Admin, Configuracion")]

#line default
#line hidden
    [Microsoft.AspNetCore.Components.LayoutAttribute(typeof(BackOfficeLayout))]
    [Microsoft.AspNetCore.Components.RouteAttribute("/BackOffice/Configuraciones/ListaPrecios/{Id:int}")]
    public partial class ListaPreciosForm : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
        }
        #pragma warning restore 1998
#line 227 "C:\Users\agust\source\repos\SurcosBlazor\Client\Pages\BackOffice\Configuracion\ListaDePreciosC\ListaPreciosForm.razor"
       
    [Parameter] public int Id { get; set; }
    public ListaPrecios ListaPrecios { get; set; }
    [Parameter] public EventCallback callback { get; set; }
    public List<ProductoPresentacion> productoPresentaciones { get; set; }
    public List<CategoriaProducto> categorias { get; set; }
    public List<Producto> productos { get; set; }
    public List<TipoListaPrecio> tiposListaDePrecios { get; set; }
    public bool cargando { get; set; } = false;
    public List<ListaPrecios> listas { get; set; }

    protected override async Task OnInitializedAsync()
    {
        if (Id == 0)
        {
            ListaPrecios = new ListaPrecios();
        }
        else {
            ListaPrecios = await http.GetJsonAsync<ListaPrecios>($"api/ListaPrecios/{Id}");

        }

        await ListarTiposListaDePrecios();

        await ListarProductosPresentacion();
        productos = productoPresentaciones.Select(x => x.Producto).Distinct().ToList();
        categorias = productos.Select(x => x.CategoriaProducto).Distinct().ToList();


    }
    public async Task ListarProductosPresentacion()
    {
        productoPresentaciones = await http.GetJsonAsync<List<ProductoPresentacion>>("api/ProductoPresentacion/ListaPrecios");

    }

    public async Task ListarListas()
    {
        listas = await http.GetJsonAsync<List<ListaPrecios>>("api/ListaPrecios");
    }
    public async Task ToggleProducto(ProductoPresentacion producto)
    {

        decimal costoFormulado = 0.00M;
        if (ListaPrecios.DetalleListaPrecios.Where(x => x.ProductoPresentacionId == producto.Id).Count() == 0)
        {

            if (producto.esFormulado)
            {
                

#line default
#line hidden
#line 276 "C:\Users\agust\source\repos\SurcosBlazor\Client\Pages\BackOffice\Configuracion\ListaDePreciosC\ListaPreciosForm.razor"
                 if (producto.FormulaProducto != null)
                {
                    costoFormulado = await http.GetJsonAsync<decimal>($"api/FormulaProducto/CostoFormula?FormulaId={producto.FormulaProducto.Id}");
                }

#line default
#line hidden
#line 279 "C:\Users\agust\source\repos\SurcosBlazor\Client\Pages\BackOffice\Configuracion\ListaDePreciosC\ListaPreciosForm.razor"
                 

            }


            ListaPrecios.DetalleListaPrecios.Add(new DetalleListaPrecios
            {
                ProductoPresentacionId = producto.Id,
                precioCosto = producto.esFormulado ? costoFormulado : producto.costo
            });
        }

        else
        {

            ListaPrecios.DetalleListaPrecios.Remove(ListaPrecios.DetalleListaPrecios.FirstOrDefault(x => x.ProductoPresentacionId == producto.Id));
        }
        this.StateHasChanged();
    }
    public async Task<decimal> BuscarCosto(ProductoPresentacion producto){
        if (producto.esFormulado && producto.FormulaProducto != null)
        {

            return await http.GetJsonAsync<decimal>($"api/FormulaProducto/CostoFormula?FormulaId={producto.FormulaProducto?.Id}");

        }
        else {
            return producto.costo;
        }

    }
    public async Task ActualizarTodosLosCostos() {

        foreach (DetalleListaPrecios detalle in ListaPrecios.DetalleListaPrecios) {

            detalle.precioCosto = await BuscarCosto(productoPresentaciones.Find(x => x.Id == detalle.ProductoPresentacionId));
            calcularTotal(detalle, "rentabilidad"); this.StateHasChanged();
        }
        cargando = false;
    }
    public async Task ListarTiposListaDePrecios()
    {
        tiposListaDePrecios = await http.GetJsonAsync<List<TipoListaPrecio>>("api/TipoListaPrecio/DisponiblesParaCrearListaPrecios");
    }

    public void calcularTotal(DetalleListaPrecios detalle, string quienfue)
    {

        if (quienfue == "rentabilidad")
        {
            detalle.precioUnitarioFinal = Math.Round((detalle.precioCosto * (1 + detalle.porcentajeRentabilidad / 100)) * (1 - detalle.porcentajeDescuento / 100), 2);
        }
        if (quienfue == "precioFinal")
        {
            detalle.porcentajeRentabilidad = Math.Round(((detalle.precioUnitarioFinal / ((1 - detalle.porcentajeDescuento / 100) * detalle.precioCosto)) - 1) * 100, 2);
        }
        if (quienfue == "descuento")
        {
            detalle.precioUnitarioFinal = Math.Round((detalle.precioCosto * (1 + detalle.porcentajeRentabilidad / 100)) * (1 - detalle.porcentajeDescuento / 100), 2);
        }
    }

    public async Task Confirmar()
    {
        try
        {
            if (Id == 0)
            {
                ListaPrecios.TipoListaPrecio = null;
                ListaPrecios.DetalleListaPrecios.ForEach((x) => { x.ProductoPresentacion = null; });
                await http.PostJsonAsync("api/ListaPrecios", ListaPrecios);
                cargando = false;
                toastService.ShowSuccess($"Se creó correctamente la Lista de Precio");
                uri.NavigateTo("/BackOffice/Configuraciones/ListaListaPrecios");

            }
            else
            {
                await http.PutJsonAsync($"api/ListaPrecios/{ListaPrecios.Id}", ListaPrecios);
                cargando = false;

                toastService.ShowSuccess($"Se editó correctamente la Lista de Precio ");
                uri.NavigateTo("/BackOffice/Configuraciones/ListaListaPrecios");
            }
        }
        catch (Exception ex)
        {
            cargando = false;

            toastService.ShowError($"Ocurrió un error:  {ex.Message}");

        }


        await CloseAllModals();

        await callback.InvokeAsync(new Object());

    }
    public async Task CloseAllModals()
    {

        await js.InvokeAsync<object>("CloseAllModals");
    }
    public async Task ClonarLista(int Id) {

        ListaPrecios listaAClonar = await http.GetJsonAsync<ListaPrecios>($"api/ListaPrecios/{Id}");
        ListaPrecios.DetalleListaPrecios = new List<DetalleListaPrecios>();
        listaAClonar.DetalleListaPrecios.ForEach(x => { x.Id = 0; ListaPrecios.DetalleListaPrecios.Add(x); });
        cargando = false;
    }


    public async Task ToggleModal(string id)
    {
        await js.InvokeAsync<object>("ModalToggle", id);
    }

#line default
#line hidden
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private IJSRuntime js { get; set; }
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private NavigationManager uri { get; set; }
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private IToastService toastService { get; set; }
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private HttpClient http { get; set; }
    }
}
#pragma warning restore 1591
