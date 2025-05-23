using AutoMapper;
using SFC.GeneralTemplate.Application.Common.Mappings.Interfaces;
using SFC.GeneralTemplate.Application.Common.Extensions;
using SFC.GeneralTemplate.Application.Features.GeneralTemplate.General.Commands.Update;

namespace SFC.GeneralTemplate.Api.Infrastructure.Models.GeneralTemplate.General.Update;

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
