using SFC.GeneralTemplate.Domain.Common;
using SFC.GeneralTemplate.Domain.Common.Interfaces;

namespace SFC.GeneralTemplate.Domain.Entities.Data;

/// <summary>
/// Parent class for all data related entities (from Data service) which is NOT enum based.
/// </summary>
/// <typeparam name="TId">Type for entity identifier.</typeparam>
public class DataEntity<TID> : BaseEntity<TID>, IDataEntity
{
    public DateTime CreatedDate { get; set; }
}
