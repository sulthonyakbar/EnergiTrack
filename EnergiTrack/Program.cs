using System;

namespace EnergiTrack
{
    class Program
    {
        static void Main(string[] args)
        {
            var manager = new EnergyConsumptionManager();

            while (true)
            {
                Console.WriteLine("\n=== Aplikasi Pemantauan Konsumsi Energi ===");
                Console.WriteLine("1. Tambah Data Konsumsi");
                Console.WriteLine("2. Edit Data Konsumsi");
                Console.WriteLine("3. Hapus Data Konsumsi");
                Console.WriteLine("4. Tampilkan Semua Data");
                Console.WriteLine("5. Hitung Total Biaya");
                Console.WriteLine("0. Keluar");
                Console.Write("Pilih menu: ");
                string pilihan = Console.ReadLine();

                switch (pilihan)
                {
                    case "1":
                        Console.Write("Nama perangkat: ");
                        string nama = Console.ReadLine();
                        Console.Write("Konsumsi (kWh): ");
                        if (double.TryParse(Console.ReadLine(), out double konsumsi))
                        {
                            manager.AddConsumption(nama, konsumsi);
                            Console.WriteLine("Data berhasil ditambahkan.");
                        }
                        else
                        {
                            Console.WriteLine("Input tidak valid.");
                        }
                        break;

                    case "2":
                        Console.Write("Nama perangkat yang akan diedit: ");
                        string editNama = Console.ReadLine();
                        Console.Write("Konsumsi baru (kWh): ");
                        if (double.TryParse(Console.ReadLine(), out double newKonsumsi))
                        {
                            manager.EditConsumption(editNama, newKonsumsi);
                            Console.WriteLine("Data berhasil diubah.");
                        }
                        else
                        {
                            Console.WriteLine("Input tidak valid.");
                        }
                        break;

                    case "3":
                        Console.Write("Nama perangkat yang akan dihapus: ");
                        string hapusNama = Console.ReadLine();
                        manager.RemoveConsumption(hapusNama);
                        Console.WriteLine("Data berhasil dihapus.");
                        break;

                    case "4":
                        var data = manager.GetAllConsumptions();
                        Console.WriteLine("\nData Konsumsi Energi:");
                        foreach (var item in data)
                        {
                            Console.WriteLine($"- {item.DeviceName}: {item.Consumption} kWh | Status: {item.Status}");
                        }
                        break;

                    case "5":
                        double total = manager.CalculateTotalCost();
                        Console.WriteLine($"Total biaya konsumsi: Rp{total:N2}");
                        break;

                    case "0":
                        Console.WriteLine("Keluar dari aplikasi.");
                        return;

                    default:
                        Console.WriteLine("Pilihan tidak valid.");
                        break;
                }
            }
        }
    }
}
