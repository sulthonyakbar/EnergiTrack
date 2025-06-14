using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnergiTrack.Service
{
    // Kelas Perangkat
    public class Perangkat
    {
        public int Id { get; set; }
        public string Nama { get; set; }
        public int Daya { get; set; }

        public Perangkat(int id, string nama, int daya)
        {
            if (string.IsNullOrWhiteSpace(nama))
                throw new ArgumentException("Nama tidak boleh kosong.");
            if (daya <= 0)
                throw new ArgumentException("Daya harus lebih dari 0.");

            Id = id;
            Nama = nama;
            Daya = daya;
        }

    }

    // Kelas statik PerangkatService
    public static class PerangkatService
    {
        private static List<Perangkat> daftarPerangkat = new();
        public static List<Perangkat> GetDaftar()
        {
            return daftarPerangkat;
        }

        private static int nextId = 1;

        public static Perangkat TambahPerangkat(string nama, int daya)
        {
            var p = new Perangkat(nextId++, nama, daya);
            daftarPerangkat.Add(p);
            Console.WriteLine($"Perangkat '{nama}' dengan daya {daya}W ditambahkan.");
            return p;
        }

        public static void LihatPerangkat()
        {
            if (daftarPerangkat.Count == 0)
            {
                Console.WriteLine("Belum ada perangkat yang terdaftar.");
                return;
            }

            Console.WriteLine("\nDaftar Perangkat:");
            foreach (var p in daftarPerangkat)
            {
                Console.WriteLine($"ID: {p.Id} | Nama: {p.Nama} | Daya: {p.Daya}W");
            }
        }

        public static void EditPerangkat(int id, string namaBaru, int dayaBaru)
        {
            var p = CariPerangkatById(id);
            if (p == null)
            {
                Console.WriteLine("Perangkat tidak ditemukan.");
                return;
            }

            if (string.IsNullOrWhiteSpace(namaBaru))
                throw new ArgumentException("Nama tidak boleh kosong.");
            if (dayaBaru <= 0)
                throw new ArgumentException("Daya harus lebih dari 0.");

            p.Nama = namaBaru;
            p.Daya = dayaBaru;
            Console.WriteLine($"Perangkat ID {id} berhasil diperbarui.");
        }

        public static void HapusPerangkat(int id)
        {
            var p = CariPerangkatById(id);
            if (p != null)
            {
                daftarPerangkat.Remove(p);
                Console.WriteLine($"Perangkat '{p.Nama}' telah dihapus.");
            }
            else
            {
                Console.WriteLine("Perangkat tidak ditemukan.");
            }
        }

        private static Perangkat CariPerangkatById(int id)
        {
            return daftarPerangkat.Find(p => p.Id == id);
        }

        public static Perangkat? GetPerangkatById(int id)
        {
            return CariPerangkatById(id);
        }

        public static void Reset()
        {
            daftarPerangkat.Clear();
            nextId = 1;
        }
    }
}