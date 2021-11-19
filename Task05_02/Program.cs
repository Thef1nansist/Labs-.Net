using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Task05_02
{
    class Program
    {
        static void Main(string[] args)
        {
            var catalog = new Catalog();
            catalog.Add("123-4-56-789012-3", new("dsfdf#", new(2000, 05, 05), "Tolstoy", "Tolstoy", "Pushkin"));
            catalog.Add("123-4-56-789012-4", new("Abcs#", new(2001, 06, 06), "Pushkin"));
            catalog.Add("123-4-56-789012-5", new("Abcd++", new(2002, 07, 07), "Savchenko"));
                

            foreach (KeyValuePair<string, BookModel> key in catalog.Dictionary)
            {
                Console.WriteLine(key);
            }

            var titleSort = catalog.Dictionary.Values.Select(x => x.TitleOfBook).OrderBy(x => x).ToList();

            var listOfBook = catalog.Dictionary.Values.Where(x => x.Authors.Contains("Pushkin")).OrderBy(y => y.DateOfPublisher).ToList();

            var listOfCountBook = catalog.Dictionary.Values
                .Select(x => $"{x.Authors.Aggregate(new StringBuilder(), (sb, current) => sb.AppendFormat("{0}  ", current))} - {x.Authors.Count}")
                .ToList();

            Console.WriteLine("Sort: ");
            foreach (var item in titleSort)
            {
                Console.WriteLine(item);
            }

            var test = catalog.Get("123-4-56-789012-4");

            Console.WriteLine(test.ToString());


        }
    }
}
