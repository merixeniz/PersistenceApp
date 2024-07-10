using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Algorithms.LINQ
{
    // LINQ -> js
    // Select -> map
    // SelectMany -> flatMap
    // Aggregate -> reduce
    // Where -> filter
    // OrderBy -> sort
    // GroupBy -> groupBy / reduce
    // Contains -> includes
    // Any -> some
    // All -> every
    // Exist/Contains -> find
    // Distinct -> new Set(array)
    // Count -> length 
    // Sum -> reduce
    // Max/Min -> Math.max(...array) / Math.min(...array)
    // FirstOrDefault -> find || defaultValue;
    public class InventoryItem
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public int Quantity { get; set; }

        public delegate bool MyDelegate(string input);
        public MyDelegate MyDelegateName;

        public Action ActionDelegate;
        public Func<string, bool> FuncDelegate;
        public InventoryItem()
        {
            MyDelegateName = MyMethod;
            FuncDelegate = MyMethod;
        }

        public static List<InventoryItem> Inventory =
        [
            new InventoryItem { Name = "asparagus", Type = "vegetables", Quantity = 5 },
            new InventoryItem { Name = "bananas", Type = "fruit", Quantity = 0 },
            new InventoryItem { Name = "goat", Type = "meat", Quantity = 23 },
            new InventoryItem { Name = "cherries", Type = "fruit", Quantity = 5 },
            new InventoryItem { Name = "fish", Type = "meat", Quantity = 22 }
        ];

        public static bool MyMethod(string input)
        {
            var tmp = GetItems().ToArray();

            foreach (var inventoryItem in tmp)
            {

            }

            foreach (var inventoryItem in tmp)
            {

            }

            foreach (var number in GetEvenNumbers().TakeWhile(n => n < 20))
            {
                Console.WriteLine(number);
            }

            return true;
        }

        public static List<InventoryItem> GetInventory()
        {
            return Inventory;
        }

        public static IEnumerable<InventoryItem> GetItems()
        {
            foreach (var item in Inventory)
            {
                yield return item;
            }
        }

        public static IEnumerable<int> GetEvenNumbers()
        {
            for (int i = 0; ; i++)
            {
                if (i % 2 == 0)
                    yield return i;
            }
        }
    }

    public class LinqFun
    {
        public static InventoryItem GroupBy_ReturnFirstItemOfFirstGroup()
        {
            var result = InventoryItem.Inventory.GroupBy(x => x.Type).ToArray();
            var firstGroup = result.First();
            var itemsOfFirstGroup = firstGroup.Select(x => x).ToArray();
            return itemsOfFirstGroup.First();
        }

        public static InventoryItem[] Distinct_byType()
        {
            return InventoryItem.Inventory.DistinctBy(x => x.Type).ToArray();
        }

        public static InventoryItem[] Distinct_byType_Hashset()
        {
            var hashSet = new HashSet<string>();
            return InventoryItem.Inventory.Where(x => hashSet.Add(x.Type)).ToArray();
        }


    }
}
