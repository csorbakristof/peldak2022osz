namespace Common
{
    public interface IGenerator
    {
        IEnumerable<int> GetNumbers(int limit);
    }
}