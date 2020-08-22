using System;
using System.Collections.Generic;
using System.Text;

namespace SurcosBlazor.Shared.Entidades
{
   public class ImputacionComprobantesCompra
    {
        public int Id { get; set; }
        public int FacturaComprasId { get; set; }
        public FacturaCompras FacturaCompras { get; set; }

        public int OrdenPagoId { get; set; }
        public OrdenPago OrdenPago { get; set; }

        public decimal totalImputado { get; set; } = 0.00M;
    }
}

