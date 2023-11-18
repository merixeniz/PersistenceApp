using Entities.Algorithms;
using System;
using System.Collections.Generic;

namespace Application.Algorithms
{
    public class DFS
    {
        public static void Traverse(Node node)
        {
            if (node == null)
                return;

            Console.WriteLine(node.Value);
            Traverse(node.Left);
            Traverse(node.Right);
        }

        public static void TraverseIterative(Node root)
        {
            if (root == null)
                return;

            Stack<Node> stack = new Stack<Node>();
            stack.Push(root);

            while (stack.Count > 0)
            {
                Node current = stack.Pop();
                Console.WriteLine(current.Value);

                if (current.Right != null)
                    stack.Push(current.Right);

                if (current.Left != null)
                    stack.Push(current.Left);
            }
        }
    }
}
