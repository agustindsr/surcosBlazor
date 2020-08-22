using Microsoft.AspNet.Identity;
using SurcosBlazor.Shared.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace SurcosBlazor.Shared.Informes.InformesVentas
{
   public class InformeVentasPorLocalidad
    {
        public string provincia { get; set; }
        public string localidad { get; set; }
        public decimal total { get; set; }
    }
}
