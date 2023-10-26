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

switch (opcao)
{
    case 1:
        GerarPrimos gerarPrimos = new GerarPrimos();
        BigInteger primo1 = gerarPrimos.GerarPrimo();
        BigInteger primo2 = gerarPrimos.GerarPrimo();
        string arquivoPrimos = Path.Combine(currentDirectory, "primos.txt");
        using (StreamWriter writer = new StreamWriter(arquivoPrimos))
        {
            writer.WriteLine("Primos:");
            writer.WriteLine("Primo 1: " + primo1);
            writer.WriteLine("Primo 2: " + primo2);
            Console.WriteLine("Primos gerados com sucesso! Arquivo: " + arquivoPrimos);
        }
        break;

    case 2:
        GerarChave gerarChave = new GerarChave();
        Console.WriteLine("Digite o primeiro primo: ");
        p = BigInteger.Parse(Console.ReadLine());
        while (!gerarChave.Checkprimo(p))
        {
            Console.WriteLine("O número digitado não é primo. Digite novamente: ");
            p = BigInteger.Parse(Console.ReadLine());
        }
        Console.WriteLine("Digite o segundo primo: ");
        q = BigInteger.Parse(Console.ReadLine());
        while (!gerarChave.Checkprimo(q))
        {
            Console.WriteLine("O número digitado não é primo. Digite novamente: ");
            q = BigInteger.Parse(Console.ReadLine());
        }
        Console.WriteLine("Digite o expoente: ");
        e = BigInteger.Parse(Console.ReadLine());
        while (gerarChave.Mdc(e, (p - 1) * (q - 1)) != 1)
        {
            Console.WriteLine("O expoente deve ser coprimo com (p - 1) * (q - 1). Digite novamente: ");
            e = BigInteger.Parse(Console.ReadLine());
        }
        gerarChave.Genchave(p, q, e);
        break;

    case 3:
        Encriptar encriptar = new Encriptar();
        Console.WriteLine("Digite a mensagem: ");
        string str = Console.ReadLine();
        BigInteger[] novaStr = new BigInteger[str.Length];
        Console.WriteLine("Digite o expoente: ");
        e = BigInteger.Parse(Console.ReadLine());
        Console.WriteLine("Digite o n: ");
        n = BigInteger.Parse(Console.ReadLine());
        encriptar.CriptoAsc(str, novaStr, e, n);
        encriptar.Escrever(novaStr);
        break;

    case 4:
        Console.WriteLine("Digite o primeiro primo: ");
        p = BigInteger.Parse(Console.ReadLine());
        Console.WriteLine("Digite o segundo primo: ");
        q = BigInteger.Parse(Console.ReadLine());
        if (p == 0 || q == 0)
        {
            Console.WriteLine("Forneça valores válidos de p e q");
        }
        else
        {
            Desencriptar desencriptar = new Desencriptar();
            Console.WriteLine("Digite a mensagem: ");
            str = Console.ReadLine();
            BigInteger[] crip = new BigInteger[str.Length];
            Console.WriteLine("Digite o expoente: ");
            e = BigInteger.Parse(Console.ReadLine());
            n = p * q;
            BigInteger phi = (p - 1) * (q - 1);
            BigInteger d = desencriptar.Calculard(e, phi);
            desencriptar.DescriptoAsc(crip, str, d, n);
            desencriptar.Escrever(str);
        }
        break;

    case 5:
        break;
}
