﻿#if IncludePlayerInfrastructure
using SFC.GeneralTemplate.Domain.Common;

namespace SFC.GeneralTemplate.Domain.Entities.Player;
public class PlayerTag : BasePlayerEntity
{
    public string Value { get; set; } = null!;
}
#endif