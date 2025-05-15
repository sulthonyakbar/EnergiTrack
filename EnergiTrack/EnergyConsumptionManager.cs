using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

namespace EnergiTrack
{
    public class EnergyConsumption
    {
        public string DeviceName { get; set; } // Nama perangkat
        public double Consumption { get; set; } // Konsumsi energi (kWh)
        public string Status { get; set; } // Status hemat atau boros
    }

    public class RuntimeConfig
    {
        public double PricePerKWh { get; set; } // Harga per kWh
    }

    public class EnergyConsumptionManager
    {
        private List<EnergyConsumption> consumptions;
        private double pricePerKWh;
        private readonly string configFilePath;
        private readonly string dataFilePath = "energy_consumptions.json";

        // Design by Contract - Postcondition & Invariant:
        // Konstruktor menjamin consumptions selalu terinisialisasi
        // dan pricePerKWh selalu memiliki nilai valid.
        public EnergyConsumptionManager()
        {
            consumptions = new List<EnergyConsumption>();
            string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
            configFilePath = Path.Combine(baseDirectory, "..", "..", "..", "runtime_config.json");

            LoadConfig(); // akan menetapkan nilai pricePerKWh
            LoadConsumptions();
        }

        // Design by Contract:
        // Precondition: file konfigurasi mungkin ada atau tidak
        // Postcondition: pricePerKWh selalu memiliki nilai valid
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
                    pricePerKWh = 1444.7; // Kontrak: nilai default
                    SaveConfig(); // Kontrak: simpan konfigurasi default
                }
            }
            catch
            {
                pricePerKWh = 1444.7; // Kontrak: fallback jika gagal memuat
            }
        }

        private void SaveConfig()
        {
            var config = new RuntimeConfig { PricePerKWh = pricePerKWh };
            string json = JsonConvert.SerializeObject(config, Formatting.Indented);
            File.WriteAllText(configFilePath, json);
        }

        private void LoadConsumptions()
        {
            try
            {
                if (File.Exists(dataFilePath))
                {
                    string json = File.ReadAllText(dataFilePath);
                    consumptions = JsonConvert.DeserializeObject<List<EnergyConsumption>>(json);
                }
            }
            catch { }
        }

        private void SaveConsumptions()
        {
            try
            {
                string json = JsonConvert.SerializeObject(consumptions, Formatting.Indented);
                File.WriteAllText(dataFilePath, json);
            }
            catch { }
        }

        // Design by Contract:
        // Precondition: nama perangkat tidak boleh kosong/null, konsumsi >= 0
        // Postcondition: data ditambahkan ke list dan disimpan
        public void AddConsumption(string deviceName, double consumption)
        {
            if (string.IsNullOrWhiteSpace(deviceName)) throw new ArgumentException("Nama perangkat tidak boleh kosong.");
            if (consumption < 0) throw new ArgumentException("Konsumsi tidak boleh negatif.");

            double totalCost = consumption * pricePerKWh;
            string status = (totalCost > 100000) ? "Boros" : "Hemat";
            consumptions.Add(new EnergyConsumption { DeviceName = deviceName, Consumption = consumption, Status = status });
            SaveConsumptions();
        }

        // Design by Contract:
        // Precondition: nama perangkat tidak boleh kosong, konsumsi baru >= 0
        // Postcondition: data pada item yang ditemukan diperbarui dan disimpan
        public void EditConsumption(string deviceName, double newConsumption)
        {
            if (string.IsNullOrWhiteSpace(deviceName)) throw new ArgumentException("Nama perangkat tidak boleh kosong.");
            if (newConsumption < 0) throw new ArgumentException("Konsumsi tidak boleh negatif.");

            var consumption = consumptions.Find(c => c.DeviceName == deviceName);
            if (consumption != null)
            {
                double totalCost = newConsumption * pricePerKWh;
                consumption.Consumption = newConsumption;
                consumption.Status = (totalCost > 100000) ? "Boros" : "Hemat";
                SaveConsumptions();
            }
        }

        // Design by Contract:
        // Precondition: perangkat harus ada dalam list
        // Postcondition: jika ditemukan, data dihapus dan perubahan disimpan
        public void RemoveConsumption(string deviceName)
        {
            var consumption = consumptions.Find(c => c.DeviceName == deviceName);
            if (consumption != null)
            {
                consumptions.Remove(consumption);
                SaveConsumptions();
            }
        }

        // Design by Contract:
        // Invariant: consumptions tidak null, selalu list aktif
        public List<EnergyConsumption> GetAllConsumptions()
        {
            return new List<EnergyConsumption>(consumptions);
        }

        // Design by Contract:
        // Postcondition: mengembalikan total biaya semua perangkat
        public double CalculateTotalCost()
        {
            double total = 0;
            foreach (var c in consumptions)
            {
                total += c.Consumption * pricePerKWh;
            }
            return total;
        }
    }
}
