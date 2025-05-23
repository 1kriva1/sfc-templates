#if IncludeDataInfrastructure
using SFC.GeneralTemplate.Application.Common.Enums;
using SFC.GeneralTemplate.Application.Features.Common.Base;

namespace SFC.GeneralTemplate.Application.Features.GeneralTemplate.Data.Queries.GetAll;

public class GetAllGeneralTemplateDataQuery : Request<GetAllGeneralTemplateDataViewModel>
{
    public override RequestId RequestId { get => RequestId.GetAllGeneralTemplateData; }
}
#endif
