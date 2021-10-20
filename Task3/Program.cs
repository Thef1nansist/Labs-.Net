using System;

namespace Task3
{
    class Program
    {
        static void Main()
        {
            var c = new Key(Note.B, Accidental.Sharp, Octave.Fourth);
            var d = new Key(Note.C, Accidental.NoSign, Octave.Fifth);
            Console.WriteLine(c);
            Console.WriteLine(c.Equals(d));
            Console.WriteLine(d.CompareTo(c));
        }
    }
}
