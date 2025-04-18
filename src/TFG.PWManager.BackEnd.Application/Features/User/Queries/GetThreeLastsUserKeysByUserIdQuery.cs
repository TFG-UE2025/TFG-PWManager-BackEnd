using MediatR;
using TFG.PWManager.BackEnd.Domain.Models;

namespace TFG.PWManager.BackEnd.Application.Features.User.Queries
{
    public class GetThreeLastsUserKeysByUserIdQuery : IRequest<IEnumerable<UserKeyModel>>
    {
        public int IdUser { get; set; }
        public int LastKeys { get; set; }

        public GetThreeLastsUserKeysByUserIdQuery(int idUser, int lastKeys)
        {
            IdUser = idUser;
            LastKeys = lastKeys;
        }
    }
}
