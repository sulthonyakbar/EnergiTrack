using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
using EnergiTrack;

namespace TestProject1.Benchmarks
{
    [MemoryDiagnoser]
    public class EnergyConsumptionBenchmark
    {
        private EnergyConsumptionManager manager;

        [GlobalSetup]
        public void Setup()
        {
            manager = new EnergyConsumptionManager();
        }

        [Benchmark]
        public void TestAddConsumption()
        {
            manager.AddConsumption("Kulkas", 100);
        }

        [Benchmark]
        public void TestEditConsumption()
        {
            manager.AddConsumption("Lampu", 50);
            manager.EditConsumption("Lampu", 75);
        }

        [Benchmark]
        public void TestRemoveConsumption()
        {
            manager.AddConsumption("TV", 120);
            manager.RemoveConsumption("TV");
        }

        [Benchmark]
        public void TestCalculateTotalCost()
        {
            manager.CalculateTotalCost();
        }
    }
}
