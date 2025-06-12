<<<<<<< HEAD
﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace EnergiTrack.Domain
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}

namespace EnergiTrack.Services
{
    public interface ICrudService<T>
    {
        void Add(T item);
        void Edit(int id, T item);
        void Delete(int id);
        List<T> GetAll();
        T GetById(int id);
    }

    public class CrudService<T> : ICrudService<T> where T : class
    {
        private readonly List<T> _items;
        private int _nextId;

        public CrudService()
        {
            _items = new List<T>();
            _nextId = 1;
        }

        public void Add(T item)
        {
            var prop = item.GetType().GetProperty("Id");
            if (prop != null)
            {
                prop.SetValue(item, _nextId);
                _nextId++;
            }
            _items.Add(item);
        }

        public void Edit(int id, T item)
        {
            var existingItem = GetById(id);
            if (existingItem != null)
            {
                var index = _items.IndexOf(existingItem);
                _items[index] = item;
            }
        }

        public void Delete(int id)
        {
            var item = GetById(id);
            if (item != null)
            {
                _items.Remove(item);
            }
        }

        public List<T> GetAll()
        {
            return _items;
        }

        public T GetById(int id)
        {
            return _items.FirstOrDefault(item => (int)item.GetType().GetProperty("Id")?.GetValue(item) == id);
        }
    }
}

namespace EnergiTrack
{
    class Program
    {
        static void Main(string[] args)
        {
            var categoryService = new EnergiTrack.Services.CrudService<EnergiTrack.Domain.Category>();

            while (true)
            {
                Console.WriteLine("\n=== CRUD Kategori ===");
                Console.WriteLine("1. Tambah Kategori");
                Console.WriteLine("2. Lihat Semua Kategori");
                Console.WriteLine("3. Edit Kategori");
                Console.WriteLine("4. Hapus Kategori");
                Console.WriteLine("0. Keluar");
                Console.Write("Pilih: ");
                var input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        Console.Write("Nama Kategori: ");
                        var name = Console.ReadLine();
                        categoryService.Add(new EnergiTrack.Domain.Category { Name = name });
                        Console.WriteLine("Kategori berhasil ditambahkan!");
                        break;

                    case "2":
                        var categories = categoryService.GetAll();
                        Console.WriteLine("\n--- Daftar Kategori ---");
                        foreach (var cat in categories)
                        {
                            Console.WriteLine($"ID: {cat.Id}, Nama: {cat.Name}");
                        }
                        break;

                    case "3":
                        Console.Write("ID Kategori: ");
                        int editId = int.Parse(Console.ReadLine()!);
                        Console.Write("Nama Baru: ");
                        var newName = Console.ReadLine();
                        categoryService.Edit(editId, new EnergiTrack.Domain.Category { Id = editId, Name = newName });
                        Console.WriteLine("Kategori berhasil diubah!");
                        break;

                    case "4":
                        Console.Write("ID Kategori: ");
                        int deleteId = int.Parse(Console.ReadLine()!);
                        categoryService.Delete(deleteId);
                        Console.WriteLine("Kategori berhasil dihapus!");
                        break;

                    case "0":
                        return;

                    default:
                        Console.WriteLine("Pilihan tidak valid!");
                        break;
                }
            }
        }
    }
}
=======
﻿using EnergiTrack.Model;
using EnergiTrack.Service;
class Program
{
    static void Main()
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("=== MENU JADWAL PERANGKAT ===");
            Console.WriteLine("1. Tambah Jadwal");
            Console.WriteLine("2. Edit Jadwal");
            Console.WriteLine("3. Hapus Jadwal");
            Console.WriteLine("4. Ubah Status Jadwal");
            Console.WriteLine("5. Tampilkan Semua Jadwal");
            Console.WriteLine("6. Keluar");
            Console.Write("Pilih opsi (1-6): ");

            string input = Console.ReadLine();
            Console.Clear();

            switch (input)
            {
                case "1":
                    TambahJadwal();
                    break;
                case "2":
                    EditJadwal();
                    break;
                case "3":
                    HapusJadwal();
                    break;
                case "4":
                    UbahStatusJadwal();
                    break;
                case "5":
                    JadwalService.TampilkanJadwal();
                    break;
                case "6":
                    return;
                default:
                    Console.WriteLine("Opsi tidak valid.");
                    break;
            }

            Console.WriteLine("\nTekan ENTER untuk kembali ke menu...");
            Console.ReadLine();
        }
    }

    static void TambahJadwal()
    {
        Console.Write("Nama Perangkat: ");
        string nama = Console.ReadLine();

        Console.Write("Hari: ");
        string hari = Console.ReadLine();

        Console.Write("Jam Mulai (hh:mm): ");
        TimeSpan mulai = TimeSpan.Parse(Console.ReadLine());

        Console.Write("Jam Selesai (hh:mm): ");
        TimeSpan selesai = TimeSpan.Parse(Console.ReadLine());

        JadwalService.TambahJadwal(nama, hari, mulai, selesai);
    }

    static void EditJadwal()
    {
        Console.Write("ID Jadwal yang akan diedit: ");
        int id = int.Parse(Console.ReadLine());

        Console.Write("Nama Baru Perangkat: ");
        string nama = Console.ReadLine();

        Console.Write("Hari Baru: ");
        string hari = Console.ReadLine();

        Console.Write("Jam Mulai Baru (hh:mm): ");
        TimeSpan mulai = TimeSpan.Parse(Console.ReadLine());

        Console.Write("Jam Selesai Baru (hh:mm): ");
        TimeSpan selesai = TimeSpan.Parse(Console.ReadLine());

        JadwalService.EditJadwal(id, nama, hari, mulai, selesai);
    }

    static void HapusJadwal()
    {
        Console.Write("ID Jadwal yang akan dihapus: ");
        int id = int.Parse(Console.ReadLine());

        JadwalService.HapusJadwal(id);
    }

    static void UbahStatusJadwal()
    {
        Console.Write("ID Jadwal: ");
        int id = int.Parse(Console.ReadLine());

        Console.WriteLine("Aksi: (1 = MULAI, 2 = SELESAIKAN, 3 = RESET)");
        string aksiInput = Console.ReadLine();

        Aksi aksi = aksiInput switch
        {
            "1" => Aksi.MULAI,
            "2" => Aksi.SELESAIKAN,
            "3" => Aksi.RESET,
            _ => throw new ArgumentException("Aksi tidak valid")
        };

        JadwalService.UbahStatus(id, aksi);
    }
}
>>>>>>> main
