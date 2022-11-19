using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataStructureAlgorithmsConsoleApp.LinkedList
{
    public class SimpleLinkedList<AnyType>
    {
        public Node<AnyType> head;

        public void AddLast(AnyType data)
        {
            // O(n)
            Node<AnyType> newItem = new Node<AnyType>();
            newItem.data = data;

            if (head == null)
            {
                head = newItem;
            }
            else
            {
                // loop and find the last node
                Node<AnyType> current = head;

                while (current.next != null)
                {
                    current = current.next;
                }

                current.next = newItem;
            }
        }

        public void AddFirst(AnyType data)
        {
            Node<AnyType> newItem = new Node<AnyType>();
            newItem.data = data;
            newItem.next = head;
            head = newItem;
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