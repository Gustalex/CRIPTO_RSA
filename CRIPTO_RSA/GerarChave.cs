using System;
using System.IO;
using System.Numerics;

namespace CRIPTO_RSA
{
    internal class GerarChave
    {
        public BigInteger Mdc(BigInteger a, BigInteger b)
        {
            while (b != 0)
            {
                BigInteger temp = a % b;
                a = b;
                b = temp;
            }
            return a;
        }

        public bool Checkprimo(BigInteger n)
        {
            if (n < 2)
                return false;
            BigInteger maiordiv = (BigInteger)Math.Sqrt((double)n);
            for (BigInteger i = 2; i <= maiordiv; i++)
            {
                if (n % i == 0)
                    return false;
            }
            return true;
        }


        public void Genchave(BigInteger p, BigInteger q, BigInteger e)
        {
            BigInteger n = p * q;
            BigInteger phi = (p - 1) * (q - 1);

            using (StreamWriter writer = new StreamWriter("chave_publica.txt"))
            {
                writer.WriteLine("Chave Pública:");
                writer.WriteLine("e: " + e);
                writer.WriteLine("n: " + n);
            }
        }
    }
}
