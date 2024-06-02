public static class ArraysTester {
    /// <summary>
    /// Entry point for the tests
    /// </summary>
    public static void Run() {
        // Sample Test Cases (may not be comprehensive)
        Console.WriteLine("\n=========== PROBLEM 1 TESTS ===========");
        double[] multiples = MultiplesOf(7, 5);
        Console.WriteLine($"<double>{{{string.Join(',', multiples)}}}"); // <double>{7, 14, 21, 28, 35}
        multiples = MultiplesOf(1.5, 10);
        Console.WriteLine($"<double>{{{string.Join(',', multiples)}}}"); // <double>{1.5, 3.0, 4.5, 6.0, 7.5, 9.0, 10.5, 12.0, 13.5, 15.0}
        multiples = MultiplesOf(-2, 10);
        Console.WriteLine($"<double>{{{string.Join(',', multiples)}}}"); // <double>{-2, -4, -6, -8, -10, -12, -14, -16, -18, -20}

        Console.WriteLine("\n=========== PROBLEM 2 TESTS ===========");
        List<int> numbers = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
        int[] rotated = RotateListRight(numbers, 1);
        Console.WriteLine($"<List>{{{string.Join(',', rotated)}}}"); // <List>{9, 1, 2, 3, 4, 5, 6, 7, 8}
        numbers = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
        rotated = RotateListRight(numbers, 5);
        Console.WriteLine($"<List>{{{string.Join(',', rotated)}}}"); // <List>{5, 6, 7, 8, 9, 1, 2, 3, 4}
        numbers = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
        rotated = RotateListRight(numbers, 3);
        Console.WriteLine($"<List>{{{string.Join(',', rotated)}}}"); // <List>{7, 8, 9, 1, 2, 3, 4, 5, 6}
        numbers = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
        rotated = RotateListRight(numbers, 9);
        Console.WriteLine($"<List>{{{string.Join(',', rotated)}}}"); // <List>{1, 2, 3, 4, 5, 6, 7, 8, 9}
    }
    /// <summary>
    /// This function will produce a list of size 'length' starting with 'number' followed by multiples of 'number'.  For 
    /// example, MultiplesOf(7, 5) will result in: {7, 14, 21, 28, 35}.  Assume that length is a positive
    /// integer greater than 0.
    /// </summary>
    /// <returns>array of doubles that are the multiples of the supplied number</returns>
    private static double[] MultiplesOf(double number, int length)
    {
        // TODO Problem 1 Start
        // Remember: Using comments in your program, write down your process for solving this problem
        // step by step before you write the code. The plan should be clear enough that it could
        // be implemented by another person.

        //1. Create a new array to store the multiples in. It should be equal in length to the "length" parameter passed
        //2. Create a loop with an auto-incrementing iterator that stops when it matches the "length" parameter
        //3. multiply "number" by the iterator
        //4. insert the product into the into the array
        //5. Return the array.

        double[] multiples = new double[length];

        for (int i = 1; i <= length; ++i) {
            double product = number * i;
            multiples[i-1] = product;
        }
        return multiples;
    }
    
    /// <summary>
    /// Rotate the 'data' to the right by the 'amount'.  For example, if the data is 
    /// <c>&lt;List&gt;{1, 2, 3, 4, 5, 6, 7, 8, 9}</c> and an amount is 3 then the list returned should be 
    /// <c>&lt;List&gt;{7, 8, 9, 1, 2, 3, 4, 5, 6}</c>.  The value of amount will be in the range of <c>1</c> and 
    /// <c>data.Count</c>.
    /// <br /><br />
    /// Because a list is dynamic, this function will modify the existing <c>data</c> list rather than returning a new list.
    /// </summary>
    private static int[] RotateListRight(List<int> data, int amount)
    {
        // TODO Problem 2 Start
        // Remember: Using comments in your program, write down your process for solving this problem
        // step by step before you write the code. The plan should be clear enough that it could
        // be implemented by another person.

        //1. Get the length of the current list and create an empty array of the same size
        //2. create a loop with an auto-incrementing iterator to keep track of the index location
        //3. read each number from the first list and assign it to the correct slot in the new array
        //  3.1 Add the "amount" to the current index location
        //  3.1.a If the sum is less than the length of the list, assign it to the new index
        //  3.1.b Otherwise subtract the length from the sum to calculate the correct index
        //4. Return the new array

        int length = data.Count;
        int[] rotated = new int[length];

        for (int i = 0; i < length; ++i) {
            int index = i+amount;
            
            if (index < length) {
                rotated[index] = data[i];
            }
            else {
                index -= length;
                rotated[index] = data[i];
            }
        }
        return rotated;

    }
}
