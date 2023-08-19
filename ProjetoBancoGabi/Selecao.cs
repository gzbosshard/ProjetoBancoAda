using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoBancoAda
{
    internal class Selecao
    {
        Conta contaPrincipal = new Conta();

        protected string TipoConta { get; set; }

        public Selecao()
        {
            
        }

        // Selecionar Operação
        public void SelecionarOperacao()
        {
            Console.Clear();


            bool validacaoOperacao = false;
            int opcaoOperacao = 0;
            do
            {
                try
                {
                    Console.WriteLine("Selecione a operação a ser realizada:");
                    Console.WriteLine("1. Abrir Conta");
                    Console.WriteLine("2. Depositar");
                    Console.WriteLine("3. Sacar");
                    Console.WriteLine("4. Consultar Saldo");
                    Console.WriteLine("5. Consultar Extrato");
                    Console.WriteLine("6. Alterar Tipo de Conta");
                    Console.WriteLine("7. Encerrar Conta");
                    Console.WriteLine("8. Sair");
                    Console.Write("Número da opção: ");
                    opcaoOperacao = int.Parse(Console.ReadLine());
                    validacaoOperacao = true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"\u001b[31mOops, tivemos um erro! Digite um valor válido{Environment.NewLine}\u001b[0m");
                }
            }
            while (!validacaoOperacao && opcaoOperacao > 0 && opcaoOperacao < 9);

            switch (opcaoOperacao)
            {
                case 1: // abrir conta
                    Console.Clear();
                    contaPrincipal.AbrirConta();
                    VoltarMenu();
                    break;
                case 2: // depositar
                    Console.Clear();
                    contaPrincipal.Depositar();
                    VoltarMenu();
                    break;
                case 3: // sacar
                    Console.Clear();
                    contaPrincipal.Sacar();
                    VoltarMenu();
                    break;
                case 4: // consultar saldo
                    Console.Clear();
                    contaPrincipal.ConsultarSaldo();
                    VoltarMenu();
                    break;
                case 5: // consultar extrato
                    Console.Clear();
                    contaPrincipal.ConsultarExtrato();
                    VoltarMenu();
                    break;
                case 6: //alterar tipo de conta
                    Console.Clear();
                    AlterarTipoConta();
                    VoltarMenu();
                    break;
                case 7: // encerrar tipo de conta
                    Console.Clear();
                    contaPrincipal.EncerrarConta();
                    VoltarMenu();
                    break;
                case 8:
                    Console.Clear();
                    Console.WriteLine("Sistema encerrado com sucesso!");
                    break;
                default:
                    Console.Clear();
                    Console.WriteLine("Opção Inválida");
                    VoltarMenu();
                    break;
            }

        }

        // Perguntar sobre retornar ao menu
        public void VoltarMenu()
        {
            Console.WriteLine();
            bool validacaoVoltarMenu = false;
            string voltarMenu = "nao";
            do
            {
                try
                {
                    Console.WriteLine("Deseja voltar ao menu? Responda S ou N");
                    voltarMenu = Console.ReadLine();
                    validacaoVoltarMenu = true;

                    if (voltarMenu == "S" || voltarMenu == "s")
                    {
                        SelecionarOperacao();
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("Sistema encerrado com sucesso!");
                    }
                }
                catch
                {
                    Console.WriteLine($"\u001b[31mOops, tivemos um erro! Digite um valor válido{Environment.NewLine}\u001b[0m");
                }
            }
            while (!validacaoVoltarMenu);
        }


        public void AlterarTipoConta()
        {
            Console.WriteLine($"----- SELECIONAR TIPO DE CONTA -----{Environment.NewLine}");

            bool validacaoTipoConta = false;
            int opcaoConta = 0;
            do
            {
                try
                {
                    Console.WriteLine("Selecione o tipo de conta:");
                    Console.WriteLine("1. Conta Corrente");
                    Console.WriteLine("2. Conta Poupança");
                    Console.Write("Número da opção: ");
                    opcaoConta = int.Parse(Console.ReadLine());
                    validacaoTipoConta = true;

                }
                catch (Exception ex)
                {
                    Console.WriteLine($"\u001b[31mOops, tivemos um erro! Digite um valor válido{Environment.NewLine}\u001b[0m");
                }
            }
            while (!validacaoTipoConta && opcaoConta > 0 && opcaoConta < 3);

            switch (opcaoConta)
            {
                case 1:
                    TipoConta = "Conta Corrente";
                    contaPrincipal = new ContaCorrente();
                    break;
                case 2:
                    TipoConta = "Conta Poupança";
                    contaPrincipal = new ContaPoupanca();
                    break;
                default:
                    Console.WriteLine("Opção Inválida");
                    break;
            }
        }
    }
}
