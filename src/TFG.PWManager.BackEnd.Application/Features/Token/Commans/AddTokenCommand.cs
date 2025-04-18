using MediatR;
using TFG.PWManager.BackEnd.Domain.Models;

namespace TFG.PWManager.BackEnd.Application.Features.Token.Commans
{
    public class AddTokenCommand : IRequest<OkResponseModel>
    {
        public TokenModel TokenModel { get; set; }

        public AddTokenCommand(TokenModel tokenModel)
        {
            TokenModel = tokenModel;
        }
    }
}
