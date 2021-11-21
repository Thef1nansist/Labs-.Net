using System.Collections.Generic;
using System.Linq;

namespace Task05_02
{
    public static class BookManager
    {
        public static IEnumerable<string> GetBooksName(Catalog books) => books
            .Select(x => x.TitleOfBook)
            .OrderBy(x => x);

        public static IEnumerable<BookModel> GetListBookOfName(Catalog books, string author) => books
            .Where(b => b.Authors.Contains(author))
            .OrderBy(b => b.DateOfPublisher);

        public static (string autor, int books)[] GetAuthorAndHisBooks(Catalog books) => books
            .SelectMany(b => b.Authors)
            .GroupBy(i => i)
            .Select(i => (i.Key, i.Count()))
            .ToArray();
    }
}
