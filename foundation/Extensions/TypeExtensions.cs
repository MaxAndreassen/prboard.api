using System;
using System.Linq;

namespace foundation.Extensions
{
    public static class TypeExtensions
    {
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