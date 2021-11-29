using System;
using System.Numerics;
using System.Threading.Tasks;

namespace Task06_02
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Sync");
            foreach (var item in Lib.Factorization(1234567890))
            {
                Console.WriteLine(item);
            }

            var test = ThreadLib.FactorizationAsync(63018038201);

            Console.WriteLine("Async");
            foreach (var item in test.Result)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("Last task: " + GcdAsync(1234567890, 63018038201).Result); 
        }

        private static async Task<BigInteger> GcdAsync(BigInteger first, BigInteger second)
        {
            var listFirst = await ThreadLib
                .FactorizationAsync(first);
            var listSecond = await ThreadLib
                .FactorizationAsync(second);
            var result = BigInteger.One;

            foreach (var item in listFirst)
            {
                if(listSecond.Contains(item))
                {
                    result *= item;
                    listSecond.Remove(item);
                }
            }

            return result;
        }
    }
}
