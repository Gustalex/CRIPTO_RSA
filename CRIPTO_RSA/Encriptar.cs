using System;
using System.Collections.Generic;
using System.IO;
using System.Numerics;

namespace CRIPTO_RSA
{
    internal class Encriptar
    {
        public BigInteger Modexp(BigInteger b, BigInteger exp, BigInteger mod)
        {
            BigInteger res = 1;
            while (exp > 0)
            {
                if (exp.IsEven)
                {
                    b = BigInteger.ModPow(b, 2, mod);
                    exp /= 2;
                }
                else
                {
                    res = BigInteger.ModPow(b, res, mod);
                    exp -= 1;
                }
            }
            return res;
        }

        public void CriptoAsc(string str, BigInteger[] novaStr, BigInteger e, BigInteger n)
        {
            for (int i = 0; i < str.Length; i++)
            {
                novaStr[i] = Modexp((BigInteger)str[i], e, n);
            }
        }

        public void Escrever(BigInteger[] novaStr)
        {
            using (StreamWriter writer = new StreamWriter("mensagem_criptografada.txt"))
            {
                writer.WriteLine("Mensagem Criptografada:");
                for (int i = 0; i < novaStr.Length; i++)
                {
                    writer.Write(novaStr[i]);
                }
            }
        }
    }
}
