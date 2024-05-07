public class Node 
{
    public int value {get; set;}
    public Node next {get; set;}

    public Node(int value, Node next = null)
    {
        this.value = value;
        this.next = next;
    }
    

}
public class LinkedList 
{
    Node head;
    Node tail;

    public LinkedList (Node head = null)
    {
        this.head = head;
        this.tail = head;
    }

    public void Append(int num)
    {
        Node newNode = new Node(num);
        if (this.head == null)
        {
            this.head = newNode;
            this.tail = newNode;
            return;
        }

        this.tail.next = newNode;
        this.tail = this.tail.next;
    }

    public void Prepend(int num)
    {
        Node newNode = new Node(num, this.head);
        this.head = newNode;
    }

    public Node Pop()
    {
        if (this.head == null)
        {
            return null;
        }
        Node current = this.head;
        while (current.next != this.tail)
        {
            current = current.next;
        }

        this.tail = current;
        current = current.next;
        this.tail.next = null;
        return current;
    }

    public Node Unqueue()
    {
        if (this.head == null)
        {
            return null;
        }

        Node current = this.head;
        this.head = this.head.next;
        if (this.head == null)
        {
            this.tail = null;
        }

        current.next = null;
        return current;
    }

    public IEnumerable<int> ToList()
    {
        Node current = this.head;
        while (current != null)
        {
            yield return current.value;
            current = current.next;
        }
    }
}