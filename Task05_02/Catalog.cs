using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Task05_02
{
    public class Catalog : IEnumerable<BookModel>
    {
        private Dictionary<string, BookModel> Dictionary { get; }
        public Catalog()
        {
            Dictionary = new();
        }

        public void Add(string isbn, BookModel bookModel)
        {
            isbn = isbn ?? throw new ArgumentNullException(nameof(isbn));
            bookModel = bookModel ?? throw new ArgumentNullException(nameof(bookModel));

            var pattern = @"^\d{3}-\d{1}-\d{2}-\d{6}-\d{1}$";
            var patternWithOut = @"^\d{13}$";

            if ((Regex.IsMatch(isbn, pattern)|| Regex.IsMatch(isbn, patternWithOut)) && !Dictionary.ContainsKey(isbn))
            {
                isbn = isbn.Replace("-", "");
                Dictionary[isbn] = bookModel;
            }
        }

        public void RemoveItem(string isbn)
        {
            isbn = isbn ?? throw new ArgumentNullException(nameof(isbn));

            if (Dictionary.ContainsKey(isbn))
            {
                Dictionary.Remove(isbn);
            }
        }

        public (string, BookModel) Get(string isbn)
        {
            isbn = isbn ?? throw new ArgumentNullException(nameof(isbn));
            var pattern = @"^\d{3}-?\d{1}-?\d{2}-?\d{6}-?\d{1}$";
            isbn = Regex.IsMatch(isbn, pattern) ? isbn.Replace("-", "") : throw new KeyNotFoundException();

            if (Dictionary.TryGetValue(isbn, out BookModel book))
            {
                return (isbn, book);
            }

            throw new KeyNotFoundException();
        }

        public IEnumerator<BookModel> GetEnumerator()
        {
            foreach (var (_, value) in Dictionary)
            {
                yield return value;
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
