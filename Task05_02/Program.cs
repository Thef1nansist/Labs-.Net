using System;
using System.Collections.Generic;
using System.Linq;

namespace Task05_02
{
    class Program
    {
        static void Main()
        {
            var catalog = new Catalog();
            catalog.Add("123-4-56-789012-3", new("dsfdf#", new(2000, 05, 05), "Tolstoy", "Tolstoy", "Pushkin"));
            catalog.Add("123-4-56-789012-4", new("Abcs#", new(2001, 06, 06), "Pushkin"));
            catalog.Add("123-4-56-789012-5", new("Abcd++", new(2002, 07, 07), "Savchenko"));
            catalog.Add("123-4-56-789012-6", new("Abcsadsds#", new(2001, 06, 06), "Pushkin"));
            catalog.Add("123-4-56-789012-7", new("Abcdasdsdasd++", new(2002, 07, 07), "Pushkin"));

            foreach (var book in catalog)
            {
                Console.WriteLine(book);
            }

            Console.WriteLine("Sort: ");
            foreach (var item in GetBooksName(catalog))
            {
                Console.WriteLine(item);
            }

            foreach (var book in GetListBookOfName(catalog, "Savchenko"))
            {
                Console.WriteLine(book);
            }

            Console.WriteLine(catalog.Get("1234567890124"));

            foreach (var item in GetAuthorAndHisBooks(catalog))
            {
                Console.WriteLine($"Автор: {item.autor}, кол-во книг: {item.books}");
            }
        }

        private static IEnumerable<string> GetBooksName(Catalog books) => books
            .Select(x => x.TitleOfBook)
            .OrderBy(x => x);

        private static IEnumerable<BookModel> GetListBookOfName(Catalog books, string author) => books
            .Where(b => b.Authors.Contains(author))
            .OrderBy(b => b.DateOfPublisher);

        private static (string autor, int books)[] GetAuthorAndHisBooks(Catalog books) => books
            .SelectMany(b => b.Authors)
            .GroupBy(i => i)
            .Select(i => (i.Key, i.Count())).ToArray();
    }
}
