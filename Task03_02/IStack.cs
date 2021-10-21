namespace Task03_02
{
    public interface IStack<T>
    {
        void Push(T element);
        T Pop();
        bool IsEmpty();
    }
}
