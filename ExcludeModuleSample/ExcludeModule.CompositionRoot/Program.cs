using System.Diagnostics;
using Autofac;
using Common.DataAccess;
using Common.Logic;
using ExcludeModule.Logic;

namespace ExcludeModule.CompositionRoot
{
    class Program
    {
        static void Main(string[] args)
        {
            var builder = new ContainerBuilder();

            builder.RegisterModule<CommonDataAccessModule>();
            // В ExcludeModuleLogicModule регистрируется и ShopingCart, и DeliveryCostCalculator, поэтому CommonLogicModule мы не используем (исключаем загрузку этого модуля)
            // В этом случае реализации сервисов должны быть public. И если в Common.Logic появится новый сервис, его нужно регистрацию будет добавить и в ExcludeModuleLogicModule
            builder.RegisterModule<ExcludeModuleLogicModule>();

            var container = builder.Build();

            var deliveryCostCalculator = container.Resolve<IDeliveryCostCalculator>();
            Debug.Assert(deliveryCostCalculator.GetType().Name.StartsWith("Free"));

            container.Resolve<IProductRepository>();

            container.Resolve<IShopingCart>();
        }
    }
}
