#if IncludeDataInfrastructure
using SFC.GeneralTemplate.Application.Common.Constants;
using SFC.GeneralTemplate.Domain.Common.Interfaces;

namespace SFC.GeneralTemplate.Application.Common.Extensions;
public static class LocalizationExtensions
{
    public static void Localize(this IEnumEntity value) => value.Title = Localization.GetDataValue(value.Title);

    public static IEnumerable<T> Localize<T>(this IEnumerable<T> values)
        where T : IEnumEntity
    {
        foreach (IEnumEntity value in values)
        {
            value.Localize();
        }

        return values;
    }
}
#endif