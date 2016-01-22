using Common.Provider;

namespace Common.Reporting
{
    public abstract class ReportGenerator<T> : IReportGenerator<T>
    {
        protected readonly ITypeNameProvider TypeNameProvider;

        protected ReportGenerator(ITypeNameProvider typeNameProvider)
        {
            TypeNameProvider = typeNameProvider;
        }

        public string Generate(T obj)
        {
            return TypeNameProvider.GetTypeName(obj);
        }
    }
}
