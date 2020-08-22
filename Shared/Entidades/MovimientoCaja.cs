using System;
using System.Collections.Generic;
using System.Text;

namespace SurcosBlazor.Shared.Entidades
{
    public class MovimientoCaja
    {
        public int Id { get; set; }
        public decimal totalMovimiento { get; set; }
        public DateTime fecha { get; set; } = DateTime.Now;
        public bool entra { get; set; }
        public bool sale { get; set; }
        public string descripcion { get; set; }
        public Caja Caja { get; set; }
        public int CajaId { get; set; }
        public int? ReciboCobranzasId { get; set; }
        public ReciboCobranzas ReciboCobranzas { get; set; }

        public int? OrdenPagoId { get; set; }
        public OrdenPago OrdenPago { get; set; }
        public int? TipoMovimientoCajaId { get; set; }
        public TipoMovimientoCaja TipoMovimientoCaja { get; set; }
    }
}
