using Microsoft.Extensions.DependencyInjection;
using System.Collections.Immutable;

namespace ManiaAPI.TMX.Extensions.Hosting;

public static class TmxServiceExtensions
{
    private static readonly TmxSite[] TmxSites = [TmxSite.TMUF, TmxSite.TMNF, TmxSite.Nations, TmxSite.Sunrise, TmxSite.Original];
    private static readonly TmxSite[] Tmx2Sites = [TmxSite.Maniaplanet, TmxSite.Trackmania, TmxSite.Shootmania];

    public static void AddTMX(this IServiceCollection services, Action<TmxOptions>? configureOptions = null)
    {
        var options = new TmxOptions();
        configureOptions?.Invoke(options);

        foreach (var site in TmxSites)
        {
            services.AddHttpClient($"{nameof(TMX)}_{site}");

            services.AddKeyedScoped(site, (provider, key) => new TMX(
                provider.GetRequiredService<IHttpClientFactory>().CreateClient($"{nameof(TMX)}_{key}"), site, options));
            services.AddScoped(provider => provider.GetRequiredKeyedService<TMX>(site));
        }

        services.AddScoped(provider => TmxSites
            .ToImmutableDictionary(site => site, site => provider.GetRequiredKeyedService<TMX>(site)));
    }

    public static void AddMX(this IServiceCollection services, Action<TmxOptions>? configureOptions = null)
    {
        var options = new TmxOptions();
        configureOptions?.Invoke(options);

        foreach (var site in Tmx2Sites)
        {
            services.AddHttpClient($"{nameof(MX)}_{site}");

            services.AddKeyedScoped(site, (provider, key) => new MX(
                provider.GetRequiredService<IHttpClientFactory>().CreateClient($"{nameof(MX)}_{key}"), site, options));
            services.AddScoped(provider => provider.GetRequiredKeyedService<MX>(site));
        }

        services.AddScoped(provider => Tmx2Sites
            .ToImmutableDictionary(site => site, site => provider.GetRequiredKeyedService<MX>(site)));
    }
}
