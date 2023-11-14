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
    }
}
