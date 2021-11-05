using System;

namespace Task04_01
{
    public static class DiagonalMatrixExtension
    {
        public static DiagonalMatrix<T> Add<T>(this DiagonalMatrix<T> first, DiagonalMatrix<T> second, Func<T, T, T> callback)
        {
            first ??= new DiagonalMatrix<T>(first.Size);
            second ??= new DiagonalMatrix<T>(second.Size);

            if (first.Size < second.Size)
            {
                var temp = first;
                first = second;
                second = temp;
            }

            var result = new DiagonalMatrix<T>(first.Size);
            for(var i = 0; i < second.Size; i++)
            {
                result[i, i] = callback(first[i, i], second[i, i]);
            }

            for (int i = second.Size; i < first.Size; i++)
            {
                result[i, i] = first[i, i];
            }

            return result;
        }
    }
}
