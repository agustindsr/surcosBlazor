using System;
using System.Collections.Generic;
using System.Text;

namespace SurcosBlazor.Shared.Entidades
{
    public class UserVendedor
    {
        public int Id { get; set; }
        public string userName { get; set; }
        public int VendedorId { get; set; }
        public Vendedor Vendedor { get; set; }
    }
}
