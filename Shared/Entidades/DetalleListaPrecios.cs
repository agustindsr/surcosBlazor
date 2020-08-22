namespace SurcosBlazor.Shared.Entidades
{
    public class DetalleListaPrecios
    {
        public int Id { get; set; }
        public int ListaPreciosId { get; set; }
        public ListaPrecios ListaPrecios { get; set; }
        public int ProductoPresentacionId { get; set; }
        public ProductoPresentacion ProductoPresentacion { get; set; }

        public decimal precioCosto { get; set; } = 0.00M;
        public decimal porcentajeRentabilidad { get; set; } = 0.00M;
        public decimal porcentajeDescuento { get; set; } = 0.00M;
        public int cantidadMinima { get; set; } = 1;      
        public decimal precioUnitarioFinal { get; set; } = 0.00M;
        public int clasificacion { get; set; } = 0;

    }
}