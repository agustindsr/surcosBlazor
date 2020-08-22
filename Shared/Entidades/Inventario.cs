using System.Collections.Generic;

namespace SurcosBlazor.Shared.Entidades
{
    public class Inventario
    {
        public int Id { get; set; }
        public ProductoPresentacion ProductoPresentacion { get; set; }
        public int ProductoPresentacionId { get; set; }

        public int cantidadUnidadesEnExistencia { get; set; } = 0;
        public decimal cantidadPesoRealEnExistencia { get; set; } = 0;

        public Deposito Deposito { get; set; }
        public int DepositoId { get; set; }

        public List<MovimientoInventario> MovimientosInventario { get; set; }
    }
}