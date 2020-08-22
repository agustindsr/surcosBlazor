using SurcosBlazor.Shared.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SurcosBlazor.Client.Helpers
{
    public class ProductoEnCarritoModel
    {
        public ProductoPresentacion producto { get; set; }
        public int cantidad { get; set; }
    }
}
