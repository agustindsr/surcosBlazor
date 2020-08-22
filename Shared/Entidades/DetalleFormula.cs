namespace SurcosBlazor.Shared.Entidades
{
    public class DetalleFormula
    {
        public int Id { get; set; }

             public int ProductoPresentacionId { get; set; }
        public virtual ProductoPresentacion ProductoPresentacion { get; set; } = new ProductoPresentacion();
            public decimal cantidad { get; set; }

        public int FormulaProductoId { get; set; }
        public FormulaProducto FormulaProducto { get; set; }

    }
}