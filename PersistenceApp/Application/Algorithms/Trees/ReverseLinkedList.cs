using Entities.Algorithms;
using System.Collections.Generic;
using System.Diagnostics;

namespace Application.Algorithms.Trees
{
    public class ReverseLinkedList
    {
        public List<int> Values = new List<int>();

        // https://youtu.be/NhapasNIKuQ?t=276

        // Input null->1->2->3->4->5->null
        // Result 5->4->3->2->1->null

        // zwasze sie rozpatruje 3 nody, previous, head i nextNode

        public ListNode ReverseList(ListNode head)
        {
            if (head == null)
                return null;

            ListNode previous = null;

            while (head != null)
            {
                ListNode nextNode = head.Next;
                head.Next = previous; // odwroc wskaznik
                previous = head; // przesuń previous w prawo
                head = nextNode; // przesun head w prawo
            }

            return previous;
        }

        public void Traverse(ListNode list)
        {
            if (list == null)
                return;

            Debug.WriteLine(list.Value);
            Traverse(list.Next);
        }

        public void FlattenList(ListNode list)
        {
            if (list == null)
                return;

            Values.Add(list.Value);
            FlattenList(list.Next);
        }
    }
}
