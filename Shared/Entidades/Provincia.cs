using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SurcosBlazor.Shared.Entidades
{
    public class Provincia : IEquatable<Provincia>
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Este campo es requerido")]
        public string nombre { get; set; }
        public virtual List<Departamento> departamentos { get; set; }
        public bool eCommerce { get; set; } = true;
        public virtual List<TipoListaPrecioProvincia> TipoListaPrecioProvincia { get; set; }

        public bool Equals(Provincia other)
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
