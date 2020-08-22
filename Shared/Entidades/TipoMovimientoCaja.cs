using System;
using System.Collections.Generic;
using System.Text;

namespace SurcosBlazor.Shared.Entidades
{
    public class TipoMovimientoCaja
    {
        public int Id { get; set; }
        public string nombre { get; set; }
        public bool enabled { get; set; } = true;
    }
}
