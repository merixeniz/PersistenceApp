using Application.Algorithms.Trees;
using Application.Algorithms.Trees.LinkedList;
using Entities.Algorithms;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using Xunit;

namespace Persistence.Tests
{
    public class ReverseLinkedListTests
    {
        private LinkedListNode linkedList = InitializeLinkedList();

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

        [Fact]
        public void ReverseLinkedList_LeetCodeLinkedList()
        {
            var sut = new LeetCodeLinkedList();
            var reversed = sut.ReverseLinkedList(linkedList);

            reversed.Val.Should().Be(5);
            reversed.Next.Val.Should().Be(4);
            reversed.Next.Next.Val.Should().Be(3);
            reversed.Next.Next.Next.Val.Should().Be(2);
            reversed.Next.Next.Next.Next.Val.Should().Be(1);
            reversed.Next.Next.Next.Next.Next.Should().Be(null);
        }

        [Fact]
        public void TraverseLinkedList()
        {
            var sut = new LeetCodeLinkedList();
            var traversed = sut.TraverseLinkedList(linkedList);
            var list = new List<int> { 1, 2, 3, 4, 5 };
            traversed.Should().BeEquivalentTo(list);
        }

        [Fact]
        public void AddTwoNumbers()
        {
            var sut = new LeetCodeLinkedList();
            var l1 = new LinkedListNode(2);
            l1.Next = new LinkedListNode(4);
            l1.Next.Next = new LinkedListNode(3);

            var l2 = new LinkedListNode(5);
            l2.Next = new LinkedListNode(6);
            l2.Next.Next = new LinkedListNode(4);

            var result = sut.AddTwoNumbers(l1, l2);

            var list = new List<int> { 7, 0, 8 };
            sut.TraverseLinkedList(result).Should().BeEquivalentTo(list);
        }


        private static LinkedListNode InitializeLinkedList()
        {
            var list = new LinkedListNode(1);
            list.Next = new LinkedListNode(2);
            list.Next.Next = new LinkedListNode(3);
            list.Next.Next.Next = new LinkedListNode(4);
            list.Next.Next.Next.Next = new LinkedListNode(5);

            return list;
        }
    }
}
