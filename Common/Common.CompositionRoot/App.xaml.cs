using System.Diagnostics;
using System.Windows;
using Autofac;
using Common.DataAccess;
using Common.Logic;

namespace Common.CompositionRoot
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

            // Регистрируем модули, а не напрямую сервисы. В этом случае классы сервисов могут видимость internal.
            // Но тогда модули будут зависеть от инфраструктуры, в нашем случае - контейнера Autofac
            builder.RegisterModule<CommonDataAccessModule>();
            builder.RegisterModule<CommonLogicModule>();

            _container = builder.Build();

            var deliveryCostCalculator = _container.Resolve<IDeliveryCostCalculator>();
            Debug.Assert(deliveryCostCalculator.GetType().Name.StartsWith("Volume"));

            _container.Resolve<IProductRepository>();

            _container.Resolve<IShopingCart>();
        }
    }
}
