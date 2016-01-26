using Autofac;
using Common.Logic;

namespace ModuleOrder.Logic
{
    public class ModuleOrderLogicModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<WeightDeliveryCostCalculator>().As<IDeliveryCostCalculator>();
        }
    }
}
