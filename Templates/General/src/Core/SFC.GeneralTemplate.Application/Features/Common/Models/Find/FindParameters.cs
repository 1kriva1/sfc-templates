﻿using SFC.GeneralTemplate.Application.Features.Common.Models.Find.Filters;
using SFC.GeneralTemplate.Application.Features.Common.Models.Find.Paging;
using SFC.GeneralTemplate.Application.Features.Common.Models.Find.Sorting;

namespace SFC.GeneralTemplate.Application.Features.Common.Models.Find;

/// <summary>
/// Compose class for execute find.
/// </summary>
/// <typeparam name="TEntity">Entity type.</typeparam>
public class FindParameters<TEntity>
{
    public Filters<TEntity>? Filters { get; set; }

    public Sortings<TEntity>? Sorting { get; set; }

    public required Pagination Pagination { get; set; }
}
