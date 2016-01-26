using System.Diagnostics;
using System.Windows;
using Autofac;
using Common.DataAccess;
using Common.Logic;
using ModuleOrder.Logic;

namespace ModuleOrder.CompositionRoot
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private IContainer _container;
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            var builder = new ContainerBuilder();

            builder.RegisterModule<CommonDataAccessModule>();
            builder.RegisterModule<CommonLogicModule>();
            // Порядок модулей важен. Сначала нужно регистрировать CommonLogicModule, а потом SpecialLogicModule
            // Иначе для интерфейса IDeliveryCostCalculator в контейнере будет VolumeDeliveryCostCalculator, а не WeightDeliveryCostCalculator
            // Доступна инкапсуляция реализаций сервисов (WeightDeliveryCostCalculator не public, а internal)
            builder.RegisterModule<ModuleOrderLogicModule>();

            _container = builder.Build();

            var deliveryCostCalculator = _container.Resolve<IDeliveryCostCalculator>();
            Debug.Assert(deliveryCostCalculator.GetType().Name.StartsWith("Weight"));

            _container.Resolve<IProductRepository>();

            _container.Resolve<IShopingCart>();

        }
    }
}
