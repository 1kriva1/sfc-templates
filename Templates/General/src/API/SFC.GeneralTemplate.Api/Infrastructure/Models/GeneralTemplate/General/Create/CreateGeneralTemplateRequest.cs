using AutoMapper;

using SFC.GeneralTemplate.Application.Common.Mappings.Interfaces;
using SFC.GeneralTemplate.Application.Common.Extensions;
using SFC.GeneralTemplate.Application.Features.GeneralTemplate.General.Commands.Create;

namespace SFC.GeneralTemplate.Api.Infrastructure.Models.GeneralTemplate.General.Create;

/// <summary>
/// **Create** GeneralTemplate request.
/// </summary>
public class CreateGeneralTemplateRequest : IMapTo<CreateGeneralTemplateCommand>
{
    /// <summary>
    /// GeneralTemplate model.
    /// </summary>
    public CreateGeneralTemplateModel GeneralTemplate { get; set; } = null!;

    public void Mapping(Profile profile) => profile.CreateMap<CreateGeneralTemplateRequest, CreateGeneralTemplateCommand>()
                                                   .IgnoreAllNonExisting();
}
