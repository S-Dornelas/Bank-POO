using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Bank_POO.Classes
{
    public class layout
    {
        private static List<Pessoa> pessoas = new List<Pessoa>();
        
        private static int opcao = 0;
       
        public static void TelaPrincipal()
        {
            Console.BackgroundColor = ConsoleColor.Green;
            Console.ForegroundColor = ConsoleColor.Yellow;

            Console.Clear();

            Console.WriteLine("==========================================================================");
            Console.WriteLine("                             BANCO POO                                    ");
            Console.WriteLine("==========================================================================");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("--------------------------------------------------------------------------");
            Console.WriteLine("                      DIGITE A OPÇÃO DESEJADA                             ");
            Console.WriteLine("--------------------------------------------------------------------------");
            Console.WriteLine("     1 - CRIAR CONTA");
            Console.WriteLine("");
            Console.WriteLine("     2 - ENTRAR COM CPF E SENHA");
            Console.WriteLine("");
            Console.WriteLine("     3 - SAIR");
            Console.WriteLine("==========================================================================");


            opcao = int.Parse(Console.ReadLine());

            switch (opcao)
            {
                case 1:TelaCriarConta();
                    break;
                case 2:TelaLogin();
                    break;
                case 3:Console.ReadKey();
                    break;
                default:
                    {
                        Console.Clear();

                        Console.WriteLine("==========================================================================");
                        Console.WriteLine("                             BANCO POO                                    ");
                        Console.WriteLine("==========================================================================");
                        Console.WriteLine("");
                        Console.WriteLine("");
                        Console.WriteLine("--------------------------------------------------------------------------");
                        Console.WriteLine("                           OPÇÃO INVALIDA!                                ");
                        Console.WriteLine("==========================================================================");

                        Thread.Sleep(1000);
                        TelaPrincipal();
                    }break;
            }       
        }
        private static void TelaCriarConta()
        {
            Console.Clear();

            Console.WriteLine("==========================================================================");
            Console.WriteLine("                             BANCO POO                                    ");
            Console.WriteLine("==========================================================================");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("--------------------------------------------------------------------------");
            Console.WriteLine("             1 - DIGITE SEU NOME:");
            string nome = Console.ReadLine();
            Console.WriteLine("--------------------------------------------------------------------------");
            Console.WriteLine("             2 - DIGITE SEU CPF");
            string cpf = Console.ReadLine();
            Console.WriteLine("");
            Console.WriteLine("             3 - DIGITE SUA SENHA");
            string senha = Console.ReadLine();
            Console.WriteLine("==========================================================================");

            //criar uma conta
            Contacorrente contaCorrente = new Contacorrente();
            Pessoa pessoa = new Pessoa();

            pessoa.SetNome(nome);
            pessoa.SetCPF(cpf);
            pessoa.SetSenha(senha);
            pessoa.Conta = contaCorrente;

            pessoas.Add(pessoa);

            Console.Clear();

            Console.WriteLine("                     CONTA CADASTRADA COM SUCESSO!                        ");
            Console.WriteLine("==========================================================================");

            //este código espera 1" para ir a TelaContaLogada
            Thread.Sleep(1000);
            TelaContaLogada(pessoa);
        }
        private static void TelaLogin()
        {
            Console.Clear();

            Console.WriteLine("==========================================================================");
            Console.WriteLine("                             BANCO POO                                    ");
            Console.WriteLine("==========================================================================");
            Console.WriteLine("");
            Console.WriteLine("");
           Console.WriteLine("--------------------------------------------------------------------------");
            Console.WriteLine("             1 - DIGITE SEU CPF");
            string cpf = Console.ReadLine();
            Console.WriteLine("");
            Console.WriteLine("             2 - DIGITE SUA SENHA");
            string senha = Console.ReadLine();
            Console.WriteLine("==========================================================================");

            //código para encontrar variável da lista
            Pessoa pessoa = pessoas.FirstOrDefault(x => x.CPF == cpf && x.Senha == senha); 

            if (pessoa != null)
            {
                //tela de boas vindas
                TelaBoasVindas(pessoa);
                //telaContaLogada
                TelaContaLogada(pessoa);
            }
            else
            {
                Console.Clear();

                Console.WriteLine("                         PESSOA NÃO CADASTRADA!                           ");
                Console.WriteLine("==========================================================================");
                Console.WriteLine("");
            }
            Thread.Sleep(1000);
            TelaPrincipal();
        }
        private static void TelaBoasVindas(Pessoa pessoa)
        {
            Console.Clear();

            string msgTelaDeBemVindo =
                $"{pessoa.Nome} | Banco: {pessoa.Conta.GetCodigoDoBanco()} | Agência: {pessoa.Conta.GetNumeroDaAgencia()}" +
                $"| Conta: {pessoa.Conta.GetNumeroDaConta()}";

            Console.WriteLine("==========================================================================");
            Console.WriteLine($"    SEJA BEM VINDO, {msgTelaDeBemVindo}                                  ");
            Console.WriteLine("==========================================================================");
            Console.WriteLine("");
        }
        private static void TelaContaLogada(Pessoa pessoa)
        {
            Console.Clear();
                     
            Console.WriteLine("==========================================================================");
            Console.WriteLine("                             BANCO POO                                    ");
            Console.WriteLine("==========================================================================");
            Console.WriteLine("");
            TelaBoasVindas(pessoa);
            Console.WriteLine("");
            Console.WriteLine("--------------------------------------------------------------------------");
            Console.WriteLine("                      DIGITE A OPÇÃO DESEJADA                             ");
            Console.WriteLine("--------------------------------------------------------------------------");
            Console.WriteLine("         1 - REALIZAR DEPOSITO");
            Console.WriteLine("");
            Console.WriteLine("         2 - REALIZAR UM SAQUE");
            Console.WriteLine("");
            Console.WriteLine("         3 - CONSULTAR O SALDO");
            Console.WriteLine("");
            Console.WriteLine("         4 - CONSULTAR EXTRATO");
            Console.WriteLine("");
            Console.WriteLine("         5 - SAIR");
            Console.WriteLine("==========================================================================");

            opcao = int.Parse(Console.ReadLine());

            switch(opcao)
            {
                case 1:TelaDeposito(pessoa);
                    break;
                case 2:TelaDeSaque(pessoa);
                    break;
                case 3:TelaSaldo(pessoa);
                    break;
                case 4:TelaExtrato(pessoa);
                    break;
                case 5: TelaPrincipal();
                    break;
                default:
                    Console.Clear();
                    Console.WriteLine("==========================================================================");
                    Console.WriteLine("                             BANCO POO                                    ");
                    Console.WriteLine("==========================================================================");
                    Console.WriteLine("");
                    Console.WriteLine("");
                    Console.WriteLine("--------------------------------------------------------------------------");
                    Console.WriteLine("                           OPÇÃO INVALIDA!                                ");
                    Console.WriteLine("==========================================================================");
                    break;
            }
        }
        private static void TelaDeposito(Pessoa pessoa)
        {
            Console.Clear();
            
            Console.WriteLine("==========================================================================");
            Console.WriteLine("                             BANCO POO                                    ");
            Console.WriteLine("==========================================================================");
            Console.WriteLine("");
            TelaBoasVindas(pessoa);
            Console.WriteLine("");
            Console.WriteLine("--------------------------------------------------------------------------");
            Console.WriteLine("                      DIGITE O VALOR DE DEPOSITO.                         ");
            Console.WriteLine("--------------------------------------------------------------------------");

            double valor = double.Parse(Console.ReadLine());
            pessoa.Conta.Deposita(valor);

            Console.Clear();

            Console.WriteLine("==========================================================================");
            Console.WriteLine("                             BANCO POO                                    ");
            Console.WriteLine("==========================================================================");
            Console.WriteLine("");
            TelaBoasVindas(pessoa);
            Console.WriteLine("");
            Console.WriteLine("--------------------------------------------------------------------------");
            Console.WriteLine("                      DEPOSITO REALIZADO COM SUCESSO!                     ");
            Console.WriteLine("--------------------------------------------------------------------------");

            Thread.Sleep(1000);
            Console.Clear();
            TelaSaldo(pessoa);

            OpcaoVoltarLogado(pessoa);

        }
        private static void TelaDeSaque(Pessoa pessoa)
        {
            Console.Clear();

            Console.WriteLine("==========================================================================");
            Console.WriteLine("                             BANCO POO                                    ");
            Console.WriteLine("==========================================================================");
            Console.WriteLine("");
            TelaBoasVindas(pessoa);
            Console.WriteLine("");
            Console.WriteLine("--------------------------------------------------------------------------");
            Console.WriteLine("                      DIGITE O VALOR DE SAQUE.                            ");
            Console.WriteLine("--------------------------------------------------------------------------");

            double valor = double.Parse(Console.ReadLine());
            bool okSaque = pessoa.Conta.Sacar(valor);

            Console.Clear();
            if (okSaque)
            {
                Console.WriteLine("==========================================================================");
                Console.WriteLine("                             BANCO POO                                    ");
                Console.WriteLine("==========================================================================");
                Console.WriteLine("");
                TelaBoasVindas(pessoa);
                Console.WriteLine("");
                Console.WriteLine("--------------------------------------------------------------------------");
                Console.WriteLine("                   SAQUE FOI REALIZADO COM SUCESSO!                       ");
                Console.WriteLine("--------------------------------------------------------------------------");

                Thread.Sleep(1000);
                TelaSaldo(pessoa);
                Console.Clear();
                
            }
            else
            {
                Console.WriteLine("==========================================================================");
                Console.WriteLine("                             BANCO POO                                    ");
                Console.WriteLine("==========================================================================");
                Console.WriteLine("");
                TelaBoasVindas(pessoa);
                Console.WriteLine("");
                Console.WriteLine("--------------------------------------------------------------------------");
                Console.WriteLine("                         SAQUE INSUFICIENTE!                              ");
                Console.WriteLine("--------------------------------------------------------------------------");

                Thread.Sleep(1000);
                TelaSaldo(pessoa);
                Console.Clear();
                
            }

            OpcaoVoltarLogado(pessoa);

        }
        private static void TelaSaldo(Pessoa pessoa)
        {
            Console.Clear();

            Console.WriteLine("==========================================================================");
            Console.WriteLine("                             BANCO POO                                    ");
            Console.WriteLine("==========================================================================");
            Console.WriteLine("");
            Console.WriteLine("");
            TelaBoasVindas(pessoa);
            Console.WriteLine("--------------------------------------------------------------------------");
            Console.WriteLine($"SEU SALDO É: {pessoa.Conta.ConsultarSaldo()}                             ");
            Console.WriteLine("--------------------------------------------------------------------------");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("==========================================================================");

            Thread.Sleep(5000);
            OpcaoVoltarLogado(pessoa);

        }
        private static void TelaExtrato(Pessoa pessoa)
        {
            Console.Clear();

            if (pessoa.Conta.Extratos().Any())
            {
                double total = pessoa.Conta.Extratos().Sum(x => x.Valor);
                               

                foreach (Extrato extrato in pessoa.Conta.Extratos())
                {
                    Console.WriteLine("==========================================================================");
                    Console.WriteLine("                             BANCO POO                                    ");
                    Console.WriteLine("==========================================================================");
                    Console.WriteLine("");
                    Console.WriteLine("");
                    TelaBoasVindas(pessoa);
                    Console.WriteLine("--------------------------------------------------------------------------");
                    Console.WriteLine($"    DATA DE MOVIMENTAÇÃO: {extrato.Data.ToString("dd/mm/yyyy: hh:mm:ss")}");
                    Console.WriteLine($"    TIPO DE MOVIMENTAÇÃO: {extrato.Descricao}                            ");
                    Console.WriteLine($"    VALOR: {extrato.Valor}                                               ");
                    Console.WriteLine("--------------------------------------------------------------------------");
                    Console.WriteLine("");
                    Console.WriteLine("");
                }
                Console.WriteLine("--------------------------------------------------------------------------");
                Console.WriteLine($"SUB TOTAL É: {total}                                                     ");
                Console.WriteLine("--------------------------------------------------------------------------");
                Console.WriteLine("");
                Console.WriteLine("");
                Console.WriteLine("==========================================================================");

                Console.ReadKey();
                OpcaoVoltarLogado(pessoa);
            }
            else
            {
                Console.WriteLine("==========================================================================");
                Console.WriteLine("                             BANCO POO                                    ");
                Console.WriteLine("==========================================================================");
                Console.WriteLine("");
                Console.WriteLine("");
                TelaBoasVindas(pessoa);
                Console.WriteLine("--------------------------------------------------------------------------");
                Console.WriteLine("                     NÃO HÁ EXTRATO A SER EXIBIDO.                        ");                     
                Console.WriteLine("--------------------------------------------------------------------------");
                Console.WriteLine("");
                Console.WriteLine("");
                Console.WriteLine("==========================================================================");
            }

            Thread.Sleep(1000);
            OpcaoVoltarLogado(pessoa);

        }
        private static void OpcaoVoltarLogado(Pessoa pessoa)
        {
            Console.Clear();

            Console.WriteLine("==========================================================================");
            Console.WriteLine("                             BANCO POO                                    ");
            Console.WriteLine("==========================================================================");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("--------------------------------------------------------------------------");
            Console.WriteLine("                      ENTRE COM UMA OPÇÃO ABAIXO.                         ");
            Console.WriteLine("--------------------------------------------------------------------------");
            Console.WriteLine("         1 - VOLTAR PARA A MINHA CONTA");
            Console.WriteLine("");
            Console.WriteLine("         2 - SAIR");
            Console.WriteLine("==========================================================================");

            opcao = int.Parse(Console.ReadLine());

            if (opcao == 1)
                TelaContaLogada(pessoa);
            else
                TelaPrincipal();
        }
        private static void OpcaoVoltarDeslogado()
        {
            Console.Clear();

            Console.WriteLine("==========================================================================");
            Console.WriteLine("                             BANCO POO                                    ");
            Console.WriteLine("==========================================================================");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("--------------------------------------------------------------------------");
            Console.WriteLine("                      ENTRE COM UMA OPÇÃO ABAIXO.                         ");
            Console.WriteLine("--------------------------------------------------------------------------");
            Console.WriteLine("         1 - VOLTAR PARA MENU PRINCIPAL");
            Console.WriteLine("");
            Console.WriteLine("         2 - SAIR");
            Console.WriteLine("==========================================================================");

            opcao = int.Parse(Console.ReadLine());

            if (opcao == 1)
                TelaPrincipal();
            else
            {
                Console.Clear();

                Console.WriteLine("==========================================================================");
                Console.WriteLine("                             BANCO POO                                    ");
                Console.WriteLine("==========================================================================");
                Console.WriteLine("");
                Console.WriteLine("");
                Console.WriteLine("--------------------------------------------------------------------------");
                Console.WriteLine("                           OPÇÃO INVALIDA!                                ");
                Console.WriteLine("==========================================================================");
            }
        }
    }
}
