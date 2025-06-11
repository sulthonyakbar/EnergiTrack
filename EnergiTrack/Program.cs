using System;
using System.Globalization;

namespace EnergiTrack
{
    class Program
    {
        static void Main()
        {
            var manager = new EnergyConsumptionManager();
            bool isRunning = true;

            while (isRunning)
            {
                DisplayMenu();
                var choice = Console.ReadLine();

                switch (choice)
                {
                    case "1": AddConsumption(manager); break;
                    case "2": EditConsumption(manager); break;
                    case "3": RemoveConsumption(manager); break;
                    case "4": ShowAllConsumptions(manager); break;
                    case "5": ShowTotalCost(manager); break;
                    case "0": isRunning = false; break;
                    default: Console.WriteLine("Pilihan tidak valid."); break;
                }
            }
        }

        private static void DisplayMenu()
        {
            Console.WriteLine("\n===== Energy Consumption Manager =====");
            Console.WriteLine("1. Tambah Konsumsi");
            Console.WriteLine("2. Edit Konsumsi (hanya KWh)");
            Console.WriteLine("3. Hapus Konsumsi");
            Console.WriteLine("4. Lihat Semua Konsumsi");
            Console.WriteLine("5. Hitung Total Biaya");
            Console.WriteLine("0. Keluar");
            Console.Write("Pilih menu: ");
        }

        private static void AddConsumption(EnergyConsumptionManager manager)
        {
            Console.Write("Nama perangkat: ");
            var name = Console.ReadLine();

            Console.Write("Konsumsi (kWh): ");
            if (TryReadDouble(out double consumption))
            {
                try
                {
                    manager.AddConsumption(name, consumption);
                    Console.WriteLine("Data konsumsi berhasil ditambahkan.");
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }
            }
            else
            {
                Console.WriteLine("Input tidak valid.");
            }
        }

        private static void EditConsumption(EnergyConsumptionManager manager)
        {
            Console.Write("Nama perangkat yang ingin diubah: ");
            var name = Console.ReadLine();

            Console.Write("Konsumsi baru (kWh): ");
            if (TryReadDouble(out double newConsumption))
            {
                try
                {
                    manager.EditConsumption(name, newConsumption);
                    Console.WriteLine("Data konsumsi berhasil diperbarui.");
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }
            }
            else
            {
                Console.WriteLine("Input tidak valid.");
            }
        }

        private static void RemoveConsumption(EnergyConsumptionManager manager)
        {
            Console.Write("Nama perangkat yang ingin dihapus: ");
            var name = Console.ReadLine();

            manager.RemoveConsumption(name);
            Console.WriteLine("Data konsumsi berhasil dihapus.");
        }

        private static void ShowAllConsumptions(EnergyConsumptionManager manager)
        {
            var consumptions = manager.GetAllConsumptions();

            if (consumptions.Count == 0)
            {
                Console.WriteLine("Data konsumsi kosong.");
                return;
            }

            Console.WriteLine("\n--- Data Konsumsi Energi ---");
            foreach (var c in consumptions)
            {
                Console.WriteLine($"Perangkat: {c.DeviceName}, Konsumsi: {c.Consumption} kWh, Status: {c.Status}");
            }
        }

        private static void ShowTotalCost(EnergyConsumptionManager manager)
        {
            double totalCost = manager.CalculateTotalCost();
            Console.WriteLine($"Total Biaya Energi: Rp {totalCost.ToString("N2", CultureInfo.InvariantCulture)}");
        }

        private static bool TryReadDouble(out double result)
        {
            var input = Console.ReadLine();
            return double.TryParse(input, out result);
        }
    }
}
