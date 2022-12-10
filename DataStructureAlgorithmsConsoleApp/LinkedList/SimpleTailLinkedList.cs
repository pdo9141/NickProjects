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

            if (current == null) {
                Console.WriteLine("Your linked list is empty.");
                return;
            }

            while (current.next != null)
            {
                Console.WriteLine(current.data);
                current = current.next;
            }

            Console.WriteLine(current.data);
        }

        public void Reverse()
        {
            // [10 - 20 - 30 - 40]
            // [40 - 30 - 20 - 10]    
            if (head == null) {
                return;
            }

            var first = head;
            var second = head.next;            

            while (second != null) {
                var next = second.next;
                second.next = first;
                first = second;
                second = next;
            }
            
            head.next = null;
            tail = head;        
            head = first;            
        }

        public void GetKthFromTheEnd(int k)
        {
            // Find the Kth node from the end
            // of a linked list in one pass.
            // [10 - 20 - 30 - 40 - 50]
            // K = 1 (50)
            // K = 2 (40)
            // K = 3 (30)

            var index = 0;
            Node<AnyType> current = head;
            Node<AnyType> answer = current;

            while (current.next != null)
            {
                index++;

                if (index >= k) { 
                    answer = answer.next;
                }                    

                current = current.next;
            }

            if (answer != null) {
                Console.WriteLine(answer.data);
            }
        }

        public void GetKthFromTheEndAlt(int k)
        {
            var a = head;
            var b = head;

            for (var i = 0; i < k - 1; i++) {
                b = b.next;
            }

            while (b != tail) {
                a = a.next;
                b = b.next;
            }

            Console.WriteLine(a.data);
        }
    }
}