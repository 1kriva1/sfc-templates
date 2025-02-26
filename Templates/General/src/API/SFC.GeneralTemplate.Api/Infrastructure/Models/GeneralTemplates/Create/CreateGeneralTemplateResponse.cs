using AutoMapper;
using SFC.GeneralTemplate.Application.Common.Extensions;
using SFC.GeneralTemplate.Application.Common.Mappings.Interfaces;
using SFC.GeneralTemplate.Application.Features.GeneralTemplate.Commands.Create;
using SFC.GeneralTemplate.Api.Infrastructure.Models.GeneralTemplates.Common;
using SFC.GeneralTemplate.Api.Infrastructure.Models.Base;

namespace SFC.GeneralTemplate.Api.Infrastructure.Models.GeneralTemplates.Create;

/// <summary>
/// **Create** generaltemplate response model.
/// </summary>
public class CreateGeneralTemplateResponse :
    BaseErrorResponse, IMapFrom<CreateGeneralTemplateViewModel>
{
    /// <summary>
    /// GeneralTemplate model.
    /// </summary>
    public GeneralTemplateModel GeneralTemplate { get; set; } = null!;

    public void Mapping(Profile profile) => profile.CreateMap<CreateGeneralTemplateViewModel, CreateGeneralTemplateResponse>()
                                                   .IgnoreAllNonExisting();
}
