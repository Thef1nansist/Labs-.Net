using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task05_02
{
    public class BookModel
    {
        private readonly string _titleOfBook;
        private DateTime? _dateOfPublisher;
        private List<string> _authors;

        public string TitleOfBook { get => _titleOfBook; }
        public DateTime? DateOfPublisher { get => _dateOfPublisher; }

        public List<string> Authors { get => _authors; }
        public BookModel()
        {
        }

        public BookModel(string titleOfBook, DateTime? dateOfPublisher,params string[] author )
        {
            _titleOfBook = string.IsNullOrEmpty(titleOfBook) ? throw new ArgumentNullException(nameof(titleOfBook)) : titleOfBook;
            _dateOfPublisher = dateOfPublisher;
            if (Equals(author, null))
            {
                throw new ArgumentNullException(nameof(author));
            }
            _authors = new List<string>(author).Distinct().ToList();

        }

        public override string ToString()
        {
            if (_authors is null)
            {
                return "the book doesn't exist";
            }
            var str = new StringBuilder();

            foreach (var item in _authors)
            {
                str.Append($"{item};");
            }

            return $"Title: {_titleOfBook}\n Date: {_dateOfPublisher}\n Publihers: {str}";
        }
    }
}
