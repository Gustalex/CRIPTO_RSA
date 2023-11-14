using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace CRIPTO_RSA
{
    internal class Opera
    {
        public BigInteger Mdc(BigInteger a, BigInteger b)
        {
            while (b != 0)
            {
                BigInteger temp = a % b;
                a = b;
                b = temp;
            }
            return a;
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
        public BigInteger Modexp(BigInteger bse, BigInteger exp, BigInteger mod)
        {
            if (mod <= 0)
            {
                // Tratar caso especial onde mod é zero ou negativo
                throw new ArgumentException("O valor de 'mod' deve ser positivo e diferente de zero.");
            }

            BigInteger result = 1;
            bse = bse % mod;

            while (exp > 0)
            {
                if (exp % 2 == 1)
                {
                    result = (result * bse) % mod;
                }
                bse = (bse * bse) % mod;
                exp = exp / 2;
            }

            return result;
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
    }
}
