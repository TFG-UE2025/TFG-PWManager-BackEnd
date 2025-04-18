using MediatR;
using TFG.PWManager.BackEnd.Domain.Models;

namespace TFG.PWManager.BackEnd.Application.Features.Token.Queries
{
    public class GetTokenByEmailQuery : IRequest<TokenModel>
    {
        public string Email { get; set; }

        public GetTokenByEmailQuery(string email)
        {
            Email = email;
        }
    }
}
