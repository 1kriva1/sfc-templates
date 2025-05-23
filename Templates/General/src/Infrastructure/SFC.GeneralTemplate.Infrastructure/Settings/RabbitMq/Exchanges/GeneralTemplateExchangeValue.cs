using SFC.GeneralTemplate.Infrastructure.Settings.RabbitMq.Exchanges.Common.Data;
using SFC.GeneralTemplate.Infrastructure.Settings.RabbitMq.Exchanges.Common.Domain;

namespace SFC.GeneralTemplate.Infrastructure.Settings.RabbitMq.Exchanges;
public class GeneralTemplateExchangeValue
{
    public DataExchange<GeneralTemplateDataDependentExchange> Data { get; set; } = default!;

    public GeneralTemplateDomainExchange Domain { get; set; } = default!;
}

public class GeneralTemplateDataDependentExchange
{
    public DataDependentExchange Data { get; set; } = default!;

#if (IncludePlayerInfrastructure && IncludeTeamInfrastructure)
    public DataDependentExchange Team { get; set; } = default!;
#endif
}

public class GeneralTemplateDomainExchange
{
    /// <summary>
    /// Should be replaces by service(s) that required seed for GeneralTemplateMultiple
    /// </summary>
    public DomainExchange<GeneralTemplateGeneralTemplateDomainEventsExchange> GeneralTemplate { get; set; } = default!;

#if (IncludePlayerInfrastructure && IncludeTeamInfrastructure)
    public GeneralTemplateTeamDomainExchange Team { get; set; } = default!;
#endif
}

public class GeneralTemplateGeneralTemplateDomainEventsExchange
{
    public Exchange Created { get; set; } = default!;

    public Exchange Updated { get; set; } = default!;
}

#if (IncludePlayerInfrastructure && IncludeTeamInfrastructure)
public class GeneralTemplateTeamDomainExchange
{
    public DomainExchange<GeneralTemplateTeamPlayerDomainEventsExchange> Player { get; set; } = default!;
}

public class GeneralTemplateTeamPlayerDomainEventsExchange
{
    public Exchange Created { get; set; } = default!;

    public Exchange Updated { get; set; } = default!;
}
#endif