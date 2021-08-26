using BenchmarkDotNet.Running;

namespace Medium.Benchmark
{
    internal static class Program
    {
        private static void Main()
        {
            BenchmarkRunner.Run<LinqBenchmark>();
        }
    }
}
