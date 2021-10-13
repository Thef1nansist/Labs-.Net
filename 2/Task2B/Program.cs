using System;

namespace Task2B
{
    class Program
    {
        static void Main()
        {
            Training training = new() { TextDescription = "train 1"};
            Exercise exercise = new Lecture{ TextDescription = "lec1", Theme = "Asp.Net Core 5" };
            Exercise exercise1 = new PracticalLesson { LessonRef = null, SolutionRef = "test1", TextDescription = "test2" };
            training.Add(exercise);
            training.Add(exercise1);

            Training training1 = new() { TextDescription = "train 2" };
            training1.Add(exercise1);
            training1.Add(exercise1);

            Console.WriteLine(training.IsPractical());
            Console.WriteLine(training1.IsPractical());

            var training2 = training1.DeepClone();
            Console.WriteLine("Deep Copy with: " + training2.TextDescription);

            Console.ReadKey();
        }
    }
}
