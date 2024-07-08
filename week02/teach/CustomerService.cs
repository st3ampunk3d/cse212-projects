using System.Net.Http.Headers;

/// <summary>
/// Maintain a Customer Service Queue.  Allows new customers to be 
/// added and allows customers to be serviced.
/// </summary>
public class CustomerService {
    public static void Run() {
        // Example code to see what's in the customer service queue:
        // var cs = new CustomerService(10);
        // Console.WriteLine(cs);

        // Test Cases

        // Test 1
        // Scenario: Specify a max size
        // Expected Result: [size 0 max_size 5 =>]
        Console.WriteLine("Test 1");
        var cs = new CustomerService(5);
        Console.WriteLine(cs);

        // Defect(s) Found: none

        Console.WriteLine("=================");

        // Test 2
        // Scenario: Specify an invalid max size
        // Expected Result: [size 0 max_size 10 =>]
        Console.WriteLine("Test 2");
        cs = new CustomerService(0);
        Console.WriteLine(cs);

        // Defect(s) Found: none

        Console.WriteLine("=================");

        // Test 3
        // Scenario: Add 2 customers and then serve 2 customers
        // Expected Result: a (1) : xyz
        //                  b (2) : xyz
        //                  a (1) : xyz
        //                  b (2) : xyz
        Console.WriteLine("Test 3");
        cs = new CustomerService(2);
        cs.AddNewCustomer();
        Console.WriteLine();
        cs.AddNewCustomer();
        Console.WriteLine();
        cs.ServeCustomer();
        Console.WriteLine();
        cs.ServeCustomer();
        Console.WriteLine();

        // Defect(s) Found: Person was being removed from the queue before being served

        Console.WriteLine("=================");

        // Test 4
        // Scenario: Try to add a person to an already full queue
        // Expected Result: Error: Maximum Number of Customers in Queue.
        Console.WriteLine("Test 4");
        cs = new CustomerService(2);
        cs.AddNewCustomer();
        cs.AddNewCustomer();
        cs.AddNewCustomer();
        Console.WriteLine();

        // Defect(s) Found: No error message displayed. Needed to change > to >=

        Console.WriteLine("=================");

        // Test 5
        // Scenario: Try to serve an empty queue
        // Expected Result: Error: Queue is empty
        Console.WriteLine("Test 5");
        cs = new CustomerService(1);
        cs.ServeCustomer();
        Console.WriteLine();

        // Defect(s) Found: No error message displayed. Added if statement to check for empty queues

    }

    private readonly List<Customer> _queue = new();
    private readonly int _maxSize;

    public CustomerService(int maxSize) {
        if (maxSize <= 0)
            _maxSize = 10;
        else
            _maxSize = maxSize;
    }

    /// <summary>
    /// Defines a Customer record for the service queue.
    /// This is an inner class.  Its real name is CustomerService.Customer
    /// </summary>
    private class Customer {
        public Customer(string name, string accountId, string problem) {
            Name = name;
            AccountId = accountId;
            Problem = problem;
        }

        private string Name { get; }
        private string AccountId { get; }
        private string Problem { get; }

        public override string ToString() {
            return $"{Name} ({AccountId})  : {Problem}";
        }
    }

    /// <summary>
    /// Prompt the user for the customer and problem information.  Put the 
    /// new record into the queue.
    /// </summary>
    private void AddNewCustomer() {
        // Verify there is room in the service queue
        if (_queue.Count >= _maxSize) {
            Console.WriteLine("Maximum Number of Customers in Queue.");
            return;
        }

        Console.Write("Customer Name: ");
        var name = Console.ReadLine()!.Trim();
        Console.Write("Account Id: ");
        var accountId = Console.ReadLine()!.Trim();
        Console.Write("Problem: ");
        var problem = Console.ReadLine()!.Trim();

        // Create the customer object and add it to the queue
        var customer = new Customer(name, accountId, problem);
        _queue.Add(customer);
    }

    /// <summary>
    /// Dequeue the next customer and display the information.
    /// </summary>
    private void ServeCustomer() {
        //_queue.RemoveAt(0);
        if (_queue.Count > 0) {
            var customer = _queue[0];
            Console.WriteLine(customer);
            _queue.RemoveAt(0);
        }
        Console.WriteLine("Queue is empty.");
    }

    /// <summary>
    /// Support the WriteLine function to provide a string representation of the
    /// customer service queue object. This is useful for debugging. If you have a 
    /// CustomerService object called cs, then you run Console.WriteLine(cs) to
    /// see the contents.
    /// </summary>
    /// <returns>A string representation of the queue</returns>
    public override string ToString() {
        return $"[size={_queue.Count} max_size={_maxSize} => " + String.Join(", ", _queue) + "]";
    }
}