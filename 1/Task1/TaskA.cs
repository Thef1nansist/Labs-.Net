using System;
using System.Linq;

namespace Task1
{
    public static class TaskA
    {
        private static int countNum;

        public static void ParseStr()
        {
            Console.WriteLine("Hi! Enter two values: ");

            var valInt = Console
                .ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            Console.WriteLine("Three-digit numbers containing two twos in your range:");

            for (int i = valInt[0]; i <= valInt[1]; i++)
            {
                var test = i
                    .ToString()
                    .Select(x => (int)char.GetNumericValue(x))
                    .ToList();

                if (test.Count.Equals(3))
                {
                    var countOfTwo = test
                        .Where(x => x.Equals(2))
                        .ToList()
                        .Count;

                    if (countOfTwo.Equals(2))
                    {
                        Console.WriteLine(i);
                        countNum++;
                    }
                }
            }
            if (countNum.Equals(0))
            {
                Console.WriteLine("You entered the wrong range.");
            }
        }
    }
}
