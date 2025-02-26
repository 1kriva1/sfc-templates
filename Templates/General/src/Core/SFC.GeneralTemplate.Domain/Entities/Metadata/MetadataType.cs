using SFC.GeneralTemplate.Domain.Common;

namespace SFC.GeneralTemplate.Domain.Entities.Metadata;
public class MetadataType : EnumEntity<MetadataTypeEnum>
{
    public MetadataType() : base() { }

    public MetadataType(MetadataTypeEnum enumType) : base(enumType) { }
}
