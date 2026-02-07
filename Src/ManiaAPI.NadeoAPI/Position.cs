using System.Collections.Immutable;
using System.Text.Json.Serialization;
using TmEssentials;
using TmEssentials.Converters;

namespace ManiaAPI.NadeoAPI;

public sealed record Position(string GroupUid,
                              string MapUid,
                              [property: JsonConverter(typeof(JsonTimeInt32Converter))] TimeInt32 Score,
                              ImmutableList<SeasonPlayerRankingZone> Zones);