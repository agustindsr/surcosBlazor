#pragma checksum "C:\Users\agust\source\repos\SurcosBlazor\Client\Pages\ECommerce\ProductoCard.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "f209e9f65791bea6efc39f65f9486837e1ea910f"
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
    public partial class ProductoCard : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
        }
        #pragma warning restore 1998
#line 75 "C:\Users\agust\source\repos\SurcosBlazor\Client\Pages\ECommerce\ProductoCard.razor"
      
    public int cantidad { get; set; } = 0;
    [Parameter]
    public Producto producto { get; set; }
    [Parameter] public List<ProductoEnCarritoModel> productosEnCarrito { get; set; }
    public bool focus { get; set; } = false;
    [Parameter]public bool esElUltimo { get; set; } = false;

    [Parameter] public int listaId { get; set; }
    [Parameter] public List<ProductoPresentacion> productoPresentaciones { get; set; }
    public ProductoPresentacion productoPresentacion { get; set; }
    [Parameter]public Func<ProductoPresentacion,decimal> calcularPrecio { get; set; }
    [Parameter] public Func<ProductoPresentacion, decimal> descuento { get; set; }
    [Parameter]
    public Func<ProductoPresentacion, int,int, Task> addProducto { get; set; }
    [Parameter] public Func<ProductoPresentacion,Task> deleteProducto { get; set; }

    public decimal _descuento { get; set; }
    public decimal _precio { get; set; }

    protected override void OnParametersSet()
    {
        if (producto != null && producto.Id != 0 && productoPresentacion == null) {

            productoPresentacion = productoPresentaciones[0];
        }

        verCantidadEnCarrito(productoPresentacion);
        calcularDescuentoYPrecio();
        this.StateHasChanged();
    }

    public void verCantidadEnCarrito(ProductoPresentacion productoPresentacion) {

        if (productosEnCarrito.FirstOrDefault(x => x.producto.Id == productoPresentacion.Id) != null)
        {
            cantidad = productosEnCarrito.FirstOrDefault(x => x.producto.Id == productoPresentacion.Id).cantidad;
        }
        else
        {
            cantidad = 0;
        }
    }
    public void calcularDescuentoYPrecio() {
        _descuento = descuento.Invoke(productoPresentacion);
        _precio = calcularPrecio.Invoke(productoPresentacion);
    }


#line default
#line hidden
    }
}
#pragma warning restore 1591