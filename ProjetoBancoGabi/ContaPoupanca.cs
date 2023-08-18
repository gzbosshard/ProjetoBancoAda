using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoBancoGabi
{
    internal class ContaPoupanca : Conta
    {
        public double TaxaRendimento { get; set; } = 0.3;

        public override double Sacar()
        {
            base.Sacar();
            SaldoConta.Add(Saldo);
            return Saldo;
        }
        public override double Depositar()
        {

            Console.Write("Valor a ser depositado: ");
            ValorDeposito = double.Parse(Console.ReadLine());
            OperacoesConta.Add(ValorDeposito);
            DataOperacaoConta.Add(DateTime.Now);
            Console.WriteLine($"Depósito de R$ {ValorDeposito.ToString("F2")} realizado com sucesso!");
            return Saldo += ValorDeposito * (1 + TaxaRendimento);

        }
    }
}
