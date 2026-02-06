using System.Collections.Immutable;

namespace ManiaAPI.NadeoAPI;

public sealed record MapGroupIdCollection(ImmutableList<MapGroupId> Maps);