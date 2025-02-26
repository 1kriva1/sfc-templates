using AutoMapper;
using SFC.GeneralTemplate.Application.Common.Extensions;
using SFC.GeneralTemplate.Application.Common.Mappings.Interfaces;
using SFC.GeneralTemplate.Application.Features.GeneralTemplate.Queries.Get;
using SFC.GeneralTemplate.Api.Infrastructure.Models.GeneralTemplates.Common;
using SFC.GeneralTemplate.Api.Infrastructure.Models.Base;

#pragma warning disable CA1716
namespace SFC.GeneralTemplate.Api.Infrastructure.Models.GeneralTemplates.Get;
#pragma warning restore CA1716

/// <summary>
/// **Get** generaltemplate response.
/// </summary>
public class GetGeneralTemplateResponse :
    BaseErrorResponse, IMapFrom<GetGeneralTemplateViewModel>
{
    /// <summary>
    /// GeneralTemplate model.
    /// </summary>
    public GeneralTemplateModel GeneralTemplate { get; set; } = null!;

    public void Mapping(Profile profile) => profile.CreateMap<GetGeneralTemplateViewModel, GetGeneralTemplateResponse>()
                                                   .IgnoreAllNonExisting();
}
