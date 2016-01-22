using Common.Provider;
using Common.Reporting;
using Special.Domain;

namespace Special.Reporting
{
    class OrderReportGenerator : ReportGenerator<Order>
    {
        public OrderReportGenerator(ITypeNameProvider typeNameProvider) : base(typeNameProvider)
        {
        }
    }
}
