using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank_POO.Classes
{
    public abstract class Banco
    {
        public Banco()
        {
            this.NomeDoBanco = "BANK POO";
            this.CodigoDoBanco = "100";
        }

        public string NomeDoBanco { get; private set; }
        public string CodigoDoBanco { get; private set; }
    }
}
