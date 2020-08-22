using System;
using System.Collections.Generic;
using System.Text;

namespace SurcosBlazor.Shared.Entidades
{
    public class OrdenPago : Comprobante
    {
        public int ProveedorId { get; set; }
        public Proveedor Proveedor { get; set; }
        public int EstadoReciboId { get; set; }
        public EstadoRecibo EstadoRecibo { get; set; }
        public List<MovimientoCaja> movimientosCaja { get; set; }
        public List<ImputacionComprobantesCompra> Imputaciones { get; set; }

    }
}
