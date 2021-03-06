#pragma checksum "C:\Users\agust\source\repos\SurcosBlazor\Client\Pages\BackOffice\Ventas\Pedido\PedidoForm.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "fe0481b226141b40a91b68f6f5146cde83af9772"
// <auto-generated/>
#pragma warning disable 1591
#pragma warning disable 0414
#pragma warning disable 0649
#pragma warning disable 0169

namespace SurcosBlazor.Client.Pages.BackOffice.Ventas.Pedido
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
#line 9 "C:\Users\agust\source\repos\SurcosBlazor\Client\Pages\BackOffice\Ventas\Pedido\PedidoForm.razor"
           [Authorize(Roles = "Admin, Ventas")]

#line default
#line hidden
    [Microsoft.AspNetCore.Components.LayoutAttribute(typeof(BackOfficeLayout))]
    [Microsoft.AspNetCore.Components.RouteAttribute("/BackOffice/Ventas/Pedido/{Id:int}")]
    public partial class PedidoForm : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
        }
        #pragma warning restore 1998
#line 339 "C:\Users\agust\source\repos\SurcosBlazor\Client\Pages\BackOffice\Ventas\Pedido\PedidoForm.razor"
       
    [Parameter]
    public int Id { get; set; }
    public TablaGenerica<Cliente> tablaClientes { get; set; }
    public Pedido pedido { get; set; }
    public string userName { get; set; }
    public List<Vendedor> vendedores { get; set; }
    public System.Security.Claims.ClaimsPrincipal User { get; set; }
    public List<Provincia> provincias { get; set; }
    public List<Departamento> departamentos { get; set; }
    public CategoriaProducto categoria { get; set; } = new CategoriaProducto();
    public List<Producto> productos { get; set; }
    public List<ProductoPresentacion> productoPresentaciones { get; set; }
    public List<ListaPrecios> listas { get; set; }
    public List<EstadoPedido> estadosPedido { get; set; }
    public ListaPrecios lista { get; set; }
    public bool cargando { get; set; }
    public bool modoAdmin { get; set; }
    protected override async Task OnParametersSetAsync()
    {
        if (Id != 0)
        {
            pedido = await http.GetJsonAsync<Pedido>($"api/Pedido/{Id}");
            await ListarListas();
            await BuscarDepartamentosDeVendedor();

        }
        else { pedido = new Pedido { Domicilio = new Domicilio() }; }
        if (User.IsInRole("Admin"))
        {
            pedido.hechoPorAdmin = true;
        }

    }
    public async Task ListarListas()
    {
        if (pedido.ClienteId == 0 || pedido.ClienteId == null)
        {
            listas = await http.GetJsonAsync<List<ListaPrecios>>($"api/ListaPrecios/ListaPrecioEcommerce?provinciaId={pedido.Domicilio.ProvinciaId}&clienteId=0");

        }
        else
        {
            listas = await http.GetJsonAsync<List<ListaPrecios>>($"api/ListaPrecios/ListaPrecioEcommerce?provinciaId={pedido.Domicilio.ProvinciaId}&clienteId={pedido.ClienteId}");

        }

        if (listas.Count() > 0)
        {
            if (lista == null)
            {
                await seleccionarLista(pedido.ListaPreciosId != 0 ? pedido.ListaPreciosId : listas[0].Id);
                cargarProductos();
                await ActualizarMapa();

            }
        }
        else
        {
            lista = null;
            Console.WriteLine("OnParameter hice la lista nula");

        }
    }
    public async Task BuscarEstadoPedido()
    {

        estadosPedido = await http.GetJsonAsync<List<EstadoPedido>>("api/EstadoPedido");

    }
    public async Task ListarVendedores()
    {
        var respuesta = await repositorio.Get<List<Vendedor>>($"api/pedido/vendedoresHabilitados?userName={userName}");
        if (!respuesta.Error)
        {
            vendedores = respuesta.Response;
        }
        else
        {
            toastService.ShowError(await respuesta.HttpResponseMessage.Content.ReadAsStringAsync());
        }
    }
    protected override async Task OnInitializedAsync()
    {
        var authState = await authStateProvider.GetAuthenticationStateAsync();
        User = authState.User;
        userName = User.Identity.Name;

        await ListarVendedores();
        if (Id != 0)
        {
            await BuscarEstadoPedido();
        }
    }
    public async Task<List<Cliente>> buscarClientes(string clienteName)
    {
        if (User.IsInRole("Admin"))
        {
            return await http.GetJsonAsync<List<Cliente>>($"api/Cliente/ClientePorZonaVendedor?filtro={clienteName}&admin=true&vendedorId={pedido.Vendedor.Id}");
        }
        else
        {
            return await http.GetJsonAsync<List<Cliente>>($"api/Cliente/ClientePorZonaVendedor?filtro={clienteName}&admin=false&vendedorId={pedido.Vendedor.Id}");

        }
    }
    public async Task<Cliente> clienteSeleccionado(Cliente cliente)
    {
        Console.WriteLine($"cliente selccionado {cliente.Id}");
        pedido.Cliente = cliente;
        pedido.ClienteId = cliente.Id;
        pedido.Domicilio.calle = pedido.Cliente.Domicilio.calle;
        pedido.Domicilio.numero = pedido.Cliente.Domicilio.numero;
        pedido.Domicilio.manzana = pedido.Cliente.Domicilio.manzana;
        pedido.Domicilio.piso = pedido.Cliente.Domicilio.piso;
        pedido.Domicilio.Provincia = pedido.Cliente.Domicilio.Provincia;
        pedido.Domicilio.ProvinciaId = pedido.Cliente.Domicilio.ProvinciaId;
        pedido.Domicilio.Departamento = pedido.Cliente.Domicilio.Departamento;
        pedido.Domicilio.DepartamentoId = pedido.Cliente.Domicilio.DepartamentoId;
        pedido.apellidoCliente = pedido.Cliente.apellido;
        pedido.nombreCliente = pedido.Cliente.nombre;
        pedido.celularCliente = pedido.Cliente.celular;
        pedido.emailCliente = pedido.Cliente.email;
        await ListarListas();
        this.StateHasChanged();
        return cliente;
    }

    public async Task CrearPedido()
    {

        //creacion de pedido
        if (Id == 0)
        {
            var response = await repositorio.Post<Pedido>("api/Pedido", pedido);
            cargando = false;

            if (response.Error)
            {
                toastService.ShowError(await response.HttpResponseMessage.Content.ReadAsStringAsync());
            }
            else
            {

                toastService.ShowSuccess("Se creó el pedido correctamente!");
                pedido.detallePedido = new List<DetallePedido>();
                pedido.Vendedor = new Vendedor();
                pedido.VendedorId = 0;
                uri.NavigateTo("/BackOffice/Ventas/ListadoPedidos");
                this.StateHasChanged();
            }
        }
        //Edicion de pedido
        else
        {
            var response = await repositorio.Put<Pedido>($"api/Pedido/{pedido.Id}", pedido);
            cargando = false;

            if (response.Error)
            {
                toastService.ShowError(await response.HttpResponseMessage.Content.ReadAsStringAsync());
            }
            else
            {
                toastService.ShowSuccess("Se editó el pedido correctamente!");
                uri.NavigateTo("/BackOffice/Ventas/ListadoPedidos");
                this.StateHasChanged();
            }
        }
    }
    public async Task ToggleModal(string id)
    {

        await js.InvokeAsync<object>("ModalToggle", id);
    }

    public async Task BuscarDepartamentosDeVendedor()
    {

        departamentos = await http.GetJsonAsync<List<Departamento>>($"api/Departamento/DepartamentosDeVendedor?vendedorId={pedido.VendedorId}");
        provincias = departamentos.Select(x => x.Provincia).Distinct().ToList();
        this.StateHasChanged();
    }

    public void cargarProductos()
    {
        productoPresentaciones = null;
        productos = null;
        productoPresentaciones = lista.DetalleListaPrecios.Select(x => x.ProductoPresentacion).OrderBy(x => x.PresentacionProducto.cantidad).Distinct().ToList();
        productos = productoPresentaciones.Select(x => x.Producto).Distinct().OrderBy(x => x.nombre).ToList();

    }
    public async Task seleccionarLista(int id)
    {

        lista = await http.GetJsonAsync<ListaPrecios>($"api/ListaPrecios/{id}");
        pedido.ListaPrecios = lista;
        pedido.ListaPreciosId = lista.Id;
        cargarProductos();

    }
    public async Task ActualizarMapa()
    {
        if (pedido.Domicilio.numero != 0 && !string.IsNullOrWhiteSpace(pedido.Domicilio.calle) && pedido.Domicilio.Provincia != null && pedido.Domicilio.Departamento != null && !string.IsNullOrWhiteSpace(pedido.Domicilio.Departamento.nombre) && !string.IsNullOrWhiteSpace(pedido.Domicilio.Provincia.nombre))
        {
            List<decimal> coords = await js.InvokeAsync<List<decimal>>("buscarCoordenadas", $"{pedido.Domicilio.numero}+{pedido.Domicilio.calle}+{pedido.Domicilio.Departamento.nombre}+{pedido.Domicilio.Provincia.nombre}+Argentina", "mapaPedidoForm");
            pedido.Domicilio.latitud = coords[0];
            pedido.Domicilio.longitud = coords[1];

        }
        else
        {
            Console.WriteLine("No estan todos los campos completos");
        }
    }


    public void SelectPresentacionDetalle(int presentacionId, DetallePedido detalle)
    {


        detalle.ProductoPresentacion = productoPresentaciones
                                          .FirstOrDefault(x => x.PresentacionProductoId == presentacionId && x.ProductoId == detalle.ProductoPresentacion.ProductoId);

        detalle.ProductoPresentacionId = productoPresentaciones
                                        .FirstOrDefault(x => x.PresentacionProductoId == presentacionId && x.ProductoId == detalle.ProductoPresentacion.ProductoId).Id;


        detalle.precioUnitario = lista.DetalleListaPrecios.FirstOrDefault(x =>
        {
            return x.ProductoPresentacion.ProductoId == detalle.ProductoPresentacion.ProductoId
                   && x.ProductoPresentacion.PresentacionProductoId == detalle.ProductoPresentacion.PresentacionProductoId;
        }).precioUnitarioFinal;
        detalle.costo = lista.DetalleListaPrecios.FirstOrDefault(x =>
        {
            return x.ProductoPresentacion.ProductoId == detalle.ProductoPresentacion.ProductoId
                   && x.ProductoPresentacion.PresentacionProductoId == detalle.ProductoPresentacion.PresentacionProductoId;
        }).precioCosto;
        CalcularTotal();
        this.StateHasChanged();

    }


    public void CalcularTotal()
    {
        pedido.total = pedido.detallePedido.Sum(x => x.precioUnitario * x.cantidad);
        pedido.costoTotal = pedido.detallePedido.Sum(x => x.costo * x.cantidad);

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
