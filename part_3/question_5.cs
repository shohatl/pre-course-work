namespace Question5{
    public class Node 
    {
        public int Value {get; set;}
        public Node next {get; set;}

        public Node(int value, Node next = null)
        {
            this.Value = value;
            this.next = next;
        }
        

    }
}