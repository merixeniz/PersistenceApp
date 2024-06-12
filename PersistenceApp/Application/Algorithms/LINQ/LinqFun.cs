using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Algorithms.LINQ
{
    public class InventoryItem
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public int Quantity { get; set; }

        public static List<InventoryItem> Inventory =
        [
            new InventoryItem { Name = "asparagus", Type = "vegetables", Quantity = 5 },
            new InventoryItem { Name = "bananas", Type = "fruit", Quantity = 0 },
            new InventoryItem { Name = "goat", Type = "meat", Quantity = 23 },
            new InventoryItem { Name = "cherries", Type = "fruit", Quantity = 5 },
            new InventoryItem { Name = "fish", Type = "meat", Quantity = 22 }
        ];
    }

    public class LinqFun
    {
        public static InventoryItem GroupBy_ReturnFirstItemOfFirstGroup()
        {
            var result = InventoryItem.Inventory.GroupBy(x => x.Type).ToList();
            var firstGroup = result.First();
            var itemsOfFirstGroup = firstGroup.Select(x => x).ToArray();
            return itemsOfFirstGroup.First();
        }
    }
}
