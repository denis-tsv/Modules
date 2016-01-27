using Autofac;

namespace Common.Logic
{
    public class CommonLogicModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder
                .RegisterType<VolumeCostCalculator>()
                .As<ICostCalculator>();

            builder
                .RegisterType<ShopingCart>()
                .As<IShopingCart>();
        }
    }
}
