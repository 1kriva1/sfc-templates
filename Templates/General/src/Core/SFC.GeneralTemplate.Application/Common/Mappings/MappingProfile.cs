using System.Reflection;

using SFC.GeneralTemplate.Application.Common.Mappings.Base;
using SFC.GeneralTemplate.Application.Features.Common.Dto.Pagination;
using SFC.GeneralTemplate.Application.Features.Common.Models.Find.Paging;

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