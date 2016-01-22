using Autofac;
using Common.Domain;

namespace Common.Reporting
{
    public class CommonReportingModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<CustomerReportGenerator>().As<IReportGenerator<Customer>>();
        }
    }
}
