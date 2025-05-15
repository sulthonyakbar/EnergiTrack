using BenchmarkDotNet.Running;
using TestProject1.Benchmarks;

class Program
{
    static void Main(string[] args)
    {
        BenchmarkRunner.Run<EnergyConsumptionBenchmark>();
    }
}
