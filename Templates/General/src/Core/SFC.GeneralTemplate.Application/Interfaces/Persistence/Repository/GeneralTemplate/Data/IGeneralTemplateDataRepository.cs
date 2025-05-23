using SFC.GeneralTemplate.Application.Interfaces.Persistence.Context;
using SFC.GeneralTemplate.Application.Interfaces.Persistence.Repository.Common.Data;
using SFC.GeneralTemplate.Domain.Common;

namespace SFC.GeneralTemplate.Application.Interfaces.Persistence.Repository.GeneralTemplate.Data;
public interface IGeneralTemplateDataRepository<T, TEnum> : IDataRepository<T, IGeneralTemplateDbContext, TEnum>
    where T : EnumDataEntity<TEnum>
    where TEnum : struct
{
}
