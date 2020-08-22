using System;
using System.Collections.Generic;
using System.Text;

namespace SurcosBlazor.Shared.Entidades
{
    public class DetallePago
    {
        public int Id { get; set; }
        public int ComprobanteId { get; set; }
        public Comprobante Comprobante { get; set; }
        public decimal subtotal { get; set; }
        public int CajaId { get; set; }
        public Caja Caja { get; set; }

    }
}
