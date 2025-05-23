using System.Reflection;

using Google.Protobuf.WellKnownTypes;

using SFC.GeneralTemplate.Application.Common.Mappings.Base;
using SFC.GeneralTemplate.Application.Features.Data.Commands.Reset;
using SFC.GeneralTemplate.Application.Common.Extensions;
using SFC.GeneralTemplate.Application.Features.Identity.Commands.Create;
using SFC.GeneralTemplate.Application.Features.Identity.Commands.CreateRange;
using SFC.GeneralTemplate.Application.Common.Dto.Identity;
using SFC.GeneralTemplate.Messages.Events.GeneralTemplate.General;
#if IncludePlayerInfrastructure
using SFC.GeneralTemplate.Application.Features.Player.Commands.Create;
using SFC.GeneralTemplate.Application.Features.Player.Commands.Update;
using SFC.GeneralTemplate.Application.Features.Player.Commands.CreateRange;
using SFC.GeneralTemplate.Application.Common.Dto.Player.General;
#endif
#if IncludeTeamInfrastructure
using SFC.GeneralTemplate.Application.Features.Team.General.Commands.CreateRange;
using SFC.GeneralTemplate.Application.Common.Dto.Team.General;
using SFC.GeneralTemplate.Application.Features.Team.General.Commands.Create;
using SFC.GeneralTemplate.Application.Features.Team.General.Commands.Update;
#endif
#if (IncludePlayerInfrastructure || IncludeTeamInfrastructure)
using SFC.GeneralTemplate.Application.Features.Data.Common.Dto;
#endif
#if (IncludePlayerInfrastructure && IncludeTeamInfrastructure)
using SFC.GeneralTemplate.Application.Features.Team.Data.Commands.Reset;
using SFC.GeneralTemplate.Application.Features.Team.Data.Common.Dto;
using SFC.GeneralTemplate.Application.Features.Team.Player.Commands.Create;
using SFC.GeneralTemplate.Application.Features.Team.Player.Commands.Update;
using SFC.GeneralTemplate.Application.Features.Team.Player.Commands.CreateRange;
using SFC.GeneralTemplate.Application.Common.Dto.Team.Player;
#endif

namespace SFC.GeneralTemplate.Infrastructure.Mapping;
public class MappingProfile : BaseMappingProfile
{
    protected override Assembly Assembly => Assembly.GetExecutingAssembly();

    public MappingProfile() : base()
    {
        ApplyCustomMappings();
    }

    private void ApplyCustomMappings()
    {
        #region Simple types       

        CreateMap<Timestamp, DateTime>()
           .ConvertUsing(value => value.ToDateTime());

        CreateMap<Duration, TimeSpan>()
            .ConvertUsing(value => value.ToTimeSpan());

        #endregion Simple types

        #region Data

        // messages        
        CreateMapDataMessages();

        #endregion Data

        #region Identity

        // messages        
        CreateMapIdentityMessages();

        // contracts        
        CreateMapIdentityContracts();

        #endregion Identity

#if IncludePlayerInfrastructure
        #region Player

        // messages
        CreateMapPlayerMessages();

        // contracts
        CreateMapPlayerContracts();

        #endregion Player
#endif

#if IncludeTeamInfrastructure
        #region Team

        CreateMapTeamMessages();

        #endregion Team
#endif

        #region GeneralTemplate

        // messages
        CreateMapGeneralTemplateMessages();

        // contracts
        CreateMapGeneralTemplateContracts();

        #endregion GeneralTemplate
    }

    #region Data

    private void CreateMapDataMessages()
    {
        CreateMap<SFC.Data.Messages.Events.DataInitialized, ResetDataCommand>().IgnoreAllNonExisting();
#if IncludePlayerInfrastructure
        CreateMap<SFC.Data.Messages.Models.Common.DataValue, FootballPositionDto>();
        CreateMap<SFC.Data.Messages.Models.Common.DataValue, GameStyleDto>();
        CreateMap<SFC.Data.Messages.Models.Common.DataValue, StatCategoryDto>();
        CreateMap<SFC.Data.Messages.Models.Common.DataValue, StatSkillDto>();
        CreateMap<SFC.Data.Messages.Models.Stats.StatTypeDataValue, StatTypeDto>();
        CreateMap<SFC.Data.Messages.Models.Common.DataValue, WorkingFootDto>();
#endif
#if IncludeTeamInfrastructure
        CreateMap<SFC.Data.Messages.Models.Common.DataValue, ShirtDto>();
#endif
    }

