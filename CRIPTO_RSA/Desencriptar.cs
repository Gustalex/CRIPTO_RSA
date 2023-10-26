using System;
using System.Collections.Generic;
using System.IO;
using System.Numerics;

namespace CRIPTO_RSA
{
    internal class Desencriptar
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

        public BigInteger Calculard(BigInteger e, BigInteger phi)
        {
            BigInteger d = 0;
            BigInteger x1 = 0, x2 = 1, y1 = 1, tempPhi = phi;

            while (e > 0)
            {
                BigInteger temp1 = BigInteger.DivRem(tempPhi, e, out BigInteger temp2);
                tempPhi = e;
                e = temp2;

                BigInteger x = x2 - temp1 * x1;
                BigInteger y = d - temp1 * y1;

                x2 = x1;
                x1 = x;
                d = y1;
                y1 = y;
            }
            if (tempPhi == 1)
            {
                return d + phi;
            }
            return d;
        }

        public void DescriptoAsc(BigInteger[] crip, string str, BigInteger d, BigInteger n)
        {
            crip = new BigInteger[str.Length]; // Inicializa o array crip com o tamanho correto
            for (int i = 0; i < str.Length; i++)
            {
                BigInteger valdcrptd = Modexp((BigInteger)str[i], d, n);
                crip[i] = valdcrptd; // Armazena o valor descriptografado no array crip
            }
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
