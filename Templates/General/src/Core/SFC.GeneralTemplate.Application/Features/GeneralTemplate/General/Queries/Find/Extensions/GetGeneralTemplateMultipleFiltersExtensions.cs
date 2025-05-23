using SFC.GeneralTemplate.Application.Features.Common.Models.Find.Filters;
using SFC.GeneralTemplate.Application.Features.GeneralTemplate.General.Queries.Find.Dto.Filters;

namespace SFC.GeneralTemplate.Application.Features.GeneralTemplate.General.Queries.Find.Extensions;
public static class GetGeneralTemplateMultipleFiltersExtensions
{
    public static IEnumerable<Filter<GeneralTemplateEntity>> BuildSearchFilters(this GetGeneralTemplateMultipleFilterDto filter)
    {
        return [];
    }
}
