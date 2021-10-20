using System;

namespace Task03_02
{
    public class Stack<T> : IStack<T>
    {
        private T[] _stack;
        private int _index;
        private const int _capacity = 15;

        public Stack()
        {
            _stack = new T[15];
            _index = -1;
        }

        public bool IsEmpty() => _index.Equals(-1);

        public T Pop()
        {
            if (IsEmpty())
            {
                throw new IndexOutOfRangeException();
            }

            var temp = _stack[_index--];
            return temp;
        }

        public void Push(T element)
        {
            if (++_index >= _capacity)
            {
                throw new IndexOutOfRangeException();
            }

            _stack[_index] = element;
        }
    }
}
