using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoBancoAda
{
    internal class ContaCorrente : Conta
    {
        // CLASSES -----

        Utilidades util = new();

        // PROPRIEDADES -----
        public double Limite { get; set; }
        public double TaxaDeManutencao { get; set; } = 0.02;


        // MÉTODOS -----

        // Construtor

        public ContaCorrente(string nome, int numeroConta, double saldo, List<DateTime> data, List<double> operacoes, List<string> tipoOperacoes, string tipoConta)
        {
            Nome = nome;
            NumeroConta = numeroConta;
            Saldo = saldo;
            DataOperacaoConta = data;
            OperacoesConta = operacoes;
            TipoOperacoesConta = tipoOperacoes;
            TipoConta = tipoConta;
        }


        // Sacar
        public override double Sacar()
        {

            util.ValidacaoInt("Informe a Senha: ");

            Console.WriteLine($"Seu saldo atual é de: R4 {Saldo.ToString("F2")} e há R$ {Limite.ToString("F2")} de limite;");
            ValorSaque = util.ValidacaoDouble("Digite o valor que deseja sacar: ");

            if (ValorSaque > (Saldo + Limite))
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
                return Saldo -= (ValorSaque + TaxaDeManutencao);
            }
        }
        
        // Depositar
        public override double Depositar()
        {
            base.Depositar();
            return Saldo -= TaxaDeManutencao;
        }

        // Definir Limite

        public override double DefinirLimite()
        {
            Console.WriteLine("Em conta corrente temos um limite de saldo definido pelo usuário.");
            Console.WriteLine($"Informe o limite e depois prossiga com as demais infomações para abertura de conta: {Environment.NewLine}");
            Limite = util.ValidacaoDouble($"Limite da conta corrente: ");
            Console.WriteLine($"{Environment.NewLine}O limite da conta corrente foi definido em R$ {Limite.ToString("F2")}.{Environment.NewLine}");

            return Limite;
        }

        // Abrir Conta
        public override void AbrirConta()
        {
            base.AbrirConta();
        }

        // Saldo

        public override void ConsultarSaldo()
        {
            base.ConsultarSaldo();
            Console.WriteLine($"Limite: R${Limite.ToString("F2")}{Environment.NewLine}");
        }

        // Extrato

        public override void ConsultarExtrato()
        {
            base.ConsultarExtrato();
            Console.WriteLine($"Limite: R$ {Limite.ToString("F2")}");
        }


    }
}
