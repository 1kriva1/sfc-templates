﻿#if IncludePlayerInfrastructure
namespace SFC.GeneralTemplate.Domain.Entities.Player;
public class PlayerFootballProfile : BasePlayerEntity
{
    public short? Height { get; set; }

    public short? Weight { get; set; }

    public FootballPositionEnum? PositionId { get; set; }

    public FootballPositionEnum? AdditionalPositionId { get; set; }

    public WorkingFootEnum? WorkingFootId { get; set; }

    public short? Number { get; set; }

    public GameStyleEnum? GameStyleId { get; set; }

    public byte? Skill { get; set; }

    public byte? WeakFoot { get; set; }

    public byte? PhysicalCondition { get; set; }
}
#endif