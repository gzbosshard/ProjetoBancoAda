using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoBancoAda
{
    internal class ContaPoupanca : Conta
    {
        // CLASSES -----

        Utilidades util = new();
        

        // PROPRIEDADES -----
        public double TaxaRendimento { get; set; } = 0.3;

        // MÉTODOS -----

        // Construtor

        public ContaPoupanca(int senha, string nome, int numeroConta, double saldo, List<DateTime> data, List<double> operacoes, List<string> tipoOperacoes, string tipoConta)
        {
            Nome = nome;
            NumeroConta = numeroConta;
            Saldo = saldo;
            DataOperacaoConta = data;
            OperacoesConta = operacoes;
            TipoOperacoesConta = tipoOperacoes;
            TipoConta = tipoConta;
            Senha = senha;
        }

        // Depositar
        public override double Depositar()
        {
            base.Depositar();
            return Saldo += (ValorDeposito * TaxaRendimento);

        }
    }
}
