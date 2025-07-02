using System.Diagnostics;
using BM.BuildingBlocks.Domain.Context;

namespace BM.BuildingBlocks.Infrastructure.Messaging;

public class CorrelationContext : ICorrelationContext
{
    private string? _correlationId;

    public string CorrelationId
    {
        get => _correlationId
            ?? Activity.Current?.GetTagItem("CorrelationId")?.ToString()
            ?? Activity.Current?.TraceId.ToString()
            ?? "N/A";
    }

    public void Set(string correlationId)
    {
        _correlationId = correlationId;
    }
}
