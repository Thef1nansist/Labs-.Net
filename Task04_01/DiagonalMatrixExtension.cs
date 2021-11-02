using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task04_01
{
    public static class DiagonalMatrixExtension
    {
        public static DiagonalMatrix<T> Add<T>(this DiagonalMatrix<T> first, DiagonalMatrix<T> second, Func<DiagonalMatrix<T>, DiagonalMatrix<T>, DiagonalMatrix<T>> callback) where T : struct
        {
            return callback(first, second);
        }
    }
}
