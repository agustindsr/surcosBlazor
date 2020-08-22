using SurcosBlazor.Shared.Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SurcosBlazor.Shared
{
    public class UserInfo
    {
        public string id { get; set; }
        [Required]
        public string username { get; set; }
        public string Password { get; set; }
        public List<Roles> roles { get; set; } = new List<Roles>();
        public List<Vendedor> vendedores { get; set; } = new List<Vendedor>();
        public List<Deposito> depositos { get; set; } = new List<Deposito>();
        public List<Caja> cajas { get; set; } = new List<Caja>();

        public UserToken userToken { get; set; }
        public int? ClienteId { get; set; }
        public Cliente Cliente { get; set; }
    }
}
