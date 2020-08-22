using System;
using System.Collections.Generic;
using System.Text;

namespace SurcosBlazor.Shared.Entidades
{
    public class OrdenProduccion
    {
        public int Id { get; set; }
        public DateTime fecha { get; set; } = DateTime.Now;
        public int DepositoId { get; set; }
        public Deposito Deposito { get; set; }
           
        public List<DetalleOrdenProduccion> detallesOrdenProduccion { get; set; } = new List<DetalleOrdenProduccion>();
              
        public int EstadoOrdenProduccionId { get; set; }
        public EstadoOrdenProduccion EstadoOrdenProduccion { get; set; }


    }
}
