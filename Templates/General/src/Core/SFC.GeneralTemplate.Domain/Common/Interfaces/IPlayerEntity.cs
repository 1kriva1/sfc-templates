#if IncludePlayerInfrastructure
namespace SFC.GeneralTemplate.Domain.Common.Interfaces;
public interface IPlayerEntity
{
    long PlayerId { get; set; }

    PlayerEntity Player { get; set; }
}
#endif