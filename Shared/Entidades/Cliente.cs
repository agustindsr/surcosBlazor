using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SurcosBlazor.Shared.Entidades
{
    public  class Cliente
    {
        public int Id { get; set; }
        [Required]
        public string nombre { get; set; }
        public string email { get; set; }
        public  string apellido { get; set; }
        public string fechaNacimiento { get; set; }
        public string celular { get; set; }

        public bool enabled { get; set; } = true;
        public decimal saldoCC { get; set; } = 0.00M;

        public int? DomicilioId { get; set; }
        public virtual Domicilio Domicilio { get; set; } = new Domicilio();

        public int? CategoriaClienteId { get; set; }
        public virtual CategoriaCliente Categoria { get; set; }
    }
}
