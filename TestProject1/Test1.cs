using EnergiTrack;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;

namespace TestProject1
{
    [TestClass]
    public class TestEnergyConsumptionManager
    {
        private EnergyConsumptionManager manager;

        [TestInitialize]
        public void SetUp()
        {
            // Hapus file lama sebelum setiap test dijalankan
            string baseDir = AppDomain.CurrentDomain.BaseDirectory;
            string configPath = Path.Combine(baseDir, "..", "..", "..", "runtime_config.json");
            string dataPath = Path.Combine(baseDir, "..", "..", "..", "energy_consumptions.json");

            if (File.Exists(configPath)) File.Delete(configPath);
            if (File.Exists(dataPath)) File.Delete(dataPath);

            manager = new EnergyConsumptionManager();
        }

        [TestMethod]
        public void TestAddConsumption()
        {
            manager.AddConsumption("Kipas", 50);
            var consumptions = manager.GetAllConsumptions();
            Assert.AreEqual(1, consumptions.Count);
            Assert.AreEqual("Kipas", consumptions[0].DeviceName);
            Assert.AreEqual(50, consumptions[0].Consumption);
            Assert.AreEqual("Hemat", consumptions[0].Status);
        }

        [TestMethod]
        public void TestEditConsumption()
        {
            manager.AddConsumption("Lampu", 80);
            manager.EditConsumption("Lampu", 100);
            var consumptions = manager.GetAllConsumptions();
            Assert.AreEqual(1, consumptions.Count);
            Assert.AreEqual(100, consumptions[0].Consumption);
            Assert.AreEqual("Boros", consumptions[0].Status);
        }

        [TestMethod]
        public void TestRemoveConsumption()
        {
            manager.AddConsumption("TV", 70);
            manager.RemoveConsumption("TV");
            var consumptions = manager.GetAllConsumptions();
            Assert.AreEqual(0, consumptions.Count);
        }

        [TestMethod]
        public void TestCalculateTotalCost()
        {
            manager.AddConsumption("AC", 100);
            manager.AddConsumption("Kulkas", 50);
            double expectedTotal = (100 + 50) * 1444.7;
            double actualTotal = manager.CalculateTotalCost();
            Assert.AreEqual(expectedTotal, actualTotal, 0.01);
        }

        [TestMethod]
        public void TestGetAllConsumptions()
        {
            manager.AddConsumption("Kulkas", 60);
            manager.AddConsumption("AC", 150);

            var consumptions = manager.GetAllConsumptions();

            Assert.AreEqual(2, consumptions.Count);
            Assert.AreEqual("Kulkas", consumptions[0].DeviceName);
            Assert.AreEqual(60, consumptions[0].Consumption);
            Assert.AreEqual("Hemat", consumptions[0].Status);

            Assert.AreEqual("AC", consumptions[1].DeviceName);
            Assert.AreEqual(150, consumptions[1].Consumption);
            Assert.AreEqual("Boros", consumptions[1].Status);
        }
    }
}
