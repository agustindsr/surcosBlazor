using System;
using System.Collections.Generic;
using System.Text;

namespace SurcosBlazor.Shared.Entidades
{
    public class Pedido
    {
        public int Id { get; set; }
        public DateTime fecha { get; set; } = DateTime.Now;
        public decimal total { get; set; } = 0.00M;
        public List<DetallePedido> detallePedido { get; set; } = new List<DetallePedido>();
        public int EstadoPedidoId { get; set; }
        public decimal costoTotal { get; set; }
        public bool hechoPorAdmin { get; set; } = false;
        public EstadoPedido EstadoPedido { get; set; }
        public int VendedorId { get; set; }
        public Vendedor Vendedor { get; set; } 
        public int? ClienteId { get; set; }
        public Cliente Cliente { get; set; }
        public int ListaPreciosId { get; set; }
        public ListaPrecios ListaPrecios { get; set; }
        public bool enabled { get; set; } = true;

        public DateTime fechaEntrega { get; set; }
        public string observaciones { get; set; }
        public int DomicilioId { get; set; }
        public virtual Domicilio Domicilio { get; set; } 
        public string nombreCliente { get; set; }
        public string apellidoCliente { get; set; }

        public string emailCliente { get; set; }
        public string celularCliente { get; set; }

    }
}
