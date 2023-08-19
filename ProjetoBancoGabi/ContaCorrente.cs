using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoBancoAda
{
    internal class ContaCorrente : Conta
    {
        public double Limite { get; set; }
        public double TaxaDeManutencao { get; set; } = 0.02;
        public override double Sacar()
        {
            base.Sacar();
            SaldoConta.Add(Saldo);
            Saldo -= TaxaDeManutencao;
            return Saldo;
        }

        public override double Depositar()
        {
            base.Depositar();
            SaldoConta.Add(Saldo);
            Saldo -= TaxaDeManutencao;
            return Saldo;
        }

    }
}
