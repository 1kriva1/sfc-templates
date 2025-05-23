namespace SFC.GeneralTemplate.Application.Interfaces.Persistence.Context;

/// <summary>
/// Core DB context of the service.
/// </summary>
public interface IGeneralTemplateDbContext : IDbContext
{
    #region General

    IQueryable<GeneralTemplateEntity> GeneralTemplateMultiple { get; }

    #endregion
#if IncludeDataInfrastructure
    #region Data

    #endregion Data
#endif
}
