using System.Diagnostics;
using System.Windows;
using Autofac;
using Common.DataAccess;
using Common.Logic;
using ExcludeModule.Logic;

namespace ExcludeModule.CompositionRoot
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
            // В ExcludeModuleLogicModule регистрируется и ShopingCart, и DeliveryCostCalculator, поэтому CommonLogicModule мы не используем (исключаем загрузку этого модуля)
            // В этом случае реализации сервисов должны быть public. И если в Common.Logic появится новый сервис, его нужно регистрацию будет добавить и в ExcludeModuleLogicModule
            builder.RegisterModule<ExcludeModuleLogicModule>();

            _container = builder.Build();

            var deliveryCostCalculator = _container.Resolve<IDeliveryCostCalculator>();
            Debug.Assert(deliveryCostCalculator.GetType().Name.StartsWith("Free"));

            _container.Resolve<IProductRepository>();

            _container.Resolve<IShopingCart>();

        }
    }
}
