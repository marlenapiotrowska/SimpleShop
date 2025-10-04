using Microsoft.Extensions.DependencyInjection;
using SimpleShop.Application.Abstractions;

namespace SimpleShop.Application.Handlers;

public class EventPublisher(
    IServiceProvider serviceProvider)
    : IEventPublisher
{
    public async Task PublishAsync<TEvent>(TEvent @event, CancellationToken cancellationToken)
        where TEvent : IEvent
    {
        var eventType = @event.GetType();

        try
        {
            var handlers = serviceProvider.GetServices<IEventHandler<TEvent>>().ToArray();

            if (handlers.Length == 0)
            {
                return;
            }

            var handlerTasks = handlers.Select(handler =>
                    ExecuteHandlerAsync(handler, @event, cancellationToken))
                .ToList();

            await Task.WhenAll(handlerTasks);

            var exceptions = handlerTasks
                .Select(t => t.Exception)
                .Where(ex => ex != null)
                .ToList();

            if (exceptions.Count > 0)
            {
                throw new AggregateException($"One or more handlers threw exceptions while processing event {eventType.Name}", exceptions);
            }
        }
        catch (Exception)
        {
            throw;
        }
    }

    private async Task<Exception?> ExecuteHandlerAsync<TEvent>(
        IEventHandler<TEvent> handler,
        TEvent @event,
        CancellationToken cancellationToken)
        where TEvent : IEvent
    {
        try
        {
            await handler.HandleAsync(@event, cancellationToken);
            return null;
        }
        catch (Exception ex)
        {
            return ex;
        }
    }
}
