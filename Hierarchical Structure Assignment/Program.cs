using System.Xml.Linq;

class Program
{
    static void Main(string[] args)
    {
        Node root = new Node("root");
        Node node1_1 = new Node("node1_1");
        Node node1_2 = new Node("node1_2");
        Node node2_1 = new Node("node2_1");
        Node node2_2 = new Node("node2_2");
        Node node2_3 = new Node("node2_3");
        Node node2_4 = new Node("node2_4");
        Node node3_1 = new Node("node3_1");
        Node node3_2 = new Node("node3_2");
        Node node3_3 = new Node("node3_3");
        Node node4_1 = new Node("node4_1");

        root.Nodes.Add(node1_1);
        root.Nodes.Add(node1_2);
        node1_1.Nodes.Add(node2_1);
        node1_2.Nodes.Add(node2_2);
        node1_2.Nodes.Add(node2_3);
        node1_2.Nodes.Add(node2_4);
        node2_2.Nodes.Add(node3_1);
        node2_3.Nodes.Add(node3_2);
        node2_3.Nodes.Add(node3_3);
        node3_2.Nodes.Add(node4_1);

        // Test the depth calculation
        var name = Console.ReadLine();
        int depth = GetNodeDepth(root, name.ToLower());
        Console.WriteLine($"The depth of {name} is {depth}.");

        // Wait for user input before closing the console window
        Console.ReadLine();
    }

    static int GetNodeDepth(Node parent, string nodeName)
    {
        // Base case: the parent node is the target node
        if (parent.Name.ToLower() == nodeName)
        {
            return 0;
        }

        // Recursive case: search the children of the parent node
        int depth = -1;
        foreach (Node child in parent.Nodes)
        {
            int childDepth = GetNodeDepth(child, nodeName);
            if (childDepth >= 0 && (depth == -1 || childDepth < depth))
            {
                depth = childDepth + 1;
            }
        }

        return depth;
    }

}

class Node
{
    public string Name;
    public List<Node> Nodes;

    public Node(string name)
    {
        Name = name;
        Nodes = new List<Node>();
    }
}