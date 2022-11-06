using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank_POO.Classes
{
    internal class Contacorrente : Conta
    {
        public Contacorrente()
        {
            this.NumeroConta = "00" + Conta.NumeroDaContaSequencial;
        }
    }
}
