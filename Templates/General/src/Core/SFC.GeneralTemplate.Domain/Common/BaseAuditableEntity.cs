using SFC.GeneralTemplate.Domain.Common.Interfaces;

namespace SFC.GeneralTemplate.Domain.Common;

/// <summary>
/// For core entities of the service.
/// </summary>
/// <typeparam name="TID">Type for entity identifier.</typeparam>
public abstract class BaseAuditableEntity<TID> : BaseEntity<TID>, IAuditableEntity
{
    public DateTime CreatedDate { get; set; }

    public Guid CreatedBy { get; set; }

    public DateTime LastModifiedDate { get; set; }

    public Guid LastModifiedBy { get; set; }
}