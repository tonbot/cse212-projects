public class Node
{
    public int Data { get; set; } // Property to hold data for the node
    public Node? Right { get; private set; } // Reference to right child node
    public Node? Left { get; private set; } // Reference to left child node

    // Constructor that initializes a node with a given data value
    public Node(int data)
    {
        this.Data = data;
    }

    // Method to insert a value into the tree while maintaining BST properties
    public void Insert(int value)
    {
        if (value == Data) return; // Prevent duplicate insertions

        if (value < Data)
        {
            if (Left is null)
                Left = new Node(value); // Create a new node if left child is null
            else
                Left.Insert(value); // Recursively insert into the left subtree
        }
        else
        {
            if (Right is null)
                Right = new Node(value); // Create a new node if right child is null
            else
                Right.Insert(value); // Recursively insert into the right subtree
        }
    }

    // Method to check if a given value exists in the tree
    public bool Contains(int value)
    {
        if (value == Data) return true;
        if (value < Data)
            return Left != null && Left.Contains(value); // Search in the left subtree
        else
            return Right != null && Right.Contains(value); // Search in the right subtree
    }

    // Method to calculate the height of the tree
    public int GetHeight()
    {
        int leftHeight = Left?.GetHeight() ?? 0; // Get height of left subtree
        int rightHeight = Right?.GetHeight() ?? 0; // Get height of right subtree
        return Math.Max(leftHeight, rightHeight) + 1; // Return max depth plus one
    }
}
