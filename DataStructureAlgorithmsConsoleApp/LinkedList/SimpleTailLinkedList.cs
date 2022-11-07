using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataStructureAlgorithmsConsoleApp.LinkedList
{
    public class SimpleTailLinkedList
    {
        public Node head = null;
        public Node tail = null;

        public void AddLast(object data)
        {
            // O(1)
            Node newItem = new Node();
            newItem.data = data;

            if (head == null)
            {
                head = newItem;
                tail = newItem;
            }
            else
            {
                tail.next = newItem;
                tail = newItem;
            }
        }

        public void AddFirst(object data)
        {
            Node newItem = new Node();
            newItem.data = data;

            if (head == null)
            {
                head = newItem;
                tail = newItem;
            }
            else
            {
                newItem.next = head;
                head = newItem;
            }
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