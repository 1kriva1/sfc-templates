﻿namespace SFC.GeneralTemplate.Application.Features.Common.Dto.Pagination;

/// <summary>
/// Page metadata.
/// </summary>
public class PageMetadataDto
{
    public int CurrentPage { get; set; }

    public int TotalPages { get; set; }

    public int PageSize { get; set; }

    public int TotalCount { get; set; }

    public bool HasPreviousPage => CurrentPage > 1;

    public bool HasNextPage => CurrentPage < TotalPages;
}
