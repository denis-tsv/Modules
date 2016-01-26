using System.Diagnostics;
using Autofac;
using Common.DataAccess;
using Common.Logic;
using ModuleOrder.Logic;

namespace ModuleOrder.CompositionRoot
{
    class Program
    {
        static void Main(string[] args)
        {
            var builder = new ContainerBuilder();

            builder.RegisterModule<CommonDataAccessModule>();
            builder.RegisterModule<CommonLogicModule>();
            // Порядок модулей важен. Сначала нужно регистрировать CommonLogicModule, а потом SpecialLogicModule
            // Иначе для интерфейса IDeliveryCostCalculator в контейнере будет VolumeDeliveryCostCalculator, а не WeightDeliveryCostCalculator
            // Доступна инкапсуляция реализаций сервисов (WeightDeliveryCostCalculator не public, а internal)
            builder.RegisterModule<ModuleOrderLogicModule>();

            var container = builder.Build();

            var deliveryCostCalculator = container.Resolve<IDeliveryCostCalculator>();
            Debug.Assert(deliveryCostCalculator.GetType().Name.StartsWith("Weight"));

            container.Resolve<IProductRepository>();

            container.Resolve<IShopingCart>();
        }
    }
}
