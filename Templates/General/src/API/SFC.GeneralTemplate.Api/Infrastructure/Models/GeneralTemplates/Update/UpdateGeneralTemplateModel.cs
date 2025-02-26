using SFC.GeneralTemplate.Api.Infrastructure.Models.GeneralTemplates.Common;
using SFC.GeneralTemplate.Application.Common.Mappings.Interfaces;
using SFC.GeneralTemplate.Application.Features.GeneralTemplate.Commands.Update;

namespace SFC.GeneralTemplate.Api.Infrastructure.Models.GeneralTemplates.Update;

/// <summary>
/// **Update** generaltemplate model.
/// </summary>
public class UpdateGeneralTemplateModel : BaseGeneralTemplateModel, IMapTo<UpdateGeneralTemplateDto> { }
