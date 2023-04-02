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