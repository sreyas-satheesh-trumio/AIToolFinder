namespace AIToolFinder.Services
{
    public interface IJsonFileService<T>
    {
        List<T> Read();
        void Write(List<T> data);
    }
}