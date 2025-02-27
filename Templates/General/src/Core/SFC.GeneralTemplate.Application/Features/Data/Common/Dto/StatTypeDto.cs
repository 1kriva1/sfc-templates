#if IncludePlayerInfrastructure
using SFC.GeneralTemplate.Application.Common.Mappings.Interfaces;
using SFC.GeneralTemplate.Domain.Entities.Data;

namespace SFC.GeneralTemplate.Application.Features.Data.Common.Dto;
public class StatTypeDto : DataDto, IMapTo<StatType>
{
    public int CategoryId { get; set; }

    public int SkillId { get; set; }
}
#endif