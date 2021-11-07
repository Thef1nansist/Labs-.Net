using System;

namespace Task04_03
{
    class Program
    {
        static void Main()
        {
            RationalRepresentationStruct rationalRepresentationStruct = new();

            RationalRepresentationStruct rationalRepresentationStruct1 = new(1, 10);

            Console.WriteLine(rationalRepresentationStruct.Equals(rationalRepresentationStruct1));
            Console.WriteLine(rationalRepresentationStruct.GetHashCode() == rationalRepresentationStruct1.GetHashCode());
            Console.WriteLine(rationalRepresentationStruct);
            Console.WriteLine(rationalRepresentationStruct.CompareTo(rationalRepresentationStruct1));

            Console.WriteLine(rationalRepresentationStruct + rationalRepresentationStruct1);
            Console.WriteLine(rationalRepresentationStruct - rationalRepresentationStruct1);
            Console.WriteLine(rationalRepresentationStruct * rationalRepresentationStruct1);
            Console.WriteLine(rationalRepresentationStruct / rationalRepresentationStruct1);

            double n = (double)rationalRepresentationStruct;
            RationalRepresentationStruct rational = 10;
            Console.WriteLine(n);
            Console.WriteLine(rational);
        }
    }
}
