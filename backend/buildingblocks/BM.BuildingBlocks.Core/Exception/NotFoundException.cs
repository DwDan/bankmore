namespace BM.BuildingBlocks.Core.Exception;

public class NotFoundException : System.Exception
{
    public NotFoundException(string errorCode)
        : base(errorCode) { }

    public NotFoundException(string errorCode, System.Exception innerException)
        : base(errorCode, innerException) { }
}
