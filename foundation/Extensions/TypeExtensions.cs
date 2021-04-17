using System;
using System.Linq;
using System.Reflection;

namespace foundation.Extensions
{
    public static class TypeExtensions
    {
        public static bool IsDerivedFrom(this TypeInfo typeInfo, Type baseType)
        {
            var baseTypeInfo = baseType?.GetTypeInfo();
            var current = typeInfo?.BaseType?.GetTypeInfo();

            while (current != null)
            {
                if (current == baseTypeInfo)
                    return true;

                if (current.IsGenericType && current.GetGenericTypeDefinition() == baseType)
                    return true;

                current = current?.BaseType?.GetTypeInfo();
            }

            return false;
        }

        public static bool Implements(this Type subject, Type type)
        {
            return subject
                .GetInterfaces()
                .Any(i => 
                    i == type || 
                    (i.IsGenericType && i.GetGenericTypeDefinition() == type));
        }
    }
}