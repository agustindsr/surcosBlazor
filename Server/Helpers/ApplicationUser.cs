using Microsoft.AspNetCore.Identity;
using SurcosBlazor.Shared.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SurcosBlazor.Server.Helpers
{
    public class ApplicationUser : IdentityUser
    {
        public int? ClienteId { get; set; }
        public Cliente Cliente { get; set; } 
        public int? VendedorId { get; set; }
        public Vendedor Vendedor { get; set; }
    }
}
