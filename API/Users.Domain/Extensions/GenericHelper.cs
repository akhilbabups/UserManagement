using System.Collections.Generic;
using System.Linq;

namespace Users.Domain.Extensions
{
    public static class GenericHelper
    {
        public static bool IsNullOrEmptyCollection<T>(this IEnumerable<T> collection)
        {
            if (collection == null || !collection.Any())
            {
                return true;
            }
            return false;
        }
    }
}