using System.Diagnostics;
using Autofac;
using Common.Logic;
using Common.Logic.Tests;
using Common.Logic.Tests.Mocks;

namespace Common.CompositionRoot
{
    class Program
    {
        static void Main(string[] args)
        {
            var builder = new ContainerBuilder();

            // Регистрируем модули, а не напрямую сервисы. В этом случае классы сервисов могут видимость internal.
            // Но тогда модули будут зависеть от инфраструктуры, в нашем случае - контейнера Autofac
            builder.RegisterModule<CommonLogicModule>();

            var container = builder.Build();

            var deliveryCostCalculator = container.Resolve<ICostCalculator>();
            Debug.Assert(deliveryCostCalculator.GetType().Name.StartsWith("Volume"));

            container.Resolve<IShopingCart>();

            var cart = new MockShopingCart
            {
                AddProductDelegate = (p) => { },
            };

            cart.AddProduct(null);
        }
    }
}
