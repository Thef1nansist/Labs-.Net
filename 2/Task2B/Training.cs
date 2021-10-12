using System;

namespace Task2B
{
    public class Training
    {
        public string TextDescription { get; set; }
        public IExercise[] Exercises;
        public int Size { get; private set; } = 0;

        public Training() => Exercises = new IExercise[Size];

        
        public IExercise[] Add(IExercise exercise)
        {
            var newExercises = new IExercise[Exercises.Length + 1];
            Array.Copy(Exercises, newExercises, Exercises.Length);
            newExercises[^1] = exercise;
            Exercises = newExercises;
            Size = Exercises.Length;
            return newExercises;
        }

        public bool IsPracrial()
        {
            var temp = 0;

            for (var i = 0; i < Size; i++)
            {
                if (Exercises[i] is PracticalLesson)
                {
                    temp++;
                }
            }

            return temp == Size;
        }

        public Training DeepClone() // можно через prototype pattern
        {
            var newTraining = new Training
            {
                Exercises = Exercises,
                Size = Size,
                TextDescription = TextDescription
            };
            return newTraining;
        }
    }
}
