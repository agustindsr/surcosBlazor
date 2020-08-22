namespace SurcosBlazor.Shared.Entidades
{
    public class DetallePedido
    {
        public int Id { get; set; }
        public int cantidad { get; set; }
        public decimal costo { get; set; }
        public decimal precioUnitario { get; set; }
        public decimal descuento { get; set; }
        public int ProductoPresentacionId { get; set; }
        public ProductoPresentacion ProductoPresentacion { get; set; }
        public int PedidoId { get; set; }
        public Pedido Pedido { get; set; }

    }
}