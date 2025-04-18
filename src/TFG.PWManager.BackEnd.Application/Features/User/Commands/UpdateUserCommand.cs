using MediatR;
using TFG.PWManager.BackEnd.Domain.Models;

namespace TFG.PWManager.BackEnd.Application.Features.User.Commands
{
    public class UpdateUserCommand : IRequest<OkResponseModel>
    {
        public int Id { get; set; }

        public UserModel Model { get; set; }

        public UpdateUserCommand(int id, UserModel model)
        {
            Id = id;
            Model = model;
        }
    }
}
