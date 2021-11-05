using System;

namespace Task04_02
{
    public sealed class RationalRepresentation : IComparable
    {
        #region private fields
        private readonly int _n;
        private readonly int _m;
        #endregion

        #region constructor
        public RationalRepresentation(int n, int m)
        {
            m = m > 0 ? m : throw new ArgumentException("M can't be <= 0");
            (_n, _m) = IrreducibleFunc(n, m);
        }
        #endregion
        #region methods
        private static (int, int) IrreducibleFunc(int n, int m)
        {
            var flag = false;
            if (n < 0)
            {
                flag = true;
                n = Math.Abs(n);
            }
            for (var i = n + m; i > 0; i--)
            {
                if (n % i == 0 && m % i == 0)
                {
                    n /= i;
                    m /= i;
                }
            }

            if (flag)
            {
                n = -n;
            }

            return (n, m);
        }

        public override bool Equals(object obj)
        {
            if (obj is not RationalRepresentation ratrep)
            {
                return false;
            }

            if (ratrep._m == _m && ratrep._n == _n)
            {
                return true;
            }

            return false;
        }

        public override int GetHashCode() => HashCode.Combine(_n, _m);

        public override string ToString() => $"{_n}/{_m}";

        public int CompareTo(object obj)
        {
            if (obj is not RationalRepresentation ratrep)
            {
                throw new TypeAccessException();
            }

            var valueble = (double)_n / _m - (double)ratrep._n /ratrep._m;

            if(valueble == 0)
            {
                return 0;
            }

            return valueble > 0 ? 1 : -1;
        }
#endregion
        #region ovveride operators

        public static RationalRepresentation operator +(RationalRepresentation first, RationalRepresentation second)
        {
            if (first == null || second == null)
            {
                throw new ArgumentNullException("RationalRepresentation can't be is null");
            }
           var result_m = first._m * second._m;
           var result_n = first._n * second._m + second._n * first._m;
            return new(result_n, result_m);
        }
        public static RationalRepresentation operator -(RationalRepresentation first, RationalRepresentation second)
        {
            if (first == null || second == null)
            {
                throw new ArgumentNullException("RationalRepresentation can't be is null");
            }
            var result_m = first._m * second._m;
            var result_n = first._n * second._m - second._n * first._m;
            return new(result_n, result_m);
        }

        public static RationalRepresentation operator *(RationalRepresentation first, RationalRepresentation second)
        {
            if (first == null || second == null)
            {
                throw new ArgumentNullException("RationalRepresentation can't be is null");
            }
            var result_m = first._m * second._m;
            var result_n = first._n * second._n;
            return new(result_n, result_m);
        }
        public static RationalRepresentation operator /(RationalRepresentation first, RationalRepresentation second)
        {
            if (first == null || second == null)
            {
                throw new ArgumentNullException("RationalRepresentation can't be is null");
            }
            var result_m = first._m * second._n;
            var result_n = first._n * second._m;
            return new(result_n, result_m);
        }

        public static explicit operator double(RationalRepresentation rationalRepresentation)
        {
            if (rationalRepresentation == null)
            {
                throw new ArgumentNullException("Argument is null");
            }

            return (double)rationalRepresentation._n / rationalRepresentation._m;
        }

        public static implicit operator RationalRepresentation(int number) => new(number, 1);

        #endregion
    }
}
