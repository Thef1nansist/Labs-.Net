namespace Task03_02
{
    public interface IStack<T>
    {
        public void Push(T element);
        public T Pop();
        public bool IsEmpty();
    }
}
