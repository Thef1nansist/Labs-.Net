using System;


namespace Task04_01
{
    class Program
    {
        static void Main()
        {
            DiagonalMatrix<byte> d2 = new(5);
            var d1 = new DiagonalMatrix<byte>(2);

            var test1 = new DiagonalMatrix<decimal>(1, 2, 3);

            var test2 = new DiagonalMatrix<byte>(1, 2, 3);

            Console.WriteLine(test2.Add(d1, AddHelper).ToString());

            var asd = d2.Add(d1, AddHelper);
            ////Console.WriteLine(asd.ToString());
            ///
            d2[1, 1] = 1;

            Console.WriteLine(d2.ToString());


            MatrixTracker<byte> matrixTracker = new(d2);

            d2[2, 2] = 2;
            Console.WriteLine(d2.ToString());
            matrixTracker.Undo();
            d2[3, 3] = 3;
            Console.WriteLine(d2.ToString());
            d2[4, 4] = 4;
            Console.WriteLine(d2.ToString());
            matrixTracker.Undo();
            matrixTracker.Undo();
            Console.ReadLine();
            Console.WriteLine(d2.ToString());
        }

        private static DiagonalMatrix<T> AddHelper<T>(DiagonalMatrix<T> first, DiagonalMatrix<T> second) where T : struct
        {
            first ??= new DiagonalMatrix<T>();
            second ??= new DiagonalMatrix<T>();

            if (first.Size < second.Size)
            {
                var temp = first;
                first = second;
                second = temp;
            }

            var data = new T[first.Size];
            dynamic a = first;
            dynamic b = second;
            for (int i = 0; i < second.Size; i++)
            {
                data[i] = (T)(a[i, i] + b[i, i]);
            }

            for (int i = second.Size; i < first.Size; i++)
            {
                data[i] = first[i, i];
            }
            return new DiagonalMatrix<T>(data);
        }

    }
}
