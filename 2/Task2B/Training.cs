using System;

namespace Task2B
{
    public class Training
    {
        public string TextDescription { get; set; }
        private Exercise[] _exercises;
        public int Size { get; private set; } = 0;

        public Training() => _exercises = new Exercise[Size];

        public void Add(Exercise exercise)
        {
            var newExercises = new Exercise[_exercises.Length + 1];
            Array.Copy(_exercises, newExercises, _exercises.Length);
            newExercises[^1] = exercise;
            _exercises = newExercises;
            Size = _exercises.Length;
        }

        public bool IsPractical()
        {
            for (var i = 0; i < Size; i++)
            {
                if (_exercises[i] is not PracticalLesson)
                {
                    return false;
                }
            }

            return true;
        }

        public Training DeepClone() // можно через prototype pattern
        {
            var newTraining = new Training
            {
                TextDescription = TextDescription,
                Size = Size
            };
            foreach (var exercise in _exercises)
            {
                newTraining.Add((Exercise)exercise.Clone());
            }
            return newTraining;
        }
    }
}
