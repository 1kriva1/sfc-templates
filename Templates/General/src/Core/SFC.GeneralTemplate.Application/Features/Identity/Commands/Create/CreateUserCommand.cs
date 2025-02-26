using SFC.GeneralTemplate.Application.Common.Dto.Identity;
using SFC.GeneralTemplate.Application.Common.Enums;
using SFC.GeneralTemplate.Application.Features.Common.Base;

namespace SFC.GeneralTemplate.Application.Features.Identity.Commands.Create;
public class CreateUserCommand : Request
{
    public override RequestId RequestId { get => RequestId.CreateUser; }

    public UserDto User { get; set; } = null!;
}
