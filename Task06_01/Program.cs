using System;

namespace Task06_01
{
    class Program
    {
        static void Main()
        {
            Cache cache = new(5);

            cache.Set("1", "1");
            cache.Set("2", "2");
            cache.Set("3", "3");
            cache.Set("4", "4");
            cache.Set("5", "5");
            cache.Get("10");
            cache.Get("10");
            cache.Get("10");
            cache.Get("10");
            cache.Get("10");
            cache.Get("10");
            cache.Get("10");
            cache.Get("10");
            cache.Get("10");
            cache.Get("10");
            cache.Get("10");
            cache.Get("10");
            cache.Get("10");
            cache.Get("10");
            cache.Get("10");
            cache.Get("10");
            cache.Get("10");
            cache.Get("10");
            cache.Get("10");
            cache.Get("10");
            cache.Get("10");
            cache.Get("10");
            cache.Get("10");
            cache.Get("10");
            cache.Get("10");
            cache.Get("10");
            cache.Get("10");
            cache.Get("10");
            cache.Get("10");
            cache.Get("10");
            cache.Get("10");
            cache.Set("6", "6");
            cache.Set("7", "7");
            cache.Set("8", "8");
            cache.Set("9", "9");
            cache.Set("10", "10");

            Console.WriteLine(cache.Get("10"));
            Console.WriteLine(cache.Remove("10"));

            cache.Set("10", "10");

            cache.Dispose();
            Console.WriteLine("Completed");
        }
    }
}
