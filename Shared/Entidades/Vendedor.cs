using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SurcosBlazor.Shared.Entidades
{
    public class Vendedor : IEquatable<Vendedor>
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Este campo es requerido")]
        public string nombre { get; set; }
        public int? DomicilioId { get; set; }
        public Domicilio domicilio { get; set; }
        public string email { get; set; }
        public string Foto { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string numeroCelular { get; set; }
        public List<VendedorDepartamento> VendedorDepartamento { get; set; }
        public bool enabled { get; set; } = true;
        public bool trabajaFeriado { get; set; } = false;
        public bool eCommerce { get; set; } = true;
        public virtual List<UserVendedor> usuarios { get; set; }
        public int clasificacion { get; set; } = 0;

        public bool Equals(Vendedor other)
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
