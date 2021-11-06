using System;
//Dodelat
namespace Task04_03
{
    public readonly struct RationalRepresentationStruct : IComparable
    {
        private readonly Test _test;
        public int CompareTo(object obj)
        {
            if (obj is not Test ratrep)
            {
                throw new TypeAccessException();
            }

            var valueble = (double)_test.N/_test.M  - (double)ratrep.N / ratrep.M;

            if (valueble == 0)
            {
                return 0;
            }

            return valueble > 0 ? 1 : -1;
        }

        private struct Test 
        {
            private readonly int _n;
            private readonly int _m;
            public int M
            {
                get => _m != 0 ? _m : 1;
            }

            public int N { get => _n; }

            public Test(int n, int m)
            {
                m = m > 0 ? m : throw new ArgumentException("M can't be <= 0");
                (_n, _m) = IrreducibleFunc(n, m);
            }

            static Test()
            {
                Console.WriteLine("asdasdsad");

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
                if (obj is not Test ratrep)
                {
                    return false;
                }

                if (ratrep.M == M && ratrep._n == _n)
                {
                    return true;
                }

                return false;
            }

            public override int GetHashCode() => HashCode.Combine(_n, M);

            public override string ToString() => $"{_n}/{M}";

            public static Test operator +(Test first, Test second)
            {
                var result_m = first.M * second.M;
                var result_n = first._n * second.M + second._n * first.M;
                return new(result_n, result_m);
            }
            public static Test operator -(Test first, Test second)
            {
                var result_m = first.M * second.M;
                var result_n = first._n * second.M - second._n * first.M;
                return new(result_n, result_m);
            }

            public static Test operator *(Test first, Test second)
            {
                var result_m = first.M * second.M;
                var result_n = first._n * second._n;
                return new(result_n, result_m);
            }
            public static Test operator /(Test first, Test second)
            {
                var result_m = first.M * second._n;
                var result_n = first._n * second.M;
                return new(result_n, result_m);
            }

            public static explicit operator double(Test rationalRepresentation) =>
               (double)rationalRepresentation._n / rationalRepresentation.M;


            public static implicit operator Test(int number) => new(number, 1);

            public static bool operator ==(Test left, Test right)
            {
                return left.Equals(right);
            }

            public static bool operator !=(Test left, Test right)
            {
                return !(left == right);
            }
        }
        
    }
}
