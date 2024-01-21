using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataStructureAlgorithmsConsoleApp.DynamicConnectivity
{
    /// <summary>
    /// Use array data structure as tree, better but can still be improved.
    /// When processing union, check size, choose longer tree to be parent.
    /// </summary>
    public class QuickUnionWeightedWithPathCompression
    {
        private int[] _ids;
        private int[] _size;

        public QuickUnionWeightedWithPathCompression(int numOfElements)
        {
            _ids = new int[numOfElements];
            _size = new int[numOfElements];

            for (var i = 0; i < numOfElements; i++)
            {
                _ids[i] = i;
                _size[i] = 1;
            }
        }

        public int GetRoot(int lookupIndex)
        {
            // Chase parent pointers until you find the root
            while (_ids[lookupIndex] != lookupIndex)
            {
                // Path compression improvement, make every other node in path 
                // point to its grandparent (thereby halving path length)
                _ids[lookupIndex] = _ids[_ids[lookupIndex]];
                lookupIndex = _ids[lookupIndex];    
            }

            return lookupIndex;
        }
        
        public bool IsConnected(int firstEntry, int secondEntry)
        {
            return GetRoot(firstEntry) == GetRoot(secondEntry);
        }        

        public void Union(int firstEntry, int secondEntry)
        {
            var rootOfFirstEntry = GetRoot(firstEntry);
            var rootOfSecondEntry = GetRoot(secondEntry);

            if (rootOfFirstEntry == rootOfSecondEntry)
            {
                return;
            }

            var sizeOfFirstEntryRoot =  _size[rootOfFirstEntry];
            var sizeOfSecondEntryRoot =  _size[rootOfSecondEntry];

            // Merge shorter tree into taller tree to achieve proper balance
            if (sizeOfFirstEntryRoot < sizeOfSecondEntryRoot)
            {
                _ids[rootOfFirstEntry] = rootOfSecondEntry;
                _size[rootOfSecondEntry] += _size[rootOfFirstEntry];
            }
            else
            {
                _ids[rootOfSecondEntry] = rootOfFirstEntry;
                _size[rootOfFirstEntry] += _size[rootOfSecondEntry];
            }
        }
    }
}