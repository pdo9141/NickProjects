using DataStructureAlgorithmsConsoleApp.LinkedList;

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
            
            RunLinkedListTest();
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
    }
}