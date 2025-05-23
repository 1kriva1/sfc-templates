#if IncludeTeamInfrastructure
using SFC.GeneralTemplate.Application.Common.Dto.Data;
using SFC.GeneralTemplate.Application.Common.Mappings.Interfaces;
using SFC.GeneralTemplate.Domain.Entities.Data;

namespace SFC.GeneralTemplate.Application.Features.Data.Common.Dto;
public class ShirtDto : DataDto, IMapTo<Shirt> { }
#endif