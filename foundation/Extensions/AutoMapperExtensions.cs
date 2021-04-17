using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Autofac;
using AutoMapper;
using foundation.Entities;
using Microsoft.Extensions.DependencyInjection;

namespace foundation.Extensions
{
    public static class AutoMapperExtensions
    {
        public static IServiceCollection AddAutoMapperWithFoundation(
            this IServiceCollection services, params Assembly[] profileAssemblies
            )
        {
            var entityAssembly = typeof(BaseEntity).Assembly;

            if (!profileAssemblies.Contains(entityAssembly))
                profileAssemblies = profileAssemblies.Concat(new[] {entityAssembly}).ToArray();

            services.AddAutoMapper(profileAssemblies);

            return services;
        }

        public static void AssertAutoMapperConfiguration(this IContainer container)
        {
            var mapper = container.Resolve<IMapper>();

            mapper.ConfigurationProvider.AssertConfigurationIsValid();
        }

        public static TDestination MapTo<TSource, TDestination>(this TSource source, IMapper mapper)
        {
            return mapper.Map<TDestination>(source);
        }

        public static IList<TDestination> MapToList<TSource, TDestination>(
            this IEnumerable<TSource> source, IMapper mapper)
        {
            return source.ToList().Select(e => mapper.Map<TDestination>(e)).ToList();
        }
    }
}