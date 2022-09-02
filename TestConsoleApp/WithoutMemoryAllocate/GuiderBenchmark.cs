namespace TestConsoleApp.WithoutMemoryAllocate
{
    using BenchmarkDotNet.Attributes;    

    [MemoryDiagnoser(false)]
    public class GuiderBenchmarks
    {
        private static readonly Guid TestIdAsGuid = Guid.Parse("572ce9d9-757b-450b-8b65-a3461b8036d3");
        private const string TestIdAsString = "2eksV3t1C0WLZaNGG4A20w";

        [Benchmark]
        public Guid ToGuidFromString()
        {
            return Guider.ToGuidFromString(TestIdAsString);
        }

        [Benchmark]
        public Guid ToGuidFromStringOp()
        {
            return Guider.ToGuidFromStringOp(TestIdAsString);
        }

        [Benchmark]
        public string ToStringFromGuid()
        {
            return Guider.ToStringFromGuid(TestIdAsGuid);
        }

        [Benchmark]
        public string ToStringFromGuidOp()
        {
            return Guider.ToStringFromGuidOp(TestIdAsGuid);
        }
    }
}