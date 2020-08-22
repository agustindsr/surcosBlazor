using System;
using System.Collections.Generic;
using System.Text;

namespace SurcosBlazor.Shared.Informes.InformesVentas
{
    public class InformeGananciasPorListaPrecios
    {
        public DateTime fecha { get; set; }
        public List<valores> valores { get; set; } = new List<valores>();
    }

    public class valores {

        public string nombreLista { get; set; }
        public decimal importe { get; set; }
    }
}
