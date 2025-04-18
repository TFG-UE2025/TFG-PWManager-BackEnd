using MediatR;
using TFG.PWManager.BackEnd.Domain.Models;

namespace TFG.PWManager.BackEnd.Application.Features.User.Commands
{
    public class CreateUserCommand : IRequest<OkResponseModel>
    {
        public UserModel Model { get; set; }

        public bool Save { get; set; }

        public CreateUserCommand(UserModel model, bool save = true)
        {
            Model = model;
            Save = save;
        }
    }
}
