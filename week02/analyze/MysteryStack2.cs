public static class MysteryStack2 {
    private static bool IsFloat(string text) {
        return float.TryParse(text, out _);
    }

    public static float Run(string text) {
        var stack = new Stack<float>();
        foreach (var item in text.Split(' ')) {
            if (item == "+" || item == "-" || item == "*" || item == "/") {
                if (stack.Count < 2)
                    throw new ApplicationException("Invalid Case 1!");

                var op2 = stack.Pop();
                var op1 = stack.Pop();
                float res;
                if (item == "+") {
                    res = op1 + op2;
                }
                else if (item == "-") {
                    res = op1 - op2;
                }
                else if (item == "*") {
                    res = op1 * op2;
                }
                else {
                    if (op2 == 0)
                        throw new ApplicationException("Invalid Case 2!");

                    res = op1 / op2;
                }

                stack.Push(res);
            }
            else if (IsFloat(item)) {
                stack.Push(float.Parse(item));
            }
            else if (item == "") {
            }
            else {
                throw new ApplicationException("Invalid Case 3!");
            }
        }

        if (stack.Count != 1)
            throw new ApplicationException("Invalid Case 4!");

        return stack.Pop();
    }
}

//Split the string at spaces.
//If the split is a number add it to the stack
//If the split is an operator and there are at least 2 number in the stack do math
//remove the numbers from the stack as math is performed
//push the result of the math back to the stack
//repeat the process until there is only 1 item left in the stack
//return that item and then remove it from the stack

//This is useful for performing several calculations and freeing up memory as we go


//5 3 7 + *
// 5
//5 3
// 5 3 7
// 3 + 7
// 5 10
// 5 * 10
// Return 50

//6 2 + 5 3 - /
//6
//6 2
//6 + 2
//8
//8 5
//8 5 3
//5 - 3
//8 2
//8 / 2
//4
// Return 4

//Invalid case 1 - a string with only one number
//Invalid case 2 - dividing by zero
//Invalid case 3 - There are more operators than there are numbers
//invalid case 4 - More numbers to get through than we have operators to handle