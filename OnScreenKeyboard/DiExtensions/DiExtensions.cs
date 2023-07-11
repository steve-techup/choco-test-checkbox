
using Microsoft.Extensions.DependencyInjection;
using OnScreenKeyboard.Models;

namespace OnScreenKeyboard.DiExtensions
{    public static class DiExtensions
    {
        public static IServiceCollection AddOnScreenKeyboard(this IServiceCollection services, OnScreenKeyboardConfig onScreenKeyboardConfig, string culture)
        {
            services.AddSingleton<OSK>();
            services.AddSingleton<OskUiController>();
            var instance = new OskUiController(onScreenKeyboardConfig, culture);
            return services;
        }
    }
}
