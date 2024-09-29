using EventHorizon.src.Util;
using Microsoft.AspNetCore.Components;

namespace EventHorizon.src.Ui
{
    /// <summary>
    /// Triggers an Update when the language has been changed.
    /// </summary>
    public class BaseComponent : ComponentBase
    {
        [Inject]
        protected I18nHelper I18n { get; set; } = default!;


        protected override void OnInitialized()
        {
            I18n.OnLanguageChanged += UpdateUI;
        }

        private void UpdateUI()
        {
            InvokeAsync(StateHasChanged);
        }

        public virtual void Dispose()
        {
            I18n.OnLanguageChanged -= UpdateUI;
        }
    }
}

