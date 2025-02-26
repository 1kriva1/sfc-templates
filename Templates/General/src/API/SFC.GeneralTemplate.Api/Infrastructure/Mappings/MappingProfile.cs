using Google.Protobuf.WellKnownTypes;

using SFC.GeneralTemplate.Api.Infrastructure.Models.Common;
using SFC.GeneralTemplate.Application.Common.Mappings.Base;
using SFC.GeneralTemplate.Application.Features.Common.Dto.Common;
using SFC.GeneralTemplate.Application.Features.Common.Dto.Pagination;
using SFC.GeneralTemplate.Application.Features.GeneralTemplate.Common.Dto;
using SFC.GeneralTemplate.Application.Features.GeneralTemplate.Queries.Get;
using SFC.GeneralTemplate.Application.Common.Extensions;

using System.Reflection;
using SFC.GeneralTemplate.Application.Features.GeneralTemplate.Queries.Find;
using SFC.GeneralTemplate.Application.Features.GeneralTemplate.Queries.Find.Dto.Filters;

namespace SFC.GeneralTemplate.Api.Infrastructure.Mappings;

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

        CreateMap<DateTime, Timestamp>()
            .ConvertUsing(value => DateTime.SpecifyKind(value, DateTimeKind.Utc).ToTimestamp());

        CreateMap<TimeSpan, Duration>()
            .ConvertUsing(value => Duration.FromTimeSpan(value));

        CreateMap<Duration, TimeSpan>()
            .ConvertUsing(value => value.ToTimeSpan());

        #endregion Simple types

        #region Generic types

        CreateMap(typeof(RangeLimitModel<>), typeof(RangeLimitDto<>));

        #endregion Generic types

        #region Complex types

        // contracts
        CreateMapGeneralTemplateContracts();

        #endregion Complex types        
    }

    private void CreateMapGeneralTemplateContracts()
    {
        // get generaltemplate
        CreateMap<GeneralTemplateDto, SFC.GeneralTemplate.Contracts.Models.GeneralTemplate.GeneralTemplate>();
        CreateMap<GetGeneralTemplateViewModel, SFC.GeneralTemplate.Contracts.Messages.Get.GetGeneralTemplateResponse>();
        CreateMap<SFC.GeneralTemplate.Contracts.Messages.Get.GetGeneralTemplateRequest, GetGeneralTemplateQuery>()
             .ForMember(p => p.GeneralTemplateId, d => d.MapFrom(z => z.Id));
        CreateMap<GeneralTemplateDto, SFC.GeneralTemplate.Contracts.Headers.AuditableHeader>()
            .IgnoreAllNonExisting();

        // get generaltemplatemultiple
        // (filters)
        CreateMap<SFC.GeneralTemplate.Contracts.Messages.Find.GetGeneralTemplatesRequest, GetGeneralTemplatesQuery>();
        CreateMap<SFC.GeneralTemplate.Contracts.Models.Common.Pagination, PaginationDto>();
        CreateMap<SFC.GeneralTemplate.Contracts.Models.Common.Sorting, SortingDto>();
        CreateMap<SFC.GeneralTemplate.Contracts.Messages.Find.Filters.GetGeneralTemplatesFilter, GetGeneralTemplatesFilterDto>();
        CreateMap(typeof(SFC.GeneralTemplate.Contracts.Models.Common.RangeLimit), typeof(RangeLimitDto<>));
        // (result)
        CreateMap<GetGeneralTemplatesViewModel, SFC.GeneralTemplate.Contracts.Messages.Find.GetGeneralTemplatesResponse>();
        CreateMap<SFC.GeneralTemplate.Application.Features.GeneralTemplate.Common.Dto.GeneralTemplateDto, SFC.GeneralTemplate.Contracts.Models.GeneralTemplate.GeneralTemplate>();
        // (headers)
        CreateMap<PageMetadataDto, SFC.GeneralTemplate.Contracts.Headers.PaginationHeader>()
            .IgnoreAllNonExisting();
    }
}
