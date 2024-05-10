﻿using System;

namespace Question6{
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
            while (current != this.tail)
            {
                yield return current.Value;
                current = current.next;
            }

            yield return current.Value;
        }

        public Boolean IsCircular()
        {
            return this.tail.next == this.head;
        }

        public void Sort()
        {
            List<int> sorted = this.ToList().ToList();
            sorted.Sort();
            Node current = this.head;
            for (int i = 0; i < sorted.Count; i++)
            {
                current.Value = sorted[i];
                current = current.next;
            }
        }

        public Node GetMaxNode()
        {
            Node current = this.head.next;
            Node max = this.head;
            while(current != null)
            {
                if (current.Value > max.Value)
                {
                    max = current;
                }
                current = current.next;
            }
            return max;
        }

        public Node GetMinNode()
        {
            Node current = this.head.next;
            Node min = this.head;
            while(current != null)
            {
                if (current.Value < min.Value)
                {
                    min = current;
                }
                current = current.next;
            }
            return min;
        }
    }

    public class Program
    {
        public static void Main()
        {
            LinkedList linkedList = new LinkedList();
            
            linkedList.Append(3);
            linkedList.Append(1);
            linkedList.Append(5);
            linkedList.Append(2);

            Console.WriteLine("Linked List:");
            foreach (int value in linkedList.ToList())
            {
                Console.WriteLine(value);
            }

            linkedList.Sort();
            Console.WriteLine("\nLinked List after sorting:");
            foreach (int value in linkedList.ToList())
            {
                Console.WriteLine(value);
            }

            Node maxNode = linkedList.GetMaxNode();
            Console.WriteLine("\nMaximum Node:");
            Console.WriteLine(maxNode.Value);

            Node minNode = linkedList.GetMinNode();
            Console.WriteLine("\nMinimum Node:");
            Console.WriteLine(minNode.Value);

            Node poppedNode = linkedList.Pop();
            Console.WriteLine("\nPopped Node:");
            Console.WriteLine(poppedNode.Value);

            Node unqueuedNode = linkedList.Unqueue();
            Console.WriteLine("\nUnqueued Node:");
            Console.WriteLine(unqueuedNode.Value);

            Console.WriteLine("\nLinked List after removing:");
            foreach (int value in linkedList.ToList())
            {
                Console.WriteLine(value);
            }

            Console.WriteLine("\nIs the list circular? " + linkedList.IsCircular());
        }
    }
}