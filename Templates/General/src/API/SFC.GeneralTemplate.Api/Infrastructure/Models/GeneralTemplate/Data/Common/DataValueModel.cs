using SFC.GeneralTemplate.Application.Common.Mappings.Interfaces;
using SFC.GeneralTemplate.Application.Features.GeneralTemplate.Data.Queries.Common.Dto;

namespace SFC.GeneralTemplate.Api.Infrastructure.Models.GeneralTemplate.Data.Common;

/// <summary>
/// Data value.
/// </summary>
public class DataValueModel : IMapFrom<DataValueDto>
{
    /// <summary>
    /// Unique identificator of data type.
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Describe data type.
    /// </summary>
    public required string Title { get; set; }
}
