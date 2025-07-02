using BM.BuildingBlocks.Domain.Events.Base;

namespace BM.BuildingBlocks.Domain.Messaging;

public interface IIntegrationEventHandler<TEvent> where TEvent : IntegrationEvent
{
    Task HandleAsync(TEvent evento, CancellationToken cancellationToken);
}
