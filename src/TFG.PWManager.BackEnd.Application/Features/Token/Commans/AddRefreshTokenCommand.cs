using MediatR;
using TFG.PWManager.BackEnd.Domain.Models;

namespace TFG.PWManager.BackEnd.Application.Features.Token.Commans
{
    public class AddRefreshTokenCommand : IRequest<OkResponseModel>
    {
        public TokenModel TokenModel { get; set; }

        public AddRefreshTokenCommand(TokenModel tokenModel)
        {
            TokenModel = tokenModel;
        }
    }
}
