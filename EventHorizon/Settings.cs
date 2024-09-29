using System;
using System.IO;
using System.Text.Json;

namespace EventHorizon
{
    public class Settings
    {
        private static Settings? instance;
        public bool SimulateI2CDevices { get; set; } = false;
        public int TimelineDuration { get; set; } = 180; //  default

        private const string SettingsFile = "save/settings.json";

        public Settings()
        {
            Console.WriteLine("Loading Configuration");
            LoadSettings();
            foreach (String arg in Environment.GetCommandLineArgs())
            {
                if (arg.Contains("--simulateI2C") && !SimulateI2CDevices)
                {
                    SimulateI2CDevices = true;
                    Console.WriteLine("Simultaing I2CDevices");
                }
            }
        }

        public static Settings getInstance()
        {
            instance ??= new Settings();
            return instance;
        }

        public void SaveSettings()
        {
            var json = JsonSerializer.Serialize(this);
            File.WriteAllText(SettingsFile, json);
            Console.WriteLine("Settings saved.");
        }

        public void LoadSettings()
        {
            if (File.Exists(SettingsFile))
            {
                var json = File.ReadAllText(SettingsFile);
                var loadedSettings = JsonSerializer.Deserialize<Settings>(json);
                SimulateI2CDevices = loadedSettings?.SimulateI2CDevices ?? false;
                TimelineDuration = loadedSettings?.TimelineDuration ?? 180;
                Console.WriteLine("Settings loaded.");
            }
        }
    }
}
