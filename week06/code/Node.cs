public class Node {
    public int Data { get; set; }
    public Node? Right { get; private set; }
    public Node? Left { get; private set; }

    public Node(int data) {
        this.Data = data;
    }

    public void Insert(int value) {
        if (value < Data) {
            // Insert to the left
            if (Left is null)
                Left = new Node(value);
            else
                Left.Insert(value);
        }
        else if (value > Data) {
            // Insert to the right
            if (Right is null)
                Right = new Node(value);
            else
                Right.Insert(value);
        }
        else {
            return;
        }
    }

    public bool Contains(int value) {
        // TODO Start Problem 2
        if (value == Data) {
            return true;
        }
        else if (value < Data) {
            return Left != null && Left.Contains(value);
        }
        //changed from else to else if to see if the value should be on the right
        else if (value > Data) {
            return Right != null && Right.Contains(value);
        }
        //if the value isn't <> data it must be ==... return false
        else {
            return false;
        }
    }

    public int GetHeight() {
        // TODO Start Problem 4
        //If left is null value is 0, otherwise recurse to get the height
        int leftHeight = Left?.GetHeight() ?? 0;
        //Same again for the right
        int rightHeight = Right?.GetHeight() ?? 0;
        //Return the larger value +1
        return 1 + Math.Max(leftHeight, rightHeight);
    }
}