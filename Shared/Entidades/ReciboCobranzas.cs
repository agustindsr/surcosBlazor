using System;
using System.Collections.Generic;
using System.Text;

namespace SurcosBlazor.Shared.Entidades
{
    public class ReciboCobranzas : Comprobante
    {
        public int ClienteId { get; set; }
        public Cliente Cliente { get; set; }
        public int EstadoReciboId { get; set; }
        public EstadoRecibo EstadoRecibo { get; set; }
        public List<MovimientoCaja> movimientosCaja { get; set; } 
        public List<ImputacionComprobantesVenta> Imputaciones { get; set; }

    }
}
