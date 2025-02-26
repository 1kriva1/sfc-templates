using AutoMapper;
using SFC.GeneralTemplate.Application.Common.Extensions;
using SFC.GeneralTemplate.Api.Infrastructure.Models.GeneralTemplates.Find.Filters;
using SFC.GeneralTemplate.Application.Common.Mappings.Interfaces;
using SFC.GeneralTemplate.Application.Features.GeneralTemplate.Queries.Find;
using SFC.GeneralTemplate.Api.Infrastructure.Models.Base;

namespace SFC.GeneralTemplate.Api.Infrastructure.Models.GeneralTemplates.Find;

/// <summary>
/// **Get** generaltemplatemultiple request.
/// </summary>
public class GetGeneralTemplatesRequest : BasePaginationRequest<GetGeneralTemplatesFilterModel>, IMapTo<GetGeneralTemplatesQuery>
{
    public void Mapping(Profile profile) => profile.CreateMap<GetGeneralTemplatesRequest, GetGeneralTemplatesQuery>()
                                                   .IgnoreAllNonExisting();
}
