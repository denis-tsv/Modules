using Autofac;
using Common.Logic;

namespace Custom.Logic
{
    public class CustomLogicModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder
                .RegisterType<WeightCostCalculator>()
                .As<ICostCalculator>();
        }
    }
}
