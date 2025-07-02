namespace BM.BuildingBlocks.Domain.Security;

public interface IPasswordHash
{
    string HashPassword(string password);
    bool Verify(string password, string hash);
}
