using Entities.Algorithms;
using System;
using System.Collections.Generic;

namespace Application.Algorithms
{
    public class BFS
    {
        public static void Traverse(Node node)
        {
            Queue<Node> queue = new Queue<Node>();

            if (node == null)
                return;

            queue.Enqueue(node);

            while (queue.Count > 0)
            {
                node = queue.Dequeue();
                Console.WriteLine(node.Value);

                if (node.Left != null)
                    queue.Enqueue(node.Left);

                if (node.Right != null)
                    queue.Enqueue(node.Right);
            }
        }
    }
}
