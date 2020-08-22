using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
namespace SurcosBlazor.Shared.Entidades
{
    public class ProductoPresentacion
    {
        public int Id { get; set; }
        [Required]
        public int PresentacionProductoId { get; set; }
        public PresentacionProducto PresentacionProducto { get; set; }
        public bool enabled { get; set; } = true;
        public decimal costo { get; set; } = 0.00M;
        [Required]
        public bool esFormulado { get; set; } = false;
        public  string descripcion { get; set; }
        public int cantidadStockMinima { get; set; } = 0;
        [Required]
        public int ProductoId { get; set; }
        public Producto Producto { get; set; }
        public int? ProveedorId { get; set; }
        public Proveedor Proveedor { get; set; }
        public FormulaProducto FormulaProducto { get; set; }

        public List<DetalleFormula> DetallesFormula { get; set; }


        public bool Equals(ProductoPresentacion other)
        {
            if (Id == other.Id)
                return true;

            return false;
        }

        public override int GetHashCode()
        {
            int hashNombre = Id == 0 ? 0 : Id.GetHashCode();

            return hashNombre;
        }
    }
}