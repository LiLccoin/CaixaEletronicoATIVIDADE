using System;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        double saldo = 2050.0;
        double limiteSaque = 500.0;
        double limiteTransferencia = 1000.0;
        string senha = "123456"; 
        string cpf = "99737244629";
        double taxaTransferencia = 0.0005;
        int opcao;

        Console.Write("Digite seu CPF: ");
        string cpfdigitado = Console.ReadLine();

        if (cpfdigitado != cpf )
        {
            Console.WriteLine("CPF incorreto.");
            return;
        }

        Console.Write("Digite sua senha (6 dígitos): ");
        string senhaDigitada = Console.ReadLine();

        if (senhaDigitada != senha)
        {
            Console.WriteLine("Senha incorreta. Acesso negado.");
            return; 
        }

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
                Console.WriteLine("6. Aplicar em Poupança");
                Console.WriteLine("7. Aplicar em CDB");
                Console.WriteLine("8. Sair");
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
                        double taxa = valorTransferencia * taxaTransferencia;

                        if (valorTransferencia > limiteTransferencia)
                        {
                            Console.WriteLine($"O valor máximo de transferência é: R$ {limiteTransferencia}");
                        }
                        else if (valorTransferencia + taxa > saldo)
                        {
                            Console.WriteLine("Saldo insuficiente para transferência.");
                        }
                        else
                        {
                            saldo -= (valorTransferencia + taxa);
                            Console.WriteLine($"Transferência de R$ {valorTransferencia} realizada com sucesso! Taxa: R$ {taxa}");
                            extrato.WriteLine($"Transferência de R$ {valorTransferencia} realizada com taxa de R$ {taxa}");
                        }
                        break;

                    case 6:
                        Console.Write("Digite o valor para aplicar em Poupança: R$ ");
                        double valorPoupanca = double.Parse(Console.ReadLine());
                        if (valorPoupanca > saldo)
                        {
                            Console.WriteLine("Saldo insuficiente para aplicação.");
                        }
                        else
                        {
                            saldo -= valorPoupanca;
                            Console.WriteLine($"Aplicação de R$ {valorPoupanca} em Poupança realizada com sucesso!");
                            extrato.WriteLine($"Aplicação de R$ {valorPoupanca} em Poupança realizada");
                        }
                        break;

                    case 7:
                        Console.Write("Digite o valor para aplicar em CDB: R$ ");
                        double valorCDB = double.Parse(Console.ReadLine());
                        if (valorCDB > saldo)
                        {
                            Console.WriteLine("Saldo insuficiente para aplicação.");
                        }
                        else
                        {
                            saldo -= valorCDB;
                            Console.WriteLine($"Aplicação de R$ {valorCDB} em CDB realizada com sucesso!");
                            extrato.WriteLine($"Aplicação de R$ {valorCDB} em CDB realizada");
                        }
                        break;

                    case 8:
                        Console.WriteLine("Obrigado por usar o Caixa Eletrônico!");
                        break;

                    default:
                        Console.WriteLine("Opção inválida. Tente novamente.");
                        break;
                }

                Console.WriteLine();
            } while (opcao != 8);
        }
    }
}
