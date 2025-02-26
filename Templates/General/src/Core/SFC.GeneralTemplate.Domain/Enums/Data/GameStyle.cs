#if IncludePlayerInfrastructure
using System.ComponentModel;

namespace SFC.GeneralTemplate.Domain.Enums.Data;
public enum GameStyle
{
    Defend = 0,
    Attacking = 1,
    Aggressive = 2,
    [Description("Counter Attacks")]
    CounterAttacks = 3
}
#endif