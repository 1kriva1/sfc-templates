using SFC.GeneralTemplate.Api.Infrastructure.Models.GeneralTemplates.Common;
using SFC.GeneralTemplate.Application.Common.Mappings.Interfaces;
using SFC.GeneralTemplate.Application.Features.GeneralTemplate.Commands.Create;

namespace SFC.GeneralTemplate.Api.Infrastructure.Models.GeneralTemplates.Create;

/// <summary>
/// **Create** generaltemplate model.
/// </summary>
public class CreateGeneralTemplateModel : BaseGeneralTemplateModel, IMapTo<CreateGeneralTemplateDto> { }
