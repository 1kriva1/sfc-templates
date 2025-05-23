using SFC.GeneralTemplate.Messages.Models.Common;

namespace SFC.GeneralTemplate.Messages.Models.GeneralTemplate;
public class GeneralTemplate : Auditable
{
    public long Id { get; set; }

    public Guid UserId { get; set; }
}
