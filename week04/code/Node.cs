public class Node {
    internal int value;

    public int Data { get; set; }
    public Node? Next { get; set; }
    public Node? Prev { get; set; }

    public Node(int data) {
        this.Data = data;
    }
}