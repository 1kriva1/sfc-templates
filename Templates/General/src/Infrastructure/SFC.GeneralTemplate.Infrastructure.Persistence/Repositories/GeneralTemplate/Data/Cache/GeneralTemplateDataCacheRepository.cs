using SFC.GeneralTemplate.Application.Interfaces.Cache;
using SFC.GeneralTemplate.Domain.Common;
using SFC.GeneralTemplate.Infrastructure.Persistence.Contexts;
using SFC.GeneralTemplate.Infrastructure.Persistence.Repositories.Common.Data;

namespace SFC.GeneralTemplate.Infrastructure.Persistence.Repositories.GeneralTemplate.Data.Cache;
public class GeneralTemplateDataCacheRepository<T, TEnum>(GeneralTemplateDataRepository<T, TEnum> repository, ICache cache)
    : DataCacheRepository<T, GeneralTemplateDbContext, TEnum>(repository, cache)
     where T : EnumDataEntity<TEnum>
     where TEnum : struct
{
}
