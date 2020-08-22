using System;
using System.Collections.Generic;
using System.Text;

namespace SurcosBlazor.Shared.Entidades
{
    public class Proveedor
    {
        public int Id { get; set; }
        public string razonSocial { get; set; }
        public string nombreComercial { get; set; }
        public string celular { get; set; }

        public int DomicilioId { get; set; }
        public Domicilio Domicilio { get; set; } = new Domicilio();
        public DateTime fechaAlta { get; set; } = DateTime.Now;
        public bool enabled { get; set; } = true;
        public string cuit { get; set; }
        public List<ProductoPresentacion> productoPresentaciones { get; set; }
        public decimal saldoCC { get; set; } = 0.00M;
    }
}
