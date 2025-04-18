using MediatR;
using TFG.PWManager.BackEnd.Domain.Models;

namespace TFG.PWManager.BackEnd.Application.Features.Token.Commans
{
    public class PutRefreshTokenCommand : IRequest<OkResponseModel>
    {
        public string Email { get; set; }
        public string ExpiredDate { get; set; }

        public PutRefreshTokenCommand(string email, string expiredDate)
        {
            Email = email;
            ExpiredDate = expiredDate;
        }
    }
}
