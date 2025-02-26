#if IncludePlayerInfrastructure
using SFC.GeneralTemplate.Domain.Common;

namespace SFC.GeneralTemplate.Domain.Entities.Data;
public class WorkingFoot : EnumDataEntity<WorkingFootEnum>
{
    public WorkingFoot() : base() { }

    public WorkingFoot(WorkingFootEnum enumType) : base(enumType) { }
}
#endif