using TFG.PWManager.BackEnd.Domain.Entities;
using TFG.PWManager.BackEnd.Domain.Models;

namespace TFG.PWManager.BackEnd.Domain.Contracts.Persistence
{
    public interface ITokenRepository
    {
        Task<OkResponseModel> AddTokenAsync(Token token);

        Task<List<Token>> GetTokenByEmailAsync(List<string> listEmail);

        Task<Token?> GetRefeshTokenByEmailAsync(string email);

        Task<TokenConfig?> GetTokenConfigAsync();

        Task<OkResponseModel> UpdateTokenAsync(Token token);
    }
}
