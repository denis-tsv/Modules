using Autofac;

namespace Common.Logic
{
    public class CommonLogicModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<VolumeDeliveryCostCalculator>().As<IDeliveryCostCalculator>();
            builder.RegisterType<ShopingCart>().As<IShopingCart>();
        }
    }
}
