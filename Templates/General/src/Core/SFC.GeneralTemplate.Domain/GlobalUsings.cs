// metadata
global using MetadataServiceEnum = SFC.GeneralTemplate.Domain.Enums.Metadata.MetadataService;
global using MetadataTypeEnum = SFC.GeneralTemplate.Domain.Enums.Metadata.MetadataType;
global using MetadataStateEnum = SFC.GeneralTemplate.Domain.Enums.Metadata.MetadataState;
// data
global using PhotoExtensionEnum = SFC.GeneralTemplate.Domain.Enums.Data.PhotoExtension;
// core
global using GeneralTemplateEntity = SFC.GeneralTemplate.Domain.Entities.GeneralTemplate.GeneralTemplate;
#if IncludePlayerInfrastructure
// player
global using PlayerEntity = SFC.GeneralTemplate.Domain.Entities.Player.Player;
global using FootballPositionEnum = SFC.GeneralTemplate.Domain.Enums.Data.FootballPosition;
global using GameStyleEnum = SFC.GeneralTemplate.Domain.Enums.Data.GameStyle;
global using StatCategoryEnum = SFC.GeneralTemplate.Domain.Enums.Data.StatCategory;
global using StatSkillEnum = SFC.GeneralTemplate.Domain.Enums.Data.StatSkill;
global using StatTypeEnum = SFC.GeneralTemplate.Domain.Enums.Data.StatType;
global using WorkingFootEnum = SFC.GeneralTemplate.Domain.Enums.Data.WorkingFoot;
#endif