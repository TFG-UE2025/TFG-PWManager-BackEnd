using MediatR;
using TFG.PWManager.BackEnd.Application.Features.User.Commands;
using TFG.PWManager.BackEnd.Application.Features.User.Queries;
using TFG.PWManager.BackEnd.Domain.Models;

namespace TFG.PWManager.BackEnd.Application.Features.User
{
    public class UserHandler :
       IRequestHandler<GetUserByEmailQuery, UserModel>,
       IRequestHandler<CreateUserCommand, OkResponseModel>,
       IRequestHandler<UpdateUserCommand, OkResponseModel>,
       IRequestHandler<DeleteUserCommand, OkResponseModel>,
       IRequestHandler<ChangeUserPasswordCommand, OkResponseModel>,
       IRequestHandler<GetThreeLastsUserKeysByUserIdQuery, IEnumerable<UserKeyModel>>,
       IRequestHandler<GetLastUserKeyByUserIdQuery, UserKeyModel>
    {
        public Task<UserModel> Handle(GetUserByEmailQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<OkResponseModel> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<OkResponseModel> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<OkResponseModel> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<OkResponseModel> Handle(ChangeUserPasswordCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<UserKeyModel>> Handle(GetThreeLastsUserKeysByUserIdQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<UserKeyModel> Handle(GetLastUserKeyByUserIdQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
