﻿namespace SFC.GeneralTemplate.Infrastructure.Constants;
public static class CommonConstants
{
    public const string ResourcePath = "Resources";

    public static readonly string[] SupportedCultures = ["en-GB", "uk-UA"];

    public const string PaginationHeaderKey = "X-Pagination";

    public const string AuditableHeaderKey = "X-Auditable";

    public const string ContentType = "application/json";
}
