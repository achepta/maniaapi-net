using System.Collections.Immutable;

namespace ManiaAPI.NadeoAPI;

public sealed record CupOfTheDayCollection(ImmutableList<CupOfTheDay> COTDs);