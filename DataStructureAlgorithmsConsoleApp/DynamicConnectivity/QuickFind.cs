using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataStructureAlgorithmsConsoleApp.DynamicConnectivity
{
    /// <summary>
    /// Eager algorithm, works but way too inefficient.
    /// </summary>
    public class QuickFind
    {
        private int[] _ids;

        public QuickFind(int numOfElements)
        {
            _ids = new int[numOfElements];

            for (var i = 0; i < numOfElements; i++)
            {
                _ids[i] = i;
            }
        }
        
        public bool IsConnected(int firstEntry, int secondEntry)
        {
            return _ids[firstEntry] == _ids[secondEntry];
        }        

        public void Union(int firstEntry, int secondEntry)
        {
            if (IsConnected(firstEntry, secondEntry))
            {
                return;
            }

            var valueOfFirstEntry = _ids[firstEntry];
            var valueOfSecondEntry = _ids[secondEntry];

            for (var i = 0; i < _ids.Length; i++)
            {
                if (_ids[i] == valueOfFirstEntry)
                {
                    _ids[i] = valueOfSecondEntry;
                }
            }
        }
    }
}