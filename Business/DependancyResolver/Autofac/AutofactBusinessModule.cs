using Autofac;
using Business.Abstract;
using Business.Concrete;
using Core.Utility.Security.Jwt;
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

            builder.RegisterType<UserManager>().As<IUserService>(); 
            builder.RegisterType<EfUserDAL>().As<IUserDAL>(); 
            
            builder.RegisterType<AuthManager>().As<IAuthService>(); 
            builder.RegisterType<TokenHelper>().As<ITokenHelper>();
        }
    }
}
