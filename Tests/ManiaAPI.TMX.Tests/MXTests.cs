using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace ManiaAPI.TMX.Tests;

public class MXTests
{
    [Theory]
    [InlineData(TmxSite.Trackmania)]
    [InlineData(TmxSite.Maniaplanet)]
    // Medals don't exist on shootmania, so need to specify fields manually
    public async Task SearchMapsAsync_Success(TmxSite site)
    {
        var tmx = new MX(site);
        var maps = await tmx.SearchMapsAsync(new ());
        using var mapGbxResponse = await tmx.GetMapGbxResponseAsync(maps.Results.First());
        using var mapThumbnailResponse = await tmx.GetMapThumbnailResponseAsync(maps.Results.First());
        Assert.NotEmpty(maps.Results);
        Assert.NotNull(mapGbxResponse);
        Assert.NotNull(mapThumbnailResponse);
    }

    [Theory]
    [InlineData(TmxSite.Trackmania, 120839)]
    [InlineData(TmxSite.Maniaplanet, 224915)]
    [InlineData(TmxSite.Shootmania, 5202)]
    public async Task GetMapImageResponseAsync_Success(TmxSite site, long mapId)
    {
        var tmx = new MX(site);
        var image = await tmx.GetMapImageResponseAsync(mapId);
        Assert.NotNull(image);
        var image1 = await tmx.GetMapImageResponseAsync(mapId, 1);
        Assert.NotNull(image1);
    }

    [Theory]
    [InlineData(TmxSite.Trackmania, 120839)]
    [InlineData(TmxSite.Maniaplanet, 224915)]
    [InlineData(TmxSite.Shootmania, 5202)]
    public async Task GetMapScreenResponseAsync_Success(TmxSite site, long mapId)
    {
        var tmx = new MX(site);
        var image = await tmx.GetMapScreenResponseAsync(mapId);
        Assert.NotNull(image);
        var image1 = await tmx.GetMapScreenResponseAsync(mapId, 1);
        Assert.NotNull(image1);
    }

    [Theory]
    [InlineData(TmxSite.Trackmania, 120839)]
    [InlineData(TmxSite.Maniaplanet, 224915)]
    [InlineData(TmxSite.Shootmania, 5202)]
    public async Task GetMapThumbnailResponseAsync_Success(TmxSite site, long mapId)
    {
        var tmx = new MX(site);
        var image = await tmx.GetMapThumbnailResponseAsync(mapId);
        Assert.NotNull(image);
    }

    [Theory]
    [InlineData(TmxSite.Trackmania, 1729)]
    [InlineData(TmxSite.Maniaplanet, 1388)]
    [InlineData(TmxSite.Shootmania, 10)]
    public async Task GetMappackThumbnailResponseAsync_Success(TmxSite site, long mappackId)
    {
        var tmx = new MX(site);
        var image = await tmx.GetMappackThumbnailResponseAsync(mappackId);
        Assert.NotNull(image);
    }

    [Theory]
    [InlineData(TmxSite.Trackmania, 120839)]
    [InlineData(TmxSite.Maniaplanet, 224915)]
    // no replays for shootmania
    public async Task SearchReplaysAsync_Success(TmxSite site, long mapId)
    {
        var tmx = new MX(site);
        var replays = await tmx.SearchReplaysAsync(new MX.SearchReplaysParameters { MapId = mapId });
        Assert.NotEmpty(replays.Results);
    }

    [Theory]
    [InlineData(TmxSite.Trackmania)]
    [InlineData(TmxSite.Maniaplanet)]
    [InlineData(TmxSite.Shootmania)]
    public async Task SearchUsersAsync_Success(TmxSite site)
    {
        var tmx = new MX(site);
        var users = await tmx.SearchUsersAsync(new ());
        Assert.NotEmpty(users.Results);
    }

    [Theory]
    [InlineData(TmxSite.Trackmania)]
    [InlineData(TmxSite.Maniaplanet)]
    [InlineData(TmxSite.Shootmania)]
    public async Task SearchVideosAsync_Success(TmxSite site)
    {
        var tmx = new MX(site);
        var videos = await tmx.SearchVideosAsync(new ());
        Assert.NotEmpty(videos.Results);
    }

    [Theory]
    [InlineData(TmxSite.Trackmania)]
    [InlineData(TmxSite.Maniaplanet)]
    [InlineData(TmxSite.Shootmania)]
    public async Task SearchMappacksAsync_Success(TmxSite site)
    {
        var tmx = new MX(site);
        var mappacks = await tmx.SearchMappacksAsync(new ());
        Assert.NotEmpty(mappacks.Results);
    }

    [Theory]
    [InlineData(TmxSite.Trackmania)]
    [InlineData(TmxSite.Maniaplanet)]
    [InlineData(TmxSite.Shootmania)]
    public async Task GetMapSearchOrdersAsync_Success(TmxSite site)
    {
        var tmx = new MX(site);
        var orders = await tmx.GetMapSearchOrdersAsync();
        Assert.NotEmpty(orders);
    }

    [Theory]
    [InlineData(TmxSite.Trackmania)]
    [InlineData(TmxSite.Maniaplanet)]
    [InlineData(TmxSite.Shootmania)]
    public async Task GetUserSearchOrdersAsync_Success(TmxSite site)
    {
        var tmx = new MX(site);
        var orders = await tmx.GetUserSearchOrdersAsync();
        Assert.NotEmpty(orders);
    }

    [Theory]
    [InlineData(TmxSite.Trackmania)]
    [InlineData(TmxSite.Maniaplanet)]
    [InlineData(TmxSite.Shootmania)]
    public async Task GetMappackSearchOrdersAsync_Success(TmxSite site)
    {
        var tmx = new MX(site);
        var orders = await tmx.GetMappackSearchOrdersAsync();
        Assert.NotEmpty(orders);
    }

    [Theory]
    [InlineData(TmxSite.Trackmania)]
    [InlineData(TmxSite.Maniaplanet)]
    [InlineData(TmxSite.Shootmania)]
    public async Task GetTagsAsync_Success(TmxSite site)
    {
        var tmx = new MX(site);
        var tags = await tmx.GetTagsAsync();
        Assert.NotEmpty(tags);
    }

    [Theory]
    [InlineData(TmxSite.Trackmania)]
    [InlineData(TmxSite.Maniaplanet)]
    [InlineData(TmxSite.Shootmania)]
    public async Task GetMaptypesAsync_Success(TmxSite site)
    {
        var tmx = new MX(site);
        var maptypes = await tmx.GetMaptypesAsync();
        Assert.NotEmpty(maptypes);
    }

    [Theory]
    [InlineData(TmxSite.Trackmania)]
    [InlineData(TmxSite.Maniaplanet)]
    [InlineData(TmxSite.Shootmania)]
    public async Task GetVehiclesAsync_Success(TmxSite site)
    {
        var tmx = new MX(site);
        var vehicles = await tmx.GetVehiclesAsync();
        Assert.NotEmpty(vehicles);
    }

    [Theory]
    [InlineData(TmxSite.Trackmania)]
    [InlineData(TmxSite.Maniaplanet)]
    [InlineData(TmxSite.Shootmania)]
    public async Task GetTitlepacksAsync_Success(TmxSite site)
    {
        var tmx = new MX(site);
        var titlepacks = await tmx.GetTitlepacksAsync();
        Assert.NotEmpty(titlepacks);
    }
}