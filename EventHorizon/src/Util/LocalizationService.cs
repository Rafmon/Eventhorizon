using System.IO;
using System.Text.Json;

namespace EventHorizon.src.Util
{
    public class LocalizationService
    {
        private readonly Dictionary<string, Dictionary<string, string>> _translations;
        private readonly Dictionary<string, (string Name, string Icon)> _availableLanguages;
        private readonly string _i18nDirectoryPath = Path.Combine(AppContext.BaseDirectory, "i18n");

        public LocalizationService()
        {
            _translations = new Dictionary<string, Dictionary<string, string>>();
            _availableLanguages = new Dictionary<string, (string Name, string Icon)>();

            LoadAllLanguages(); // Load all languages at startup
        }

        // Loads all available languages from the i18n directory
        private void LoadAllLanguages()
        {
            Console.WriteLine($"i18n Directory Path: {_i18nDirectoryPath}");

            if (Directory.Exists(_i18nDirectoryPath))
            {
                var jsonFiles = Directory.GetFiles(_i18nDirectoryPath, "*.json");
                Console.WriteLine($"Found {jsonFiles.Length} language files");

                foreach (var file in jsonFiles)
                {
                    try
                    {
                        var language = Path.GetFileNameWithoutExtension(file);
                        var jsonContent = File.ReadAllText(file);
                        var languageData = JsonSerializer.Deserialize<Dictionary<string, object>>(jsonContent);

                        if (languageData != null && languageData.ContainsKey("language"))
                        {
                            // Extract language information
                            var langInfo = languageData["language"] as JsonElement?;
                            if (langInfo.HasValue && langInfo.Value.TryGetProperty("name", out var name) && langInfo.Value.TryGetProperty("icon", out var icon))
                            {
                                // Add language information to the list
                                _availableLanguages[language] = (name.GetString() ?? "unknown", icon.GetString() ?? "❓");
                                Console.WriteLine($"Loaded language: {name.GetString()} with icon: {icon.GetString()}");
                            }

                            // Extract all translations except for the "language" property
                            var translations = languageData
                                .Where(kv => kv.Key != "language")
                                .ToDictionary(kv => kv.Key, kv => kv.Value?.ToString() ?? string.Empty);

                            _translations[language] = translations;
                        }
                        else
                        {
                            Console.WriteLine($"File {file} does not contain valid language data.");
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Error processing file {file}: {ex.Message}");
                    }
                }
            }
            else
            {
                Console.WriteLine("i18n directory not found!");
            }
        }

        // Returns the translation for the given key in the specified language
        public string Translate(string language, string key)
        {
            if (_translations.TryGetValue(language, out var translations) && translations.TryGetValue(key, out var value))
            {
                return value;
            }

            return $"[{key}]";
        }

        // Returns all available languages and their information
        public Dictionary<string, (string Name, string Icon)> GetAvailableLanguages()
        {
            return _availableLanguages;
        }
    }
}
