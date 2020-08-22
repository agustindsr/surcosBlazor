using System;
using System.Collections.Generic;
using System.Text;

namespace SurcosBlazor.Shared.Entidades
{
    public class UserDeposito
    {
        public int Id { get; set; }
        public string userName { get; set; }
        public int DepositoId { get; set; }
        public Deposito Deposito { get; set; }
    }
}
