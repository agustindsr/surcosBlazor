using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace SurcosBlazor.Shared.Entidades
{
    public class FormulaProducto
    {
        public int Id { get; set; }
        public string nombre { get; set; }
        public DateTime fechaCreacion { get; set; } = DateTime.Now;

        public int ProductoPresentacionId { get; set; }

        public virtual ProductoPresentacion ProductoPresentacion { get; set; }

        public virtual List<DetalleFormula> DetallesFormula { get; set; } = new List<DetalleFormula>();

        public decimal _total;

        public decimal total
        {
            get {
                return DetallesFormula.Sum(x => x.ProductoPresentacion.costo * (x.ProductoPresentacion.PresentacionProducto != null ? (x.cantidad / x.ProductoPresentacion.PresentacionProducto.cantidad) : 0));


                }
            set
            {
                _total = DetallesFormula.Sum(x => x.ProductoPresentacion.costo * (x.ProductoPresentacion.PresentacionProducto != null ? (x.cantidad / x.ProductoPresentacion.PresentacionProducto.cantidad) : 0));

            }
        }
       

        
    }
}
