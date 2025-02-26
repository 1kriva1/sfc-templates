using SFC.GeneralTemplate.Application.Common.Enums;
using SFC.GeneralTemplate.Application.Features.Common.Base;
using SFC.GeneralTemplate.Application.Features.GeneralTemplate.Common.Dto;

namespace SFC.GeneralTemplate.Application.Features.GeneralTemplate.Commands.Create;
public class CreateGeneralTemplateCommand : Request<CreateGeneralTemplateViewModel>
{
    public override RequestId RequestId { get => RequestId.CreateGeneralTemplate; }

    public CreateGeneralTemplateDto GeneralTemplate { get; set; } = null!;
}
