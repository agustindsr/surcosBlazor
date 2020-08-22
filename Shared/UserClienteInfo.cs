using SurcosBlazor.Shared.Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SurcosBlazor.Shared
{
    public class UserClienteInfo
    {
        public string id { get; set; }
      
        
        public string Password { get; set; }
        public string PasswordConfirm { get; set; }
        public string CelConfirm { get; set; }

        public int ClienteId { get; set; }
        public Cliente Cliente { get; set; } = new Cliente();
        public List<Roles> roles { get; set; } = new List<Roles>();
        public UserToken userToken { get; set; }
    }
}
