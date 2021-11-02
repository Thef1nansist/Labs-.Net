using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task04_01
{
    public class MatrixTracker<T> where T : struct
    {
        private readonly DiagonalMatrix<T> _diagonalMatrix;
        private readonly Stack<Tuple<int, int, T, T>> stack;

        public MatrixTracker(DiagonalMatrix<T> diagonalMatrix)
        {
            
            _diagonalMatrix = diagonalMatrix;
            _diagonalMatrix.ElementChanged += SaveInstanse;
            stack = new Stack<Tuple<int, int, T, T>>();
        }

        private void SaveInstanse(int arg1, int arg2, T arg3, T arg4)
        {
            stack.Push(Tuple.Create(arg1, arg2, arg3, arg4));
        }

        public void Undo()
        {
            if (!stack.Count.Equals(0))
            {
                var item = stack.Pop();
                _diagonalMatrix[item.Item1, item.Item2] = item.Item3;
                stack.Clear();
            }
        }
    }
}
