using CRIPTO_RSA;
using System;
using System.IO;
using System.Numerics;

string currentDirectory = Directory.GetCurrentDirectory();
Console.WriteLine("CRIPTOGRAFIA RSA\n\n");
Console.WriteLine("Escolha uma opção:\n");
Console.WriteLine("1 - Gerar Primos\n");
Console.WriteLine("2 - Gerar Chave\n");
Console.WriteLine("3 - Encriptar\n");
Console.WriteLine("4 - Desencriptar\n");
Console.WriteLine("5 - Sair\n");

int opcao = int.Parse(Console.ReadLine());

BigInteger p = 0;
BigInteger q = 0;
BigInteger e = 0;
BigInteger n = 0;

Opera calc = new Opera();
GerarChave chave = new GerarChave();

switch (opcao)
{
    case 1:
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

}