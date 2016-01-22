namespace Common.Reporting
{
    public interface IReportGenerator<T>
    {
        string Generate(T obj);
    }
}
