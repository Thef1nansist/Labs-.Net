using System;

namespace Task04_02
{
    class Program
    {
        static void Main()
        {
            RationalRepresentation rationalRepresentation = new(-7, 10);
            RationalRepresentation rationalRepresentation2 = new(2, 5);

            Console.WriteLine(rationalRepresentation.Equals(rationalRepresentation2));
            Console.WriteLine(rationalRepresentation.GetHashCode() == rationalRepresentation2.GetHashCode());
            Console.WriteLine(rationalRepresentation);
            Console.WriteLine(rationalRepresentation.CompareTo(rationalRepresentation2));

            Console.WriteLine(rationalRepresentation + rationalRepresentation2);
            Console.WriteLine(rationalRepresentation - rationalRepresentation2);
            Console.WriteLine(rationalRepresentation * rationalRepresentation2);
            Console.WriteLine(rationalRepresentation / rationalRepresentation2);

            double n = (double)rationalRepresentation;
            RationalRepresentation rational = 10;
            Console.WriteLine(n);
            Console.WriteLine(rational);

        }
    }
}
