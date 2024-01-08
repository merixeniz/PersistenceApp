namespace Entities.Algorithms
{
    public class Node
    {
        public string Data { get; set; }
        public int Value { get; set; }
        public Node Left { get; set; }
        public Node Right { get; set; }

        public Node(string data, Node left, Node right)
        {
            this.Data = data;
            this.Left = left;
            this.Right = right;
        }

        public Node(string data)
        {
            this.Data = data;
            this.Left = null;
            this.Right = null;
        }

        public Node(int value)
        {
            this.Value = value;
            this.Left = null;
            this.Right = null;
        }
    }
}
