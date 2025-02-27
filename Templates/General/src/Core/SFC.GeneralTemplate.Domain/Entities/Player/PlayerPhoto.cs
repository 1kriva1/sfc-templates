﻿#if IncludePlayerInfrastructure
using SFC.GeneralTemplate.Domain.Enums.Data;

namespace SFC.GeneralTemplate.Domain.Entities.Player;
public class PlayerPhoto : BasePlayerEntity
{
#pragma warning disable CA1819 // Properties should not return arrays
    public byte[] Source { get; set; } = [];
#pragma warning restore CA1819 // Properties should not return arrays

    public string Name { get; set; } = string.Empty;

    public required PhotoExtension Extension { get; set; }

    public int Size { get; set; }
}
#endif