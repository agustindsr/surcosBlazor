using System;
using System.Collections.Generic;
using System.Text;

namespace SurcosBlazor.Shared.Entidades
{
    public class UserCaja
    {
        public int Id { get; set; }
        public string userName { get; set; }
        public int CajaId { get; set; }
        public Caja Caja { get; set; }
    }
}
