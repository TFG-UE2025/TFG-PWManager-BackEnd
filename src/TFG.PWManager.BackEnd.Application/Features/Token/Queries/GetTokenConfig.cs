using MediatR;
using TFG.PWManager.BackEnd.Domain.Commons;

namespace TFG.PWManager.BackEnd.Application.Features.Token.Queries
{
    public class GetTokenConfig : IRequest<TokenConfigModel>
    {
        public GetTokenConfig()
        {
        }
    }
}
