﻿using SFC.GeneralTemplate.Infrastructure.Settings.RabbitMq.Exchanges;

namespace SFC.GeneralTemplate.Infrastructure.Settings.RabbitMq;
public class RabbitMqSettings
{
    public const string SectionKey = "RabbitMq";

    public string Username { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string Name { get; set; } = null!;

    public RabbitMqRetrySettings Retry { get; set; } = default!;

    public RabbitMqExchangesSettings Exchanges { get; set; } = default!;
}

public class RabbitMqRetrySettings
{
    public ushort Limit { get; set; }

    public IEnumerable<ushort> Intervals { get; set; } = [];
}

#region Exchanges

public class RabbitMqExchangesSettings
{
    public ExchangeSetting<DataExchangeValue> Data { get; set; } = default!;

    public ExchangeSetting<IdentityExchangeValue> Identity { get; set; } = default!;

    public ExchangeSetting<GeneralTemplateExchangeValue> GeneralTemplate { get; set; } = default!;

#if IncludePlayerInfrastructure
    public ExchangeSetting<PlayerExchangeValue> Player { get; set; } = default!;
#endif

#if IncludeTeamInfrastructure
    public ExchangeSetting<TeamExchangeValue> Team { get; set; } = default!;
#endif
}

public class ExchangeSetting<T>
{
    public string Key { get; set; } = default!;

    public T Value { get; set; } = default!;
}

public class Message
{
    public string Name { get; set; } = default!;
}

public class Exchange : Message
{
    public string Type { get; set; } = default!;

    public string? RoutingKey { get; set; }
}

#endregion Exchanges
