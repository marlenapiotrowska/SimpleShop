namespace SimpleShop.Application.Abstractions;

public interface IEventHandler;

public interface IEventHandler<in TEvent>
    : IEventHandler
    where TEvent : IEvent
{
    Task HandleAsync(TEvent @event, CancellationToken cancellationToken);
}
