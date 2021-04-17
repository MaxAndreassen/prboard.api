using System;
using System.Linq;
using System.Reflection;
using Autofac;
using Autofac.Builder;
using Autofac.Features.Scanning;
using foundation.Configuration;
using foundation.Validation;

namespace foundation.Extensions
{
    public static class AutofacExtensions
    {
        public static ContainerBuilder AddAutofacWithFoundation(this ContainerBuilder builder)
        {
            builder.ConfigureFoundationDependencies();

            return builder;
        }

        private static void ConfigureFoundationDependencies(this ContainerBuilder builder)
        {
            var assemblyNames = Assembly
                .GetEntryAssembly()?
                .GetReferencedAssemblies()
                .Where(x => x.Name.StartsWith("prboard.api"));

            foreach (var assemblyName in assemblyNames)
            {
                Assembly.Load(assemblyName);
            }

            var assemblies = AppDomain.CurrentDomain.GetAssemblies();

            builder.RegisterAssemblyTypes(assemblies)
                .WithAttribute<FoundationServiceAttribute>()
                .AsImplementedInterfaces()
                .InstancePerDependency();

            builder.RegisterAssemblyTypes(assemblies)
                .Where(e => e.Implements(typeof(IDomainValidator<>)))
                .AsImplementedInterfaces();
        }

        public static IRegistrationBuilder<object, ScanningActivatorData, DynamicRegistrationStyle>
            WithAttribute<TAttribute>(
                this IRegistrationBuilder<object, ScanningActivatorData, DynamicRegistrationStyle> builder)
            where TAttribute : Attribute
        {
            return builder.Where(e => e.GetCustomAttribute<TAttribute>() != null);
        }
    }
}