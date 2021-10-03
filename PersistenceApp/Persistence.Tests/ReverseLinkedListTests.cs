using Application.Algorithms.Trees;
using Entities.Algorithms;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Persistence.Tests
{
    public class ReverseLinkedListTests
    {
        [Fact]
        public void ReverseLinkedList()
        {
            // Input null->1->2->3->4->5->null
            // Result 5->4->3->2->1->null

            var list = new ListNode(1);
            list.Next = new ListNode(2);
            list.Next.Next = new ListNode(3);
            list.Next.Next.Next = new ListNode(4);
            list.Next.Next.Next.Next = new ListNode(5);

            var sut = new ReverseLinkedList();
            sut.Traverse(list);
            sut.FlattenList(list);
            var result1 = sut.Values;

            var reversedList = sut.ReverseList(list);
            sut.Traverse(reversedList);
            sut.FlattenList(reversedList);
            var result2 = sut.Values;

        }
    }
}
