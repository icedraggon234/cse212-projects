using Microsoft.VisualStudio.TestTools.UnitTesting;

// TODO Problem 2 - Write and run test cases and fix the code to match requirements.

[TestClass]
public class PriorityQueueTests
{
    [TestMethod]
    // Scenario: Queueing and then dequeueing two items from queue with same priority.
    // Expected Result: Should return items in order they were queued. Item 1, Item 2
    // Defect(s) Found: PriorityQueue.Dequeue() was comparing priorities incorrectly, and was not removing from the queue.
    public void TestPriorityQueue_QueueingDequeueing()
    {
        var priorityQueue = new PriorityQueue();

        priorityQueue.Enqueue("Item 1", 1);
        priorityQueue.Enqueue("Item 2", 1);
        priorityQueue.Enqueue("Item 3", 1);
        priorityQueue.Enqueue("Item 4", 1);

        string[] expectedResult = ["Item 1", "Item 2", "Item 3", "Item 4"];

        for (int i = 0; i < expectedResult.Length; i++)
        {
            string item = priorityQueue.Dequeue();
            Assert.AreEqual(expectedResult[i], item);
        }
        
    }

    [TestMethod]
    // Scenario: Queue two items with priority one, dequeue one, add one higher priority item, dequeue rest.
    // Expected Result: Item 1, Item 3, Item 2
    // Defect(s) Found: PriorityQueue.Dequeue() was comparing the index to the queue count incorrectly.
    public void TestPriorityQueue_PriorityOverOrder()
    {
        var priorityQueue = new PriorityQueue();

        string[] expectedResult = ["Item 1", "Item 3", "Item 2"];
        int i = 0;

        priorityQueue.Enqueue("Item 1", 1);
        priorityQueue.Enqueue("Item 2", 1);

        string item = priorityQueue.Dequeue();
        Assert.AreEqual(expectedResult[i], item);
        i++;

        priorityQueue.Enqueue("Item 3", 2);

        while (i < expectedResult.Length)
        {
            item = priorityQueue.Dequeue();
            Assert.AreEqual(expectedResult[i], item);
            i++;
        }
    }
    
    [TestMethod]
    // Scenario: A longer queue with a few priorities
    // Expected Result: Item 8, Item 9, Item 6, Item 3, Item 4, Item 7, Item 1, Item 2, Item 5
    // Defect(s) Found: None
    public void TestPriorityQueue_2()
    {
        var priorityQueue = new PriorityQueue();
        
        priorityQueue.Enqueue("Item 1", 1);
        priorityQueue.Enqueue("Item 2", 1);
        priorityQueue.Enqueue("Item 3", 2);
        priorityQueue.Enqueue("Item 4", 2);
        priorityQueue.Enqueue("Item 5", 1);
        priorityQueue.Enqueue("Item 6", 3);
        priorityQueue.Enqueue("Item 7", 2);
        priorityQueue.Enqueue("Item 8", 4);
        priorityQueue.Enqueue("Item 9", 4);

        string[] expectedResult = ["Item 8", "Item 9", "Item 6", "Item 3", "Item 4", "Item 7", "Item 1", "Item 2", "Item 5"];

        for (int i = 0; i < expectedResult.Length; i++)
        {
            string item = priorityQueue.Dequeue();
            Assert.AreEqual(expectedResult[i], item);
        }

        
    }

    [TestMethod]
    // Scenario: Dequeue an empty queue
    // Expected Result: An InvalidOperationException to be thrown with the message "The queue is empty."
    // Defect(s) Found: None
    public void TestPriorityQueue_ErrorMessage()
    {
        var priorityQueue = new PriorityQueue();

        try
        {
            priorityQueue.Dequeue();
            Assert.Fail("Exception should have been thrown.");
        }
        catch (InvalidOperationException e)
        {
            Assert.AreEqual("The queue is empty.", e.Message);
        }
        catch (AssertFailedException)
        {
            throw;
        }
        catch (Exception e)
        {
            Assert.Fail(
                 string.Format("Unexpected exception of type {0} caught: {1}",
                                e.GetType(), e.Message)
            );
        }
    }

    // Add more test cases as needed below.
}