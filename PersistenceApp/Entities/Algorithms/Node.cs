namespace Entities.Algorithms
{
    public class Node
    {
        public string Value { get; set; }
        public Node Left { get; set; }
        public Node Right { get; set; }

        public Node(string value, Node left, Node right)
        {
            this.Value = value;
            this.Left = left;
            this.Right = right;
        }

        public Node(string value)
        {
            this.Value = value;
            this.Left = null;
            this.Right = null;
        }
    }
}
