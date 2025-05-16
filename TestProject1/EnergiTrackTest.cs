using Microsoft.VisualStudio.TestTools.UnitTesting;
using EnergiTrack;
using System;

namespace EnergiTrackTest
{
    [TestClass]
    public class PerangkatServiceTests
    {
        [TestInitialize]
        public void Setup()
        {
            PerangkatService.Reset();
        }

        //[TestMethod]
        //public void TambahPerangkat_ValidData_PerangkatDitambahkan()
        //{
        //    var perangkat = PerangkatService.TambahPerangkat("Kipas Angin", 50);

        //    Assert.IsNotNull(perangkat);
        //    Assert.AreEqual("Kipas Angin", perangkat.Nama);
        //    Assert.AreEqual(50, perangkat.Daya);
        //}

        //[TestMethod]
        //[ExpectedException(typeof(ArgumentException))]
        //public void TambahPerangkat_NamaKosong_ThrowException()
        //{
        //    PerangkatService.TambahPerangkat("", 100);
        //}

        //[TestMethod]
        //[ExpectedException(typeof(ArgumentException))]
        //public void TambahPerangkat_DayaNegatif_ThrowException()
        //{
        //    PerangkatService.TambahPerangkat("AC", -50);
        //}

        //[TestMethod]
        //public void EditPerangkat_ValidData_DataBerubah()
        //{
        //    var p = PerangkatService.TambahPerangkat("TV", 100);
        //    PerangkatService.EditPerangkat(p.Id, "Televisi", 120);

        //    var perangkat = PerangkatService.GetPerangkatById(p.Id);
        //    Assert.AreEqual("Televisi", perangkat.Nama);
        //    Assert.AreEqual(120, perangkat.Daya);
        //}

        //[TestMethod]
        //[ExpectedException(typeof(ArgumentException))]
        //public void EditPerangkat_NamaKosong_ThrowException()
        //{
        //    var p = PerangkatService.TambahPerangkat("Laptop", 75);
        //    PerangkatService.EditPerangkat(p.Id, "", 80);
        //}

        //[TestMethod]
        //public void EditPerangkat_IdTidakDitemukan_TidakThrow()
        //{
        //    try
        //    {
        //        PerangkatService.EditPerangkat(999, "Smart TV", 150);
        //        Assert.IsTrue(true);
        //    }
        //    catch
        //    {
        //        Assert.Fail("Edit perangkat seharusnya tidak melempar exception jika ID tidak ditemukan.");
        //    }
        //}

        [TestMethod]
        public void HapusPerangkat_PerangkatDihapus()
        {
            var p = PerangkatService.TambahPerangkat("Kulkas", 200);
            PerangkatService.HapusPerangkat(p.Id);

            var perangkat = PerangkatService.GetPerangkatById(p.Id);
            Assert.IsNull(perangkat);
        }

        [TestMethod]
        public void HapusPerangkat_TidakAdaID_TidakThrow()
        {
            try
            {
                PerangkatService.HapusPerangkat(999);
                Assert.IsTrue(true);
            }
            catch
            {
                Assert.Fail("Hapus perangkat seharusnya tidak melempar exception jika ID tidak ditemukan.");
            }
        }
    }
}
