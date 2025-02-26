using SFC.GeneralTemplate.Application.Features.Common.Models.Find.Filters;
using SFC.GeneralTemplate.Application.Features.GeneralTemplate.Queries.Find.Dto.Filters;

namespace SFC.GeneralTemplate.Application.Features.GeneralTemplate.Queries.Find.Extensions;
public static class GetGeneralTemplatesFiltersExtensions
{
    public static IEnumerable<Filter<GeneralTemplateEntity>> BuildSearchFilters(this GetGeneralTemplatesFilterDto filter)
    {
        return [];
    }
}
