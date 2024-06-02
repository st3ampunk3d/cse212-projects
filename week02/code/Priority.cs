public static class Priority {
    public static void Test() {
        // TODO Problem 2 - Write and run test cases and fix the code to match requirements
        // Example of creating and using the priority queue
        //var priorityQueue = new PriorityQueue();
        //Console.WriteLine(priorityQueue);

        // Test Cases

        // Test 1
        // Scenario:  The Enqueue function shall add an item (which contains both data and priority) to the back of the queue.
        // Expected Result: [Bob, Daniel, Saoirse]
        Console.WriteLine("Test 1");
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("Bobb", 1);
        priorityQueue.Enqueue("Daniel", 2);
        priorityQueue.Enqueue("Saoirse", 5);
        
        Console.WriteLine(priorityQueue.ToString());

        // Defect(s) Found: None

        Console.WriteLine("---------");

        // Test 2
        // Scenario: The Dequeue function shall remove the item with the highest priority and return its value.
        // Expected Result: Saoirse, [Bob, Daniel]
        Console.WriteLine("Test 2");
        priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("Bobb", 1);
        priorityQueue.Enqueue("Daniel", 2);
        priorityQueue.Enqueue("Saoirse", 5);
        var highPriority = priorityQueue.Dequeue();
        
        Console.WriteLine(highPriority + ", " + priorityQueue.ToString());

        // Defect(s) Found: 
        // Current Output: Daniel, [Bobb, Daniel, Saoirse]
        // The expected result is returned if I change the priority of Bobb to 5 or if I add another item to the queue. It looks like the last item in the queue is being ignored
        // PriorityQueue.cs line 25: for (int index = 1; index < _queue.Count - 1; index++) -> for (int index = 1; index < _queue.Count; index++)
        // The item is not being removed from the queue. Only the value is being returned.
        // PriorityQueue.cs line 32 inserted the following: _queue.RemoveAt(highPriorityIndex);

        Console.WriteLine("---------");

        // Test 3
        // Scenario: If there are more than one item with the highest priority, then the item closest to the front of the queue will be removed and its value returned.
        // Expected Result: Daniel, [Bobb, Saoirse]
        Console.WriteLine("Test 3");
        priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("Bobb", 1);
        priorityQueue.Enqueue("Daniel", 5);
        priorityQueue.Enqueue("Saoirse", 5);
        highPriority = priorityQueue.Dequeue();
        
        Console.WriteLine(highPriority + ", " + priorityQueue.ToString());

        // Defect(s) Found:
        // Current Output: Saoirse, [Bobb, Danie]
        // It is taking the highest priority from the back instead of from the front
        // Correct the comparison to look for greater than instead of greater than or equal to
        // PriorityQueue.cs line 25: if (_queue[index].Priority >= _queue[highPriorityIndex].Priority) -> if (_queue[index].Priority > _queue[highPriorityIndex].Priority)

        Console.WriteLine("---------");

        // Test 4
        // Scenario: If the queue is empty, then an error message will be displayed.
        // Expected Result: "The queue is empty"
        Console.WriteLine("Test 4");
        Console.WriteLine("---------");
        priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("Bobb", 1);
        priorityQueue.Enqueue("Daniel", 5);
        priorityQueue.Enqueue("Saoirse", 5);

        for (int i = 0; i < 4; i++) {
            priorityQueue.Dequeue();
        }

        // Defect(s) Found: None

        // Add more Test Cases As Needed Below
    }
}