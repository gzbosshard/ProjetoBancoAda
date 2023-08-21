using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoBancoAda
{
    internal class Selecao
    {
        // CLASSES -----

        Conta contaPrincipal = new Conta();
        Utilidades util = new();

        // PROPRIEDAEDS

        public int Opcao { get; set; }

        // MÉTODOS -----

        // Selecionar Operação : Menu Principal
        public void SelecionarOperacao()
        {
            Console.Clear();
            int opcaoOperacao = util.ValidarMenu();

            switch (opcaoOperacao)
            {
                case 1: // depositar
                    Console.Clear();
                    contaPrincipal.Depositar();
                    VoltarMenu();
                    break;
                case 2: // sacar
                    Console.Clear();
                    contaPrincipal.Sacar();
                    VoltarMenu();
                    break;
                case 3: // consultar saldo
                    Console.Clear();
                    contaPrincipal.ConsultarSaldo();
                    VoltarMenu();
                    break;
                case 4: // consultar extrato
                    Console.Clear();
                    contaPrincipal.ConsultarExtrato();
                    VoltarMenu();
                    break;
                case 5: //alterar tipo de conta
                    Console.Clear();
                    AlterarTipoConta();
                    VoltarMenu();
                    break;
                case 6: // encerrar tipo de conta
                    Console.Clear();
                    contaPrincipal.EncerrarConta();
                    break;
                case 7:
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
                    Console.WriteLine($"\u001b[36mDeseja voltar ao menu? Responda S ou N.\u001b[0m");
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

        // Alterar tipo de conta
        public void AlterarTipoConta()
        {
            Console.Clear();
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
                    Console.Write($"{Environment.NewLine}Número da opção: ");
                    opcaoConta = int.Parse(Console.ReadLine());
                    Console.WriteLine();
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
                    contaPrincipal = new ContaCorrente(contaPrincipal.Senha, contaPrincipal.Nome, contaPrincipal.NumeroConta, contaPrincipal.Saldo, contaPrincipal.DataOperacaoConta, contaPrincipal.OperacoesConta, contaPrincipal.TipoOperacoesConta, "Conta Corrente");
                    contaPrincipal.DefinirLimite();
                    break;
                case 2:
                    contaPrincipal = new ContaPoupanca(contaPrincipal.Senha, contaPrincipal.Nome, contaPrincipal.NumeroConta, contaPrincipal.Saldo, contaPrincipal.DataOperacaoConta, contaPrincipal.OperacoesConta, contaPrincipal.TipoOperacoesConta, "Conta Poupança");
                    break;
                default:
                    Console.WriteLine("Opção Inválida");
                    break;
            }
        }

        // Tela Inicial

        public void Iniciar()
        {
            Console.WriteLine($"Seja bem vindo ao banco!{Environment.NewLine}");

            Console.WriteLine($"Selecione a opção de interesse:{Environment.NewLine}");
            Console.WriteLine("1. Abrir conta.");
            Console.WriteLine($"2. Acessar conta.{Environment.NewLine}");
            Opcao = util.ValidacaoInt("Opção desejada: ");

            switch (Opcao)
            {
                case 1:
                    AlterarTipoConta();
                    contaPrincipal.AbrirConta();
                    VoltarMenu();
                    break;
                case 2:
                    Console.WriteLine($"Você ainda não tem uma conta. Abra uma agora mesmo!{Environment.NewLine}");
                    Console.WriteLine($"Pressione qualquer tecla para processguir para a abertura de conta.{Environment.NewLine}");
                    Console.ReadKey();
                    AlterarTipoConta();
                    contaPrincipal.AbrirConta();
                    VoltarMenu();
                    break;
                default: Console.WriteLine("Opção Invalida"); break;
            }
        }
    }
}
