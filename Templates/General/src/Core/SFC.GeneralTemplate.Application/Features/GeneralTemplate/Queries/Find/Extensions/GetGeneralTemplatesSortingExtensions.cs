using System.Linq.Expressions;
using SFC.GeneralTemplate.Application.Features.Common.Models.Find.Sorting;
using SFC.GeneralTemplate.Application.Features.Common.Dto.Common;
using SFC.GeneralTemplate.Application.Features.Common.Extensions;

namespace SFC.GeneralTemplate.Application.Features.GeneralTemplate.Queries.Find.Extensions;
public static class GetGeneralTemplatesSortingExtensions
{
    public static IEnumerable<Sorting<GeneralTemplateEntity, dynamic>> BuildGeneralTemplateSearchSorting(this IEnumerable<SortingDto> sorting)
        => sorting.BuildSearchSorting<GeneralTemplateEntity>(BuildExpression);

    private static Expression<Func<GeneralTemplateEntity, dynamic>>? BuildExpression(string name)
    {
        return name switch
        {
            _ => null
        };
    }
}
