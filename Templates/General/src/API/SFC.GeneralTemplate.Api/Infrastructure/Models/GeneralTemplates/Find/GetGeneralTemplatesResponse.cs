using AutoMapper;
using SFC.GeneralTemplate.Application.Common.Extensions;
using SFC.GeneralTemplate.Api.Infrastructure.Models.Base;
using SFC.GeneralTemplate.Api.Infrastructure.Models.GeneralTemplates.Common;
using SFC.GeneralTemplate.Application.Common.Mappings.Interfaces;
using SFC.GeneralTemplate.Application.Features.GeneralTemplate.Queries.Find;

namespace SFC.GeneralTemplate.Api.Infrastructure.Models.GeneralTemplates.Find;

/// <summary>
/// **Get** generaltemplatemultiple response.
/// </summary>
public class GetGeneralTemplatesResponse : BaseListResponse<GeneralTemplateModel>, IMapFrom<GetGeneralTemplatesViewModel>
{
    public void Mapping(Profile profile) => profile.CreateMap<GetGeneralTemplatesViewModel, GetGeneralTemplatesResponse>()
                                                   .IgnoreAllNonExisting();
}
