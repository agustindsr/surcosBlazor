using System;
using System.Collections.Generic;
using System.Text;

namespace SurcosBlazor.Shared.Entidades
{
    public abstract class Comprobante
    {
        public int Id { get; set; }
        public DateTime fecha { get; set; } = DateTime.Now;
        public decimal totalCancelado { get; set; } = 0.00M;
        public decimal totalComprobante { get; set; } = 0.00M;
        public decimal totalImputado { get; set; } = 0.00M;

        //de donde sale la mercadería


    }
}
