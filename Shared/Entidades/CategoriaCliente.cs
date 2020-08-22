using System.Collections.Generic;

namespace SurcosBlazor.Shared.Entidades
{
    public class CategoriaCliente
    {
        public int Id { get; set; }
        public string nombre { get; set; }
        
        public virtual List<TipoListaPrecioCategoriaCliente> TipoListaPrecioCategoriaClientes { get; set; }
        public virtual List<Cliente> Cliente { get; set; }

    }
}