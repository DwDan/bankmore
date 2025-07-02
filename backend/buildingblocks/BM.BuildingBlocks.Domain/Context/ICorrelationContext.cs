namespace BM.BuildingBlocks.Domain.Context;

public interface ICorrelationContext
{
    string CorrelationId { get; }
    void Set(string correlationId);
}
