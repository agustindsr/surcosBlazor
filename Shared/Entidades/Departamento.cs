using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SurcosBlazor.Shared.Entidades
{
    public class Departamento : IEquatable<Departamento>
    {
        public int Id { get; set; }
        [Required (ErrorMessage = "Este campo es requerido")]
        public string nombre { get; set; }
        public int ProvinciaId { get; set; }
        public Provincia Provincia { get; set; }
        public bool eCommerce { get; set; } = true;
        public virtual List<Domicilio> Domicilio { get; set; }
        public virtual List<VendedorDepartamento> VendedorDepartamentos { get; set; }
        public bool Equals(Departamento other)
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