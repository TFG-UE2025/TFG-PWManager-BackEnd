using MediatR;
using TFG.PWManager.BackEnd.Domain.Models;

namespace TFG.PWManager.BackEnd.Application.Features.Token.Queries
{
    public class GetTokenRefreshByEmailQuery : IRequest<TokenModel>
    {
        public string Email { get; set; }

        public GetTokenRefreshByEmailQuery(string email)
        {
            Email = email;
        }
    }
}
