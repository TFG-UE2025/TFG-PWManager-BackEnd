using TFG.PWManager.BackEnd.Domain.Models;

namespace TFG.PWManager.BackEnd.Jwt.Contracts
{
    public interface IJwtService
    {
        JwtResponseModel GenerateJwt(JwtRequestModel request);
    }
}
