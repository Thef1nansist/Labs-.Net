using System;

namespace Task04_01
{
    public class DiagonalMatrix<T> 
    {
        public event Action<int, int, T, T> ElementChanged;
        private readonly T[] _data;

        public readonly int Size;

        public T this[int i, int j]
        {
            get => i == j && IsCorrect(i) ? _data[i] : default;
            set
            {
                if (i == j && IsCorrect(i) && !(_data[i]?.GetHashCode() == value?.GetHashCode()))
                {
                    var temp = _data[i];
                    _data[i] = value;
                    ElementChanged?.Invoke(i, j, temp, value);
                }
            }
        }

        public DiagonalMatrix(int size)
        {
            Size = size < 0 ? throw new ArgumentException("Size can't be < 0") : size;
            _data = new T[size];
        }

        public override string ToString()
        {
            var result = string.Empty;
            for (var i = 0; i < Size; i++)
            {
                for (var j = 0; j < Size; j++)
                {
                    result += $"{this[i, j],-10}";
                }

                result += Environment.NewLine;
            }
            return result;
        }

        private bool IsCorrect(int i) => i >= 0 && i < Size ? true : throw new IndexOutOfRangeException();
    }
}
