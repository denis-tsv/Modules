using Autofac;
using Common.Provider;

namespace Special.Provider
{
    public class SpecialProviderModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<SpecialTypeNameProvider>().As<ITypeNameProvider>();
        }
    }
}
