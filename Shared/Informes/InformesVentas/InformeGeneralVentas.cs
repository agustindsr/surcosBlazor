using SurcosBlazor.Shared.Informes.InformesVentas;
using System;
using System.Collections.Generic;
using System.Text;

namespace SurcosBlazor.Shared.Entidades.Informes.InformesVentas
{
    public class InformeGeneralVentas
    {
        public int cantidadPEDPEN { get; set; }
        public int cantidadPEDCON { get; set; }
        public int cantidadPEDENT { get; set; }
        public int cantidadPEDANU { get; set; }
        public int cantidadFAC { get; set; }


        public int cantidadNC { get; set; }
        public int cantidadND { get; set; }
        public decimal totalFAC { get; set; }

        public decimal totalND { get; set; }

        public decimal totalNC { get; set; }
        public List<InformeVentasPorLocalidad> InformeVentasPorLocalidad { get; set; } = new List<InformeVentasPorLocalidad>();
        public List<InformePedidosVendedores> InformePedidosVendedores { get; set; } = new List<InformePedidosVendedores>();
        public List<InformeGananciasPorListaPrecios> informeGananciasPorListaPrecios { get; set; } = new List<InformeGananciasPorListaPrecios>();
        public List<InformeVentasPorListaPrecios> informeVentasPorListaPrecios { get; set; } = new List<InformeVentasPorListaPrecios>();
        public List<InformeTotalVentasPorListaPrecios> informeTotalVentasPorListaPrecios { get; set; } = new List<InformeTotalVentasPorListaPrecios>();
                public List<InformeTotalGananciasPorLista> informeTotalGanancias { get; set; } = new List<InformeTotalGananciasPorLista>();


    }
}
