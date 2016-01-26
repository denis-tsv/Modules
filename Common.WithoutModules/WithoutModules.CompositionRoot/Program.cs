using System.Diagnostics;
using Autofac;
using Common.DataAccess;
using Common.Logic;

namespace WithoutModules.CompositionRoot
{
    class Program
    {
        static void Main(string[] args)
        {
            var builder = new ContainerBuilder();
            // Регистрируем напрямую сервисы. В этом случае реализации сервисов должны быть public
            // Но можно убрать из модулей зависимость от инфраструктуры (в нашем случае - от Autofac)
            builder.RegisterType<ProductRepository>().As<IProductRepository>();
            builder.RegisterType<VolumeDeliveryCostCalculator>().As<IDeliveryCostCalculator>();
            builder.RegisterType<ShopingCart>().As<IShopingCart>();

            var container = builder.Build();

            var deliveryCostCalculator = container.Resolve<IDeliveryCostCalculator>();
            Debug.Assert(deliveryCostCalculator.GetType().Name.StartsWith("Volume"));

            container.Resolve<IProductRepository>();

            container.Resolve<IShopingCart>();
        }
    }
}
