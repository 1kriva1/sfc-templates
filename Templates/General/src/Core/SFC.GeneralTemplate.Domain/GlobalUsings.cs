// metadata
global using MetadataServiceEnum = SFC.GeneralTemplate.Domain.Enums.Metadata.MetadataService;
global using MetadataTypeEnum = SFC.GeneralTemplate.Domain.Enums.Metadata.MetadataType;
global using MetadataStateEnum = SFC.GeneralTemplate.Domain.Enums.Metadata.MetadataState;
global using MetadataDomainEnum = SFC.GeneralTemplate.Domain.Enums.Metadata.MetadataDomain;
// enums
global using PhotoExtensionEnum = SFC.GeneralTemplate.Domain.Enums.Data.PhotoExtension;
// data
#if IncludePlayerInfrastructure
global using FootballPositionEnum = SFC.GeneralTemplate.Domain.Enums.Data.FootballPosition;
global using GameStyleEnum = SFC.GeneralTemplate.Domain.Enums.Data.GameStyle;
global using StatCategoryEnum = SFC.GeneralTemplate.Domain.Enums.Data.StatCategory;
global using StatSkillEnum = SFC.GeneralTemplate.Domain.Enums.Data.StatSkill;
global using StatTypeEnum = SFC.GeneralTemplate.Domain.Enums.Data.StatType;
global using WorkingFootEnum = SFC.GeneralTemplate.Domain.Enums.Data.WorkingFoot;
#endif
#if IncludeTeamInfrastructure
global using ShirtEnum = SFC.GeneralTemplate.Domain.Enums.Data.Shirt;
#endif
#if IncludePlayerInfrastructure
// player
global using PlayerEntity = SFC.GeneralTemplate.Domain.Entities.Player.Player;
#endif
#if IncludeTeamInfrastructure
// team
global using TeamEntity = SFC.GeneralTemplate.Domain.Entities.Team.General.Team;
#endif
#if (IncludePlayerInfrastructure && IncludeTeamInfrastructure)
global using TeamPlayerStatusEnum = SFC.GeneralTemplate.Domain.Enums.Team.TeamPlayerStatus;
#endif
// core
global using GeneralTemplateEntity = SFC.GeneralTemplate.Domain.Entities.GeneralTemplate.General.GeneralTemplate;