using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;

namespace Application.Algorithms
{
    public static class SpanFun
    {
        public static List<int> SpanPlayground()
        {
            var array = Enumerable.Range(0, 9).ToArray();
            var list = array.ToList();

            var span = CollectionsMarshal.AsSpan(list);
            span.Reverse();
            list.Add(10); // will be in list, wont be in span

            return list;
        }
    }
}
