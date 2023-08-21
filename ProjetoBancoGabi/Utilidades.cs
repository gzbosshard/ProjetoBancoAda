using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoBancoAda
{
    internal class Utilidades
    {       
        // PROPRIEDADES -----

        public double DoubleValidado { get; private set; }
        public int IntValidado { get; private set; }
        public int OpcaoOperacao { get; set; }
        public int Senha { get; private set; }
        public long CPFValidado { get; private set; }
        public string Mensagem { get; set; }
        public string TextoValidado { get; set; }
        public DateTime DataValidada { get; set; }

        // MÉTODOS -----

        // Validação de Valores Double
        public double ValidacaoDouble(string mensagem)
        {
            Mensagem = mensagem;

            bool validacao = false;
            do
            {
                try
                {
                    Console.Write(Mensagem);
                    DoubleValidado = double.Parse((Console.ReadLine()));
                    validacao = true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"\u001b[31mOops, tivemos um erro! Digite um valor válido{Environment.NewLine}\u001b[0m");
                }
            }
            while (!validacao);

            return DoubleValidado;
        }

        // Validação de Valores Int
        public int ValidacaoInt(string mensagem)
        {
            Mensagem = mensagem;

            bool validacao = false;
            do
            {
                try
                {
                    Console.Write(Mensagem);
                    IntValidado = int.Parse((Console.ReadLine()));
                    validacao = true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"\u001b[31mOops, tivemos um erro! Digite um valor válido{Environment.NewLine}\u001b[0m");
                }
            }
            while (!validacao);

            return IntValidado;
        }

        // Validação Senha

        public int SenhaValidada(int senha)
        {
            Senha = senha;
            do
            {
                int senhaInformada = ValidacaoInt("Informe a Senha: ");
                if (senhaInformada != Senha)
                {
                    Console.WriteLine($"\u001b[31mSenha inválida! Tente novamente.{Environment.NewLine}\u001b[0m");
                }
            }
            while (senha != Senha);

            return Senha;
        }
        
        // Validar Texto

        public string ValidarTexto(string mensagem)
        {
            bool validacao = false;
            Mensagem = mensagem;

            do
            {
                Console.Write(Mensagem);
                TextoValidado = Console.ReadLine();

                if (TextoValidado == "")
                {
                    Console.WriteLine($"\u001b[31mEsse campo é obrigatório!\u001b[0m");
                }
                else
                {
                    validacao = true;
                }
            }
            while (!validacao);

            return TextoValidado;
        }


        // Validação do CPF
        public long ValidacaoCPF()
        {
            bool validacaoCPF = false;
            string cpf = "vazio";

            do
            {
                try
                {
                    Console.Write("CPF (digite apenas os números): ");
                    cpf = Console.ReadLine();
                    CPFValidado = long.Parse(cpf);
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

            return CPFValidado;
        }

        // Validação de Data

        public DateTime ValidacaoData(string mensagem)
        {
            bool validacao = false;
            Mensagem = mensagem;

            do
            {
                try
                {
                    Console.Write(Mensagem);
                    DataValidada = DateTime.Parse(Console.ReadLine());

                    if (DataValidada < DateTime.Now)
                    {
                        validacao = true;
                    }
                    else
                    {
                        Console.WriteLine($"\u001b[31mA data de nascimento deve ser maior que a data atual." +
                            $"Só abrimos contas para pessoas que já nasceram!{Environment.NewLine}\u001b[0m");
                    }

                    
                    
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"\u001b[31mOops, tivemos um erro! Digite um valor válido.{Environment.NewLine}\u001b[0m");
                }

            }
            while (!validacao);
            return DataValidada;
        }

        // Validacao Menu de Selecão de Opções

        public int ValidarMenu()
        {

            bool validacaoOperacao = false;
            
            do
            {
                try
                {
                    Console.WriteLine("Selecione a operação a ser realizada:");
                    Console.WriteLine("1. Depositar");
                    Console.WriteLine("2. Sacar");
                    Console.WriteLine("3. Consultar Saldo");
                    Console.WriteLine("4. Consultar Extrato");
                    Console.WriteLine("5. Alterar Tipo de Conta");
                    Console.WriteLine("6. Encerrar Conta");
                    Console.WriteLine("7. Sair");
                    Console.Write("Número da opção: ");
                    OpcaoOperacao = int.Parse(Console.ReadLine());
                    validacaoOperacao = true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"\u001b[31mOops, tivemos um erro! Digite um valor válido{Environment.NewLine}\u001b[0m");
                }
            }
            while (!validacaoOperacao && OpcaoOperacao > 0 && OpcaoOperacao < 8);

            return OpcaoOperacao;
        }

        
    }
}
