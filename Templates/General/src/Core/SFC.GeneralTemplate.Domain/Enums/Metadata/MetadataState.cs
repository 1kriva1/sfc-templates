using System.ComponentModel;

namespace SFC.GeneralTemplate.Domain.Enums.Metadata;
public enum MetadataState
{
    [Description("Not Required")]
    NotRequired,
    Required,
    Done
}
