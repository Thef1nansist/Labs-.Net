using System;

namespace Task04_01
{
    class Program
    {
        static void Main()
        {
            DiagonalMatrix<string> strdig = new(5);

            strdig[0, 0] = "One";
            strdig[1, 1] = "Two";
            strdig[2, 2] = "Three";
            strdig[3, 3] = "Four";
            strdig[4, 4] = "Five";

            Console.WriteLine(strdig.ToString());

            DiagonalMatrix<string> strdig2 = new(5);

            strdig2[0, 0] = "One";
            strdig2[1, 1] = "Two";
            strdig2[2, 2] = "Three";
            strdig2[3, 3] = "Four";
            strdig2[4, 4] = "Five";

            Console.WriteLine(strdig.Add(strdig2, (a1, a2) =>
            {
                return a1 + a2;
            }));

            MatrixTracker<string> matrixTrackerString = new(strdig2);

            Console.WriteLine("ComeBack link type///////////////////");
            strdig2[0, 0] = "1";
            Console.WriteLine(strdig2);
            matrixTrackerString.Undo();
            strdig2[1, 1] = "2";
            Console.WriteLine(strdig2);
            strdig2[2, 2] = "3";
            Console.WriteLine(strdig2);
            strdig2[3, 3] = "4";
            Console.WriteLine(strdig2);
            matrixTrackerString.Undo();
            strdig2[4, 4] = null;
            Console.WriteLine(strdig2);
            matrixTrackerString.Undo();
            Console.WriteLine(strdig2);


            DiagonalMatrix<int> intdig = new(5);

            intdig[0, 0] = 1;
            intdig[1, 1] = 2;
            intdig[2, 2] = 3;
            intdig[3, 3] = 4;
            intdig[4, 4] = 5;
            Console.WriteLine(intdig.ToString());


            DiagonalMatrix<int> intdig2 = new(4);

            intdig2[0, 0] = 1;
            intdig2[1, 1] = 2;
            intdig2[2, 2] = 3;
            intdig2[3, 3] = 4;
            Console.WriteLine(intdig2.ToString());

            Console.WriteLine(intdig.Add(intdig2, (a1, a2) =>
            {
                return a1 + a2;
            }));


            Console.WriteLine("ComeBack value type ***************");
            MatrixTracker<int> matrixTracker = new(intdig2);
            intdig2[0, 0] = 0;
            Console.WriteLine(intdig2);
            intdig2[1, 1] = 2;
            Console.WriteLine(intdig2);
            matrixTracker.Undo();
            intdig2[2, 2] = 0;
            Console.WriteLine(intdig2);
            intdig2[3, 3] = 0;
            Console.WriteLine(intdig2);
            matrixTracker.Undo();
            Console.WriteLine(intdig2);


           // DiagonalMatrix<decimal> decimaldig = new(-5);

        }
    }
}
