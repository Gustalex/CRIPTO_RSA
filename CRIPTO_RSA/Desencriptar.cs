using System;
using System.Collections.Generic;
using System.IO;
using System.Numerics;

namespace CRIPTO_RSA
{
    internal class Desencriptar
    {
        Opera calc = new Opera();

        public string DesencriptoAsc(BigInteger[] crip, string str, BigInteger d, BigInteger n)
        {
            List<char> decryptedChars = new List<char>();

            for (int i = 0; i < crip.Length; i++)
            {
                BigInteger desencrpt_val = calc.Modexp(crip[i], d, n);
                decryptedChars.Add((char)desencrpt_val);
            }

            string decryptedString = new string(decryptedChars.ToArray());

            return decryptedString;
        }



        public void Escrever(string str)
        {
            using (StreamWriter writer = new StreamWriter("mensagem_descriptografada.txt"))
            {
                writer.WriteLine("Mensagem Descriptografada:");
                writer.WriteLine(str);
            }
        }
    }
}
