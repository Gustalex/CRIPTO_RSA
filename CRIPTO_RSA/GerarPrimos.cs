using System;
using System.IO;
using System.Numerics;

namespace CRIPTO_RSA
{
    internal class GerarPrimos
    {
        private Random rnd = new Random();

        public BigInteger GerarPrimo()
        {
            BigInteger primo = 0;

            while (true)
            {
                primo = (BigInteger)rnd.Next(1000, 35000);
                if (Checkprimo(primo))
                {
                    return primo;
                }
            }
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
    }
}
