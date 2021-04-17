using System;
using Autofac;
using foundation.Configuration;
using foundation.Entities.Contracts;
using foundation.Extensions;
using Microsoft.EntityFrameworkCore;
using prboard.api.data;
using prboard.api.data.Base;
using prboard.api.domain.Users.Services.Contracts;
using prboard.api.Security.Services;

namespace prboard.api.Extensions
{
    public static class AutofacContainerBuilderExtensions
    {
        public static ContainerBuilder ConfigureDependencies(this ContainerBuilder builder)
        {
            builder.RegisterType<PrBoardDbContext>()
                .As<IWorkUnit>()
                .As<DbContext>()
                .InstancePerLifetimeScope();

            /*builder
                .RegisterType<UserRegistrationService>()
                .As<IUserRegistrationService>();

            builder
                .RegisterType<LoginService>()
                .As<ILoginService>();*/

            builder
                .RegisterType<SecurityService>()
                .As<ISecurityService>();
            
            builder.RegisterAssemblyTypes(AppDomain.CurrentDomain.GetAssemblies())
                .WithAttribute<DomainServiceAttribute>()
                .AsImplementedInterfaces()
                .InstancePerDependency();
            
            builder.RegisterGeneric(typeof(Repository<>))
                .As(typeof(IRepository<>));

            return builder;
        }
    }
}