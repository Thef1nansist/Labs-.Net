﻿using System;

namespace Task04_03
{
    class Program
    {
        static void Main()
        {
            RationalRepresentationStruct rationalRepresentationStruct = new();
            Console.WriteLine(rationalRepresentationStruct);
            Console.WriteLine(rationalRepresentationStruct / rationalRepresentationStruct);
        }
    }
}
