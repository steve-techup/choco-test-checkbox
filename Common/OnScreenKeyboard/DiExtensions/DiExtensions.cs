using Common.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace OnScreenKeyboard.DiExtensions;

public static class DiExtensions
{
    public static IServiceCollection AddOnScreenKeyboard(this IServiceCollection services, OnScreenKeyboardConfig onScreenKeyboardConfig)
    {
        services.AddSingleton<OSK>();
        services.AddSingleton<OskUiController>();
        var instance = new OskUiController(onScreenKeyboardConfig);
        return services;
    }
}