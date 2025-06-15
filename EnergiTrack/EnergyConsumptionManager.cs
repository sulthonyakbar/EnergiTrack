using EnergiTrack.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

namespace EnergiTrack
{
    public class EnergyConsumption
    {
        public string DeviceName { get; set; }
        public double Consumption { get; set; }
        public double Cost { get; set; }
        public string Status { get; set; }
    }

    public class RuntimeConfig
    {
        public double PricePerKWh { get; set; }
    }

    public enum EnergyStatusState
    {
        Hemat,
        Boros
    }

    public class EnergyStatusAutomata
    {
        private EnergyStatusState currentState = EnergyStatusState.Hemat;

        public EnergyStatusState Evaluate(double totalCost)
        {
            currentState = totalCost > 100000 ? EnergyStatusState.Boros : EnergyStatusState.Hemat;
            return currentState;
        }
    }

    public class EnergyConsumptionManager
    {
        private readonly List<EnergyConsumption> _consumptions;
        private double _pricePerKWh;
        private readonly string _configFilePath;
        private readonly string _dataFilePath = "energy_consumptions.json";
        private readonly EnergyStatusAutomata _automata;

        public EnergyConsumptionManager()
        {
            _consumptions = new List<EnergyConsumption>();
            _configFilePath = GetConfigFilePath();
            LoadConfig();
            LoadConsumptions();
            _automata = new EnergyStatusAutomata();
        }

        private string GetConfigFilePath()
        {
            string baseDir = AppDomain.CurrentDomain.BaseDirectory;
            return Path.Combine(baseDir, "..", "..", "..", "runtime_config.json");
        }

        private void LoadConfig()
        {
            if (!File.Exists(_configFilePath))
            {
                _pricePerKWh = 1444.7;
                SaveConfig();
                return;
            }

            try
            {
                var json = File.ReadAllText(_configFilePath);
                var config = JsonConvert.DeserializeObject<RuntimeConfig>(json);
                _pricePerKWh = config?.PricePerKWh ?? 1444.7;
            }
            catch
            {
                _pricePerKWh = 1444.7;
            }
        }

        private void SaveConfig()
        {
            var config = new RuntimeConfig { PricePerKWh = _pricePerKWh };
            var json = JsonConvert.SerializeObject(config, Formatting.Indented);
            File.WriteAllText(_configFilePath, json);
        }

        private void LoadConsumptions()
        {
            if (!File.Exists(_dataFilePath)) return;

            try
            {
                var json = File.ReadAllText(_dataFilePath);
                var data = JsonConvert.DeserializeObject<List<EnergyConsumption>>(json);
                if (data != null) _consumptions.AddRange(data);
            }
            catch
            {
                
            }
        }
        private void SaveConsumptions()
        {
            try
            {
                var json = JsonConvert.SerializeObject(_consumptions, Formatting.Indented);
                File.WriteAllText(_dataFilePath, json);
            }
            catch
            {
               
            }
        }

        public void AddConsumption(Device device, DeviceSchedule schedule)
        {
            double durationHours = (schedule.EndTime - schedule.StartTime).TotalHours;
            double consumption = (device.PowerInWatts / 1000.0) * durationHours;

            ValidateInput(device.Name, consumption);

            var totalCost = consumption * _pricePerKWh;
            var status = _automata.Evaluate(totalCost);

            _consumptions.Add(new EnergyConsumption
            {
                DeviceName = device.Name,
                Consumption = consumption,
                Cost = totalCost,
                Status = status.ToString()
            });

            SaveConsumptions();
        }

        public void RemoveConsumption(string deviceName)
        {
            var consumption = _consumptions.Find(c => c.DeviceName == deviceName);
            if (consumption == null) return;

            _consumptions.Remove(consumption);
            SaveConsumptions();
        }

        public IReadOnlyList<EnergyConsumption> GetAllConsumptions()
        {
            return _consumptions.AsReadOnly();
        }

        public double CalculateTotalCost()
        {
            double total = 0;
            foreach (var c in _consumptions)
            {
                total += c.Consumption * _pricePerKWh;
            }
            return total;
        }

        public void ClearAllData()
        {
            _consumptions.Clear();
            SaveConsumptions();
        }

        private static void ValidateInput(string deviceName, double consumption)
        {
            if (string.IsNullOrWhiteSpace(deviceName))
                throw new ArgumentException("Nama perangkat tidak boleh kosong.");
            if (consumption < 0)
                throw new ArgumentException("Konsumsi tidak boleh negatif.");
        }

        public void UpdatePricePerKWh(double newPrice)
        {
            _pricePerKWh = newPrice;
            SaveConfig();
        }

        public double GetPricePerKWh()
        {
            return _pricePerKWh;
        }

    }
}
