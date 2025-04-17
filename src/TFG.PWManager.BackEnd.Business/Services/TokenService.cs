using TFG.PWManager.BackEnd.Domain.Contracts.Services;
using TFG.PWManager.BackEnd.Domain.Models;

namespace TFG.PWManager.BackEnd.Business.Services
{
    internal class TokenService : ITokenService
    {
        public Task<bool> GetEnabledToken(string email)
        {
            throw new NotImplementedException();
        }

        public Task<TokenModel> GetToken(string[] credentials)
        {
            throw new NotImplementedException();
        }

        public Task<OkResponseModel> InvalidateTokenByEmail(string email)
        {
            throw new NotImplementedException();
        }

        public Task<OkResponseModel> InvalidateTokenByRol(int idRol)
        {
            throw new NotImplementedException();
        }

        public Task<bool> IsValidToken(TokenInfoModel tokenInfo)
        {
            throw new NotImplementedException();
        }

        public Task<TokenModel> PostToken(string[] credentials, bool verify = true)
        {
            throw new NotImplementedException();
        }

        public Task<TokenModel> RefreshToken(string email)
        {
            throw new NotImplementedException();
        }
    }
}
