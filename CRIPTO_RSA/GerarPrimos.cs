using System;
using System.IO;
using System.Numerics;

namespace CRIPTO_RSA
{
    internal class GerarPrimos
    {
        Opera calc = new Opera();

        private Random rnd = new Random();
        public BigInteger GerarPrimo()
        {
            BigInteger primo = 0;

            while (true)
            {
                primo = (BigInteger)rnd.Next(1000, 35000);
                if (calc.Checkprimo(primo))
                {
                    return primo;
                }
            }
        }
    }
}
