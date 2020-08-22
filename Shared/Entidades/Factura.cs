using System;
using System.Collections.Generic;
using System.Text;

namespace SurcosBlazor.Shared.Entidades
{
    public class Factura : Comprobante
    {
        public string codigo { get; set; }
        public int DepositoId { get; set; }
        public Deposito Deposito { get; set; }
        public int ClienteId { get; set; }
        public Cliente Cliente { get; set; }
        public int ListaPreciosId { get; set; }
        public int TipoComprobanteId { get; set; }
        public TipoComprobante TipoComprobante { get; set; }
        public ListaPrecios ListaPrecios { get; set; }
        public decimal costoTotal { get; set; }
        public bool hechoPorAdmin { get; set; } = false;

        public List<DetalleFactura> detallesFactura { get; set; } = new List<DetalleFactura>();
        public int DomicilioId { get; set; }
        public virtual Domicilio Domicilio { get; set; }
        public string nombreCliente { get; set; }
        public string apellidoCliente { get; set; }
        public string emailCliente { get; set; }
        public string celularCliente { get; set; }
        public int? VendedorId { get; set; }
        public Vendedor Vendedor { get; set; }
        public DateTime fechaEntrega { get; set; }
        public int EstadoFacturaId { get; set; }
        public EstadoFactura EstadoFactura { get; set; }

        public List<ImputacionComprobantesVenta> ComprobantesImputados { get; set; }

    }
}
