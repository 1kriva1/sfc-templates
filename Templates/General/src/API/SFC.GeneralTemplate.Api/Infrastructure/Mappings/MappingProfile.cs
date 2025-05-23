using Google.Protobuf.WellKnownTypes;

using SFC.GeneralTemplate.Api.Infrastructure.Models.Common;
using SFC.GeneralTemplate.Application.Common.Mappings.Base;
using SFC.GeneralTemplate.Application.Features.Common.Dto.Common;
using SFC.GeneralTemplate.Application.Features.Common.Dto.Pagination;
using SFC.GeneralTemplate.Application.Common.Extensions;

using System.Reflection;
using SFC.GeneralTemplate.Application.Features.GeneralTemplate.General.Queries.Find;
using SFC.GeneralTemplate.Application.Features.GeneralTemplate.General.Queries.Get;
using SFC.GeneralTemplate.Application.Features.GeneralTemplate.General.Common.Dto;
using SFC.GeneralTemplate.Application.Features.GeneralTemplate.General.Queries.Find.Dto.Filters;
#if IncludeDataInfrastructure
using SFC.GeneralTemplate.Application.Features.GeneralTemplate.Data.Queries.Common.Dto;
using SFC.GeneralTemplate.Application.Features.GeneralTemplate.Data.Queries.GetAll;
#endif

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
#if IncludeDataInfrastructure
        // data
        CreateMapGeneralTemplateDataContracts();
#endif
        // contracts
        CreateMapGeneralTemplateContracts();

        #endregion Complex types        
    }
#if IncludeDataInfrastructure
    private void CreateMapGeneralTemplateDataContracts()
    {
        CreateMap<DataValueDto, SFC.GeneralTemplate.Contracts.Models.GeneralTemplate.Data.DataValue>();
        CreateMap<GetAllGeneralTemplateDataViewModel, SFC.GeneralTemplate.Contracts.Messages.GeneralTemplate.Data.GetAll.GetAllGeneralTemplateDataResponse>();
    }
#endif
    private void CreateMapGeneralTemplateContracts()
    {
        // get generaltemplate
        CreateMap<GeneralTemplateDto, SFC.GeneralTemplate.Contracts.Models.GeneralTemplate.GeneralTemplate>();
        CreateMap<GetGeneralTemplateViewModel, SFC.GeneralTemplate.Contracts.Messages.GeneralTemplate.General.Get.GetGeneralTemplateResponse>();
        CreateMap<SFC.GeneralTemplate.Contracts.Messages.GeneralTemplate.General.Get.GetGeneralTemplateRequest, GetGeneralTemplateQuery>();
        CreateMap<GeneralTemplateDto, SFC.GeneralTemplate.Contracts.Headers.AuditableHeader>()
            .IgnoreAllNonExisting();

        // get generaltemplatemultiple
        // (filters)
        CreateMap<SFC.GeneralTemplate.Contracts.Messages.GeneralTemplate.General.Find.GetGeneralTemplateMultipleRequest, GetGeneralTemplateMultipleQuery>();
        CreateMap<SFC.GeneralTemplate.Contracts.Models.Common.Pagination, PaginationDto>();
        CreateMap<SFC.GeneralTemplate.Contracts.Models.Common.Sorting, SortingDto>();
        CreateMap<SFC.GeneralTemplate.Contracts.Messages.GeneralTemplate.General.Find.Filters.GetGeneralTemplateMultipleFilter, GetGeneralTemplateMultipleFilterDto>();
        CreateMap(typeof(SFC.GeneralTemplate.Contracts.Models.Common.RangeLimit), typeof(RangeLimitDto<>));
        // (result)
        CreateMap<GetGeneralTemplateMultipleViewModel, SFC.GeneralTemplate.Contracts.Messages.GeneralTemplate.General.Find.GetGeneralTemplateMultipleResponse>();
        // (headers)
        CreateMap<PageMetadataDto, SFC.GeneralTemplate.Contracts.Headers.PaginationHeader>()
            .IgnoreAllNonExisting();
    }
}
