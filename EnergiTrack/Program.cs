using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

public class EnergyConsumption
{
    public string DeviceName { get; set; }
    public double Consumption { get; set; }
    public string Status { get; set; }
}

public class RuntimeConfig
{
    public double PricePerKWh { get; set; }
}

public class EnergyConsumptionManager
{
    private List<EnergyConsumption> consumptions;
    private double pricePerKWh;
    private string configFilePath;

    public EnergyConsumptionManager()
    {
        consumptions = new List<EnergyConsumption>();
        string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
        configFilePath = Path.Combine(baseDirectory, "..", "..", "..", "runtime_config.json");

        LoadConfig(); 
        LoadConsumptions(); 
    }

    // Membaca konfigurasi harga listrik dari file runtime_config.json
    private void LoadConfig()
    {
        try
        {
            if (File.Exists(configFilePath))
            {
                string json = File.ReadAllText(configFilePath);
                var config = JsonConvert.DeserializeObject<RuntimeConfig>(json);
                pricePerKWh = config.PricePerKWh;
            }
            else
            {
                pricePerKWh = 1444.7;  
                SaveConfig();  
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error saat memuat konfigurasi: {ex.Message}");
            pricePerKWh = 1444.7; 
        }
    }

    // Menyimpan konfigurasi harga listrik ke dalam file JSON
    private void SaveConfig()
    {
        var config = new RuntimeConfig { PricePerKWh = pricePerKWh };
        string json = JsonConvert.SerializeObject(config, Formatting.Indented);
        File.WriteAllText(configFilePath, json);
        Console.WriteLine("Harga listrik disimpan ke file konfigurasi.");
    }

    // Memuat data konsumsi energi dari file JSON
    private void LoadConsumptions()
    {
        try
        {
            string filePath = "energy_consumptions.json";
            if (File.Exists(filePath))
            {
                string json = File.ReadAllText(filePath);
                consumptions = JsonConvert.DeserializeObject<List<EnergyConsumption>>(json);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error saat memuat data konsumsi: {ex.Message}");
        }
    }

    // Menyimpan data konsumsi energi ke dalam file JSON
    private void SaveConsumptions()
    {
        try
        {
            string json = JsonConvert.SerializeObject(consumptions, Formatting.Indented);
            File.WriteAllText("energy_consumptions.json", json);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error saat menyimpan data konsumsi: {ex.Message}");
        }
    }

    // Menambahkan konsumsi perangkat
    public void AddConsumption(string deviceName, double consumption)
    {
        // Menghitung biaya total perangkat
        double totalCost = consumption * pricePerKWh;

        // Status berdasarkan total biaya
        string status = (totalCost > 100000) ? "Boros" : "Hemat";  // Jika biaya lebih dari 100,000 IDR, maka Boros
        consumptions.Add(new EnergyConsumption { DeviceName = deviceName, Consumption = consumption, Status = status });
        SaveConsumptions();
    }

    // Mengedit konsumsi perangkat
    public void EditConsumption(string deviceName, double newConsumption)
    {
        var consumption = consumptions.Find(c => c.DeviceName == deviceName);
        if (consumption != null)
        {
            // Menghitung biaya total perangkat setelah diubah
            double totalCost = newConsumption * pricePerKWh;

            // Status berdasarkan total biaya
            consumption.Consumption = newConsumption;
            consumption.Status = (totalCost > 100000) ? "Boros" : "Hemat"; // Jika biaya lebih dari 100,000 IDR, maka Boros
            SaveConsumptions();
        }
    }

    // Menghapus konsumsi perangkat
    public void RemoveConsumption(string deviceName)
    {
        var consumption = consumptions.Find(c => c.DeviceName == deviceName);
        if (consumption != null)
        {
            consumptions.Remove(consumption);
            SaveConsumptions();
        }
    }

    // Menampilkan semua konsumsi perangkat
    public void DisplayConsumptions()
    {
        Console.WriteLine("Device Name | Consumption (kWh) | Status");
        foreach (var consumption in consumptions)
        {
            Console.WriteLine($"{consumption.DeviceName} | {consumption.Consumption} | {consumption.Status}");
        }
    }

    // Menghitung total biaya berdasarkan konsumsi perangkat
    public double CalculateTotalCost()
    {
        double totalCost = 0;
        foreach (var consumption in consumptions)
        {
            totalCost += consumption.Consumption * pricePerKWh;
        }
        return totalCost;
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        EnergyConsumptionManager manager = new EnergyConsumptionManager();

        while (true)
        {
            Console.WriteLine("\nMenu:");
            Console.WriteLine("1. Lihat Semua Konsumsi");
            Console.WriteLine("2. Tambah Konsumsi");
            Console.WriteLine("3. Edit Konsumsi");
            Console.WriteLine("4. Hapus Konsumsi");
            Console.WriteLine("5. Total Biaya");
            Console.WriteLine("6. Keluar");
            Console.Write("Pilih menu: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    manager.DisplayConsumptions();
                    break;
                case "2":
                    Console.Write("Masukkan nama perangkat: ");
                    string deviceName = Console.ReadLine();
                    Console.Write("Masukkan konsumsi (kWh): ");
                    double consumption = Convert.ToDouble(Console.ReadLine());
                    manager.AddConsumption(deviceName, consumption);
                    break;
                case "3":
                    Console.Write("Masukkan nama perangkat yang ingin diedit: ");
                    string editDevice = Console.ReadLine();
                    Console.Write("Masukkan konsumsi baru (kWh): ");
                    double newConsumption = Convert.ToDouble(Console.ReadLine());
                    manager.EditConsumption(editDevice, newConsumption);
                    break;
                case "4":
                    Console.Write("Masukkan nama perangkat yang ingin dihapus: ");
                    string removeDevice = Console.ReadLine();
                    manager.RemoveConsumption(removeDevice);
                    break;
                case "5":
                    double totalCost = manager.CalculateTotalCost();
                    Console.WriteLine($"Total biaya untuk semua perangkat: {totalCost} IDR");
                    break;
                case "6":
                    return;
                default:
                    Console.WriteLine("Pilihan tidak valid.");
                    break;
            }
        }
    }
}
