using EnergiTrack;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Reflection;
using System.Collections.Generic;

namespace TestProject1
{
    [TestClass]
    public sealed class Test1
    {
        [TestMethod]
        public void TambahJadwal()
        {
            // Act
            JadwalService.TambahJadwal("Lampu", "Senin", new TimeSpan(7, 0, 0), new TimeSpan(9, 0, 0));

            // Assert
            var field = typeof(JadwalService).GetField("daftarJadwal", BindingFlags.NonPublic | BindingFlags.Static);
            var list = field.GetValue(null) as List<Jadwal>;
            Assert.AreEqual(1, list.Count);
            Assert.AreEqual("Lampu", list[0].NamaPerangkat);
        }

        [TestMethod]
        public void EditJadwal()
        {
            // Arrange
            JadwalService.TambahJadwal("TV", "Selasa", new TimeSpan(6, 0, 0), new TimeSpan(10, 0, 0));

            // Act
            JadwalService.EditJadwal(1, "Kipas", "Rabu", new TimeSpan(8, 0, 0), new TimeSpan(10, 0, 0));

            // Assert
            var field = typeof(JadwalService).GetField("daftarJadwal", BindingFlags.NonPublic | BindingFlags.Static);
            var list = field.GetValue(null) as List<Jadwal>;
            Assert.AreEqual("Kipas", list[0].NamaPerangkat);
            Assert.AreEqual("Rabu", list[0].Hari);
        }

        [TestMethod]
        public void HapusJadwal()
        {
            // Arrange
            JadwalService.TambahJadwal("Pompa", "Kamis", new TimeSpan(5, 0, 0), new TimeSpan(6, 0, 0));

            // Act
            JadwalService.HapusJadwal(1);

            // Assert
            var field = typeof(JadwalService).GetField("daftarJadwal", BindingFlags.NonPublic | BindingFlags.Static);
            var list = field.GetValue(null) as System.Collections.Generic.List<Jadwal>;
            Assert.AreEqual(0, list.Count);
        }

        [TestMethod]
        public void UbahStatus()
        {

            // Arrange
            JadwalService.TambahJadwal("Kulkas", "Jumat", new TimeSpan(3, 0, 0), new TimeSpan(5, 0, 0));

            // Act
            JadwalService.UbahStatus(1, Aksi.MULAI);
            JadwalService.UbahStatus(1, Aksi.SELESAIKAN);

            // Assert
            var field = typeof(JadwalService).GetField("daftarJadwal", BindingFlags.NonPublic | BindingFlags.Static);
            var list = field.GetValue(null) as System.Collections.Generic.List<Jadwal>;
            Assert.AreEqual(StatusJadwal.SELESAI, list[0].Status);
        }
    }
}
