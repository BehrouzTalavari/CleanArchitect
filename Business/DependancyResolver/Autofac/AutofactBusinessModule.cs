using Autofac;
using Business.Abstract;
using Business.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;

namespace Business.DependancyResolver.Autofac
{
    public class AutofactBusinessModule:Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<ProductManager>().As<IProductService>(); 
            builder.RegisterType<EfProductDAL>().As<IProductDAL>(); 
        }
    }
}
