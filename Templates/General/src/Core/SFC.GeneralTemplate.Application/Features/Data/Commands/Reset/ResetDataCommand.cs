using SFC.GeneralTemplate.Application.Common.Enums;
using SFC.GeneralTemplate.Application.Features.Common.Base;

namespace SFC.GeneralTemplate.Application.Features.Data.Commands.Reset;
public class ResetDataCommand : Request
{
    public override RequestId RequestId { get => RequestId.ResetData; }
}
