using System.ComponentModel.DataAnnotations;

public static class ArraySelector
{
    public static void Run()
    {
        var l1 = new[] { 1, 2, 3, 4, 5 };
        var l2 = new[] { 2, 4, 6, 8, 10};
        var select = new[] { 1, 1, 1, 2, 2, 1, 2, 2, 2, 1};
        var intResult = ListSelector(l1, l2, select);
        Console.WriteLine("<int[]>{" + string.Join(", ", intResult) + "}"); // <int[]>{1, 2, 3, 2, 4, 4, 6, 8, 10, 5}
    }

    private static int[] ListSelector(int[] list1, int[] list2, int[] select)
    {
        //create an empty array the same size as the select array
        var result = new int [select.Length];

        //create iterators to keep track of the working index of l1 and l2
        var l1i = 0;
        var l2i = 0;

        //loop through the select array and create an iterator to keep track of the index
        for (var i = 0; i < select.Length; i++ ) {

            //If the current index of select contains a 1 store the value of the first array
            if (select[i] == 1) 
                result[i] = list1[l1i++]; //increment the index of list 1
            //If the current index of select contains a 2, store the value of the second array
            else 
                result[i] = list2[l2i++]; //increment the index of list2
        }
        return result; //return the new, combined array
    }
}