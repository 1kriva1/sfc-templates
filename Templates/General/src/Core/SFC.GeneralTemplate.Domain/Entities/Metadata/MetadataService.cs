using SFC.GeneralTemplate.Domain.Common;

namespace SFC.GeneralTemplate.Domain.Entities.Metadata;
public class MetadataService : EnumEntity<MetadataServiceEnum>
{
    public MetadataService() : base() { }

    public MetadataService(MetadataServiceEnum enumType) : base(enumType) { }
}
