using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataStructureAlgorithmsConsoleApp.LinkedList
{
    public class Node<AnyType>
    {
        public AnyType data;
        
        public Node<AnyType> next;
    }
}