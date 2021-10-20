using System;

namespace Task03_02
{
    class Program
    {
        static void Main(string[] args)
        {
            var stack = new Stack<int>();

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
