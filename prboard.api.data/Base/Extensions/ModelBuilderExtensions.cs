using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Microsoft.EntityFrameworkCore;

namespace prboard.api.data.Base.Extensions
{
    public static class ModelBuilderExtensions
    {
        public static IEnumerable<Type> GetEntityMappingTypes(this Assembly assembly, Type mappingInterface)
        {
            var assemblyTypes = assembly.DefinedTypes;

            return assemblyTypes
                .Where(t =>
                    t.ImplementedInterfaces.Any(i => i.Name == mappingInterface.Name) &
                    !t.ContainsGenericParameters &&
                    !t.IsAbstract)
                .Select(typeInfo => typeInfo.AsType());
        }

        public static void AddEntityMappingConfgurations(this ModelBuilder modelBuilder, Assembly[] assemblies, Type mappingInterface)
        {
            foreach (var assembly in assemblies)
            {
                var configTypes = assembly.GetEntityMappingTypes(mappingInterface);

                foreach (var configType in configTypes)
                {
                    modelBuilder.AddEntityMappingConfiguration(configType);
                }
            }
        }

        private static void AddEntityMappingConfiguration(this ModelBuilder modelBuilder, Type configType)
        {
            var config = (dynamic)Activator.CreateInstance(configType);
            modelBuilder.ApplyConfiguration(config);
        }
        
        

        public static void RemoveEntitySuffixFromTableNames(this ModelBuilder builder)
        {
            const string entityString = "Entity";
            
            foreach (var entityType in builder.Model.GetEntityTypes())
            {
                entityType.SetTableName(entityType.GetTableName().Replace(entityString, string.Empty));
            }
        }
    }
}