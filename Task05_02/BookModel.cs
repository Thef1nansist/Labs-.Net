using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Task05_02
{
    public class BookModel
    {
        public string TitleOfBook { get; }
        public DateTime? DateOfPublisher { get; }

        public List<string> Authors { get; }

        public BookModel(string titleOfBook, DateTime? dateOfPublisher,params string[] author )
        {
            TitleOfBook = string.IsNullOrEmpty(titleOfBook) ? throw new ArgumentNullException(nameof(titleOfBook)) : titleOfBook;
            DateOfPublisher = dateOfPublisher;
            if (author == null)  
            {
                throw new ArgumentNullException(nameof(author));
            }

            Authors = new List<string>(author).Distinct().ToList();
        }

        public override string ToString()
        {
            var str = new StringBuilder();

            foreach (var item in Authors)
            {
                str.Append($"{item};");
            }

            return $"Title: {TitleOfBook}\n Date: {DateOfPublisher}\n Publihers: {str}";
        }
    }
}
