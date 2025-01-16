using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

[TestClass]
public class PriorityQueueTests
{
    [TestMethod]
    // Scenario: Add multiple items with different priorities and check if the highest priority item is dequeued first.
    // Expected Result: "Item3" (priority 5) is dequeued first, followed by "Item1" (priority 3), and then "Item2" (priority 1).
    // Defect(s) Found: None (assuming the code behaves correctly).
    public void TestPriorityQueue_1()
    {
        var priorityQueue = new PriorityQueue();
        
        priorityQueue.Enqueue("Item1", 3);
        priorityQueue.Enqueue("Item2", 1);
        priorityQueue.Enqueue("Item3", 5);

        Assert.AreEqual("Item3", priorityQueue.Dequeue()); // Highest priority item
        Assert.AreEqual("Item1", priorityQueue.Dequeue()); // Next highest
        Assert.AreEqual("Item2", priorityQueue.Dequeue()); // Lowest priority
    }

    [TestMethod]
    // Scenario: Add multiple items with the same highest priority and ensure FIFO order is followed.
    // Expected Result: "Item3" and "Item4" both have the highest priority (5), but "Item3" should be dequeued first due to FIFO.
    // Defect(s) Found: None (assuming the code behaves correctly).
    public void TestPriorityQueue_2()
    {
        var priorityQueue = new PriorityQueue();
        
        priorityQueue.Enqueue("Item1", 3);
        priorityQueue.Enqueue("Item2", 1);
        priorityQueue.Enqueue("Item3", 5);
        priorityQueue.Enqueue("Item4", 5); // Same priority as "Item3"

        Assert.AreEqual("Item3", priorityQueue.Dequeue()); // FIFO with the same priority
        Assert.AreEqual("Item4", priorityQueue.Dequeue());
        Assert.AreEqual("Item1", priorityQueue.Dequeue());
        Assert.AreEqual("Item2", priorityQueue.Dequeue());
    }

    [TestMethod]
    // Scenario: Attempt to dequeue from an empty queue.
    // Expected Result: InvalidOperationException should be thrown.
    // Defect(s) Found: None (assuming the code behaves correctly).
    public void TestPriorityQueue_3()
    {
        var priorityQueue = new PriorityQueue();

        Assert.ThrowsException<InvalidOperationException>(() => priorityQueue.Dequeue());
    }

    [TestMethod]
    // Scenario: Enqueue a single item and then dequeue it.
    // Expected Result: After dequeueing the item, the queue should be empty.
    // Defect(s) Found: None (assuming the code behaves correctly).
    public void TestPriorityQueue_4()
    {
        var priorityQueue = new PriorityQueue();
        
        priorityQueue.Enqueue("Item1", 3);
        Assert.AreEqual("Item1", priorityQueue.Dequeue());

        // Attempt to dequeue again should throw an exception as the queue is empty now
        Assert.ThrowsException<InvalidOperationException>(() => priorityQueue.Dequeue());
    }
}
