using BM.BuildingBlocks.Domain.Events.Base;

namespace BM.BuildingBlocks.Domain.Messaging.EventBus;

public interface IEventBusProducer
{
    Task PublicarAsync<T>(string topic, T message) where T : IntegrationEvent;
}
