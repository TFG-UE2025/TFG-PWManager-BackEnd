using TFG.PWManager.BackEnd.Domain.Models;

namespace TFG.PWManager.BackEnd.Domain.Contracts.Services
{
    public interface ITokenService
    {
        Task<TokenModel> GetToken(string[] credentials);

        Task<TokenModel> PostToken(string[] credentials, bool verify = true);

        Task<bool> IsValidToken(TokenInfoModel tokenInfo);

        Task<TokenModel> RefreshToken(string email);

        Task<OkResponseModel> InvalidateTokenByEmail(string email);

        Task<bool> GetEnabledToken(string email);
    }
}
