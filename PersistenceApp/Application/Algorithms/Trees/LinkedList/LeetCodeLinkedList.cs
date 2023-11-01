using System.Collections.Generic;
using System.Linq;

namespace Application.Algorithms.Trees.LinkedList
{
    public class LeetCodeLinkedList
    {
        public LinkedListNode AddTwoNumbers(LinkedListNode l1, LinkedListNode l2)
        {
            int.TryParse(string.Concat(TraverseLinkedList(ReverseLinkedList(l1))), out int valueL1);
            int.TryParse(string.Concat(TraverseLinkedList(ReverseLinkedList(l2))), out int valueL2);

            var result = valueL1 + valueL2;
            var stringResult = result.ToString().Reverse();

            LinkedListNode resultLinkedList = null;

            foreach (var sign in stringResult)
            {
                if (int.TryParse(sign.ToString(), out int value))
                {
                    var node = new LinkedListNode(value);

                    if (resultLinkedList == null)
                    {
                        resultLinkedList = node;
                    }
                    else
                    {
                        AddNode(resultLinkedList, node);
                    }
                }
            }

            return resultLinkedList;
        }

        public LinkedListNode ReverseLinkedList(LinkedListNode node)
        {
            if (node == null) return null;

            LinkedListNode prev = null;

            while (node != null)
            {
                LinkedListNode next = node.Next; // zapisz referencje do Next
                node.Next = prev; // odwroc wskaznik
                prev = node; // przesun prev w prawo
                node = next; // przesun newNode w prawo
            }

            return prev;
        }

        public List<int> TraverseLinkedList(LinkedListNode node, List<int> result = null)
        {
            if (node == null)
                return result ?? new List<int>();

            if (result == null)
            {
                result = new List<int>();
            }

            result.Add(node.Val);
            TraverseLinkedList(node.Next, result);

            return result;
        }

        public LinkedListNode AddNode(LinkedListNode root, LinkedListNode newNode)
        {
            if (root == null) return null;

            if (root.Next != null)
            {
                AddNode(root.Next, newNode);
            }

            root.Next = newNode;
            return root;
        }
    }
    // Definition for singly-linked list.
    public class LinkedListNode
    {
        public int Val;
        public LinkedListNode Next;
        public LinkedListNode(int val = 0, LinkedListNode next = null)
        {
            this.Val = val;
            this.Next = next;
        }
    }
}

// https://leetcode.com/problems/add-two-numbers/
