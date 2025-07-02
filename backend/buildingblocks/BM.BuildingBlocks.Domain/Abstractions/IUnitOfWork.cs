namespace BM.BuildingBlocks.Domain.Abstractions;

public interface IUnitOfWork
{
    Task<bool> CommitAsync(CancellationToken cancellationToken);
    Task EnsureCommitAsync(CancellationToken cancellationToken);
}