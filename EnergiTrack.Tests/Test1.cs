using EnergiTrack;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;

namespace TestProject1
{
    [TestClass]
    public class EnergyConsumptionManagerTests
    {
        private EnergyConsumptionManager manager;
        private string configPath;
        private string dataPath;

        [TestInitialize]
        public void SetUp()
        {
            string baseDir = AppDomain.CurrentDomain.BaseDirectory;
            configPath = Path.Combine(baseDir, "..", "..", "..", "runtime_config.json");
            dataPath = Path.Combine(baseDir, "..", "..", "..", "energy_consumptions.json");

            if (File.Exists(configPath)) File.Delete(configPath);
            if (File.Exists(dataPath)) File.Delete(dataPath);

            manager = new EnergyConsumptionManager();

            manager.ClearAllData();
        }

        [TestMethod]
        public void TestAddConsumption()
        {
            manager.AddConsumption("Kipas", 50);

            var consumptions = manager.GetAllConsumptions();

            Assert.AreEqual(1, consumptions.Count);
            Assert.AreEqual("Kipas", consumptions[0].DeviceName);
            Assert.AreEqual(50, consumptions[0].Consumption);

            double totalCost = 50 * 1444.7;
            string expectedStatus = GetExpectedStatus(totalCost);

            Assert.AreEqual(expectedStatus, consumptions[0].Status);
        }

        [TestMethod]
        public void TestEditConsumption()
        {
            manager.AddConsumption("Lampu", 80);
            manager.EditConsumption("Lampu", 100);

            var consumptions = manager.GetAllConsumptions();
            Assert.AreEqual(1, consumptions.Count);
            Assert.AreEqual("Lampu", consumptions[0].DeviceName);
            Assert.AreEqual(100, consumptions[0].Consumption);

            double totalCost = 100 * 1444.7;
            string expectedStatus = GetExpectedStatus(totalCost);
            Assert.AreEqual(expectedStatus, consumptions[0].Status);
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

            ValidateDevice(consumptions, "Kulkas", 60);
            ValidateDevice(consumptions, "AC", 150);
        }

        private void ValidateDevice(IReadOnlyList<EnergyConsumption> consumptions, string deviceName, double expectedConsumption)
        {
            var device = consumptions.FirstOrDefault(c => c.DeviceName == deviceName);
            Assert.IsNotNull(device, $"Device '{deviceName}' tidak ditemukan.");
            Assert.AreEqual(expectedConsumption, device.Consumption);

            double totalCost = expectedConsumption * 1444.7;
            string expectedStatus = GetExpectedStatus(totalCost);

            Assert.AreEqual(expectedStatus, device.Status);
        }

        private string GetExpectedStatus(double totalCost)
        {
            return totalCost > 100000 ? "Boros" : "Hemat";
        }
    }
}
