using System;
using System.Collections.Generic;
using System.Text;

namespace SurcosBlazor.Shared.Informes.InformesVentas
{
    public class InformeVentasPorListaPrecios
    {
        public DateTime fecha { get; set; }
        public List<valores2> valores { get; set; } = new List<valores2>();
    }
    public class valores2
    {

        public string nombreLista { get; set; }
        public decimal importe { get; set; }
    }
}
   

