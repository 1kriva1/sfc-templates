using SFC.GeneralTemplate.Domain.Common.Interfaces;
using SFC.GeneralTemplate.Domain.Common;

namespace SFC.GeneralTemplate.Domain.Entities.GeneralTemplate;

/// <summary>
/// Core entity of the service.
/// </summary>
public class GeneralTemplate : BaseAuditableEntity<long>, IUserEntity
{
    public Guid UserId { get; set; }
}
