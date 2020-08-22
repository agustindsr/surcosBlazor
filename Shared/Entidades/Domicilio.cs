using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SurcosBlazor.Shared.Entidades
{
    public class Domicilio
    {
        public int Id { get; set; }
        [Required]
        public string calle { get; set; }
        public int numero { get; set; }
        public  string manzana { get; set; }
        public string piso { get; set; }
        public string codigoPostal { get; set; }
        public decimal? longitud { get; set; }
        public decimal? latitud { get; set; }

        public int? DepartamentoId { get; set; }
        public virtual Departamento Departamento { get; set; } 
        public int? ProvinciaId { get; set; }
        public virtual Provincia Provincia { get; set; } 


    }
}
