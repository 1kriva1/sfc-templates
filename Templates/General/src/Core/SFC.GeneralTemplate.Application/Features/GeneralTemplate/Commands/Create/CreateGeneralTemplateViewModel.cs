using SFC.GeneralTemplate.Application.Common.Mappings.Interfaces;
using SFC.GeneralTemplate.Application.Features.GeneralTemplate.Common.Dto;

namespace SFC.GeneralTemplate.Application.Features.GeneralTemplate.Commands.Create;
public class CreateGeneralTemplateViewModel : IMapFrom<GeneralTemplateEntity>
{
    public required GeneralTemplateDto GeneralTemplate { get; set; }
}
