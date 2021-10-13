using System;

namespace Task2
{
    class Program
    {
        static void Main()
        {
            var matrix = new TestMatrix(new int[] { 1, 2, 3, 4, 5 });

            Console.WriteLine(matrix.Equals(new TestMatrix(null)));
            Console.WriteLine(matrix.Sum(new TestMatrix(new int[] { 1, 2, 3, 4 })).ToString());
            Console.WriteLine( matrix[10,-10]);
        }
    }
}
