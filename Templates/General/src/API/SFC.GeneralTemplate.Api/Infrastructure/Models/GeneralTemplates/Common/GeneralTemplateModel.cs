using SFC.GeneralTemplate.Application.Common.Mappings.Interfaces;
using SFC.GeneralTemplate.Application.Features.GeneralTemplate.Common.Dto;

namespace SFC.GeneralTemplate.Api.Infrastructure.Models.GeneralTemplates.Common;

/// <summary>
/// GeneralTemplate model.
/// </summary>
public class GeneralTemplateModel : BaseGeneralTemplateModel, IMapFrom<GeneralTemplateDto>
{
    /// <summary>
    /// Unique identifier.
    /// </summary>
    public long Id { get; set; }
}
