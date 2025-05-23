using SFC.GeneralTemplate.Application.Common.Enums;
using SFC.GeneralTemplate.Application.Features.Common.Base;
using SFC.GeneralTemplate.Application.Features.GeneralTemplate.General.Common.Dto;

namespace SFC.GeneralTemplate.Application.Features.GeneralTemplate.General.Commands.Create;
public class CreateGeneralTemplateCommand : Request<CreateGeneralTemplateViewModel>
{
    public override RequestId RequestId { get => RequestId.CreateGeneralTemplate; }

    public CreateGeneralTemplateDto GeneralTemplate { get; set; } = null!;
}
