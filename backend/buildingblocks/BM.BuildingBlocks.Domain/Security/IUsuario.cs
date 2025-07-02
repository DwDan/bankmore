namespace BM.BuildingBlocks.Domain.Security;

public interface IUsuario
{
    public Guid Id { get; }
    public string Cpf { get; }
}
