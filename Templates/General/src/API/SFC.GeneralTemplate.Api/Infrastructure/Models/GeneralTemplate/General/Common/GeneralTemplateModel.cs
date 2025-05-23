using SFC.GeneralTemplate.Application.Common.Mappings.Interfaces;
using SFC.GeneralTemplate.Application.Features.GeneralTemplate.General.Common.Dto;

namespace SFC.GeneralTemplate.Api.Infrastructure.Models.GeneralTemplate.General.Common;

/// <summary>
/// GeneralTemplate model.
/// </summary>
public class GeneralTemplateModel : IMapFrom<GeneralTemplateDto>
{
    /// <summary>
    /// Unique identifier.
    /// </summary>
    public long Id { get; set; }
}
