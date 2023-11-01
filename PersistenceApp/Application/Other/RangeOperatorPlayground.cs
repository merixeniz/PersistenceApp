using System.Linq;
using Application.Extensions;

namespace Application.Other
{
    public static class RangeOperatorPlayground
    {
        public static int[] ChangeOrderOfElementsInCollection()
        {
            var arr = new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            var list = arr.ToList();
            (arr[0], arr[1]) = (arr[1], arr[0]);

            var partA = arr[..4];
            var partB = arr[5..];

            var listA = list.GetRange(..4);
            var listB = list.GetRange(5..);

            return arr;
        }
    }
}
