using System;

namespace Task2B
{
    class Program
    {
        static void Main()
        {
            Training training = new() { TextDescription = "train 1"};
            IExercise exercise = new Lecture{ TextDescription = "lec1", Theme = "suck some dick" };
            IExercise exercise1 = new PracticalLesson { LessonRef = null, SolutionRef = "test1", TextDescription = "test2" };
            training.Add(exercise);
            training.Add(exercise1);

            Training training1 = new() { TextDescription = "train 2" };
            training1.Add(exercise1);
            training1.Add(exercise1);

            Console.WriteLine(training.IsPracrial());
            Console.WriteLine(training1.IsPracrial());

            Training training2 = training.DeepClone();

            Console.ReadKey();
        }
    }
}
