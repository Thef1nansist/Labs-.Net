using System;
using System.Collections.Generic;
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

            if (valInt[0] > valInt[1])
            {
                var temp = valInt[1];
                valInt[1] = valInt[0];
                valInt[0] = temp;
            }

            Console.WriteLine("Three-digit numbers containing two twos in your range:");

            for (var i = valInt[0]; i <= valInt[1]; i++)
            {
                var convertValues = ParseToThree(i);

                var countOfTwo = convertValues
                    .Where(x => x.Equals(2))
                    .Count();

                if (countOfTwo.Equals(2) && i > 0)
                {
                    Console.WriteLine(i);
                    countNum++;
                }
                else if (countOfTwo.Equals(2) && i < 0)
                {
                    Console.WriteLine(i);
                    countNum++;
                }

            }
            if (countNum.Equals(0))
            {
                Console.WriteLine("You entered the wrong range.");
            }
        }
        private static List<int> ParseToThree(int numberOfInt)
        {
            var list = new List<int>();

            numberOfInt = Math.Abs(numberOfInt);

            while (numberOfInt > 0)
            {
                var temp1 = numberOfInt % 3;
                numberOfInt = numberOfInt / 3;
                list.Add(temp1);
            }

            return list;
        }
    }
}
