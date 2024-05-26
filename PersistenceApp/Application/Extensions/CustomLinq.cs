using System;
using System.Collections.Generic;

namespace Application.Extensions
{
    public static class CustomLinq
    {
        public static IEnumerable<T> MoveToEnd<T>(this IEnumerable<T> collection, Func<T, bool> predicate)
        {
            var temporaryList = new List<T>();

            foreach (var item in collection)
            {
                if (predicate(item)) temporaryList.Add(item);
                else yield return item;
            }

            foreach (var item in temporaryList)
            {
                yield return item;
            }
        }
    }
}
