using System;
using System.Collections.Generic;
using System.IO;
using System.Numerics;

namespace CRIPTO_RSA
{
    internal class Encriptar
    {
        Opera calc = new Opera();

        public void EncriptoAsc(BigInteger[] crip, string str, BigInteger e, BigInteger n)
        {
            for (int i = 0; i < str.Length; i++)
            {
                int ascii_val = (int)str[i];
                crip[i] = calc.Modexp(ascii_val, e, n);
            }
        }

        public void Escrever(BigInteger[] crip)
        {
            using (StreamWriter writer = new StreamWriter("mensagem_criptografada.txt"))
            {
                writer.WriteLine("Mensagem Criptografada:");
                for(int i = 0; i < crip.Length; i++)
                {
                    writer.Write(crip[i] + " ");
                }
            }
        }
    }
}