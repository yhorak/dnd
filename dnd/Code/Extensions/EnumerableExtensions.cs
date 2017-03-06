using System.Collections.Generic;
using Kendo.Mvc.Extensions;

namespace dnd.Code.Extensions
{
    public static class EnumerableExtensions
    {
        public static HashSet<T> ToHashSet<T>(this IEnumerable<T> source)
        {
            if (source == null) return new HashSet<T>();
            var set = new HashSet<T>();
            set.AddRange(source);
            return set;
        }
    }
}