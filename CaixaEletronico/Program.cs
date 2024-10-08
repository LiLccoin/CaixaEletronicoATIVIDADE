using System;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        double saldo = 2050.0;
        double limiteSaque = 500.0;
        int opcao;

        using (StreamWriter extrato = new StreamWriter("extrato.txt", true))
        {
            do
            {
                Console.WriteLine("Bem-vindo ao Caixa Eletrônico!");
                Console.WriteLine("1. Verificar Saldo");
                Console.WriteLine("2. Sacar");
                Console.WriteLine("3. Depositar");
                Console.WriteLine("4. Extrato");
                Console.WriteLine("5. Transferir");
                Console.WriteLine("6. Sair");
                Console.Write("Escolha uma opção: ");
                opcao = int.Parse(Console.ReadLine());

                switch (opcao)
                {
                    case 1:
                        Console.WriteLine($"Seu saldo atual é: R$ {saldo}");
                        extrato.WriteLine($"Saldo: R$ {saldo}");
                        break;

                    case 2:
                        Console.Write("Digite o valor do saque: R$ ");
                        double valorSaque = double.Parse(Console.ReadLine());
                        if (valorSaque > limiteSaque)
                        {
                            Console.WriteLine($"O valor máximo de saque é: R$ {limiteSaque}");
                        }
                        else if (valorSaque > saldo)
                        {
                            Console.WriteLine("Saldo insuficiente.");
                        }
                        else
                        {
                            saldo -= valorSaque;
                            Console.WriteLine($"Saque de R$ {valorSaque} realizado com sucesso!");
                            extrato.WriteLine($"Saque de R$ {valorSaque} realizado");
                        }
                        break;

                    case 3:
                        Console.Write("Digite o valor do depósito: R$ ");
                        double valorDeposito = double.Parse(Console.ReadLine());
                        saldo += valorDeposito;
                        Console.WriteLine($"Depósito de R$ {valorDeposito} realizado com sucesso!");
                        extrato.WriteLine($"Depósito de R$ {valorDeposito} realizado");
                        break;

                    case 4:
                        Console.WriteLine("Extrato:");
                        using (StreamReader reader = new StreamReader("extrato.txt"))
                        {
                            string line;
                            while ((line = reader.ReadLine()) != null)
                            {
                                Console.WriteLine(line);
                            }
                        }
                        break;

                    case 5:
                        Console.Write("Digite o valor da transferência: R$ ");
                        double valorTransferencia = double.Parse(Console.ReadLine());
                        if (valorTransferencia > saldo)
                        {
                            Console.WriteLine("Saldo insuficiente para transferência.");
                        }
                        else
                        {
                            saldo -= valorTransferencia;
                            Console.WriteLine($"Transferência de R$ {valorTransferencia} realizada com sucesso!");
                            extrato.WriteLine($"Transferência de R$ {valorTransferencia} realizada");
                        }
                        break;

                    case 6:
                        Console.WriteLine("Obrigado por usar o Caixa Eletrônico!");
                        break;

                    default:
                        Console.WriteLine("Opção inválida. Tente novamente.");
                        break;
                }

                Console.WriteLine();
            } while (opcao != 6);
        }
    }
}
