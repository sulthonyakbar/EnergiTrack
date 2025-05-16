using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using BenchmarkDotNet.Running;
[assembly: InternalsVisibleTo("EnergiTrackTest")]

namespace EnergiTrack
{
    public class Perangkat
    {
        public int Id { get; set; }
        public string Nama { get; set; }
        public int Daya { get; set; }

        public Perangkat(int id, string nama, int daya)
        {
            if (string.IsNullOrWhiteSpace(nama)) throw new ArgumentException("Nama tidak boleh kosong.");
            if (daya <= 0) throw new ArgumentException("Daya harus lebih dari 0.");

            Id = id;
            Nama = nama;
            Daya = daya;
        }
    }

    public static class PerangkatService
    {
        private static List<Perangkat> daftarPerangkat = new();
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
                // Tidak lempar exception, cuma return
                return;
            }

            if (string.IsNullOrWhiteSpace(namaBaru))
                throw new ArgumentException("Nama tidak boleh kosong.");
            if (dayaBaru <= 0)
                throw new ArgumentException("Daya harus lebih dari 0.");

            p.Nama = namaBaru;
            p.Daya = dayaBaru;
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

    class App
    {
        static void Main()
        {
            while (true)
            {
                Console.WriteLine("\n====== MENU PERANGKAT ======");
                Console.WriteLine("1. Tambah Perangkat");
                Console.WriteLine("2. Lihat Semua Perangkat");
                Console.WriteLine("3. Edit Perangkat");
                Console.WriteLine("4. Hapus Perangkat");
                Console.WriteLine("5. Keluar");
                Console.WriteLine("6. Jalankan Benchmark");
                Console.Write("Pilih menu (1-6): ");
                string pilihan = Console.ReadLine();

                switch (pilihan)
                {
                    case "1":
                        Console.Write("Nama perangkat: ");
                        string nama = Console.ReadLine();
                        Console.Write("Daya perangkat (Watt): ");
                        if (int.TryParse(Console.ReadLine(), out int daya))
                        {
                            try
                            {
                                PerangkatService.TambahPerangkat(nama, daya);
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine($"Gagal menambahkan perangkat: {ex.Message}");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Input daya tidak valid.");
                        }
                        break;

                    case "2":
                        PerangkatService.LihatPerangkat();
                        break;

                    case "3":
                        Console.Write("Masukkan ID perangkat yang ingin diedit: ");
                        if (int.TryParse(Console.ReadLine(), out int idEdit))
                        {
                            Console.Write("Nama baru: ");
                            string namaBaru = Console.ReadLine();
                            Console.Write("Daya baru (Watt): ");
                            if (int.TryParse(Console.ReadLine(), out int dayaBaru))
                            {
                                try
                                {
                                    PerangkatService.EditPerangkat(idEdit, namaBaru, dayaBaru);
                                }
                                catch (Exception ex)
                                {
                                    Console.WriteLine($"Gagal mengedit perangkat: {ex.Message}");
                                }
                            }
                            else
                            {
                                Console.WriteLine("Input daya tidak valid.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Input ID tidak valid.");
                        }
                        break;

                    case "4":
                        Console.Write("Masukkan ID perangkat yang ingin dihapus: ");
                        if (int.TryParse(Console.ReadLine(), out int idHapus))
                        {
                            PerangkatService.HapusPerangkat(idHapus);
                        }
                        else
                        {
                            Console.WriteLine("Input ID tidak valid.");
                        }
                        break;

                    case "5":
                        Console.WriteLine("Terima kasih! Program selesai.");
                        return;

                    case "6":
                        Console.WriteLine("Menjalankan benchmark, harap tunggu...");
                        BenchmarkRunner.Run<BenchmarkPerangkat>();
                        break;

                    default:
                        Console.WriteLine("Pilihan tidak valid.");
                        break;
                }
            }
        }
    }
}
