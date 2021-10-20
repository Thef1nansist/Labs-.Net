namespace Task03_02
{
    public static class Extensions
    {
        public static IStack<T> Reverse<T>(this IStack<T> stack)
        {
            IStack<T> temp = new Stack<T>();

            while (!stack.IsEmpty())
            {
                temp.Push(stack.Pop());
            }

            return temp;
        }
    }
}
