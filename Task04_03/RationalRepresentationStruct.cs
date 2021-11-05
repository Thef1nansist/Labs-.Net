using System;
//Dodelat
namespace Task04_03
{
    readonly public struct RationalRepresentationStruct : IComparable
    {
        private readonly int _n;
        private readonly int _m;

        public RationalRepresentationStruct(int n, int m)
        {
            m = m > 0 ? m : throw new ArgumentException("M can't be <= 0");
            (_n, _m) = IrreducibleFunc(n, m);
        }

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
            if (obj is not RationalRepresentationStruct ratrep)
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
            if (obj is not RationalRepresentationStruct ratrep)
            {
                throw new TypeAccessException();
            }

            var valueble = (double)_n / _m - (double)ratrep._n / ratrep._m;

            if (valueble == 0)
            {
                return 0;
            }

            return valueble > 0 ? 1 : -1;
        }

        public static RationalRepresentationStruct operator +(RationalRepresentationStruct first, RationalRepresentationStruct second)
        {
            var result_m = first._m * second._m;
            var result_n = first._n * second._m + second._n * first._m;
            return new(result_n, result_m);
        }
        public static RationalRepresentationStruct operator -(RationalRepresentationStruct first, RationalRepresentationStruct second)
        {
            var result_m = first._m * second._m;
            var result_n = first._n * second._m - second._n * first._m;
            return new(result_n, result_m);
        }

        public static RationalRepresentationStruct operator *(RationalRepresentationStruct first, RationalRepresentationStruct second)
        {
            var result_m = first._m * second._m;
            var result_n = first._n * second._n;
            return new(result_n, result_m);
        }
        public static RationalRepresentationStruct operator /(RationalRepresentationStruct first, RationalRepresentationStruct second)
        {
            var result_m = first._m * second._n;
            var result_n = first._n * second._m;
            return new(result_n, result_m);
        }

        public static explicit operator double(RationalRepresentationStruct rationalRepresentation) =>
           (double) rationalRepresentation._n / rationalRepresentation._m;


        public static implicit operator RationalRepresentationStruct(int number) => new(number, 1);

        public static bool operator ==(RationalRepresentationStruct left, RationalRepresentationStruct right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(RationalRepresentationStruct left, RationalRepresentationStruct right)
        {
            return !(left == right);
        }
    }
}
