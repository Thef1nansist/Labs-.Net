using System;

namespace Task04_02
{
    public sealed class RationalRepresentation : IComparable
    {
        #region private fields
        private readonly int _numerator;
        private readonly int _denominator;
        #endregion

        #region constructor
        public RationalRepresentation(int n, int m)
        {
            m = m > 0 ? m : throw new ArgumentException("M can't be <= 0");
            (_numerator, _denominator) = IrreducibleFunc(n, m);
        }
        #endregion
        #region methods
        private static (int, int) IrreducibleFunc(int numerator, int denominator)
        {
            var flag = false;
            if (numerator < 0)
            {
                flag = true;
                numerator = Math.Abs(numerator);
            }

            for (var i = numerator + denominator; i > 0; i--)
            {
                if (numerator % i == 0 && denominator % i == 0)
                {
                    numerator /= i;
                    denominator /= i;
                }
            }

            if (flag)
            {
                numerator = -numerator;
            }

            return (numerator, denominator);
        }

        public override bool Equals(object obj) =>
                obj is RationalRepresentation rat &&
                rat._denominator == _denominator &&
                rat._numerator == _numerator;

        public override int GetHashCode() => HashCode.Combine(_numerator, _denominator);

        public override string ToString() => $"{_numerator}/{_denominator}";

        public int CompareTo(object obj)
        {
            if (obj is not RationalRepresentation ratrep)
            {
                throw new TypeAccessException();
            }

            var valueble = (double)_numerator / _denominator - (double)ratrep._numerator / ratrep._denominator;
            if (valueble == 0)
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

            var result_m = first._denominator * second._denominator;
            var result_n = first._numerator * second._denominator + second._numerator * first._denominator;

            return new(result_n, result_m);
        }
        public static RationalRepresentation operator -(RationalRepresentation first, RationalRepresentation second)
        {
            if (first == null || second == null)
            {
                throw new ArgumentNullException("RationalRepresentation can't be is null");
            }

            var result_m = first._denominator * second._denominator;
            var result_n = first._numerator * second._denominator - second._numerator * first._denominator;

            return new(result_n, result_m);
        }
        public static RationalRepresentation operator *(RationalRepresentation first, RationalRepresentation second)
        {
            if (first == null || second == null)
            {
                throw new ArgumentNullException("RationalRepresentation can't be is null");
            }

            var result_m = first._denominator * second._denominator;
            var result_n = first._numerator * second._numerator;

            return new(result_n, result_m);
        }
        public static RationalRepresentation operator /(RationalRepresentation first, RationalRepresentation second)
        {
            if (first == null || second == null)
            {
                throw new ArgumentNullException("RationalRepresentation can't be is null");
            }

            if (second._numerator == 0)
            {
                throw new DivideByZeroException("Divide can't 0");
            }

            var result_m = first._denominator * second._numerator;
            var result_n = first._numerator * second._denominator;

            return new(result_n, result_m);
        }

        public static explicit operator double(RationalRepresentation rationalRepresentation)
        {
            if (rationalRepresentation == null)
            {
                throw new ArgumentNullException("Argument is null");
            }

            return (double)rationalRepresentation._numerator / rationalRepresentation._denominator;
        }

        public static implicit operator RationalRepresentation(int number) => new(number, 1);
        #endregion
    }
}
