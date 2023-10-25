using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRIPTO_RSA
{

    public class Gerar_Chave
    {
     public ulong Mdc(ulong a, ulong b)
        {
            while (b!=0)
            {
                ulong temp = a % b;
                a = b;
                b = temp;
            }
            return a;
        }
      public bool Checkprimo(ulong n)
        {
            if (n < 2) return false;
            ulong maiordiv = (ulong)Math.Sqrt(n);
            for (ulong i = 2; i <= maiordiv; i++)
            {
                if (n % i == 0) return false;
            }
           return true;
        }
      public void Genchave(ulong p, ulong q, ulong e)
        {
            ulong n = p * q;
            ulong phi = (p - 1) * (q - 1);

            using (StreamWriter writer = new StreamWriter("chave_publica.txt"))
            {
                writer.WriteLine("Chave Pública:");
                writer.WriteLine("e: " + e);
                writer.WriteLine("n: " + n);
            }
        }
    }
}
