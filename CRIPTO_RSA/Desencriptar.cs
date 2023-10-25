using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRIPTO_RSA
{
    internal class Desencriptar
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
        public ulong Calculard(ulong e, ulong phi)
        {
            ulong d = 0;
            ulong x1 = 0, x2 = 1, y1 = 1, tempPhi = phi;

            while (e > 0)
            {
                ulong temp1 = tempPhi / e;
                ulong temp2 = tempPhi - temp1 * e;
                tempPhi = e;
                e = temp2;

                ulong x = x2 - temp1 * x1;
                ulong y = d - temp1 * y1;

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
        public void DescriptoAsc(ulong[] crip, string str, ulong d, ulong n)
        {
            for(int i = 0; i < str.Length; i++)
            {
                ulong valdcrptd = Modexp(crip[i], d, n);
                str += (char)valdcrptd;
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
