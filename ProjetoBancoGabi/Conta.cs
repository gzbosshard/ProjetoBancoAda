using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoBancoAda
{

    internal class Conta
    {
        protected string Nome { get; set; }
        protected string Endereco { get; set; }
        protected int NumeroConta { get; set; }
        protected long CPF { get; private set; }
        protected int Senha { get; set; }
        protected double Saldo { get; set; }
        protected DateTime DataDeNascimento { get; set; } // validacação para idade aceitável
        public double ValorDeposito { get; set; }
        public double ValorSaque { get; set; }

        protected bool StatusConta { get; set; } = false;


        // Listas de Contas

        public List<double> SaldoConta { get; set; } = new List<double>();
        public List<DateTime> DataOperacaoConta { get; set; } = new();
        public List<double> OperacoesConta { get; set; } = new List<double>();
        public List<string> TipoOperacoesConta { get; set; } = new List<string>();


        public virtual double Depositar()
        {
            bool validacaoDeposito = false;
            do
            {
                try
                {
                    Console.Write("Valor a ser depositado: ");
                    ValorDeposito = double.Parse(Console.ReadLine());
                    validacaoDeposito = true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"\u001b[31mOops, tivemos um erro! Digite um valor válido{Environment.NewLine}\u001b[0m");
                }
            }
            while (!validacaoDeposito);
            
            OperacoesConta.Add(ValorDeposito);
            DataOperacaoConta.Add(DateTime.Now);
            TipoOperacoesConta.Add("Deposito");
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
            TipoOperacoesConta.Add("Saque");
            Console.WriteLine($"Retirada de {ValorSaque} realizado com sucesso!");
            return Saldo -= ValorSaque;
        }

        public void ConsultarSaldo()
        {
            Console.WriteLine($"O Saldo na conta é de R${Saldo.ToString("F2")}");
        }

        public void ConsultarExtrato()
        {
            Console.WriteLine($"----- EXTRATO -----{Environment.NewLine}");

            Console.WriteLine($"Conta: {NumeroConta}{Environment.NewLine}");
            Console.WriteLine($"Nome do Titular: {Nome}{Environment.NewLine}");

            Console.WriteLine($"O Saldo na conta é de R${Saldo.ToString("F2")}{Environment.NewLine}");
            Console.WriteLine(DateTime.Now);

            // Operacoes realizadas

            Console.WriteLine($"----- OPERAÇÕES REALIZADAS -----{Environment.NewLine}");


            for (int j = 0; j < OperacoesConta.Count; j++)
            {
                Console.WriteLine($"{j+1}: {DataOperacaoConta[j]} : {TipoOperacoesConta[j]} : R$ {OperacoesConta[j].ToString("F2")}");
            }
        }

        public int GerarSenha()
        {
            Random rnd = new Random();
            Senha = rnd.Next(10000, 99999);

            return Senha;
        }       

        // Abrir Conta
        public void AbrirConta()
        {

            Console.WriteLine($"Seja bem vindo ao nosso banco!{Environment.NewLine}" +
                $"Precisaremos seguir algumas etapas para abrir a sua conta:");


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

        // Encerrar Conta
        public void EncerrarConta()
        {
            StatusConta = false;
            Console.WriteLine("Conta Encerrada com sucesso!");
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
