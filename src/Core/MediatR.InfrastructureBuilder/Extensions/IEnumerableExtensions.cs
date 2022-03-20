namespace MediatR.InfrastructureBuilder.Extensions
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    internal static class IEnumerableExtensions
    {
        internal static bool HasAnyDuplicate<T>(this IEnumerable<T> source, out T duplicate)
        {
            if (source is null)
            {
                throw new ArgumentNullException(nameof(source));
            }

            var set = new HashSet<T>();
            foreach (var t in source)
            {
                if (!set.Add(t))
                {
                    duplicate = t;
                    return true;
                }
            }

            duplicate = default;
            return false;
        }
    }
}
