using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Task05_01
{
    public class SparseMatrix : IEnumerable<long>
    {
        private readonly List<ElementOfList> list;
        private readonly int _countOfRow;
        private readonly int _countOfColumn;

        public long this[int row, int column]
        {
            get
            {
                if (!IsCorrect(row, column))
                {
                    throw new IndexOutOfRangeException();
                }

                foreach (var item in list)
                {
                    if (item.Row == row && item.Column == column)
                    {
                        return item.Value;
                    }
                }

                return 0;
            }
            set
            {
                if (!IsCorrect(row, column))
                {
                    throw new IndexOutOfRangeException();
                }

                if (value == 0)
                {
                    foreach (var item in list)
                    {
                        if (item.Row == row && item.Column == column)
                        {
                            list.Remove(item);
                            break;
                        }
                    }
                }
                else
                {
                    foreach (var item in list)
                    {
                        if (item.Row == row && item.Column == column)
                        {
                            item.Value = value;
                            return;
                        }
                    }

                    list.Add(new ElementOfList(row, column, value));
                }
            }
        }
        public SparseMatrix(int countOfRow, int countOfColumn)
        {
            if (countOfColumn < 0 || countOfRow < 0)
            {
                throw new IndexOutOfRangeException();
            }

            _countOfRow = countOfRow;
            _countOfColumn = countOfColumn;
            list = new();
        }

        public override string ToString()
        {
            var stringBuilder = new StringBuilder();
            var flagOfZero = false;

            for (var i = 1; i <= _countOfRow; i++)
            {
                for (var j = 1; j <= _countOfColumn; j++)
                {
                    foreach (var item in list)
                    {
                        if (item.Row == i && item.Column == j)
                        {
                            stringBuilder.Append($"{item.Value,-10}");
                            flagOfZero = true;
                            break;
                        }
                    }

                    if (!flagOfZero)
                    {
                        stringBuilder.Append($"{0,-10}");
                    }

                    flagOfZero = false;
                }

                stringBuilder.Append(Environment.NewLine);
            }

            return stringBuilder.ToString();
        }

        public IEnumerable<(int, int, long)> GetNonZeroElements() => list
            .OrderBy(x => x.Column)
            .ThenBy(x => x.Row)
            .Select(x => (x.Row, x.Column, x.Value));

        public int GetCount(int x)
        {
            if (x == 0)
            {
                return _countOfRow * _countOfColumn - list.Count;
            }

            return list.Count(e => e.Value == x);
        }

        public IEnumerator<long> GetEnumerator()
        {
            var flagOfZero = false;
            for (var i = 1; i <= _countOfRow; i++)
            {
                for (var j = 1; j <= _countOfColumn; j++)
                {
                    foreach (var item in list)
                    {
                        if (item.Row.Equals(i) && item.Column.Equals(j))
                        {
                            yield return item.Value;
                            flagOfZero = true;
                            break;
                        }
                    }

                    if (!flagOfZero)
                    {
                        yield return 0;
                    }

                    flagOfZero = false;
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        private bool IsCorrect(int row, int column) => row >= 0 || row <= _countOfRow || column <= 0 || column >= _countOfColumn;

        private class ElementOfList
        {
            public int Row { get; }
            public int Column { get; }

            public long Value { get; set; }

            public ElementOfList(int row, int column, long value)
            {
                Row = row;
                Column = column;
                Value = value;
            }
        }

    }
}
