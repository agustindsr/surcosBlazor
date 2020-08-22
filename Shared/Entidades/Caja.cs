using System;
using System.Collections.Generic;
using System.Text;

namespace SurcosBlazor.Shared.Entidades
{
    public class Caja
    {
        public int Id { get; set; }
        public string nombre { get; set; }
        public decimal saldo { get; set; } = 0.00M;
        public bool enabled { get; set; } = true;
        public List<MovimientoCaja> MovimientosCaja { get; set; }
    }
}
