using System.Text.Json.Serialization;

namespace ManiaAPI.NadeoAPI;

public sealed record ErrorResponse(string Code, [property: JsonPropertyName("correlation_id")] string CorrelationId, string Message, Dictionary<string, string> Info);