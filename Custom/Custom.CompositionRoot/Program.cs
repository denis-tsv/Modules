using System.Diagnostics;
using Autofac;
using Common.Logic;
using Custom.Logic;

namespace Custom.CompositionRoot
{
    class Program
    {
        static void Main(string[] args)
        {
            var builder = new ContainerBuilder();

            builder.RegisterModule<CommonLogicModule>();
            // Порядок модулей важен. Сначала нужно регистрировать CommonLogicModule, а потом CustomLogicModule
            // Иначе для интерфейса ICostCalculator в контейнере будет VolumeCostCalculator, а не WeightCostCalculator
            // Доступна инкапсуляция реализаций сервисов (WeightCostCalculator и VolumeCostCalculator не public, а internal)
            builder.RegisterModule<CustomLogicModule>();

            var container = builder.Build();

            var deliveryCostCalculator = container.Resolve<ICostCalculator>();
            Debug.Assert(deliveryCostCalculator.GetType().Name.StartsWith("Weight"));
            
            container.Resolve<IShopingCart>();
        }
    }
}
