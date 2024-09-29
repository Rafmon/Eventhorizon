using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using EventHorizon.src.Events;

namespace EventHorizon.src.Util
{
    public static class SaveManager
    {
        private const string EventsFilename = "events.json";
        private static readonly JsonSerializerOptions Options = new() { IncludeFields = true, WriteIndented = true };

        private static readonly string SaveDirectory;

        static SaveManager()
        {
            // Get Apllication Default Path
            string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
            SaveDirectory = Path.Combine(baseDirectory, "save");
        }

        public static void SaveEvents(List<Event> events)
        {
            try
            {
                if (!Directory.Exists(SaveDirectory))
                {
                    Directory.CreateDirectory(SaveDirectory);
                }

                var filePath = Path.Combine(SaveDirectory, EventsFilename);

                using FileStream createStream = File.Create(filePath);
                JsonSerializer.Serialize(createStream, events, Options);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Fehler beim Speichern der Events: {ex.Message}");
            }
        }

        public static List<Event> LoadEvents()
        {
            var filePath = Path.Combine(SaveDirectory, EventsFilename);
            List<Event>? events = null;

            try
            {
                if (File.Exists(filePath))
                {
                    using FileStream openStream = File.OpenRead(filePath);
                    events = JsonSerializer.Deserialize<List<Event>>(openStream, Options);
                }
                else
                {
                    Console.WriteLine("Keine Events-Datei gefunden, starte mit einer leeren Liste.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Fehler beim Laden der Events: {ex.Message}");
            }

            if (events == null || events.Count <= 0)
            {
                events = new List<Event>();
            }

            return events;
        }
    }
}
