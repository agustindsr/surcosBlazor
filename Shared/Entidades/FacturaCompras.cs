using System;
using System.Collections.Generic;
using System.Text;

namespace SurcosBlazor.Shared.Entidades
{
    public class FacturaCompras : Comprobante
    {
        public string codigo { get; set; }
        public int DepositoId { get; set; }
        public Deposito Deposito { get; set; }
    
        public int ProveedorId { get; set; }
        public Proveedor Proveedor { get; set; }
        public int TipoComprobanteId { get; set; }
        public TipoComprobante TipoComprobante { get; set; }
        public List<DetalleFacturaCompras> detallesFactura { get; set; } = new List<DetalleFacturaCompras>();
        public int EstadoFacturaId { get; set; }
        public EstadoFactura EstadoFactura { get; set; }
    }
}
