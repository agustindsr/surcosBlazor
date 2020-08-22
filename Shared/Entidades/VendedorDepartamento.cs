using System.Collections.Generic;

namespace SurcosBlazor.Shared.Entidades
{
    public class VendedorDepartamento
    {
        public int Id { get; set; }
        public int VendedorId { get; set; }
        public Vendedor vendedor { get; set; }
        public int DepartamentoId { get; set; }
        public Departamento departamento { get; set; }
        public bool entregaLunes { get; set; } = false;
        public bool entregaMartes { get; set; } = false;
        public bool entregaMiercoles { get; set; } = false;
        public bool entregaJueves{ get; set; } = false;
        public bool entregaViernes { get; set; } = false;
        public bool entregaSabado { get; set; } = false;
        public bool entregaDomingo { get; set; } = false;


    }
}