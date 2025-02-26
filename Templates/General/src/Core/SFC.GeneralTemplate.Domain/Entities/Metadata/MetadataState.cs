using SFC.GeneralTemplate.Domain.Common;

namespace SFC.GeneralTemplate.Domain.Entities.Metadata;
public class MetadataState : EnumEntity<MetadataStateEnum>
{
    public MetadataState() : base() { }

    public MetadataState(MetadataStateEnum enumType) : base(enumType) { }
}
