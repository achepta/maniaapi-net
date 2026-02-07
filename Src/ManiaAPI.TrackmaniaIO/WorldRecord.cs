using System.Text.Json.Serialization;
using TmEssentials;
using TmEssentials.Converters;

namespace ManiaAPI.TrackmaniaIO;

public sealed record WorldRecord(int Id,
                                 string Group,
                                 Map Map,
                                 Player Player,
                                 DateTimeOffset DrivenAt,
                                 [property: JsonConverter(typeof(JsonTimeInt32Converter))] TimeInt32 Time, 
                                 int TimeDiff, 
                                 int Type);