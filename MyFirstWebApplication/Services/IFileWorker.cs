namespace MyFirstWebApplication.Services
{
    public interface IFileWorker
    {
        void AddToEnd(int value);
        int GetSum(int from, int till);
    }
}
