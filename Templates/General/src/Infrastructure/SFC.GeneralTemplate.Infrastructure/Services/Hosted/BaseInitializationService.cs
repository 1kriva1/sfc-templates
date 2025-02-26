﻿using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace SFC.GeneralTemplate.Infrastructure.Services.Hosted;
public abstract class BaseInitializationService(ILogger logger) : IHostedService
{
    private readonly ILogger _logger = logger;

    public int MyProperty { get; set; }

    protected ILogger Logger { get { return _logger; } }

    public virtual Task StartAsync(CancellationToken cancellationToken)
    {
        return ExecuteAsync(cancellationToken);
    }

    public virtual Task StopAsync(CancellationToken cancellationToken)
    {
        return Task.CompletedTask;
    }

    protected abstract Task ExecuteAsync(CancellationToken cancellationToken);
}
