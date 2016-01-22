using Common.Domain;
using Common.Provider;


namespace Common.Reporting
{
    class CustomerReportGenerator : ReportGenerator<Customer>
    {
        public CustomerReportGenerator(ITypeNameProvider typeNameProvider) : base(typeNameProvider)
        {
        }
    }
}
