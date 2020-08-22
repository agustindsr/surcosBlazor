using System;
using System.Collections.Generic;
using System.Text;

namespace SurcosBlazor.Shared.Entidades
{
    public class DetalleFacturaCompras
    {
        public int Id { get; set; }
        public int cantidad { get; set; }
        public decimal precioUnitario { get; set; }
        public double bonificacion { get; set; }
        public DateTime fechaAlta { get; set; } = DateTime.Now;
        public bool enabled { get; set; } = true;
        public int FacturaComprasId { get; set; }
        public virtual FacturaCompras Factura { get; set; }
        public int ProductoPresentacionId { get; set; }
        public virtual ProductoPresentacion ProductoPresentacion { get; set; }
    }
}
