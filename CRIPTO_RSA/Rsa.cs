using CRIPTO_RSA;
using System;
using System.IO;
using System.Numerics;

class Program
{
    static void Main()
    {
        string currentDirectory = Directory.GetCurrentDirectory();
        int opcao = 0;

        Opera calc = new Opera();
        GerarPrimos primo = new GerarPrimos();
        GerarChave chave = new GerarChave();

        BigInteger p = 0;
        BigInteger q = 0;
        BigInteger e = 0;
        BigInteger n = 0;

        while (opcao != 5)
        {
            Console.WriteLine("CRIPTOGRAFIA RSA\n\n");
            Console.WriteLine("Escolha uma opção:\n");
            Console.WriteLine("1 - Gerar Primos\n");
            Console.WriteLine("2 - Gerar Chave\n");
            Console.WriteLine("3 - Encriptar\n");
            Console.WriteLine("4 - Desencriptar\n");
            Console.WriteLine("5 - Sair\n");

            opcao = int.Parse(Console.ReadLine());

            switch (opcao)
            {
                case 1:
                    p = primo.GerarPrimo();
                    q = primo.GerarPrimo();
                    Console.WriteLine("p: " + p);
                    Console.WriteLine("q: " + q);
                    Console.WriteLine("\n");
                    break;
                case 2:
                    Console.WriteLine("Digite o valor de p:");
                    p = BigInteger.Parse(Console.ReadLine());
                    while (!calc.Checkprimo(p))
                    {
                        Console.WriteLine("O valor de p não é primo, digite outro valor:");
                        p = BigInteger.Parse(Console.ReadLine());
                    }
                    Console.WriteLine("Digite o valor de q:");
                    q = BigInteger.Parse(Console.ReadLine());
                    while (!calc.Checkprimo(q))
                    {
                        Console.WriteLine("O valor de q não é primo, digite outro valor:");
                        q = BigInteger.Parse(Console.ReadLine());
                    }
                    Console.WriteLine("Digite o valor de e");
                    e = BigInteger.Parse(Console.ReadLine());
                    while (calc.Mdc(e, (p - 1) * (q - 1)) != 1)
                    {
                        Console.WriteLine("O valor de e não é coprimo com (p-1)*(q-1), digite outro valor:");
                        e = BigInteger.Parse(Console.ReadLine());
                    }
                    chave.Genchave(p, q, e);
                    break;
                case 3:
                    Console.WriteLine("Digite o valor de e:");
                    e = BigInteger.Parse(Console.ReadLine());
                    Console.WriteLine("Digite o valor de n:");
                    n = BigInteger.Parse(Console.ReadLine());
                    Console.WriteLine("Digite a mensagem:");
                    string str = Console.ReadLine();
                    BigInteger[] crip = new BigInteger[str.Length];
                    Encriptar encriptar = new Encriptar();
                    encriptar.EncriptoAsc(crip, str, e, n);
                    encriptar.Escrever(str, crip);
                    Console.WriteLine("Mensagem criptografada com sucesso.\n");
                    break;
                case 4:
                    break;
                case 5:
                    Console.WriteLine("Saindo.");
                    break;
                default:
                    Console.WriteLine("Opção inválida. Tente novamente.");
                    break;
            }
        }
    }
}
