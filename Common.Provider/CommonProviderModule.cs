using Autofac;

namespace Common.Provider
{
    public class CommonProviderModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<TypeNameProvider>().As<ITypeNameProvider>();
        }
    }
}
