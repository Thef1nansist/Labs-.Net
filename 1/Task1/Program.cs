using System;

namespace Task1
{
    class Program
    {
        static void Main()
        {
            while (true)
            {
                Console.Write("\n1-1\n2-2\n3-3\n");
                Console.Write("> ");
                var index = Console.ReadLine();

                switch (index)
                {
                    case "1":
                        TaskA.ParseStr();
                        break;
                    case "2":
                        TaskB.CreateISBN();
                        break;
                    case "3":
                        TaskC.SumArr();
                        break;

                    default:
                        Console.WriteLine("Incorrect value!!!");
                        break;
                }
            }
        }
    }
}
