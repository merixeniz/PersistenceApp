using Entities.Algorithms;
using System;

namespace Application.Algorithms
{
    public class TreeTraversals
    {
        public void InOrderTraversal(Node node)
        {
            //left -> Root --> Right

            if (node.Left != null)
                InOrderTraversal(node.Left);

            Console.WriteLine(node.Value + " ");

            if (node.Right != null)
                InOrderTraversal(node.Right);
        }

        public void PreOrderTraversal(Node node)
        {
            //Root -> Left - > Right
            Console.WriteLine(node.Value + " ");

            if (node.Left != null)
                PreOrderTraversal(node.Left);

            if (node.Right != null)
                PreOrderTraversal(node.Right);
        }

        public void PostOrderTraversal(Node node)
        {
            //Right - > Left -> Root

            if (node.Right != null)
                PostOrderTraversal(node.Right);

            if (node.Left != null)
                PostOrderTraversal(node.Left);

            Console.WriteLine(node.Value + " ");
        }
    }
}
