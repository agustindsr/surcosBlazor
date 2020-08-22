using System;
using System.Collections.Generic;
using System.Text;

namespace SurcosBlazor.Shared.Entidades
{
   public class DetalleOrdenProduccion
    {
        public int Id { get; set; }
        public int cantidad { get; set; }
        public DateTime fechaAlta { get; set; } = DateTime.Now;
        public int OrdenProduccionId { get; set; }
        public virtual OrdenProduccion OrdenProduccion { get; set; }
        public int ProductoPresentacionId { get; set; }
        public virtual ProductoPresentacion ProductoPresentacion { get; set; }
    }
}
