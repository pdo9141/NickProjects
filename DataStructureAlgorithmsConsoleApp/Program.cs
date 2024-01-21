using DataStructureAlgorithmsConsoleApp.LinkedList;
using DataStructureAlgorithmsConsoleApp.Tree;
using DataStructureAlgorithmsConsoleApp.DynamicConnectivity;
using System.Collections.Generic;

namespace DataStructureAlgorithmsConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            // Big O Notation (runtime complexity), processing time/increased data relationship
            // We use Big O to describe the performance of an algorithm
            // Helps us determine if a particular algorithm is scalable
            // We need to consider space complexity as well, if we have a lot of space so we can optimize our algorithm by utilizing memory
            
            // Linked List
            // RunLinkedListTest();

            // Stacks (all operations in a stack run in O(1) or constant time)
            // RunIsStringBalanced("(1 + 2)");
            // RunIsStringBalanced("((1 + 2{))");
            // RunIsStringBalanced("<(1 + 2) + (9 % 3)>");
            // RunIsStringBalanced("<([1] + 2) + (<9> % 3)>");

            // Queues (all operations in a stack run in O(1) or constant time)
            // When implementing queue using array, use circular array
            // To keep track of circular array use this formula to enqueue unused array index: (index + 1) % items.length
            // You can implement queue by using two stack (enqueue and dequeue stacks), whenever dequeue stack is empty pop all enqueue items into dequeue stack
            // ReverseQueue();

            // HashMaps (most  operations in a stack run in O(1) or constant time)
            // ContainsKey runs O(1) while ContainsValue runs O(n)
            // FindFirstNonRepeatedCharacter("A Green Apple");

            // Binary Tree has at most 2 children of a node, use trees when you want to represent hierarachical data
            // Databases, autocompletion, compilers, compression (JPEG, MP3) algorithms
            // Binary Search Tree is when node value is less than anything to its right and greater than anything to its left
            // Binary Search Tree helps optimize searches by narrowing search to left or right side with each iteration (logarithmic time)
            // Lookup, delete, and insert runs O(log n)
            // RunBinarySearchTreeTest();

            // FactorialLoop(4);
            // Console.WriteLine(FactorialRecursion(4));

            // AVL (Adelson-Velsky and Landis) Trees are self-balancing trees
            // To self-balance AVL Trees use rotations, right heavy tree will need left rotation
            // Left heavy tree will need right rotation, some trees will require both

            // You can implement Heaps using Arrays since Heaps are complete
            // Heaps are nearly complete binary tree
            // Uses of heaps include heapsort, priority queues, types include max heaps and min heaps
            // left(i) = 2*i, right(i) = 2*i + 1, parent(i) = floor (i/2)

            QuickFindTest();
            QuickUnionTest();
            QuickUnionWeightedTest();
            QuickUnionWeightedWithPathCompressionTest();
        }

        private static void GetFirstStringFromList(List<string> data)
        {
            // O(1) = constant performance, performance of algorithm will not change if data increases
            var firstString = data[0];
        }

        private static void BinarySearch()
        {
            // O(log n) = logarithmic performance, this is what we want if O(1) is not possible
            // Let's say we're searching for a matching number in a sorted array
            // We choose a pivot point, say middle of the array, we inspect that number, is it lesser or greater than the number we are searching for?
            // If less, we take the greater half and we repeat same partition process until we find our number
            // With logarithmic algorithm, if we have 1 million items that will only equal 19 comparisons to find our matching number
            // We have a logarithmic algorithm when we reduce our work by half in every iteration
        }

        private static void FindDoctorFromList(List<string> data)
        {
            // O(n) = linear performance, performance increase equivalent to data size increase
            // direct correlation of size of input
            foreach (var value in data)
            {
                if (value.Equals("PHD"))
                {
                    return;
                }
            }
        }

        private static void CountTheZs(List<string> data)
        {
            var zCounts = 0; 

            // O(2n) or O(n^2) = quadratic performance
            foreach (var value in data)
            {
                foreach (var val in value)
                {
                    if (val == 'z')
                    {
                        zCounts++;                            
                    }
                }
            }
        }

        private static void ExponentialSearch()
        {
            // O(2 power of n) or O(2^n) = exponential performance, this is opposite of logarithmic performance
        }

        private static void RunLinkedListTest()
        {
            /*
            SimpleLinkedList<string> simpleLinkedList = new SimpleLinkedList<string>();
            simpleLinkedList.AddLast("One");
            simpleLinkedList.AddLast("Two");
            simpleLinkedList.AddLast("3");
            simpleLinkedList.AddLast("4");
            simpleLinkedList.AddFirst("First");
            simpleLinkedList.ReadAll();

            Console.WriteLine("");
            */

            SimpleTailLinkedList<string> simpleTailLinkedList = new SimpleTailLinkedList<string>();
            simpleTailLinkedList.AddLast("10");
            simpleTailLinkedList.AddLast("20");
            simpleTailLinkedList.AddLast("30");
            simpleTailLinkedList.AddLast("40");
            simpleTailLinkedList.AddLast("50");
            //simpleTailLinkedList.Reverse();
            simpleTailLinkedList.GetKthFromTheEnd(1);
            simpleTailLinkedList.GetKthFromTheEnd(2);
            simpleTailLinkedList.GetKthFromTheEnd(3);
            simpleTailLinkedList.GetKthFromTheEnd(4);
            simpleTailLinkedList.GetKthFromTheEnd(5);
            //simpleTailLinkedList.ReadAll();
        }

        private static void RunIsStringBalanced(string input)
        {
            // Stacks are Last-In First-Out (LIFO) data structure
            // Go for when you want to undo or do things in reverse order
            // They can be implemented internally using arrays or linked lists
            // All operations in a stack run in O(1) or constant time

            var result = true;
            var balanceCharHolder = new Stack<char>();
            var balanceCharLookup = new Dictionary<char, char>
            {
                { '>', '<'}, { ')', '('}, { ']', '['}, { '}', '{'}
            };

            foreach (var value in input)
            {
                if (balanceCharLookup.ContainsValue(value))
                {
                    balanceCharHolder.Push(value);
                }

                if (balanceCharLookup.ContainsKey(value))
                {
                    if (balanceCharHolder.Count == 0)
                    {
                        result = false;
                        break;
                    }

                    var lastEntry = balanceCharHolder.Pop();
                    
                    if (balanceCharLookup[value] != lastEntry)
                    {
                        result = false;
                        break;
                    }
                }
            }

            if (balanceCharHolder.Count > 0)
            {
                result = false;
            }

            Console.WriteLine($"String is {(result ? "balanced" : "unbalanced")}: {input}");
        }

        private static void ReverseQueue()
        {
            // You're only allowed to use add, remove, and isEmpty methods
            var stack = new Stack<int>();
            var queue = new Queue<int>();
            queue.Enqueue(10);
            queue.Enqueue(20);
            queue.Enqueue(30);

            foreach(var item in queue)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine(string.Empty);

            for (int i=0; i<queue.Count; i++)
            {
                var item = queue.Dequeue();
                stack.Push(item);
            }

            while (stack.Count > 0)
            {
                queue.Enqueue(stack.Pop());
            }

            foreach(var item in queue)
            {
                Console.WriteLine(item);
            }
        }
    
        private static void FindFirstNonRepeatedCharacter(string input)
        {
            var result = new Dictionary<char, int>();
            
            foreach (char character in input)
            {
                if (!result.ContainsKey(character))
                {
                    result.Add(character, 1);
                }
                else
                {
                    result[character] = result[character] + 1;
                }
            }

            // You can't loop through the result dictionary since it's not ordered by inserted sequence
            foreach (char character in input)
            {
                if (result[character] == 1)
                {
                    Console.WriteLine($"{character} is the first non repeated character");
                    return;
                }
            }

            Console.WriteLine("Found no characters that are not repeating");
        }

        private static void RunBinarySearchTreeTest()
        {
            var tree = new DataStructureAlgorithmsConsoleApp.Tree.Tree();
            tree.Insert(7);
            tree.Insert(4);
            tree.Insert(9);
            tree.Insert(1);
            tree.Insert(6);
            tree.Insert(8);
            tree.Insert(10);

            // var tree2 = new DataStructureAlgorithmsConsoleApp.Tree.Tree();
            // tree2.Insert(7);
            // tree2.Insert(4);
            // tree2.Insert(9);
            // tree2.Insert(1);
            // tree2.Insert(6);
            // tree2.Insert(8);
            // tree2.Insert(10);

            // Console.WriteLine(tree.Find(11));
            // tree.TraversePreOrder();
            // tree.TraversePostOrder();
            // Console.WriteLine(tree.Height());
            // Console.WriteLine(tree.Min());
            // Console.WriteLine(tree.MinForBinarySearchTree());
            // Console.WriteLine(tree.Equals(tree2));
            // tree.SwapRoot();
            // Console.WriteLine(tree.IsBinarySearchTree());
            // tree.PrintNodesAtDistance(2);
            tree.TraverseLevelOrder();
        }

        private static void FactorialLoop(int n)
        {
            var factorial = 1;
            for (var i = n; i > 1; i--)
            {
                factorial *= i;
            }

            Console.WriteLine(factorial);
        }

        private static int FactorialRecursion(int n)
        {
            // Base condition (way to terminate recursion)
            if (n == 0)
            {
                return 1;
            }

            return n * FactorialRecursion(n - 1);
        }

        private static void QuickFindTest()
        {
            var quickFind = new QuickFind(10);
            quickFind.Union(4, 3);
            quickFind.Union(3, 8);
            quickFind.Union(6, 5);
            quickFind.Union(9, 4);
            quickFind.Union(2, 1);
            Console.WriteLine($"IsConnected(8, 9) = {quickFind.IsConnected(8, 9)}");
            Console.WriteLine($"IsConnected(5, 0) = {quickFind.IsConnected(5, 0)}");
            quickFind.Union(5, 0);
            quickFind.Union(7, 2);
            quickFind.Union(6, 1);
        }

        private static void QuickUnionTest()
        {
            var quickUnion = new QuickUnion(10);
            quickUnion.Union(4, 3);
            quickUnion.Union(3, 8);
            quickUnion.Union(6, 5);
            quickUnion.Union(9, 4);
            quickUnion.Union(2, 1);
            Console.WriteLine($"IsConnected(8, 9) = {quickUnion.IsConnected(8, 9)}");
            Console.WriteLine($"IsConnected(5, 0) = {quickUnion.IsConnected(5, 0)}");
            quickUnion.Union(5, 0);
            quickUnion.Union(7, 2);
            quickUnion.Union(6, 1);
        }

        private static void QuickUnionWeightedTest()
        {
            var quickUnionWeighted = new QuickUnionWeighted(10);
            quickUnionWeighted.Union(4, 3);
            quickUnionWeighted.Union(3, 8);
            quickUnionWeighted.Union(6, 5);
            quickUnionWeighted.Union(9, 4);
            quickUnionWeighted.Union(2, 1);
            Console.WriteLine($"IsConnected(8, 9) = {quickUnionWeighted.IsConnected(8, 9)}");
            Console.WriteLine($"IsConnected(5, 0) = {quickUnionWeighted.IsConnected(5, 0)}");
            quickUnionWeighted.Union(5, 0);
            quickUnionWeighted.Union(7, 2);
            quickUnionWeighted.Union(6, 1);
        }

        private static void QuickUnionWeightedWithPathCompressionTest()
        {
            var quickUnionWeightedWithPathCompression = new QuickUnionWeightedWithPathCompression(10);
            quickUnionWeightedWithPathCompression.Union(4, 3);
            quickUnionWeightedWithPathCompression.Union(3, 8);
            quickUnionWeightedWithPathCompression.Union(6, 5);
            quickUnionWeightedWithPathCompression.Union(9, 4);
            quickUnionWeightedWithPathCompression.Union(2, 1);
            Console.WriteLine($"IsConnected(8, 9) = {quickUnionWeightedWithPathCompression.IsConnected(8, 9)}");
            Console.WriteLine($"IsConnected(5, 0) = {quickUnionWeightedWithPathCompression.IsConnected(5, 0)}");
            quickUnionWeightedWithPathCompression.Union(5, 0);
            quickUnionWeightedWithPathCompression.Union(7, 2);
            quickUnionWeightedWithPathCompression.Union(6, 1);   
        }
    }
}