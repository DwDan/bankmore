using BM.BuildingBlocks.Infrastructure.Messaging.EventBus;

namespace BM.BuildingBlocks.Infrastructure.Messaging.Kafka;

public class KafkaConsumerSettings : EventBusConsumerSettings
{
    public string BootstrapServers { get; set; } = default!;
    public string ClientId { get; set; } = default!;
    public string GroupId { get; set; } = null!;
}
