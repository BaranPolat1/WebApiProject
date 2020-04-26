using Autofac;
using Business.Services.Abstract;
using Business.Services.Concrete;
using DataAccess.Repository.Abstract;
using DataAccess.Repository.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using Utility.Security.Jwt;

namespace Business.DependencyResolvers.Autofac
{
    public class AutofacBusinessModule:Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<PostService>().As<IPostService>().InstancePerLifetimeScope();
            builder.RegisterType<CategoryService>().As<ICategoryService>().InstancePerLifetimeScope();
            builder.RegisterType<AppUserService>().As<IAppUserService>();
            builder.RegisterType<EfCategoryRepository>().As<ICategoryRepository>().InstancePerLifetimeScope();
            builder.RegisterType<EfPostRepository>().As<IPostRepository>().InstancePerLifetimeScope();
            builder.RegisterType<EfAppUserRepository>().As<IAppUserRepository>().InstancePerLifetimeScope();
            builder.RegisterType<AuthService>().As<IAuthService>().InstancePerLifetimeScope();
            builder.RegisterType<JwtHelper>().As<ITokenHelper>().InstancePerLifetimeScope();

        }
    }
}
