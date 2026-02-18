using ManiaAPI.TMX.Attributes;

namespace ManiaAPI.TMX;

[Fields]
public record struct MapFeature(string? Comment, bool Pinned);