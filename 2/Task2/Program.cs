using System;

namespace Task2
{
    class Program
    {
        static void Main()
        {
            TestMatrix matrix = new(new int[] { 1, 2, 3, 4, 5 });

            Console.WriteLine(matrix.Equals(new TestMatrix(new int[] { 1, 2, 3, 4, 5 })));
            Console.WriteLine(matrix.Sum(new TestMatrix(new int[] { 1, 2, 3, 4 })).ToString()); 
        }
    }
}
