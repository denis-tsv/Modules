using Autofac;
using Common.Reporting;
using Special.Domain;

namespace Special.Reporting
{
    public class SpecialReportingModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<OrderReportGenerator>().As<IReportGenerator<Order>>();
        }
    }
}
