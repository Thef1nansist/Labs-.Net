using System;

namespace Task03_02
{
    class Program
    {
        static void Main()
        {
            var stack = new Stack<int>();
            var vladik = new Stack<int>();

            //vladik.Push(null);

            Console.WriteLine(stack.IsEmpty());

            for (int i = 0; i < 12; i++)
            {
                stack.Push(i);
            }
            Console.WriteLine(stack.Pop());

            var newstack = stack.Reverse();

            while (!newstack.IsEmpty())
            {
                Console.WriteLine(newstack.Pop());
            }
        }
    }
}
