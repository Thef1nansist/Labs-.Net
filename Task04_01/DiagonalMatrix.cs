using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task04_01
{
    public class DiagonalMatrix<T> where T : struct
    {
        public event Action<int, int, T, T> ElementChanged;
        private readonly T[] _data;

        public readonly int Size;

        public T this[int i, int j]
        {
            get => i == j && IsCorrect(i) ? _data[i] : default;
            set
            {
                if (i == j && IsCorrect(i))
                {
                    if (_data[i].Equals(value))
                    {
                        _data[i] = value;
                    }
                    else
                    {
                        var temp = _data[i];
                        _data[i] = value;
                        ElementChanged?.Invoke(i, j, temp, value);
                    }
                }
            }
        }

        public DiagonalMatrix(int size)
        {
            Size = size < 0 ? throw new ArgumentException() : size;
            _data = new T[size];
            FillingMatrix(size);
        }

        public DiagonalMatrix()
        {

        }

        public DiagonalMatrix(params T[] data)
        {
            _data = data;
            Size = _data.Length;
        }

        private void FillingMatrix(int size)
        {
            for (int i = 0; i < size; i++)
            {
                _data[i] = default;
            }
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
