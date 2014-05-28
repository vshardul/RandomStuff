using System;
using System.Collections.Generic;
using System.Linq;

public class Test
{
    public static void Main()
    {
        var inputList = Console.ReadLine().Split(new[] { ' ' }).Select(value => int.Parse(value));
        Node head = null;
        Node current = null;

        var first = true;
        foreach (var value in inputList)
        {
            var node = new Node(value);

            if (first)
            {
                head = node;
                current = head;
                first = false;
            }
            else
            {
                current.next = node;
                current = current.next;
            }
        }

        current = head;
        while (current != null)
        {
            Console.Write(current.data + " ");
            current = current.next;
        }
        RemoveDuplicates(head);
        Console.WriteLine("\n now without duplicates");
        current = head;
        while (current != null)
        {
            Console.Write(current.data + " ");
            current = current.next;
        }


        Console.WriteLine("\n now without duplicates without buffer");
        current = head;
        while (current != null)
        {
            Console.Write(current.data + " ");
            current = current.next;
        }
    }

    private static void RemoveDuplicates(Node head)
    {
        var current = head;
        var valueDict = new Dictionary<int, bool>();
        while (current.next != null)
        {
            valueDict[current.data] = true;
            if (valueDict.ContainsKey(current.next.data))
            {
                current.next = current.next.next;
            }
            else
            {
                current = current.next;
            }
        }
    }

    private static void RemoveDuplicatesWithoutBuffer(Node head)
    {
        var current = head;
        while (current != null)
        {
            var iterNode = current;
            while (iterNode.next != null)
            {
                if (iterNode.next.data == current.data)
                {
                    iterNode.next = iterNode.next.next;
                }
                else
                {
                    iterNode = iterNode.next;
                }
            }

            current = current.next;
        }
    }

    private class Node
    {
        public int data;
        public Node next;

        public Node(int data)
        {
            this.data = data;
            this.next = null;
        }
    }
}