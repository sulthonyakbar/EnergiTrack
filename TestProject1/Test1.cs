<<<<<<< HEAD
﻿using EnergiTrack;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
=======
﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Reflection;
using System.Collections.Generic;
using EnergiTrack.Model;
using EnergiTrack.Service;
>>>>>>> cdcfb45f179201a40fd0a363fdb2b13ea609e048

namespace TestProject1
{
    [TestClass]
<<<<<<< HEAD
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
=======
    public sealed class Test1
    {
        [TestMethod]
        public void TambahJadwal()
        {
            JadwalService.TambahJadwal("Lampu", "Senin", new TimeSpan(7, 0, 0), new TimeSpan(9, 0, 0));

            var field = typeof(JadwalService).GetField("daftarJadwal", BindingFlags.NonPublic | BindingFlags.Static);
            var list = field.GetValue(null) as List<Jadwal>;
            Assert.AreEqual(1, list.Count);
            Assert.AreEqual("Lampu", list[0].NamaPerangkat);
        }

        [TestMethod]
        public void EditJadwal()
        {
            JadwalService.TambahJadwal("TV", "Selasa", new TimeSpan(6, 0, 0), new TimeSpan(10, 0, 0));

            JadwalService.EditJadwal(1, "Kipas", "Rabu", new TimeSpan(8, 0, 0), new TimeSpan(10, 0, 0));

            var field = typeof(JadwalService).GetField("daftarJadwal", BindingFlags.NonPublic | BindingFlags.Static);
            var list = field.GetValue(null) as List<Jadwal>;
            Assert.AreEqual("Kipas", list[0].NamaPerangkat);
            Assert.AreEqual("Rabu", list[0].Hari);
        }

        [TestMethod]
        public void HapusJadwal()
        {
            JadwalService.TambahJadwal("Pompa", "Kamis", new TimeSpan(5, 0, 0), new TimeSpan(6, 0, 0));

            JadwalService.HapusJadwal(1);

            var field = typeof(JadwalService).GetField("daftarJadwal", BindingFlags.NonPublic | BindingFlags.Static);
            var list = field.GetValue(null) as System.Collections.Generic.List<Jadwal>;
            Assert.AreEqual(0, list.Count);
        }

        [TestMethod]
        public void UbahStatus()
        {

            JadwalService.TambahJadwal("Kulkas", "Jumat", new TimeSpan(3, 0, 0), new TimeSpan(5, 0, 0));

            JadwalService.UbahStatus(1, Aksi.MULAI);
            JadwalService.UbahStatus(1, Aksi.SELESAIKAN);

            var field = typeof(JadwalService).GetField("daftarJadwal", BindingFlags.NonPublic | BindingFlags.Static);
            var list = field.GetValue(null) as System.Collections.Generic.List<Jadwal>;
            Assert.AreEqual(StatusJadwal.SELESAI, list[0].Status);
>>>>>>> cdcfb45f179201a40fd0a363fdb2b13ea609e048
        }
    }
}