    #endregion Data

    #region Identity

    private void CreateMapIdentityMessages()
    {
        CreateMap<SFC.Identity.Messages.Events.UserCreated, CreateUserCommand>().IgnoreAllNonExisting();

        CreateMap<IEnumerable<SFC.Identity.Messages.Models.User>, CreateUsersCommand>()
            .ForMember(p => p.Users, d => d.MapFrom(z => z));

        CreateMap<SFC.Identity.Messages.Models.User, UserDto>();
    }

    private void CreateMapIdentityContracts()
    {
        CreateMap<Guid, SFC.Identity.Contracts.Messages.Get.GetUserRequest>()
            .ConvertUsing(id => new SFC.Identity.Contracts.Messages.Get.GetUserRequest { Id = id.ToString() });
        CreateMap<SFC.Identity.Contracts.Models.Get.User, UserDto>();
    }

    #endregion Identity

#if IncludePlayerInfrastructure
    #region Player

    private void CreateMapPlayerMessages()
    {
        CreateMap<SFC.Player.Messages.Events.PlayerCreated, CreatePlayerCommand>().IgnoreAllNonExisting();

        CreateMap<SFC.Player.Messages.Events.PlayerUpdated, UpdatePlayerCommand>().IgnoreAllNonExisting();

        CreateMap<SFC.Player.Messages.Events.PlayerUpdated, CreatePlayerCommand>().IgnoreAllNonExisting();

        CreateMap<IEnumerable<SFC.Player.Messages.Models.Player.Player>, CreatePlayersCommand>()
            .ForMember(p => p.Players, d => d.MapFrom(z => z));

        CreateMap<SFC.Player.Messages.Commands.Player.SeedPlayers, CreatePlayersCommand>();

        CreateMap<SFC.Player.Messages.Models.Player.Player, PlayerDto>()
            .ForPath(p => p.Stats.Values, d => d.MapFrom(z => z.Stats))
            .ForPath(p => p.Stats.Points, d => d.MapFrom(z => z.Points))
            .ForPath(p => p.Profile.General, d => d.MapFrom(z => z.GeneralProfile))
            .ForPath(p => p.Profile.Football, d => d.MapFrom(z => z.FootballProfile))
            .ForPath(p => p.Profile.General.Photo, d => d.MapFrom(z => z.Photo))
            .ForPath(p => p.Profile.General.Availability, d => d.MapFrom(z => z.Availability))
            .ForPath(p => p.Profile.General.Tags, d => d.MapFrom(z => z.Tags));

        // stats
        CreateMap<SFC.Player.Messages.Models.Player.PlayerStat, PlayerStatValueDto>()
            .ForPath(p => p.Type, d => d.MapFrom(z => z.TypeId));
        CreateMap<SFC.Player.Messages.Models.Player.PlayerStatPoints, PlayerStatPointsDto>();

        // general profile
        CreateMap<SFC.Player.Messages.Models.Player.PlayerGeneralProfile, PlayerGeneralProfileDto>();
        CreateMap<SFC.Player.Messages.Models.Player.PlayerPhoto, PlayerPhotoDto>();
        CreateMap<SFC.Player.Messages.Models.Player.PlayerAvailability, PlayerAvailabilityDto>();
        CreateMap<SFC.Player.Messages.Models.Player.PlayerAvailableDay, DayOfWeek>().ConvertUsing(day => day.Day);
        CreateMap<SFC.Player.Messages.Models.Player.PlayerTag, string>().ConvertUsing(tag => tag.Value);

        // football profile
        CreateMap<SFC.Player.Messages.Models.Player.PlayerFootballProfile, PlayerFootballProfileDto>()
            .ForPath(p => p.AdditionalPosition, d => d.MapFrom(z => z.AdditionalPositionId))
            .ForPath(p => p.Position, d => d.MapFrom(z => z.PositionId))
            .ForPath(p => p.GameStyle, d => d.MapFrom(z => z.GameStyleId))
            .ForPath(p => p.WorkingFoot, d => d.MapFrom(z => z.WorkingFootId));
    }

