﻿namespace Whispr;

/// <summary>
/// Service collection extensions.
/// </summary>
public static class ServiceCollectionExtensions
{
    /// <summary>
    /// Adds Whispr to the service collection.
    /// </summary>
    /// <param name="services">The service collection.</param>
    /// <returns>The <see cref="WhisprBuilder"/>.</returns>
    public static WhisprBuilder AddWhispr(this IServiceCollection services)
    {
        services
            .AddSingleton<IMessageBusInitializer, MessageBusInitializer>()
            .AddSingleton<IDiagnosticEventListener, ActivityDiagnosticEventListener>()
            .AddSingleton<IMessageSender, MessageSender>()
            .AddScoped<IMessagePublisher, MessagePublisher>()
            .AddScoped(typeof(MessageProcessor<,>));

        return new WhisprBuilder(services);
    }
}
