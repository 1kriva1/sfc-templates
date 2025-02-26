using System.Reflection;

using SFC.GeneralTemplate.Application.Common.Mappings.Base;
using SFC.GeneralTemplate.Application.Features.Common.Dto.Pagination;
using SFC.GeneralTemplate.Application.Features.Common.Models.Find.Paging;
using SFC.GeneralTemplate.Domain.Entities.Data;
using SFC.GeneralTemplate.Domain.Entities.Identity;
#if IncludePlayerInfrastructure
using SFC.GeneralTemplate.Domain.Entities.Player;
#endif

namespace SFC.GeneralTemplate.Application.Common.Mappings;
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

#if IncludePlayerInfrastructure
        CreateMap<int, StatType>()
           .ConvertUsing(statType => new StatType { Id = (StatTypeEnum)statType });
        CreateMap<StatType, int>()
            .ConvertUsing(statType => (int)statType.Id);

        CreateMap<DayOfWeek, PlayerAvailableDay>()
            .ConvertUsing(day => new PlayerAvailableDay { Day = day });
        CreateMap<PlayerAvailableDay, DayOfWeek>()
            .ConvertUsing(day => day.Day);

        CreateMap<string, PlayerTag>()
            .ConvertUsing(tag => new PlayerTag { Value = tag });
        CreateMap<PlayerTag, string>()
            .ConvertUsing(tag => tag.Value);
#endif
        CreateMap<Guid, User>()
            .ConvertUsing(id => new User { Id = id });

        #endregion Simple types

        #region Complex types

        #endregion Complex types

        #region Generic types

        CreateMap(typeof(PagedList<>), typeof(PageDto<>))
            .ForMember(nameof(PageDto<object>.Items), d => d.Ignore())
            .ForMember(nameof(PageDto<object>.Metadata), d => d.Ignore());

        CreateMap(typeof(PagedList<>), typeof(PageMetadataDto));

        #endregion Generic types        
    }
}