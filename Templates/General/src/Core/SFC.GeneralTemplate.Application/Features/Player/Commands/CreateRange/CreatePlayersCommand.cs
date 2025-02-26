#if IncludePlayerInfrastructure
using SFC.GeneralTemplate.Application.Common.Dto.Player.General;
using SFC.GeneralTemplate.Application.Common.Enums;
using SFC.GeneralTemplate.Application.Features.Common.Base;

namespace SFC.GeneralTemplate.Application.Features.Player.Commands.CreateRange;
public class CreatePlayersCommand : Request
{
    public override RequestId RequestId { get => RequestId.CreatePlayers; }

    public IEnumerable<PlayerDto> Players { get; set; } = null!;
}
#endif