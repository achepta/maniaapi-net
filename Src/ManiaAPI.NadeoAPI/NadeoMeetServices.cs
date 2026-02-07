namespace ManiaAPI.NadeoAPI;

public interface INadeoMeetServices : INadeoAPI
{
    Task<CupOfTheDay?> GetCurrentCupOfTheDayAsync(CancellationToken cancellationToken = default);
    Task<CupOfTheDayCollection> GetCupsOfTheDayAsync(CupOfTheDayType type, int length = 10, int offset = 0, CancellationToken cancellationToken = default);
}

public class NadeoMeetServices : NadeoAPI, INadeoMeetServices
{
    public override string Audience => nameof(NadeoLiveServices);
    public override string BaseAddress => "https://meet.trackmania.nadeo.club/api";

    public NadeoMeetServices(HttpClient client, NadeoAPIHandler? handler = null, bool automaticallyAuthorize = true)
        : base(client, handler ?? new NadeoAPIHandler(), automaticallyAuthorize)
    {
    }

    public NadeoMeetServices(bool automaticallyAuthorize = true) : this(new HttpClient(), new NadeoAPIHandler(), automaticallyAuthorize)
    {
    }

    public virtual async Task<CupOfTheDay?> GetCurrentCupOfTheDayAsync(CancellationToken cancellationToken = default)
    {
        return await GetNullableJsonAsync("cup-of-the-day/current", NadeoAPIJsonContext.Default.CupOfTheDay, cancellationToken);
    }

    public virtual async Task<CupOfTheDayCollection> GetCupsOfTheDayAsync(CupOfTheDayType type, int length = 10, int offset = 0, CancellationToken cancellationToken = default)
    {
        var typeStr = type switch
        {
            CupOfTheDayType.COTD => "cotd",
            CupOfTheDayType.COTW => "cotw",
            CupOfTheDayType.GrandRace => "grand_race",
            _ => throw new ArgumentOutOfRangeException(nameof(type), $"Not expected cup of the day type value: {type}")
        };

        return await GetJsonAsync($"cups-of-the-day?type={typeStr}&length={length}&offset={offset}", NadeoAPIJsonContext.Default.CupOfTheDayCollection, cancellationToken);
    }
}
