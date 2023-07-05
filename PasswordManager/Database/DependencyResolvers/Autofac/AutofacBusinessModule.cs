using Microsoft.IdentityModel.Tokens;
using Autofac;
using Autofac.Extras.DynamicProxy;
using PasswordManager.Database.Repository.CategoryRepository;
using PasswordManager.Database.Repository.PasswordsRepository;
using PasswordManager.Database.Repository.UserRepository;
using PasswordManager.Utilities.Interceptors;

namespace PasswordManager.Database.DependencyResolvers.Autofac
{
    public class AutofacBusinessModule: Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<EfUserDal>().As<IUserDal>();
            builder.RegisterType<EfCategoryDal>().As<ICategoryDal>();
            builder.RegisterType<EfPasswordsDal>().As<IPasswordsDal>();
            

            //var assembly = System.Reflection.Assembly.GetExecutingAssembly();

            //builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces().EnableInterfaceInterceptors(new Castle.DynamicProxy.ProxyGenerationOptions()
            //{
            //    Selector = new AspectInterceptorSelector()
            //}).SingleInstance();
        }

    }
}
