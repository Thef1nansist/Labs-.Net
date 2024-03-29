﻿using System;

namespace Task04_03
{
    public readonly struct RationalRepresentationStruct : IComparable
    {
        #region private fields
        private readonly NestedStruct _nestedStruct;
        #endregion

        #region constructor
        public RationalRepresentationStruct(int n, int m)
        {
            m = m > 0 ? m : throw new ArgumentException("M can't be <= 0");
            (n, m) = IrreducibleFunc(n, m);
            _nestedStruct = new NestedStruct(n, m);
        }
        #endregion
        #region struct
        private readonly struct NestedStruct 
        {
            private readonly int _numerator;
            private readonly int _denominator;
            public int M
            {
                get => _denominator != 0 ? _denominator : 1;
            }

            public int N { get => _numerator; }

            public NestedStruct(int n, int m)
            {
                _numerator = n;
                _denominator = m;
            }

        }
        #endregion
        #region methods
        public override bool Equals(object obj) =>
             obj is RationalRepresentationStruct rat &&
             rat._nestedStruct.M == _nestedStruct.M &&
             rat._nestedStruct.N == _nestedStruct.N;

        public override int GetHashCode() => HashCode.Combine(_nestedStruct.N, _nestedStruct.M);

        public override string ToString() => $"{_nestedStruct.N}/{_nestedStruct.M}";

        public int CompareTo(object obj)
        {
            if (obj is not RationalRepresentationStruct ratrep)
            {
                throw new TypeAccessException();
            }

            var valueble = (double)_nestedStruct.N / _nestedStruct.M - (double)ratrep._nestedStruct.N / ratrep._nestedStruct.M;

            if (valueble == 0)
            {
                return 0;
            }

            return valueble > 0 ? 1 : -1;
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

        #endregion
        #region ovveride operators

        public static RationalRepresentationStruct operator +(RationalRepresentationStruct first, RationalRepresentationStruct second)
        {
            var result_m = first._nestedStruct.M * second._nestedStruct.M;
            var result_n = first._nestedStruct.N * second._nestedStruct.M + second._nestedStruct.N * first._nestedStruct.M;
            return new(result_n, result_m);
        }
        public static RationalRepresentationStruct operator -(RationalRepresentationStruct first, RationalRepresentationStruct second)
        {
            var result_m = first._nestedStruct.M * second._nestedStruct.M;
            var result_n = first._nestedStruct.N * second._nestedStruct.M - second._nestedStruct.N * first._nestedStruct.M;
            return new(result_n, result_m);
        }

        public static RationalRepresentationStruct operator *(RationalRepresentationStruct first, RationalRepresentationStruct second)
        {
            var result_m = first._nestedStruct.M * second._nestedStruct.M;
            var result_n = first._nestedStruct.N * second._nestedStruct.N;
            return new(result_n, result_m);
        }
        public static RationalRepresentationStruct operator /(RationalRepresentationStruct first, RationalRepresentationStruct second)
        {
            if (second._nestedStruct.N == 0)
            {
                throw new DivideByZeroException("Divide can't 0");
            }
            var result_m = first._nestedStruct.M * second._nestedStruct.N;
            var result_n = first._nestedStruct.N * second._nestedStruct.M;
            return new(result_n, result_m);
        }

        public static explicit operator double(RationalRepresentationStruct rationalRepresentation) =>
           (double)rationalRepresentation._nestedStruct.N / rationalRepresentation._nestedStruct.M;


        public static implicit operator RationalRepresentationStruct(int number) => new(number, 1);

        public static bool operator ==(RationalRepresentationStruct left, RationalRepresentationStruct right) => left.Equals(right);
        public static bool operator !=(RationalRepresentationStruct left, RationalRepresentationStruct right) => !(left == right);

        #endregion
    }
}
