using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRIPTO_RSA
{
    internal class Encriptar
    {
        public ulong Modexp(ulong b, ulong exp, ulong mod)
        {
            ulong res = 1;
            while (exp > 0)
            {
                if ((exp & 1) == 1)
                {
                    res = (res * b) % mod;
                }
                exp >>= 1;
                b = (b * b) % mod;
            }
            return res;
        }
        public void CriptoAsc(string str, ulong[] novaStr, ulong e, ulong n)
        {
            for (int i = 0; i < str.Length; i++)
            {
                novaStr[i] = Modexp((ulong)str[i], e, n);
            }
        }
        public void Escrever(ulong[] novaStr)
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