    private void CreateMapPlayerContracts()
    {
        CreateMap<long, SFC.Player.Contracts.Messages.Get.GetPlayerRequest>()
            .ConvertUsing(id => new SFC.Player.Contracts.Messages.Get.GetPlayerRequest { Id = id });

        CreateMap<SFC.Player.Contracts.Models.Get.GetPlayer, PlayerDto>();
        CreateMap<SFC.Player.Contracts.Models.Get.GetPlayerProfile, PlayerProfileDto>();
        CreateMap<SFC.Player.Contracts.Models.Get.GetPlayerGeneralProfile, PlayerGeneralProfileDto>();
        CreateMap<SFC.Player.Contracts.Models.Common.Player.PlayerAvailability, PlayerAvailabilityDto>();
        CreateMap<SFC.Player.Contracts.Models.Get.GetPlayerFootballProfile, PlayerFootballProfileDto>();
        CreateMap<SFC.Player.Contracts.Models.Get.GetPlayerStats, PlayerStatsDto>();
        CreateMap<SFC.Player.Contracts.Models.Get.GetPlayerStatPoints, PlayerStatPointsDto>();
        CreateMap<SFC.Player.Contracts.Models.Common.Player.PlayerStatValue, PlayerStatValueDto>();
    }

    #endregion Player
#endif

#if IncludeTeamInfrastructure
    #region Team

    private void CreateMapTeamMessages()
    {
#if (IncludePlayerInfrastructure && IncludeTeamInfrastructure)
        // data
        // events
        CreateMap<SFC.Team.Messages.Events.Data.DataInitialized, ResetTeamDataCommand>().IgnoreAllNonExisting();
        // models
        CreateMap<SFC.Team.Messages.Models.Common.DataValue, TeamPlayerStatusDto>();
#endif

        // domain
        // team
        // events
        CreateMap<SFC.Team.Messages.Events.Team.General.TeamCreated, CreateTeamCommand>().IgnoreAllNonExisting();
        CreateMap<SFC.Team.Messages.Events.Team.General.TeamUpdated, UpdateTeamCommand>().IgnoreAllNonExisting();
        CreateMap<SFC.Team.Messages.Events.Team.General.TeamUpdated, CreateTeamCommand>().IgnoreAllNonExisting();
        // commands
        CreateMap<SFC.Team.Messages.Commands.Team.General.SeedTeams, CreateTeamsCommand>();
        // models
        CreateMap<IEnumerable<SFC.Team.Messages.Models.Team.General.Team>, CreateTeamsCommand>()
           .ForMember(p => p.Teams, d => d.MapFrom(z => z));
        CreateMap<SFC.Team.Messages.Models.Team.General.Team, TeamDto>()
           .ForPath(p => p.Profile.General, d => d.MapFrom(z => z.GeneralProfile))
           .ForPath(p => p.Profile.Financial, d => d.MapFrom(z => z.FinancialProfile))
           .ForPath(p => p.Profile.Inventary.Shirts, d => d.MapFrom(z => z.Shirts))
           .ForPath(p => p.Profile.General.Logo, d => d.MapFrom(z => z.Logo))
           .ForPath(p => p.Profile.General.Availability, d => d.MapFrom(z => z.Availability))
           .ForPath(p => p.Profile.General.Tags, d => d.MapFrom(z => z.Tags));
        CreateMap<SFC.Team.Messages.Models.Team.General.TeamGeneralProfile, TeamGeneralProfileDto>();
        CreateMap<SFC.Team.Messages.Models.Team.General.TeamFinancialProfile, TeamFinancialProfileDto>();
        CreateMap<SFC.Team.Messages.Models.Team.General.TeamLogo, TeamLogoDto>();
        CreateMap<SFC.Team.Messages.Models.Team.General.TeamAvailability, TeamAvailabilityDto>();
        CreateMap<SFC.Team.Messages.Models.Team.General.TeamTag, string>().ConvertUsing(tag => tag.Value);
        CreateMap<SFC.Team.Messages.Models.Team.General.TeamShirt, int>().ConvertUsing(shirt => shirt.ShirtId);
#if (IncludePlayerInfrastructure && IncludeTeamInfrastructure)
        // team player
        // events
        CreateMap<SFC.Team.Messages.Events.Team.Player.TeamPlayerCreated, CreateTeamPlayerCommand>().IgnoreAllNonExisting();
        CreateMap<SFC.Team.Messages.Events.Team.Player.TeamPlayerUpdated, UpdateTeamPlayerCommand>().IgnoreAllNonExisting();
        // models
        CreateMap<IEnumerable<SFC.Team.Messages.Models.Team.Player.TeamPlayer>, CreateTeamPlayersCommand>()
           .ForMember(p => p.TeamPlayers, d => d.MapFrom(z => z));
        CreateMap<SFC.Team.Messages.Models.Team.Player.TeamPlayer, TeamPlayerDto>();
#endif
    }

#endregion Team
#endif

