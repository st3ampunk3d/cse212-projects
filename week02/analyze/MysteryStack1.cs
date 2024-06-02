public static class MysteryStack1 {
    public static string Run(string text) {
        var stack = new Stack<char>();
        foreach (var letter in text)
            stack.Push(letter);

        var result = "";
        while (stack.Count > 0)
            result += stack.Pop();

        return result;
    }
}

//Takes a string and iterates through it
//each letter in the string is pushed to the stack
//While there are still items in the stack remove them one by one by pushing them to result
//"result" should be the original string but backwards

//racecar -> racecar
//stressed -> desserts
//a nut for a jar of tuna -> anut fo raj a rof tun a

//This is an ok way to reverse the order of a list