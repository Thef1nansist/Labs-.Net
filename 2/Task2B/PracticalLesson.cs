namespace Task2B
{
    public class PracticalLesson : Exercise
    {
        public string LessonRef { get; set; }
        public string SolutionRef { get; set; }

        public override PracticalLesson Clone()
        {
            var practical = new PracticalLesson
            {
                LessonRef = LessonRef,
                SolutionRef = SolutionRef,
                TextDescription = TextDescription
            };

            return practical;
        }
    }
}
