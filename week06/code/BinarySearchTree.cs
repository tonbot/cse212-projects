// using System.Collections;

// public class BinarySearchTree : IEnumerable<int>
// {
//     private Node? _root;

//     /// <summary>
//     /// Insert a new node in the BST.
//     /// </summary>
//     public void Insert(int value)
//     {
//         // Create new node
//         Node newNode = new(value);
//         // If the list is empty, then point both head and tail to the new node.
//         if (_root is null)
//         {
//             _root = newNode;
//         }
//         // If the list is not empty, then only head will be affected.
//         else
//         {
//             _root.Insert(value);
//         }
//     }

//     /// <summary>
//     /// Check to see if the tree contains a certain value
//     /// </summary>
//     /// <param name="value">The value to look for</param>
//     /// <returns>true if found, otherwise false</returns>
//     public bool Contains(int value)
//     {
//         return _root != null && _root.Contains(value);
//     }

//     /// <summary>
//     /// Yields all values in the tree
//     /// </summary>
//     IEnumerator IEnumerable.GetEnumerator()
//     {
//         // call the generic version of the method
//         return GetEnumerator();
//     }

//     /// <summary>
//     /// Iterate forward through the BST
//     /// </summary>
//     public IEnumerator<int> GetEnumerator()
//     {
//         var numbers = new List<int>();
//         TraverseForward(_root, numbers);
//         foreach (var number in numbers)
//         {
//             yield return number;
//         }
//     }

//     private void TraverseForward(Node? node, List<int> values)
//     {
//         if (node is not null)
//         {
//             TraverseForward(node.Left, values);
//             values.Add(node.Data);
//             TraverseForward(node.Right, values);
//         }
//     }

//     /// <summary>
//     /// Iterate backward through the BST.
//     /// </summary>
//     public IEnumerable Reverse()
//     {
//         var numbers = new List<int>();
//         TraverseBackward(_root, numbers);
//         foreach (var number in numbers)
//         {
//             yield return number;
//         }
//     }

//  private void TraverseBackward(Node? node, List<int> values)
// {
//     if (node is not null)
//     {
//         TraverseBackward(node.Right, values); // Traverse right subtree first (larger values)
//         values.Add(node.Data);                // Visit the current node
//         TraverseBackward(node.Left, values);  // Traverse left subtree (smaller values)
//     }
// }


//     /// <summary>
//     /// Get the height of the tree
//     /// </summary>
//     public int GetHeight()
//     {
//         if (_root is null)
//             return 0;
//         return _root.GetHeight();
//     }

//     public override string ToString()
//     {
//         return "<Bst>{" + string.Join(", ", this) + "}";
//     }
// }

// public static class IntArrayExtensionMethods {
//     public static string AsString(this IEnumerable array) {
//         return "<IEnumerable>{" + string.Join(", ", array.Cast<int>()) + "}";
//     }
// }

using System.Collections;

public class BinarySearchTree : IEnumerable<int>
{
    private Node? _root; // Reference to the root node of the BST

    // Method to insert a value into the BST
    public void Insert(int value)
    {
        if (_root is null)
        {
            _root = new Node(value); // Create root if it doesn't exist
        }
        else
        {
            _root.Insert(value); // Insert into the existing tree
        }
    }

    // Method to check if a value exists in the BST
    public bool Contains(int value)
    {
        return _root != null && _root.Contains(value);
    }

    // Method to get the height of the BST
    public int GetHeight()
    {
        return _root?.GetHeight() ?? 0; // Return 0 if tree is empty
    }

    // Method to get elements of the tree in descending order
    public IEnumerable<int> Reverse()
    {
        var result = new List<int>();
        ReverseTraversal(_root, result);
        return result;
    }

    // Helper method for reverse traversal (right -> root -> left)
    private void ReverseTraversal(Node? node, List<int> result)
    {
        if (node is null) return;
        ReverseTraversal(node.Right, result); // Visit right subtree
        result.Add(node.Data); // Visit node
        ReverseTraversal(node.Left, result); // Visit left subtree
    }

    // Enumerator to enable in-order traversal
    public IEnumerator<int> GetEnumerator()
    {
        return InOrderTraversal(_root).GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    // Helper method for in-order traversal (left -> root -> right)
    private IEnumerable<int> InOrderTraversal(Node? node)
    {
        if (node is null) yield break;
        foreach (var value in InOrderTraversal(node.Left)) yield return value; // Traverse left subtree
        yield return node.Data; // Visit node
        foreach (var value in InOrderTraversal(node.Right)) yield return value; // Traverse right subtree
    }

    // Override ToString() method to display the BST elements
    public override string ToString()
    {
        return "<Bst>{" + string.Join(", ", this) + "}"; // Format output as BST
    }
}
