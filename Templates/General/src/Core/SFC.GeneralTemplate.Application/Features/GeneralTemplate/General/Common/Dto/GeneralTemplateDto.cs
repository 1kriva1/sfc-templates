using SFC.GeneralTemplate.Application.Common.Mappings.Interfaces;

namespace SFC.GeneralTemplate.Application.Features.GeneralTemplate.General.Common.Dto;
public class GeneralTemplateDto : IMapFrom<GeneralTemplateEntity>
{
    public long Id { get; set; }

    public Guid UserId { get; set; }
}
