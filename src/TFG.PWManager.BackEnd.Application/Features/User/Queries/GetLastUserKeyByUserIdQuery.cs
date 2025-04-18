using MediatR;
using TFG.PWManager.BackEnd.Domain.Models;

namespace TFG.PWManager.BackEnd.Application.Features.User.Queries
{
    public class GetLastUserKeyByUserIdQuery : IRequest<UserKeyModel>
    {
        public int IdUser { get; set; }

        public GetLastUserKeyByUserIdQuery(int idUser)
        {
            IdUser = idUser;
        }
    }
}
