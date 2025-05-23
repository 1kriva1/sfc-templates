using AutoMapper;
using SFC.GeneralTemplate.Application.Common.Extensions;
using SFC.GeneralTemplate.Application.Common.Mappings.Interfaces;
using SFC.GeneralTemplate.Api.Infrastructure.Models.Base;
using SFC.GeneralTemplate.Application.Features.GeneralTemplate.General.Commands.Create;
using SFC.GeneralTemplate.Api.Infrastructure.Models.GeneralTemplate.General.Common;

namespace SFC.GeneralTemplate.Api.Infrastructure.Models.GeneralTemplate.General.Create;

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
