using SFC.GeneralTemplate.Application.Interfaces.Persistence.Repository.GeneralTemplate.Data;
using SFC.GeneralTemplate.Domain.Common;
using SFC.GeneralTemplate.Infrastructure.Persistence.Contexts;
using SFC.GeneralTemplate.Infrastructure.Persistence.Repositories.Common.Data;

namespace SFC.GeneralTemplate.Infrastructure.Persistence.Repositories.GeneralTemplate.Data;
public class GeneralTemplateDataRepository<T, TEnum>(GeneralTemplateDbContext context)
     : DataRepository<T, GeneralTemplateDbContext, TEnum>(context), IGeneralTemplateDataRepository<T, TEnum>
     where T : EnumDataEntity<TEnum>
     where TEnum : struct
{
}
