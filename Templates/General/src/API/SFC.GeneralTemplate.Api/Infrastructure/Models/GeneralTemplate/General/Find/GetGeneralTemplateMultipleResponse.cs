using AutoMapper;
using SFC.GeneralTemplate.Application.Common.Extensions;
using SFC.GeneralTemplate.Api.Infrastructure.Models.Base;
using SFC.GeneralTemplate.Application.Common.Mappings.Interfaces;
using SFC.GeneralTemplate.Application.Features.GeneralTemplate.General.Queries.Find;
using SFC.GeneralTemplate.Api.Infrastructure.Models.GeneralTemplate.General.Common;

namespace SFC.GeneralTemplate.Api.Infrastructure.Models.GeneralTemplate.General.Find;

/// <summary>
/// **Get** generaltemplatemultiple response.
/// </summary>
public class GetGeneralTemplateMultipleResponse : BaseListResponse<GeneralTemplateModel>, IMapFrom<GetGeneralTemplateMultipleViewModel>
{
    public void Mapping(Profile profile) => profile.CreateMap<GetGeneralTemplateMultipleViewModel, GetGeneralTemplateMultipleResponse>()
                                                   .IgnoreAllNonExisting();
}
