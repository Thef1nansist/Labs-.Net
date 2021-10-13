using System;

namespace Task2
{
    public class TestMatrix
    {
        #region private

        private readonly int[] _matrix;

        #endregion

        #region public

        public int Size { get; }

        public int this[int i, int j]
        {
            get
            {
                if (i != j)
                {
                    return 0;
                }

                return _matrix[i];
            }
            set
            {
                if (i == j && IsIndexCorrect(i) && IsIndexCorrect(j))
                {
                    _matrix[i] = value;
                }
            }

        }

        private bool IsIndexCorrect(int index)
        {
            return index < Size && index >= 0;
        }

        #endregion

        #region constructors
        public TestMatrix(params int[] matrix)
        {
            _matrix = matrix ?? Array.Empty<int>();
            Size = matrix == null ? 0 : matrix.Length; 
        }

        #endregion

        #region methods

        public int Track()
        {
            var temp = 0;

            for (var i = 0; i < Size; i++)
            {
                temp += _matrix[i];
            }

            return temp;
        }

        public override bool Equals(object obj)
        {
            if (obj is not TestMatrix matrix)
            {
                return false;
            }

            if (Size != matrix.Size)
            {
                return false;
            }

            for (var i = 0; i < Size; i++)
            {
                if (this[i, i] != matrix[i, i])
                {
                    return false;
                }
            }

            return true;
        }
        public override string ToString()
        {
            var str = "";

            for (var i = 0; i < Size; i++)
            {
                for (var j = 0; j < Size; j++)
                {
                    str += this[i, j] + " ";
                }
                str += "\n";
            }

            return str;
        }

        public override int GetHashCode() => _matrix.GetHashCode();
    }

    #endregion
}
