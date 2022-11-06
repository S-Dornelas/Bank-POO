using Bank_POO.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank_POO.Contratos
{
    public interface IConta
    {
        void Deposita(double valor);
        bool Sacar(double valor);
        double ConsultarSaldo();
        string GetCodigoDoBanco();
        string GetNumeroDaAgencia();
        string GetNumeroDaConta();
        List<Extrato> Extratos();
    }
}
