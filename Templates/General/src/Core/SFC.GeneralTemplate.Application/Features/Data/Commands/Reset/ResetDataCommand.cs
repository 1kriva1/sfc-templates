using SFC.GeneralTemplate.Application.Common.Enums;
using SFC.GeneralTemplate.Application.Features.Common.Base;
#if (IncludePlayerInfrastructure || IncludeTeamInfrastructure)
using SFC.GeneralTemplate.Application.Features.Data.Common.Dto;
#endif

namespace SFC.GeneralTemplate.Application.Features.Data.Commands.Reset;
public class ResetDataCommand : Request
{
    public override RequestId RequestId { get => RequestId.ResetData; }

#if IncludePlayerInfrastructure
    public IEnumerable<FootballPositionDto> FootballPositions { get; init; } = [];

    public IEnumerable<GameStyleDto> GameStyles { get; init; } = [];

    public IEnumerable<StatCategoryDto> StatCategories { get; init; } = [];

    public IEnumerable<StatSkillDto> StatSkills { get; init; } = [];

    public IEnumerable<StatTypeDto> StatTypes { get; init; } = [];

    public IEnumerable<WorkingFootDto> WorkingFoots { get; init; } = [];
#endif

#if IncludeTeamInfrastructure
    public IEnumerable<ShirtDto> Shirts { get; init; } = [];
#endif
}
