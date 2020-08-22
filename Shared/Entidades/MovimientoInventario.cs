using System;

namespace SurcosBlazor.Shared.Entidades
{
    public class MovimientoInventario
    {
        public int Id { get; set; }
        public int cantidadUnidadesMovida { get; set; }
        public DateTime fecha { get; set; } = DateTime.Now;
        public bool entra { get; set; }
        public bool sale { get; set; }
        public string descripcion { get; set; }
        public Inventario Inventario { get; set; }
        public int InventarioId { get; set; }

        public int? OrdenProduccionId { get; set; }
        public OrdenProduccion OrdenProduccion { get; set; }

    }
}