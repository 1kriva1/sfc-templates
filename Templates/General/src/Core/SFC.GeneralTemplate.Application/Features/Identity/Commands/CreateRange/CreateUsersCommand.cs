using SFC.GeneralTemplate.Application.Common.Dto.Identity;
using SFC.GeneralTemplate.Application.Common.Enums;
using SFC.GeneralTemplate.Application.Features.Common.Base;

namespace SFC.GeneralTemplate.Application.Features.Identity.Commands.CreateRange;
public class CreateUsersCommand : Request
{
    public override RequestId RequestId { get => RequestId.CreateUsers; }

    public IEnumerable<UserDto> Users { get; set; } = null!;
}
