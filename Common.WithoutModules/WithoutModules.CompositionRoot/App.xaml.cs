using System.Diagnostics;
using System.Windows;
using Autofac;
using Common.DataAccess;
using Common.Logic;

namespace WithoutModules.CompositionRoot
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
            // Регистрируем напрямую сервисы. В этом случае реализации сервисов должны быть public
            // Но можно убрать из модулей зависимость от инфраструктуры (в нашем случае - от Autofac)
            builder.RegisterType<ProductRepository>().As<IProductRepository>();
            builder.RegisterType<VolumeDeliveryCostCalculator>().As<IDeliveryCostCalculator>();
            builder.RegisterType<ShopingCart>().As<IShopingCart>();

            _container = builder.Build();

            var deliveryCostCalculator = _container.Resolve<IDeliveryCostCalculator>();
            Debug.Assert(deliveryCostCalculator.GetType().Name.StartsWith("Volume"));

            _container.Resolve<IProductRepository>();

            _container.Resolve<IShopingCart>();
        }
    }
}
