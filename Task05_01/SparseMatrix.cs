using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task05_01
{
    public class SparseMatrix : IEnumerable<int>
    {
        private readonly List<ElementOfList> list;
        private readonly int _countOfRow;
        private readonly int _countOfColumn;

        public int this[int row, int column]
        {
            get
            {
                if (IsCorrect(row, column))
                {
                    throw new IndexOutOfRangeException();
                }

                foreach (var item in list)
                {
                    if( item.Row == row && item.Column == column)
                    {
                        return item.Value;
                    }
                }
                return 0;
            }
            set
            {
                if (IsCorrect(row, column))
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
                    var flag = true;
                    foreach (var item in list)
                    {
                        if(item.Row == row && item.Column == column)
                        {
                            item.Value = value;
                            flag = false;
                            break;
                        }
                    }

                    if(flag)
                    {
                        list.Add(new ElementOfList(row, column, value));
                    }
                }
            }
        }
        public SparseMatrix(int countOfRow, int countOfColumn)
        {
            if (countOfColumn < 0 || countOfRow < 0 )
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
            var flag = false;

            for (var i = 1; i <= _countOfRow ; i++)
            {
                for (var j = 1; j <= _countOfColumn; j++)
                {
                    foreach (var item in list)
                    {
                        if (item.Row == i && item.Column == j)
                        {
                            stringBuilder.Append($"{item.Value,-10}");
                            flag = true;
                            break;
                        }
                    }

                    if (!flag)
                    {
                        stringBuilder.Append($"{0,-10}");
                    }
                    flag = false;
                }
                stringBuilder.Append(Environment.NewLine);
            }
            return stringBuilder.ToString();
        }

        //public IEnumerable<(int, int, int)> GetNonxeroElements()
        //{
            
        //}

        public int GetCount(int x)
        {
            var flag = false;
            var count = 0;
            for (var i = 1; i <= _countOfRow; i++)
            {
                for (var j = 1; j <= _countOfColumn; j++)
                {
                    foreach (var item in list)
                    {
                        if (item.Row.Equals(i) && item.Column.Equals(j))
                        {
                            flag = true;
                            if (item.Value.Equals(x))
                            {
                                count++;
                            }

                            break;
                        }
                    }

                    if(!flag && x == 0)
                    {
                        count++;
                    }

                    flag = false;
                }
            }
            return count;
        }

        public IEnumerator<int> GetEnumerator()
        {
            var flag = false;
            for (var i =1 ; i <= _countOfRow; i++)
            {
                for (var j = 1; j <= _countOfColumn; j++)
                {
                    foreach (var item in list)
                    {
                        if(item.Row.Equals(i) && item.Column.Equals(j))
                        {
                            yield return item.Value;
                            flag = true;
                            break;
                        }
                    }

                    if(!flag)
                    {
                        yield return 0;
                    }

                    flag = false;
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        private bool IsCorrect(int row, int column) => row < 0 || row > _countOfRow || column < 0 || column > _countOfColumn;

        private class ElementOfList
        {
            private readonly int _row;
            private readonly int _column;
            private int _value;

            public int Row { get => _row; }
            public int Column { get => _column; }

            public int Value { get => _value; set => _value = value; }

            public ElementOfList(int row, int column, int value)
            {
                _row = row;
                _column = column;
                _value = value;
            }
        }
        
    }
}
