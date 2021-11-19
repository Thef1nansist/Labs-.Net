using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Task05_02
{
    public class Catalog
    {
        private readonly Dictionary<string, BookModel> _dictionary;

        public Dictionary<string, BookModel> Dictionary { get => _dictionary; }
        public Catalog()
        {
            _dictionary = new();
        }

        public void Add(string isbn, BookModel bookModel)
        {

            isbn = isbn ?? throw new ArgumentNullException(nameof(isbn));
            bookModel = bookModel ?? throw new ArgumentNullException(nameof(bookModel));

            var pattern = @"^\d{3}-?\d{1}-?\d{2}-?\d{6}-?\d{1}$";

            if(Regex.IsMatch(isbn, pattern) && !_dictionary.ContainsKey(isbn))
            {
                _dictionary.Add(isbn, bookModel);
            }
        }
        
        public void RemoveItem(string isbn)
        {
            isbn = isbn ?? throw new ArgumentNullException(nameof(isbn));
            
            if(_dictionary.ContainsKey(isbn))
            {
                _dictionary.Remove(isbn);
            }
        }

        public (string, BookModel) Get(string isbn)
        {
            isbn = isbn ?? throw new ArgumentNullException(nameof(isbn));
            var pattern = @"^\d{3}-?\d{1}-?\d{2}-?\d{6}-?\d{1}$";

            foreach (var item in _dictionary)
            {
                if (Regex.Match(isbn, pattern).Value.Equals(Regex.Match(item.Key, pattern).Value))
                {
                    return (item.Key, item.Value);
                }
            }

            return ("", new());
        }
    }
}
