using FluentValidation;

namespace BM.BuildingBlocks.Infrastructure.Messaging.EventBus;

public class EventBusConsumerSettingsValidator : AbstractValidator<EventBusConsumerSettings>
{
    public EventBusConsumerSettingsValidator()
    {
        RuleFor(x => x.Topic)
            .NotEmpty().WithMessage("Configuração EventBus.Topic obrigatória.");
    }
}
