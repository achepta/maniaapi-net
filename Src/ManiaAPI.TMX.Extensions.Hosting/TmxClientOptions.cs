using Microsoft.Extensions.DependencyInjection;

namespace ManiaAPI.TMX.Extensions.Hosting;

public sealed class TmxClientOptions
{
    /// <summary>
    /// User-Agent appended to all TMX clients.
    /// </summary>
    public string UserAgent { get; set; } = "ManiaAPI.NET/2.6.0 (TMX; Discord=bigbang1112)";

    public Action<IHttpClientBuilder>? ConfigureHttpClient { get; set; }
}
