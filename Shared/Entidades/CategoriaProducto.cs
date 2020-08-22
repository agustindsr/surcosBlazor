using System;
using System.Collections.Generic;

namespace SurcosBlazor.Shared.Entidades
{
    public class CategoriaProducto : IEquatable<CategoriaProducto>
    {
        public int Id { get; set; }
        public string nombre { get; set; }
        public List<Producto> Productos { get; set; }

        public int clasificacion { get; set; } = 0;


        public bool Equals(CategoriaProducto other)
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