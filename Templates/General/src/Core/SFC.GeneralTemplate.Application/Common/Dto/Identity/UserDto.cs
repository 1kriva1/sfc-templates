using SFC.GeneralTemplate.Application.Common.Mappings.Interfaces;
using SFC.GeneralTemplate.Application.Features.Common.Dto.Base;
using SFC.GeneralTemplate.Domain.Entities.Identity;

namespace SFC.GeneralTemplate.Application.Common.Dto.Identity;
public class UserDto : BaseAuditableDto, IMapTo<User>
{
    public Guid Id { get; set; }
}