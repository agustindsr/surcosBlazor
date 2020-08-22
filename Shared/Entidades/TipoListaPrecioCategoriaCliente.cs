using System;
using System.Collections.Generic;
using System.Text;

namespace SurcosBlazor.Shared.Entidades
{
    public class TipoListaPrecioCategoriaCliente
    {
        public int Id { get; set; }
        public int TipoListaPrecioId { get; set; }
        public TipoListaPrecio TipoListaPrecio { get; set; }
        public int CategoriaClienteId { get; set; }
        public CategoriaCliente CategoriaCliente { get; set; }
    }
}
