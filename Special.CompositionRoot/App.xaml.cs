using System.Windows;
using Autofac;
using Common.Reporting;
using Special.Provider;
using Special.Reporting;

namespace Special.CompositionRoot
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

            builder.RegisterModule<SpecialProviderModule>();
            builder.RegisterModule<CommonReportingModule>();
            builder.RegisterModule<SpecialReportingModule>();

            _container = builder.Build();

        }
    }
}
