using Autofac;
using Common.Logic;

namespace ExcludeModule.Logic
{
    public class ExcludeModuleLogicModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<ShopingCart>().As<IShopingCart>();
            builder.RegisterType<FreeDeliveryCostCalculator>().As<IDeliveryCostCalculator>();
        }
    }
}
