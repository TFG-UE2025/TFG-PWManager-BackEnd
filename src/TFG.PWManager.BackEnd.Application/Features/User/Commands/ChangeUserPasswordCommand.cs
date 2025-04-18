using MediatR;
using TFG.PWManager.BackEnd.Domain.Models;

namespace TFG.PWManager.BackEnd.Application.Features.User.Commands
{
    public class ChangeUserPasswordCommand : IRequest<OkResponseModel>
    {
        public int Id { get; set; }
        public string newPassword { get; set; }
        public ChangeUserPasswordCommand(int id, string password)
        {
            Id = id;
            newPassword = password;           
        }
    }
}
