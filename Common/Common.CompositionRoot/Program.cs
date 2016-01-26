using System.Diagnostics;
using Autofac;
using Common.DataAccess;
using Common.Logic;

namespace Common.CompositionRoot
{
    class Program
    {
        static void Main(string[] args)
        {
            var builder = new ContainerBuilder();

            // Регистрируем модули, а не напрямую сервисы. В этом случае классы сервисов могут видимость internal.
            // Но тогда модули будут зависеть от инфраструктуры, в нашем случае - контейнера Autofac
            builder.RegisterModule<CommonDataAccessModule>();
            builder.RegisterModule<CommonLogicModule>();

            var container = builder.Build();

            var deliveryCostCalculator = container.Resolve<IDeliveryCostCalculator>();
            Debug.Assert(deliveryCostCalculator.GetType().Name.StartsWith("Volume"));

            container.Resolve<IProductRepository>();

            container.Resolve<IShopingCart>();
        }
    }
}
