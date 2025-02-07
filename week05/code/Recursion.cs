using System.Collections;
using System.Collections.Generic;

public static class Recursion
{
    /// <summary>
    /// #############
    /// # Problem 1 #
    /// #############
    /// Using recursion, find the sum of 1^2 + 2^2 + 3^2 + ... + n^2
    /// and return it.  Remember to both express the solution 
    /// in terms of recursive call on a smaller problem and 
    /// to identify a base case (terminating case).  If the value of
    /// n <= 0, just return 0.   A loop should not be used.
    /// </summary>
    public static int SumSquaresRecursive(int n)
    {
        // Base case: If n is 0 or negative, return 0
        if (n <= 0)
            return 0;

        // Recursive case: n^2 + SumSquaresRecursive(n-1)
        return (n * n) + SumSquaresRecursive(n - 1);
    }

    /// <summary>
    /// #############
    /// # Problem 2 #
    /// #############
    /// Using recursion, insert permutations of length
    /// 'size' from a list of 'letters' into the results list.  This function
    /// should assume that each letter is unique (i.e. the 
    /// function does not need to find unique permutations).
    ///
    /// In mathematics, we can calculate the number of permutations
    /// using the formula: len(letters)! / (len(letters) - size)!
    ///
    /// For example, if letters was [A,B,C] and size was 2 then
    /// the following would the contents of the results array after the function ran: AB, AC, BA, BC, CA, CB (might be in 
    /// a different order).
    ///
    /// You can assume that the size specified is always valid (between 1 
    /// and the length of the letters list).
    /// </summary>
    public static void PermutationsChoose(List<string> results, string letters, int size, string word = "")
    {
        // Base case: If the current word has reached the required size, add it to results
        if (word.Length == size)
        {
            results.Add(word);
            return;
        }

        // Recursive case: Add each letter to the current word and recurse
        for (int i = 0; i < letters.Length; i++)
        {
            PermutationsChoose(results, letters.Remove(i, 1), size, word + letters[i]);
        }
    }

    /// <summary>
    /// #############
    /// # Problem 3 #
    /// #############
    /// Imagine that there was a staircase with 's' stairs.  
    /// We want to count how many ways there are to climb 
    /// the stairs.  If the person could only climb one 
    /// stair at a time, then the total would be just one.  
    /// However, if the person could choose to climb either 
    /// one, two, or three stairs at a time (in any order), 
    /// then the total possibilities become much more 
    /// complicated.  
    ///
    /// These final leaps give us a sum:
    ///
    /// CountWaysToClimb(s) = CountWaysToClimb(s-1) + 
    ///                       CountWaysToClimb(s-2) +
    ///                       CountWaysToClimb(s-3)
    ///
    /// To run this function for larger values of 's', you will need
    /// to update this function to use memoization.  The parameter
    /// 'remember' has already been added as an input parameter to 
    /// the function for you to complete this task.
    /// </summary>
    public static decimal CountWaysToClimb(int s, Dictionary<int, decimal>? remember = null)
    {
        if (remember == null)
            remember = new Dictionary<int, decimal>();

        // Base Cases
        if (s == 0)
            return 0;
        if (s == 1)
            return 1;
        if (s == 2)
            return 2;
        if (s == 3)
            return 4;

        // Check if the result is already calculated
        if (remember.ContainsKey(s))
            return remember[s];

        // Recursive case with memoization
        decimal ways = CountWaysToClimb(s - 1, remember) +
                       CountWaysToClimb(s - 2, remember) +
                       CountWaysToClimb(s - 3, remember);

        remember[s] = ways; // Store result in the dictionary
        return ways;
    }

    /// <summary>
    /// #############
    /// # Problem 4 #
    /// #############
    /// A binary string is a string consisting of just 1's and 0's.  For example, 1010111 is 
    /// a binary string.  If we introduce a wildcard symbol * into the string, we can say that 
    /// this is now a pattern for multiple binary strings.
    ///
    /// Using recursion, insert all possible binary strings for a given pattern into the results list.
    /// </summary>
    public static void WildcardBinary(string pattern, List<string> results)
    {
        int index = pattern.IndexOf('*');

        // Base case: If there are no wildcards, add the pattern to results
        if (index == -1)
        {
            results.Add(pattern);
            return;
        }

        // Recursive case: Replace '*' with '0' and '1' and recurse
        WildcardBinary(pattern.Substring(0, index) + '0' + pattern.Substring(index + 1), results);
        WildcardBinary(pattern.Substring(0, index) + '1' + pattern.Substring(index + 1), results);
    }

    /// <summary>
    /// Use recursion to insert all paths that start at (0,0) and end at the
    /// 'end' square into the results list.
    /// </summary>
   public static void SolveMaze(List<string> results, Maze maze, int x = 0, int y = 0, List<ValueTuple<int, int>>? currPath = null)
{
    // Initialize currPath if this is the first call
    if (currPath == null)
    {
        currPath = new List<ValueTuple<int, int>>();
    }

    // If already visited, return to avoid loops
    if (currPath.Contains((x, y))) return;

    // Add current position to the path
    currPath.Add((x, y));

    // Check if we reached the goal (2)
    if (maze.Data[y * maze.Width + x] == 2)
    {
        results.Add($"<List>{{{string.Join(", ", currPath)}}}");
        return;
    }

    // Try moving in all 4 possible directions (right, down, left, up)
    if (maze.IsValidMove(currPath, x + 1, y))
        SolveMaze(results, maze, x + 1, y, new List<ValueTuple<int, int>>(currPath));

    if (maze.IsValidMove(currPath, x, y + 1))
        SolveMaze(results, maze, x, y + 1, new List<ValueTuple<int, int>>(currPath));

    if (maze.IsValidMove(currPath, x - 1, y))
        SolveMaze(results, maze, x - 1, y, new List<ValueTuple<int, int>>(currPath));

    if (maze.IsValidMove(currPath, x, y - 1))
        SolveMaze(results, maze, x, y - 1, new List<ValueTuple<int, int>>(currPath));
}

}
