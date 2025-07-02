namespace BM.BuildingBlocks.Domain.Abstractions;

public interface IEntity
{
    IReadOnlyCollection<IDomainEvent> ObterEventosDominio();
    void AdicionarEventoDominio(IDomainEvent evento);
    void LimparEventosDominio();
}
