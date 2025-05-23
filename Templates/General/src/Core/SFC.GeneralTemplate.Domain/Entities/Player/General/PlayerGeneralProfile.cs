﻿#if IncludePlayerInfrastructure
namespace SFC.GeneralTemplate.Domain.Entities.Player.General;
public class PlayerGeneralProfile : BasePlayerEntity
{
    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string? Biography { get; set; }

    public DateTime? Birthday { get; set; }

    public string City { get; set; } = null!;

    public bool FreePlay { get; set; }
}
#endif