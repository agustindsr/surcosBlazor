using System;
using System.ComponentModel.DataAnnotations;

namespace SurcosBlazor.Shared.Entidades
{
    public class PresentacionProducto : IEquatable<PresentacionProducto>
    {
        public int Id { get; set; }
        [Required]
        public string nombre { get; set; }
        [Required]
        public decimal cantidad { get; set; }
        public int UnidadId { get; set; }
        public Unidad Unidad { get; set; } 
        public bool enabled { get; set; } = true;

        public bool Equals(PresentacionProducto other)
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