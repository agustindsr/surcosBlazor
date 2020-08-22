using System;
using System.Collections.Generic;
using System.Text;

namespace SurcosBlazor.Shared.Entidades
{
    public class ListaPrecios
    {
        public int Id { get; set; }
        public DateTime fecha { get; set; } = DateTime.UtcNow;
        public virtual List<DetalleListaPrecios> DetalleListaPrecios { get; set; } = new List<DetalleListaPrecios>();
        public int? TipoListaPrecioId { get; set; }
        public TipoListaPrecio TipoListaPrecio { get; set; }
        public bool vigente { get; set; } = true;
        public int clasificacion { get; set; } = 0;


    }
}
