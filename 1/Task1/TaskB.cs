using System;
using System.Linq;

namespace Task1
{
    public static class TaskB
    {
        public static void CreateISBN()
        {
            var uniqId = 0;
            var current = 10;
            var divider = 11;
            var ISBN = "";

            var items =
                Console
                .ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();

            foreach (var item in items)
            {
                ISBN += item.ToString();
                uniqId += current * item;
                current--;
            }

            var partIntCount = uniqId / divider + 1;
            var d10 = partIntCount * divider - uniqId;
            if (d10 == 10)
            {
                ISBN += 'X';
            }
            else
            {
                ISBN += d10.ToString();
            }
            Console.WriteLine(ISBN);
        }
    }
}
