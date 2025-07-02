namespace BM.BuildingBlocks.Domain.Abstractions;

public interface IRepository<T> : IDisposable where T : IAggregateRoot
{
    IUnitOfWork UnitOfWork { get; }
}