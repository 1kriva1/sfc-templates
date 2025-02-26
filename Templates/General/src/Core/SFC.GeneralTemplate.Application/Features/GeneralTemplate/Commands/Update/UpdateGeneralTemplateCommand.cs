using SFC.GeneralTemplate.Application.Common.Enums;
using SFC.GeneralTemplate.Application.Features.Common.Base;

namespace SFC.GeneralTemplate.Application.Features.GeneralTemplate.Commands.Update;
public class UpdateGeneralTemplateCommand : Request
{
    public override RequestId RequestId { get => RequestId.UpdateGeneralTemplate; }

    public long GeneralTemplateId { get; set; }

    public required UpdateGeneralTemplateDto GeneralTemplate { get; set; }

    public UpdateGeneralTemplateCommand SetGeneralTemplateId(long id)
    {
        GeneralTemplateId = id;
        return this;
    }
}
