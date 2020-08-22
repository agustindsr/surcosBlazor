using System;
using System.Collections.Generic;
using System.Text;

namespace SurcosBlazor.Shared.Entidades
{
    public class DetalleFactura
    {
        public int Id { get; set; }
        public int cantidad { get; set; }
        public decimal costo { get; set; }

        public decimal precioUnitario { get; set; }

        public double bonificacion { get; set; }
        public DateTime fechaAlta { get; set; } = DateTime.Now;
        public bool enabled { get; set; } = true;
        public int FacturaId { get; set; }
        public virtual Factura Factura { get; set; }
        public int ProductoPresentacionId { get; set; }
        public virtual ProductoPresentacion ProductoPresentacion { get; set; }
    }
}
