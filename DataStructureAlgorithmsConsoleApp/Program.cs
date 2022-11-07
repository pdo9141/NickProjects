using DataStructureAlgorithmsConsoleApp.LinkedList;

namespace DataStructureAlgorithmsConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            // Big O Notation, processing time/increased data relationship
            RunLinkedListTest();
        }

        private static void GetFirstStringFromList(List<string> data)
        {
            // O(1) = performance of algorithm will not change if data increases, constant performance
            var firstString = data[0];
        }

        private static void FindDoctorFromList(List<string> data)
        {
            // O(n) = linear performance, performance increase equivalent to data size increase
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

        private static void RunLinkedListTest()
        {
            SimpleLinkedList<string> simpleLinkedList = new SimpleLinkedList<string>();
            simpleLinkedList.AddLast("One");
            simpleLinkedList.AddLast("Two");
            simpleLinkedList.AddLast("3");
            simpleLinkedList.AddLast("4");
            simpleLinkedList.AddFirst("First");
            simpleLinkedList.ReadAll();

            Console.WriteLine("");

            SimpleTailLinkedList<string> simpleTailLinkedList = new SimpleTailLinkedList<string>();
            simpleTailLinkedList.AddLast("One");
            simpleTailLinkedList.AddLast("Two");
            simpleTailLinkedList.AddLast("3");
            simpleTailLinkedList.AddLast("4");
            simpleTailLinkedList.AddFirst("First");
            simpleTailLinkedList.ReadAll();
        }
    }
}