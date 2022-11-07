using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataStructureAlgorithmsConsoleApp.LinkedList
{
    public class SimpleLinkedList
    {
        public Node head = null;

        public void AddLast(object data)
        {
            // O(n)
            Node newItem = new Node();
            newItem.data = data;

            if (head == null)
            {
                head = newItem;
                head.next = null;
            }
            else
            {
                // loop and find the last node
                Node current = head;

                while (current.next != null)
                {
                    current = current.next;
                }

                current.next = newItem;
                newItem.next = null;
            }
        }

        public void AddFirst(object data)
        {
            Node newItem = new Node();
            newItem.data = data;
            newItem.next = head;
            head = newItem;
        }

        public void ReadAll()
        {
            // O(n)
            Node current = head;

            while (current.next != null)
            {
                Console.WriteLine(current.data);
                current = current.next;
            }

            Console.WriteLine(current.data);
        }
    }
}