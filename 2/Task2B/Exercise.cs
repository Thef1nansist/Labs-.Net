namespace Task2B
{
    public abstract class Exercise
    {
        public string TextDescription { get; set; }

        public abstract object Clone();
    }
}
