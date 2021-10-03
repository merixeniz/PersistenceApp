using Entities.Algorithms;
using System;

namespace Application.Algorithms
{
    public class DFS
    {
        public void Traverse(Node node)
        {
            if (node == null)
                return;

            Console.WriteLine(node.Value);
            Traverse(node.Left);
            Traverse(node.Right);
        }
    }
}
