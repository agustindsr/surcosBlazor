using System;
using System.Collections.Generic;
using System.Text;

namespace SurcosBlazor.Shared.Entidades
{
    public class TipoListaPrecioProvincia
    {
        public int Id { get; set; }
        public int TipoListaPrecioId { get; set; }
        public TipoListaPrecio TipoListaPrecio { get; set; }
        public int ProvinciaId { get; set; }
        public Provincia Provincia { get; set; }
    }
}
