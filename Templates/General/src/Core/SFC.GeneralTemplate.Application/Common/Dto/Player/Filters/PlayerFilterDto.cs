﻿#if IncludePlayerInfrastructure
namespace SFC.GeneralTemplate.Application.Common.Dto.Player.Filters;
public class PlayerFilterDto
{
    public PlayerProfileFilterDto Profile { get; set; } = default!;

    public PlayerStatsFilterDto Stats { get; set; } = default!;
}
#endif