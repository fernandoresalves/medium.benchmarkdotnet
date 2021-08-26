using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Medium.Benchmark
{
    [SimpleJob(RuntimeMoniker.Net50)]
    [SimpleJob(RuntimeMoniker.NetCoreApp31)]
    [MarkdownExporter]
    public class LinqBenchmark
    {
        private const int slice = 250;
        private readonly IList<int> _numbers = new List<int>();

        [GlobalSetup]
        public void Setup()
        {
            for (int i = 0; i < 500; i++)
                _numbers.Add(i);
        }

        [Benchmark]
        public int WhereAndFirst() =>
            _numbers.Where(number => number > slice).First();

        [Benchmark]
        public int OnlyFirst() =>
            _numbers.First(number => number > slice);

        [Benchmark(Baseline = true)]
        public int No()
        {
            for (int i = 0; i < _numbers.Count; i++)
            {
                if (_numbers[i] > slice)
                {
                    return _numbers[i];
                }
            }

            throw new InvalidOperationException();
        }
    }
}
