using System;
using System.Collections.Generic;
using System.Numerics;

namespace Task06_02
{
    public static class Lib
    {
        public static List<BigInteger> Factorization(BigInteger N)
        {
            N = N < 2 ? throw new ArgumentException("N must be >= 2", nameof(N)) : N;

            var result = new List<BigInteger>();
            BigInteger i = 3;

            while (N % 2 == 0)
            {
                result.Add(2);
                N /= 2;
            }

            while (i * i <= N)
            {
                if (N % i == 0)
                {
                    result.Add(i);
                    N /= i;
                }
                else
                {
                    i += 2;
                }
            }

            if (N > 1)
            {
                result.Add(N);
            }

            return result;
        }
    }
}
