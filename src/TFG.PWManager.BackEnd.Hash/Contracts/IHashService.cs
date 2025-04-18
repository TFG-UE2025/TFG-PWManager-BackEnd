
namespace TFG.PWManager.BackEnd.Hash.Contracts
{
    public interface IHashService
    {
        bool VerifyHashedPassword(string? passwordHash, string password);

        string HashPassword(string password);
    }
}
