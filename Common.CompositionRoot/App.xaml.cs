using System.Windows;
using Autofac;
using Common.Provider;
using Common.Reporting;

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

            builder.RegisterModule<CommonProviderModule>();
            builder.RegisterModule<CommonReportingModule>();

            _container = builder.Build();
        }
    }
}
