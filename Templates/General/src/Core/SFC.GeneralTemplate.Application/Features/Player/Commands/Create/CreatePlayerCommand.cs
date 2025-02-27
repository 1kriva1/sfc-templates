#if IncludePlayerInfrastructure
using SFC.GeneralTemplate.Application.Common.Dto.Player.General;
using SFC.GeneralTemplate.Application.Common.Enums;
using SFC.GeneralTemplate.Application.Features.Common.Base;

namespace SFC.GeneralTemplate.Application.Features.Player.Commands.Create;
public class CreatePlayerCommand : Request
{
    public override RequestId RequestId { get => RequestId.CreatePlayer; }

    public PlayerDto Player { get; set; } = null!;
}
#endif