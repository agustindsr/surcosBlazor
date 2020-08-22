using System;
using System.Collections.Generic;
using System.Text;

namespace SurcosBlazor.Shared.Entidades
{
    public class Producto : IEquatable<Producto>
    {
        public int Id { get; set; }
        public string nombre { get; set; }
        public bool enabled { get; set; } = true;
        public string Foto { get; set; }
        public int? CategoriaProductoId { get; set; }
        public CategoriaProducto CategoriaProducto { get; set; }
        public List<ProductoPresentacion> productoPresentaciones { get; set; }

        public bool Equals(Producto other)
        {
            if (nombre == other.nombre)
                return true;

            return false;
        }

        public override int GetHashCode()
        {
            int hashNombre = nombre == null ? 0 : nombre.GetHashCode();

            return hashNombre;
        }
    }
}
