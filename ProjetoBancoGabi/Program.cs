namespace ProjetoBancoGabi
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Conta conta1 = new Conta();

            Conta conta2 = new ContaCorrente();
            Conta conta3 = new ContaPoupanca();

            conta1.SelecionarOperacao();
        }
    }
}
