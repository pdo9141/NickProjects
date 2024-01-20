using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataStructureAlgorithmsConsoleApp.DynamicConnectivity
{
    /// <summary>
    /// Use array data structure as tree, possible tall tress, still inefficient.
    /// </summary>
    public class QuickUnion
    {
        private int[] _ids;

        public QuickUnion(int numOfElements)
        {
            _ids = new int[numOfElements];

            for (var i = 0; i < numOfElements; i++)
            {
                _ids[i] = i;
            }
        }

        public int GetRoot(int lookupIndex)
        {
            // Chase parent pointers until you find the root
            while (_ids[lookupIndex] != lookupIndex)
            {
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
            // Change root of firstEntry to point to root of secondEntry
            var rootOfFirstEntry = GetRoot(firstEntry);
            var rootOfSecondEntry = GetRoot(secondEntry);

            _ids[rootOfFirstEntry] = rootOfSecondEntry;
        }
    }
}