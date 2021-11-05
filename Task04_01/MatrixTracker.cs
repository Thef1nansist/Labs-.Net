using System.Collections.Generic;

namespace Task04_01
{
    public class MatrixTracker<T>
    {
        private readonly DiagonalMatrix<T> _diagonalMatrix;
        private readonly Stack<(int, int, T, T)> _stack;

        public MatrixTracker(DiagonalMatrix<T> diagonalMatrix)
        {
            
            _diagonalMatrix ??= diagonalMatrix;
            _diagonalMatrix.ElementChanged += SaveInstanse;
            _stack = new Stack<(int, int, T, T)>();
        }

        private void SaveInstanse(int arg1, int arg2, T arg3, T arg4)
        {
            _stack.Push((arg1, arg2, arg3, arg4));
        }

        public void Undo()
        {
            if (!_stack.Count.Equals(0))
            {
                var item = _stack.Pop();
                _diagonalMatrix[item.Item1, item.Item2] = item.Item3;
                _stack.Clear();
            }
        }
    }
}
