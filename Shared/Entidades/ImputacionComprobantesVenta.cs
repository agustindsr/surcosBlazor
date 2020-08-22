using System;
using System.Collections.Generic;
using System.Text;

namespace SurcosBlazor.Shared.Entidades
{
    public class ImputacionComprobantesVenta
    {
        public int Id { get; set; }
        public int FacturaVentasId { get; set; }
        public Factura FacturaVenta { get; set; }

        public int ReciboCobranzasId { get; set; }
        public ReciboCobranzas ReciboCobranzas { get; set; }

        public decimal totalImputado { get; set; } = 0.00M;
    }
}
