using System;
using System.Collections.Generic;

namespace Application.Extensions
{
    public static class ListExtensions
    {
        public static List<T> GetRange<T>(this List<T> list, Range range)
        {
            var (start, length) = range.GetOffsetAndLength(list.Count);
            return list.GetRange(start, length);
        }
    }
}
