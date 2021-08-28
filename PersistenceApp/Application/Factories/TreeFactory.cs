using Entities.Algorithms;

namespace Application.Factories
{
    public static class TreeFactory
    {
        public static Node CreateTree()
        {
            Node root =
                new Node("A",
                    new Node("B",
                        new Node("C"), new Node("D")),
                    new Node("E",
                        new Node("F"), new Node("G",
                            new Node("H"), null)));

            return root;
        }
    }
}
