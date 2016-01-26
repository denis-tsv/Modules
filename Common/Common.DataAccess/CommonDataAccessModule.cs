using Autofac;

namespace Common.DataAccess
{
    public class CommonDataAccessModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<ProductRepository>().As<IProductRepository>();
        }
    }
}
