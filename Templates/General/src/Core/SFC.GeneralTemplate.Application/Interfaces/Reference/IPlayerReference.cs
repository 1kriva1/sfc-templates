#if IncludePlayerInfrastructure
using SFC.GeneralTemplate.Application.Common.Dto.Player.General;

namespace SFC.GeneralTemplate.Application.Interfaces.Reference;
public interface IPlayerReference : IReference<PlayerEntity, long, PlayerDto> { }
#endif