using AutoMapper;
using SFC.GeneralTemplate.Application.Common.Mappings.Interfaces;
using SFC.GeneralTemplate.Application.Features.GeneralTemplate.Commands.Update;
using SFC.GeneralTemplate.Application.Common.Extensions;

namespace SFC.GeneralTemplate.Api.Infrastructure.Models.GeneralTemplates.Update;

/// <summary>
/// **Update** generaltemplate request.
/// </summary>
public class UpdateGeneralTemplateRequest : IMapTo<UpdateGeneralTemplateCommand>
{
    /// <summary>
    /// GeneralTemplate model.
    /// </summary>
    public UpdateGeneralTemplateModel GeneralTemplate { get; set; } = null!;

    public void Mapping(Profile profile) => profile.CreateMap<UpdateGeneralTemplateRequest, UpdateGeneralTemplateCommand>()
                                                   .IgnoreAllNonExisting();
}
