using System.Text.Json.Serialization;
using TmEssentials;
using TmEssentials.Converters;

using ManiaAPI.TMX.Attributes;

namespace ManiaAPI.TMX;

[Fields]
public record struct MapMedals(
    [property: JsonConverter(typeof(JsonTimeInt32Converter))] TimeInt32 Author,
    [property: JsonConverter(typeof(JsonTimeInt32Converter))] TimeInt32 Gold,
    [property: JsonConverter(typeof(JsonTimeInt32Converter))] TimeInt32 Silver,
    [property: JsonConverter(typeof(JsonTimeInt32Converter))] TimeInt32 Bronze);