using Microsoft.JSInterop;
using System.ComponentModel;

namespace EventHorizon.src.Util
{
    /// <summary>
    /// Provides translations based on the session based user language settings.
    /// </summary>
    public class I18nHelper
    {
        private String Language = "en";
        private readonly TaskCompletionSource<bool> _initializationTaskSource = new();
        private LocalizationService localizationService;
        private readonly IJSRuntime _jsRuntime;

        public event Action? OnLanguageChanged;

        public I18nHelper(LocalizationService localizationService, IJSRuntime jsRuntime)
        {
            this.localizationService = localizationService;
            _jsRuntime = jsRuntime;

            _ = InitializeLanguage();
        }

        public async Task InitializeLanguage()
        {
            try
            {
                var languageFromCookie = await _jsRuntime.InvokeAsync<string>("getLanguageCookie");
                if (!string.IsNullOrEmpty(languageFromCookie))
                {
                    Language = languageFromCookie;
                }
                else
                {
                    await SetLanguageAsync(Language);
                }
            }
            catch // we create the cookie again anyway.
            {

                Console.WriteLine("couldn't load cookie");
                await SetLanguageAsync(Language);
            }

            _initializationTaskSource.SetResult(true);
        }

        // asynchronus call for use in Razor sites
        public async Task EnsureInitializedAsync()
        {
            await _initializationTaskSource.Task; 
        }


        // Ensures that the initialization is completed before continuing
        public void EnsureInitialized()
        {
            if (!_initializationTaskSource.Task.IsCompleted)
            {
                _initializationTaskSource.Task.Wait(); // Block synchronously until initialization is complete
            }               
        }

        public async Task SetLanguageAsync(String newLanguage)
        {
            if (!string.IsNullOrEmpty(newLanguage))
            {
                Language = newLanguage;
                await _jsRuntime.InvokeVoidAsync("setLanguageCookie", newLanguage);
                OnLanguageChanged?.Invoke();
            }
        }


        public bool IsCurrentLanguage(string currentLanguage)
        {
            return Language == currentLanguage;
        }

        // Retrieve the translation from the localization service

        public string Translate(string key)
        {
            EnsureInitialized();
            return localizationService.Translate(Language, key);
        }

        public string Translate(string key, params object[] args)
        {
            var translation = Translate(key);

            if (args.Length > 0)
            {
                try
                {
                    // Replace placeholders {0}, {1}, etc. with the provided arguments
                    translation = string.Format(translation, args);
                }
                catch (FormatException ex)
                {
                    Console.WriteLine($"Error formatting translation for key '{key}': {ex.Message}");
                }
            }
            return translation;
        }
    }
}
