namespace TestConsoleApp
{
    using BenchmarkDotNet.Running;
    using TestConsoleApp.WithoutMemoryAllocate;

    class Program
    {
        static void Main(string[] args)
        {
            //WithoutMemoryAllocate();
            BenchmarkRunner.Run<GuiderBenchmarks>();     
        }

        private static void WithoutMemoryAllocate()
        {
            var id = Guid.NewGuid();
            Console.WriteLine(id);

            var base64Id = Convert.ToBase64String(id.ToByteArray());
            Console.WriteLine(base64Id);

            var urlFriendlyBase64Id = Guider.ToStringFromGuid(id);
            Console.WriteLine(urlFriendlyBase64Id);

            var idAgain = Guider.ToGuidFromString(urlFriendlyBase64Id);
            Console.WriteLine(idAgain);
        }
    }
}