using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
using EnergiTrack;

namespace TestProject1.Benchmarks
{
    [MemoryDiagnoser]
    public class EnergyConsumptionBenchmark
    {
        private EnergyConsumptionManager _manager;

        private const string DeviceKulkas = "Kulkas";
        private const string DeviceLampu = "Lampu";
        private const string DeviceTV = "TV";

        [GlobalSetup]
        public void Setup()
        {
            _manager = new EnergyConsumptionManager();
            // Bersihkan data supaya benchmark dimulai dari kondisi bersih
            _manager.ClearAllData();
        }

        [Benchmark]
        public void AddConsumptionBenchmark()
        {
            _manager.AddConsumption(DeviceKulkas, 100);
        }

        [Benchmark]
        public void EditConsumptionBenchmark()
        {
            _manager.AddConsumption(DeviceLampu, 50);
            _manager.EditConsumption(DeviceLampu, 75);
        }

        [Benchmark]
        public void RemoveConsumptionBenchmark()
        {
            _manager.AddConsumption(DeviceTV, 120);
            _manager.RemoveConsumption(DeviceTV);
        }

        [Benchmark]
        public void CalculateTotalCostBenchmark()
        {
            _manager.CalculateTotalCost();
        }
    }

    public class Program
    {
        public static void Main(string[] args)
        {
            var summary = BenchmarkRunner.Run<EnergyConsumptionBenchmark>();
        }
    }
}
