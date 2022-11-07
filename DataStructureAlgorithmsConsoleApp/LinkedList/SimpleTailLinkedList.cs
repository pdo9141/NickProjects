using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataStructureAlgorithmsConsoleApp.LinkedList
{
    public class SimpleTailLinkedList<AnyType>
    {
        public Node<AnyType> head;
        public Node<AnyType> tail;

        public void AddLast(AnyType data)
        {
            // O(1)
            Node<AnyType> newItem = new Node<AnyType>();
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

        public void AddFirst(AnyType data)
        {
            Node<AnyType> newItem = new Node<AnyType>();
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
            Node<AnyType> current = head;

            while (current.next != null)
            {
                Console.WriteLine(current.data);
                current = current.next;
            }

            Console.WriteLine(current.data);
        }
    }
}