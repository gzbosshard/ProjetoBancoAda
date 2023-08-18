using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoBancoGabi
{
    internal class Conta
    {
        protected string Nome { get; set; }
        protected string Endereco { get; set; }
        protected string TipoConta { get; set; }
        protected bool StatusConta { get; set; } = false;
        protected int NumeroConta { get; set; }
        protected long CPF { get; set; }
        protected int Senha { get; set; }
        protected double Saldo { get; set; }
        protected DateTime DataDeNascimento { get; set; }
        public double ValorDeposito { get; set; }
        public double ValorSaque { get; set; }

        // Listas de Contas

        public List<double> SaldoConta { get; set; } = new List<double>();
        public List<DateTime> DataOperacaoConta { get; set; } = new();
        public List<double> OperacoesConta { get; set; } = new List<double>();


        public virtual double Depositar()
        {
            Console.Write("Valor a ser depositado: ");
            ValorDeposito = double.Parse(Console.ReadLine());
            OperacoesConta.Add(ValorDeposito);
            DataOperacaoConta.Add(DateTime.Now);
            Console.WriteLine($"Depósito de R$ {ValorDeposito.ToString("F2")} realizado com sucesso!");
            return Saldo += ValorDeposito;

        }
        public virtual double Sacar()
        {

            ValidarSenha();

            bool validacaoValorSaque = false;
            do
            {
                try
                {
                    Console.Write("Digite o valor que deseja sacar: ");
                    ValorSaque = double.Parse(Console.ReadLine());

                    validacaoValorSaque = true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"\u001b[31mOops, tivemos um erro! Digite um valor válido{Environment.NewLine}\u001b[0m");
                }


            }
            while (!validacaoValorSaque);
            OperacoesConta.Add(ValorSaque);
            DataOperacaoConta.Add(DateTime.Now);
            Console.WriteLine($"Retirada de {ValorSaque} realizado com sucesso!");
            return Saldo -= ValorSaque;
        }

        public double ConsultarSaldo()
        {
            Console.WriteLine($"O Saldo na conta é de R${Saldo.ToString("F2")}");
            return Saldo;
        }

        public void ConsultarExtrato()
        {
            Console.WriteLine($"----- EXTRATO -----{Environment.NewLine}");
            Console.WriteLine($"Conta: {NumeroConta}{Environment.NewLine}");
            Console.WriteLine($"Nome do Titular: {Nome}{Environment.NewLine}");
            Console.WriteLine($"O Saldo na conta é de R${Saldo.ToString("F2")}{Environment.NewLine}");

            // Operacoes realizadas

            Console.WriteLine($"----- OPERAÇÕES REALIZADAS -----{Environment.NewLine}");


            for (int j = 0; j < OperacoesConta.Count; j++)
            {
                Console.WriteLine($"{j}: R$ {OperacoesConta[j].ToString("F2")}");
            }



        }

        public int GerarSenha()
        {
            Random rnd = new Random();
            Senha = rnd.Next(10000, 99999);

            return Senha;

        }

        public void SelecionarOperacao()
        {
            Console.Clear();


            if (StatusConta == false)
            {
                Console.Clear();
                AbrirConta();
                VoltarMenu();
            }
            else
            {
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
                while (!validacaoOperacao && opcaoOperacao > 0 && opcaoOperacao < 8);

                switch (opcaoOperacao)
                {
                    case 1: // abrir conta
                        Console.Clear();
                        AbrirConta();
                        VoltarMenu();
                        break;
                    case 2: // depositar
                        Console.Clear();
                        Depositar();
                        VoltarMenu();
                        break;
                    case 3: // sacar
                        Console.Clear();
                        Sacar();
                        VoltarMenu();
                        break;
                    case 4: // consultar saldo
                        Console.Clear();
                        ConsultarSaldo();
                        VoltarMenu();
                        break;
                    case 5: // consultar extrato
                        Console.Clear();
                        ConsultarExtrato();
                        VoltarMenu();
                        break;
                    case 6: //alterar tipo de conta
                        Console.Clear();
                        AlterarTipoConta();
                        VoltarMenu();
                        break;
                    case 7: // encerrar tipo de conta
                        Console.Clear();
                        EncerrarConta();
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
        }

        // Abrir Conta
        public void AbrirConta()
        {

            Console.WriteLine($"Seja bem vindo ao nosso banco!{Environment.NewLine}" +
                $"Precisaremos seguir algumas etapas para abrir a sua conta:");

            AlterarTipoConta();

            // nome

            Console.WriteLine("Preencha os dados pessoais:");
            Console.Write("Nome: ");
            Nome = Console.ReadLine();

            // data de nascimento

            bool validacaoDataNascimento = false;


            do
            {
                try
                {
                    Console.Write("Data de Nascimento: ");
                    DataDeNascimento = DateTime.Parse(Console.ReadLine());
                    validacaoDataNascimento = true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"\u001b[31mOops, tivemos um erro! Digite um valor válido{Environment.NewLine}\u001b[0m");
                }

            }
            while (!validacaoDataNascimento);

            // Numero da Conta

            Random rndNumeroConta = new Random();
            NumeroConta = rndNumeroConta.Next(1000, 9999);

            Console.WriteLine($"O número da conta é {NumeroConta}");

            // CPF

            bool validacaoCPF = false;
            string cpf = "vazio";

            do
            {
                try
                {
                    Console.Write("CPF (digite apenas os números): ");
                    cpf = Console.ReadLine();
                    CPF = long.Parse(cpf);
                    validacaoCPF = true;

                    if (cpf.Length != 11)
                    {
                        Console.WriteLine($"\u001b[31mOops, tivemos um erro! Tente novamente. Lembre-se que o CPF tem 11 dígitos.{Environment.NewLine}\u001b[0m");
                    }

                }
                catch (Exception ex)
                {
                    Console.WriteLine($"\u001b[31mOops, tivemos um erro! Tente novamente.{Environment.NewLine}\u001b[0m");
                }

            }
            while (!validacaoCPF || cpf.Length != 11);

            // endereço

            Console.Write("Endereço: ");
            Endereco = Console.ReadLine();

            // saldo inicial

            bool validacaoSaldoInicial = false;

            do
            {
                try
                {
                    Console.WriteLine("Defina o saldo Inicial:");
                    Console.Write("Saldo: ");
                    Saldo = double.Parse(Console.ReadLine());
                    validacaoSaldoInicial = true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"\u001b[31mOops, tivemos um erro! Tente novamente.{Environment.NewLine}\u001b[0m");
                }
            }
            while (!validacaoSaldoInicial);


            // gerar senha

            GerarSenha();

            // definir status da conta como aberta

            StatusConta = true;
            Console.WriteLine($"{Environment.NewLine}Conta Aberta com sucesso!");

            Console.WriteLine($"{Environment.NewLine}Sua senha é {Senha}");

        }

        //Alterar tipo de conta

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
                    break;
                case 2:
                    TipoConta = "Conta Poupança";
                    break;
                default:
                    Console.WriteLine("Opção Inválida");
                    break;
            }
        }

        // Encerrar Conta
        public void EncerrarConta()
        {
            StatusConta = false;
            Console.WriteLine("Conta Encerrada com sucesso!");
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

        // validacao Senha

        public void ValidarSenha()
        {
            bool validacaoSenha = false;
            do
            {
                try
                {
                    Console.Write("Informe a Senha: ");
                    int senha = int.Parse(Console.ReadLine());
                    if (senha != Senha)
                    {
                        Console.WriteLine($"\u001b[31mSenha Incorreta! Digite um valor válido{Environment.NewLine}\u001b[0m");
                    }
                    else
                    {
                        validacaoSenha = true;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"\u001b[31mOops, tivemos um erro! Tente Novamente{Environment.NewLine}\u001b[0m");
                }
            }
            while (!validacaoSenha);
        }

    }


}
