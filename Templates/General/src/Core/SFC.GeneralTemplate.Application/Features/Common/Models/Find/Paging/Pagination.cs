using SFC.GeneralTemplate.Application.Common.Mappings.Interfaces;
using SFC.GeneralTemplate.Application.Features.Common.Dto.Pagination;

namespace SFC.GeneralTemplate.Application.Features.Common.Models.Find.Paging;

/// <summary>
/// Pagination for quering to database.
/// </summary>
public class Pagination : IMapFrom<PaginationDto>
{
    public int Page { get; set; }

    public int Size { get; set; }
}
