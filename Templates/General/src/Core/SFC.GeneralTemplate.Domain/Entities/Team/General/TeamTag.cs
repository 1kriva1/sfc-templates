﻿#if IncludeTeamInfrastructure
namespace SFC.GeneralTemplate.Domain.Entities.Team.General;
public class TeamTag : BaseTeamEntity
{
    public required string Value { get; set; }
}
#endif