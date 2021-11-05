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

            stack.Push(1);
            stack.Push(2);
            stack.Push(3);
            stack.Push(4);
            Console.WriteLine(stack.IsEmpty());
            //stack.Pop();
            //stack.Pop();
            //stack.Pop();
            //stack.Pop();

            Console.WriteLine(stack.IsEmpty());

            var newstack = stack.Reverse();

            while (!newstack.IsEmpty())
            {
                Console.WriteLine(newstack.Pop());
            }
        }
    }
}
