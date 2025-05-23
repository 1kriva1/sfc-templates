using AutoMapper;
using SFC.GeneralTemplate.Application.Common.Extensions;
using SFC.GeneralTemplate.Application.Common.Mappings.Interfaces;
using SFC.GeneralTemplate.Api.Infrastructure.Models.Base;
using SFC.GeneralTemplate.Application.Features.GeneralTemplate.General.Queries.Find;
using SFC.GeneralTemplate.Api.Infrastructure.Models.GeneralTemplate.General.Find.Filters;

namespace SFC.GeneralTemplate.Api.Infrastructure.Models.GeneralTemplate.General.Find;

/// <summary>
/// **Get** generaltemplatemultiple request.
/// </summary>
public class GetGeneralTemplateMultipleRequest : BasePaginationRequest<GetGeneralTemplateMultipleFilterModel>, IMapTo<GetGeneralTemplateMultipleQuery>
{
    public void Mapping(Profile profile) => profile.CreateMap<GetGeneralTemplateMultipleRequest, GetGeneralTemplateMultipleQuery>()
                                                   .IgnoreAllNonExisting();
}
