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
                if (i == j)
                {
                    _matrix[i] = value;
                }
            }
        }

        #endregion

        #region constructors

        public TestMatrix(params int[] matrix)
        {
            _matrix = matrix;
            Size = matrix.Length;
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
            if (!(obj is TestMatrix))
            {
                return false;
            }

            TestMatrix matrix = obj as TestMatrix;

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

            for (var i = 0; i < this.Size; i++)
            {
                for (var j = 0; j < this.Size; j++)
                {
                    str += this[i, j] + " ";
                }
                str += "\n";
            }

            return str;
        }

        public override int GetHashCode()
        {
            throw new NotImplementedException();
        }
    }

    #endregion
}
