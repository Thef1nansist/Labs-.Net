using System;

namespace Task05_01
{
    class Program
    {
        static void Main(string[] args)
        {
            var matrix = new SparseMatrix(5, 5);
            matrix[1, 1] = 5;
            matrix[1, 3] = 5;
            matrix[1, 5] = 5;
            matrix[1, 2] = 5;
            matrix[3, 5] = 5;
            matrix[2, 3] = 5;
            matrix[3, 3] = 5;
            matrix[4, 2] = 5;
            matrix[5, 5] = 5;
            //Console.WriteLine(matrix.ToString());

            //foreach (var item in matrix)
            //{
            //    Console.WriteLine(item);
            //}

            Console.WriteLine(matrix.GetCount(4));

        }
    }
}
