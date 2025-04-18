using MediatR;
using TFG.PWManager.BackEnd.Domain.Models;

namespace TFG.PWManager.BackEnd.Application.Features.Token.Commans
{
    public class PutTokenCommand : IRequest<OkResponseModel>
    {
        public List<string> ListEmail { get; set; }

        public PutTokenCommand(List<string> listEmail)
        {
            ListEmail = listEmail;
        }
    }
}
