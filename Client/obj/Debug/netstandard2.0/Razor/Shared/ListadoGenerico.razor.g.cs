#pragma checksum "C:\Users\agust\source\repos\SurcosBlazor\Client\Shared\ListadoGenerico.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "0c950129e912fca3afc50fc4f984902ff5945deb"
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
    public partial class ListadoGenerico<T> : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
            __builder.AddMarkupContent(0, "<style>\r\n</style>\r\n\r\n");
#line 5 "C:\Users\agust\source\repos\SurcosBlazor\Client\Shared\ListadoGenerico.razor"
 if (listado == null)
{

#line default
#line hidden
            __builder.AddMarkupContent(1, @"<div class=""d-flex justify-content-center"">
    <div class=""loadingio-spinner-gear-sf2yw67lypl"">
        <div class=""ldio-2bbk9jzsuoo"">
            <div><div></div><div></div><div></div><div></div><div></div><div></div><div></div><div></div></div>
        </div>
    </div>
</div>
");
#line 14 "C:\Users\agust\source\repos\SurcosBlazor\Client\Shared\ListadoGenerico.razor"

}
else if (listado.Count == 0)
{
    if (NoHayRegistros != null)

    {
        

#line default
#line hidden
            __builder.AddContent(2, 
#line 21 "C:\Users\agust\source\repos\SurcosBlazor\Client\Shared\ListadoGenerico.razor"
         NoHayRegistros

#line default
#line hidden
            );
#line 21 "C:\Users\agust\source\repos\SurcosBlazor\Client\Shared\ListadoGenerico.razor"
                       

    }
    else
    {

#line default
#line hidden
            __builder.AddContent(3, "        ");
            __builder.AddMarkupContent(4, "<p><strong>No hay registros para mostrar</strong></p>\r\n");
#line 27 "C:\Users\agust\source\repos\SurcosBlazor\Client\Shared\ListadoGenerico.razor"
    }
}
else
{
    

#line default
#line hidden
            __builder.AddContent(5, 
#line 31 "C:\Users\agust\source\repos\SurcosBlazor\Client\Shared\ListadoGenerico.razor"
     HayRegistros

#line default
#line hidden
            );
#line 31 "C:\Users\agust\source\repos\SurcosBlazor\Client\Shared\ListadoGenerico.razor"
                 
}

#line default
#line hidden
        }
        #pragma warning restore 1998
#line 35 "C:\Users\agust\source\repos\SurcosBlazor\Client\Shared\ListadoGenerico.razor"
 
    [Parameter] public List<T> listado { get; set; }
    [Parameter]

    public RenderFragment HayRegistros { get; set; }
    [Parameter]
    public RenderFragment NoHayRegistros { get; set; }


#line default
#line hidden
    }
}
#pragma warning restore 1591