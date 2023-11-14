﻿using System;
using System.IO;
using System.Numerics;

namespace CRIPTO_RSA
{
    internal class GerarChave
    {
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
