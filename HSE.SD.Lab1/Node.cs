using HSE.SD.Lab1.Identifiers;

namespace HSE.SD.Lab1
{
    public class Node
    {
        public Identifier Identifier;
        public Node Left;
        public Node Right;

        public Node() { }

        public Node(Identifier identifier)
        {
            Identifier = identifier;
            Left = null;
            Right = null;
        }

        public static Node Add(Node root, Identifier identifier)
        {
            if (root == null)
            {
                Node newNode = new Node(identifier);
                root = newNode;
            }
            else if (identifier.Hash < root.Identifier.Hash)
                root.Left = Add(root.Left, identifier);
            else
                root.Right = Add(root.Right, identifier);

            return root;
        }
    }
}
