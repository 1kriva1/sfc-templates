#if IncludeTeamInfrastructure
using SFC.GeneralTemplate.Infrastructure.Settings.RabbitMq.Exchanges.Common.Data;
using SFC.GeneralTemplate.Infrastructure.Settings.RabbitMq.Exchanges.Common.Domain;

namespace SFC.GeneralTemplate.Infrastructure.Settings.RabbitMq.Exchanges;
public class TeamExchangeValue
{
    public DataExchange<TeamDataDependentExchange> Data { get; set; } = default!;

    public TeamDomainExchange Domain { get; set; } = default!;
}

public class TeamDataDependentExchange
{  
    public DataDependentExchange GeneralTemplate { get; set; } = default!;
}

public class TeamDomainExchange
{
    public DomainExchange<TeamDomainEventsExchange> Team { get; set; } = default!;

#if (IncludePlayerInfrastructure && IncludeTeamInfrastructure)
    public DomainExchange<TeamPlayerDomainEventsExchange> Player { get; set; } = default!;
#endif
}

public class TeamDomainEventsExchange
{
    public Exchange Created { get; set; } = default!;

    public Exchange Updated { get; set; } = default!;
}

#if (IncludePlayerInfrastructure && IncludeTeamInfrastructure)
public class TeamPlayerDomainEventsExchange
{
    public Exchange Created { get; set; } = default!;

    public Exchange Updated { get; set; } = default!;
}
#endif
#endif