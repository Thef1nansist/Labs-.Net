using System;

namespace Task05_02
{
    class Program
    {
        static void Main()
        {
            var catalog = new Catalog
            {
                { "123-4-56-789012-3", new("dsfdf#", null, "Tolstoy", "Tolstoy", "Pushkin") },
                { "123-4-56-789012-4", new("Abcs#", new(2001, 06, 06), "Pushkin") },
                { "123-4-56-789012-5", new("Abcd++", new(2002, 07, 07), "Savchenko") },
                { "123-4-56-789012-6", new("Abcsadsds#", new(2001, 06, 06), "Pushkin") },
                { "123-4-56-789012-7", new("Abcdasdsdasd++", new(2002, 07, 07), "Pushkin") }
            };

            foreach (var book in catalog)
            {
                Console.WriteLine(book);
            }

            Console.WriteLine("Sort: ");
            foreach (var item in BookManager.GetBooksName(catalog))
            {
                Console.WriteLine(item);
            }

            foreach (var book in BookManager.GetListBookOfName(catalog, "Savchenko"))
            {
                Console.WriteLine(book);
            }

            Console.WriteLine(catalog.Get("1234567890124"));

            foreach (var (autor, books) in BookManager.GetAuthorAndHisBooks(catalog))
            {
                Console.WriteLine($"Автор: {autor}, кол-во книг: {books}");
            }
        }
    }
}
