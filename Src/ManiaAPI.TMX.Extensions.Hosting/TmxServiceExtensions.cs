using Microsoft.Extensions.DependencyInjection;
using System.Collections.Immutable;

namespace ManiaAPI.TMX.Extensions.Hosting;

public static class TmxServiceExtensions
{

    public static void AddTMX(this IServiceCollection services, Action<TmxClientOptions>? configureOptions = null)
    {
        var options = new TmxClientOptions();
        configureOptions?.Invoke(options);

        foreach (var site in Enum.GetValues<TmxSite>())
        {
            if (site.isMX()) {
                var builder = services.AddHttpClient($"{nameof(MX)}_{site}");
                options.ConfigureHttpClient?.Invoke(builder);
                
                services.AddKeyedScoped(site, (provider, key) => new MX(
                    provider.GetRequiredService<IHttpClientFactory>().CreateClient($"{nameof(MX)}_{key}"), site, new TmxOptions { UserAgent = options.UserAgent}));
                services.AddScoped(provider => provider.GetRequiredKeyedService<MX>(site));
            }
            else {
                var builder = services.AddHttpClient($"{nameof(TMX)}_{site}");
                options.ConfigureHttpClient?.Invoke(builder);
                
                services.AddKeyedScoped(site, (provider, key) => new TMX(
                    provider.GetRequiredService<IHttpClientFactory>().CreateClient($"{nameof(TMX)}_{key}"), site, new TmxOptions { UserAgent = options.UserAgent}));
                services.AddScoped(provider => provider.GetRequiredKeyedService<TMX>(site));
            }
        }

        services.AddScoped(provider => Enum.GetValues<TmxSite>().Where(site => site.isMX())
            .ToImmutableDictionary(site => site, site => provider.GetRequiredKeyedService<MX>(site)));
        services.AddScoped(provider => Enum.GetValues<TmxSite>().Where(site => !site.isMX())
            .ToImmutableDictionary(site => site, site => provider.GetRequiredKeyedService<TMX>(site)));
    }
}
