namespace SFC.GeneralTemplate.Application.Interfaces.Metadata;

/// <summary>
/// Service metadata contract.
/// </summary>
public interface IMetadataService
{
    Task CompleteAsync(MetadataServiceEnum service, MetadataTypeEnum type);

    Task<bool> IsCompletedAsync(MetadataServiceEnum service, MetadataTypeEnum type);
}
