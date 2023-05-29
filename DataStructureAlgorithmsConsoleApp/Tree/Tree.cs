using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataStructureAlgorithmsConsoleApp.Tree
{
    public class Tree
    {
        private Node? root;

        public void Insert(int value)
        {
            var node = new Node(value);

            if (root == null)
            {
                root = node;
                return;
            }

            var current = root;
            
            while (true)
            {
                if (value < current.value)
                {
                    if (current.leftChild == null)
                    {
                        current.leftChild = node;
                        break;
                    }
                    current = current.leftChild;
                }
                else
                {
                    if (current.rightChild == null)
                    {
                        current.rightChild = node;
                        break;
                    }
                    current = current.rightChild;
                }
            }
        }

        public bool Find(int value)
        {
            var current = root;
            
            while (current != null)
            {
                if (value < current.value)
                {
                    current = current.leftChild;
                }
                else if (value > current.value)
                {
                    current = current.rightChild;
                }
                else
                {
                    return true;
                }
            }

            return false;
        }

        public void TraversePreOrder()
        {
            if (root != null)
            {
                TraversePreOrder(root);
            }
        }

        private void TraversePreOrder(Node root)
        {
            // Base condition (way to terminate recursion)
            if (root == null)
            {
                return;
            }

            Console.WriteLine(root.value);

            if (root.leftChild != null)
            {
                TraversePreOrder(root.leftChild);
            }

            if (root.rightChild != null)
            {
                TraversePreOrder(root.rightChild);
            }
        }

        public void TraversePostOrder()
        {
            if (root != null)
            {
                TraversePostOrder(root);
            }
        }

        private void TraversePostOrder(Node root)
        {
            // Base condition (way to terminate recursion)
            if (root == null)
            {
                return;
            }

            if (root.leftChild != null)
            {
                TraversePostOrder(root.leftChild);
            }

            if (root.rightChild != null)
            {
                TraversePostOrder(root.rightChild);
            }

            Console.WriteLine(root.value);
        }

        public int Height()
        {
            return Height(root);
        }

        private int Height(Node root)
        {
            // Base condition
            if (root == null)
                return -1;
            
            if (root.leftChild == null && root.rightChild == null)
                return 0;

            return 1 + Math.Max(Height(root.leftChild), Height(root.rightChild));
        }

        public int Min()
        {
            // Binary Tree
            // O(n)
            return Min(root);
        }

        public int MinForBinarySearchTree()
        {
            // Binary Search Tree
            // O{}
            if (root == null)
                throw new InvalidDataException();

            var current = root;
            var last = current;

            while (current != null)
            {
                last = current;
                current = current.leftChild;
            }                

            return last.value;
        }

        private int Min(Node root)
        {
            // Base condition
            if (root.leftChild == null && root.rightChild == null)
                return root.value;

            var left = Min(root.leftChild);
            var right = Min(root.rightChild);

            return Math.Min(Math.Min(left, right), root.value);
        }

        public bool Equals(Tree other)
        {
            return Equals(root, other.root);
        }

        private bool Equals(Node first, Node second)
        {
            if (first == null && second == null)
                return true;

            if (first != null && second != null)
            {
                return first.value == second.value
                    && Equals(first.leftChild, second.leftChild)
                    && Equals(first.rightChild, second.rightChild);
            }  

            return false;              
        }

        public bool IsBinarySearchTree() {
            return IsBinarySearchTree(root, int.MinValue, int.MaxValue);
        }

        private bool IsBinarySearchTree(Node root, int min, int max) {
            if (root == null) {
                return true;
            }

            if (root.value < min || root.value > max) {
                return false;
            }

            return IsBinarySearchTree(root.leftChild, min, root.value -1) && IsBinarySearchTree(root.rightChild, root.value + 1, max);
        }

        public void SwapRoot() {
            var temp = root.leftChild;
            root.leftChild = root.rightChild;
            root.rightChild = temp;
        }
    
        public void PrintNodesAtDistance(int distance) {
            PrintNodesAtDistance(root, distance);
        }

        private void PrintNodesAtDistance(Node root, int distance) {
            if (root == null) {
                return;
            }

            if (distance == 0) {
                Console.WriteLine(root.value);
                return;
            }

            PrintNodesAtDistance(root.leftChild, distance - 1);
            PrintNodesAtDistance(root.rightChild, distance - 1);
        }
    
        public void TraverseLevelOrder() {
            for (var i=0; i<= Height(); i++) {
                PrintNodesAtDistance(i);
            }
        }
    }

    public class Node
    {
        internal int value;
        internal Node? leftChild;
        internal Node? rightChild;

        public Node(int value)
        {
            this.value = value;
        }
    }
}