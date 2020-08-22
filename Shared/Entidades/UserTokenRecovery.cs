using System;
using System.Collections.Generic;
using System.Text;

namespace SurcosBlazor.Shared.Entidades
{
    public class UserTokenRecovery
    {
        public int Id { get; set; }
        public string email { get; set; }
        public string token { get; set; }
        public DateTime fechaExpiracion { get; set; }
    }
}
