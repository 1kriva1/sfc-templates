#if IncludePlayerInfrastructure
using SFC.GeneralTemplate.Application.Common.Dto.Player.General;
using SFC.GeneralTemplate.Application.Common.Enums;
using SFC.GeneralTemplate.Application.Features.Common.Base;

namespace SFC.GeneralTemplate.Application.Features.Player.Commands.Update;
public class UpdatePlayerCommand : Request
{
    public override RequestId RequestId { get => RequestId.UpdatePlayer; }

    public PlayerDto Player { get; set; } = null!;
}
#endif