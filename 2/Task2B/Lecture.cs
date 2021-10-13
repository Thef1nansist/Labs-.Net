namespace Task2B
{
    public class Lecture : Exercise
    {
        public string Theme { get; set; }

        public override Lecture Clone()
        {
            var lecture = new Lecture
            {
                Theme = Theme,
                TextDescription = TextDescription
            };
            return lecture;
        }
    }
}