    #region GeneralTemplate

    private void CreateMapGeneralTemplateMessages()
    {
        // data
        //commands
        CreateMap<SFC.GeneralTemplate.Messages.Commands.Data.InitializeData, ResetDataCommand>().IgnoreAllNonExisting();
#if IncludePlayerInfrastructure
        CreateMap<SFC.GeneralTemplate.Messages.Models.Data.DataValue, FootballPositionDto>();
        CreateMap<SFC.GeneralTemplate.Messages.Models.Data.DataValue, GameStyleDto>();
        CreateMap<SFC.GeneralTemplate.Messages.Models.Data.DataValue, StatCategoryDto>();
        CreateMap<SFC.GeneralTemplate.Messages.Models.Data.DataValue, StatSkillDto>();
        CreateMap<SFC.GeneralTemplate.Messages.Models.Data.StatTypeDataValue, StatTypeDto>();
        CreateMap<SFC.GeneralTemplate.Messages.Models.Data.DataValue, WorkingFootDto>();
#endif
#if IncludeTeamInfrastructure
        CreateMap<SFC.GeneralTemplate.Messages.Models.Data.DataValue, ShirtDto>();
#endif

#if (IncludePlayerInfrastructure && IncludeTeamInfrastructure)
        // team
        // commands
        CreateMap<SFC.GeneralTemplate.Messages.Commands.Team.Data.InitializeData, ResetTeamDataCommand>().IgnoreAllNonExisting();
        //models
        CreateMap<SFC.GeneralTemplate.Messages.Models.Data.DataValue, TeamPlayerStatusDto>();
#endif

        // generaltemplate
        // events
        CreateMap<GeneralTemplateEntity, GeneralTemplateCreated>()
            .ForMember(p => p.GeneralTemplate, d => d.MapFrom(z => z));
        CreateMap<GeneralTemplateEntity, GeneralTemplateUpdated>()
            .ForMember(p => p.GeneralTemplate, d => d.MapFrom(z => z));
        CreateMap<IEnumerable<GeneralTemplateEntity>, GeneralTemplateMultipleSeeded>()
           .ForMember(p => p.GeneralTemplateMultiple, d => d.MapFrom(z => z));
        //commands
        CreateMap<IEnumerable<GeneralTemplateEntity>, SFC.GeneralTemplate.Messages.Commands.GeneralTemplate.SeedGeneralTemplateMultiple>()
            .ForMember(p => p.GeneralTemplateMultiple, d => d.MapFrom(z => z));
        // models
        CreateMap<GeneralTemplateEntity, SFC.GeneralTemplate.Messages.Models.GeneralTemplate.GeneralTemplate>();
    }

    private static void CreateMapGeneralTemplateContracts()
    {

    }

#endregion GeneralTemplate
}
