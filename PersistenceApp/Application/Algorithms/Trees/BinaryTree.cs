using System;
using Entities.Algorithms;

namespace Application.Algorithms.Trees
{
    public class BinaryTree
    {
        private Node root;

        public BinaryTree()
        {
            root = null;
        }

        private Node InvertTree(Node node)
        {
            if (node == null)
                return null;

            Node temp = node.Left;
            node.Left = InvertTree(node.Right);
            node.Right = InvertTree(temp);

            return node;
        }

        public void InvertTree()
        {
            root = InvertTree(root);
        }

        private void InorderTraversal(Node node)
        {
            if (node != null)
            {
                InorderTraversal(node.Left);
                Console.Write(node.Value + " ");
                InorderTraversal(node.Right);
            }
        }

        private void PreorderTraversal(Node node)
        {
            if (node != null)
            {
                Console.Write(node.Data + " ");
                PreorderTraversal(node.Left);
                PreorderTraversal(node.Right);
            }
        }

        private void PostorderTraversal(Node node)
        {
            if (node != null)
            {
                PostorderTraversal(node.Left);
                PostorderTraversal(node.Right);
                Console.Write(node.Data + " ");
            }
        }

        public void InorderTraversal()
        {
            InorderTraversal(root);
            Console.WriteLine();
        }

        private Node Insert(Node node, int key)
        {
            if (node == null)
                return new Node(key);

            if (key < node.Value)
                node.Left = Insert(node.Left, key);
            else if (key > node.Value)
                node.Right = Insert(node.Right, key);

            return node;
        }

        public void Insert(int key)
        {
            root = Insert(root, key);
        }

        public static void CreateAndInvertBinaryTree()
        {
            BinaryTree tree = new BinaryTree();

            tree.Insert(1);
            tree.Insert(2);
            tree.Insert(3);
            tree.Insert(4);
            tree.Insert(5);

            Console.WriteLine("Drzewo przed odwróceniem:");
            tree.InorderTraversal();

            tree.InvertTree();

            Console.WriteLine("Drzewo po odwróceniu:");
            tree.InorderTraversal();
        }
    }
}
