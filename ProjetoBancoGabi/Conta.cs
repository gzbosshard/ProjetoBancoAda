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
        // CLASSES -----

        Utilidades util = new();

        // PROPRIEDADES -----

        public string Nome { get; set; }
        protected string Endereco { get; set; }
        public int NumeroConta { get; set; }
        protected long CPF { get; private set; }
        protected int Senha { get; set; }
        public double Saldo { get; set; }
        protected double Limite { get; set; } = 0;
        protected DateTime DataDeNascimento { get; set; } // validacação para idade aceitável
        public double ValorDeposito { get; set; }
        public double ValorSaque { get; set; }
        public string TipoConta { get; set; }

        // Listas de Contas

        public List<DateTime> DataOperacaoConta { get; set; } = new();
        public List<double> OperacoesConta { get; set; } = new List<double>();
        public List<string> TipoOperacoesConta { get; set; } = new List<string>();

        // MÉTODOS -----

        // Depositar

        public virtual double Depositar()
        {
            ValorDeposito = util.ValidacaoDouble("Valor a ser depositado: ");

            OperacoesConta.Add(ValorDeposito);
            DataOperacaoConta.Add(DateTime.Now);
            TipoOperacoesConta.Add("Deposito");
            Console.WriteLine($"Depósito de R$ {ValorDeposito.ToString("F2")} realizado com sucesso!");
            return Saldo += ValorDeposito;
        }

        // Sacar
        public virtual double Sacar()
        {
            util.ValidacaoInt("Informe a Senha: ");

            Console.WriteLine($"{Environment.NewLine}Seu saldo atual é de: R4 {Saldo.ToString("F2")}.{Environment.NewLine}");
            ValorSaque = util.ValidacaoDouble("Digite o valor que deseja sacar: ");

            if (ValorSaque > (Saldo))
            {
                Console.WriteLine($"Saldo Insuficiente. O seu saldo é de R$ {Saldo.ToString("F2")}.");
                return Saldo;
            }
            else
            {
                OperacoesConta.Add(ValorSaque);
                DataOperacaoConta.Add(DateTime.Now);
                TipoOperacoesConta.Add("Saque");
                Console.WriteLine($"Retirada de {ValorSaque} realizado com sucesso!");
                return Saldo -= ValorSaque;
            }


        }

        // Consultar Saldo
        public virtual void ConsultarSaldo()
        {

            Console.WriteLine($"O Saldo na conta é de R${Saldo.ToString("F2")}");
        }

        // Consultar Extrato
        public virtual void ConsultarExtrato()
        {
            Console.WriteLine($"----- EXTRATO -----{Environment.NewLine}");
            Console.WriteLine(DateTime.Now);
            Console.WriteLine();

            Console.WriteLine($"Conta: {NumeroConta} | Nome do Titular: {Nome} | Tipo de Conta: {TipoConta}{Environment.NewLine}");




            // Operacoes realizadas

            Console.WriteLine($"----- OPERAÇÕES REALIZADAS -----{Environment.NewLine}");

            if (OperacoesConta.Count == 0)
            {
                Console.WriteLine($"Ainda não foram realizadas operações bancárias.{Environment.NewLine}");
            }
            else
            {

                for (int i = 0; i < OperacoesConta.Count; i++)
                {
                    Console.WriteLine($"{i + 1}: {DataOperacaoConta[i]} : {TipoOperacoesConta[i]} : R$ {OperacoesConta[i].ToString("F2")}");
                }
            }

            // Saldos

            Console.WriteLine($"{Environment.NewLine}----- SALDO -----{Environment.NewLine}");

            Console.WriteLine($"Saldo: R${Saldo.ToString("F2")}{Environment.NewLine}");


        }

        // Gerar Senha

        public int GerarSenha()
        {
            Random rnd = new Random();
            Senha = rnd.Next(10000, 99999);

            return Senha;
        }

        // Gerar Número da Conta

        public int GerarConta()
        {
            Random rndNumeroConta = new Random();
            NumeroConta = rndNumeroConta.Next(1000, 9999);

            Console.WriteLine($"O número da conta é {NumeroConta}");
            return NumeroConta;
        }

        // Abrir Conta
        public virtual void AbrirConta()
        {
            Console.Clear();
            Console.WriteLine($"----- ABERTURA DE CONTA -----{Environment.NewLine}");
            Console.WriteLine($"Seja bem vindo ao nosso banco!{Environment.NewLine}" +
                $"Precisaremos seguir algumas etapas para abrir a sua conta:");

            // nome

            Console.WriteLine($"{Environment.NewLine}Preencha os dados pessoais:{Environment.NewLine}");
            Console.Write("Nome: ");
            Nome = Console.ReadLine();

            // data de nascimento

            DataDeNascimento = util.ValidacaoData("Data de nascimento: ");

            // Numero da Conta

            GerarConta();

            // CPF

            CPF = util.ValidacaoCPF();

            // endereço

            Console.Write("Endereço: ");
            Endereco = Console.ReadLine();

            // saldo inicial


            Saldo = util.ValidacaoDouble("Saldo inicial: ");


            // gerar senha

            GerarSenha();

            // definir status da conta como aberta

            Console.WriteLine($"{Environment.NewLine}Conta Aberta com sucesso!");

            Console.WriteLine($"{Environment.NewLine}Sua senha é {Senha}");

        }

        // Encerrar Conta
        public void EncerrarConta()
        {
            Console.WriteLine($"{Environment.NewLine}Conta Encerrada com sucesso!{Environment.NewLine}");
        }

        // Definir Limite

        public virtual double DefinirLimite()
        {
            return Limite;
        }

    }


}
