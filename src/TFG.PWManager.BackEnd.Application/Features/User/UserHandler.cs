using AutoMapper;
using MediatR;
using TFG.PWManager.BackEnd.Application.Features.User.Commands;
using TFG.PWManager.BackEnd.Application.Features.User.Queries;
using TFG.PWManager.BackEnd.Domain.Contracts.Persistence;
using TFG.PWManager.BackEnd.Domain.Exceptions;
using TFG.PWManager.BackEnd.Domain.Models;
using TFG.PWManager.BackEnd.Domain.Resources;

namespace TFG.PWManager.BackEnd.Application.Features.User
{
    public class UserHandler :
       IRequestHandler<GetUserByEmailQuery, UserModel>,
       IRequestHandler<CreateUserCommand, OkResponseModel>,
       IRequestHandler<UpdateUserCommand, OkResponseModel>,
       IRequestHandler<DeleteUserCommand, OkResponseModel>,
       IRequestHandler<ChangeUserPasswordCommand, OkResponseModel>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UserHandler(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<UserModel> Handle(GetUserByEmailQuery request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetUserByEmailAsync(request.Email);
            return _mapper.Map<UserModel>(user);
        }

        public async Task<OkResponseModel> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<Domain.Entities.User>(request.Model);            
            entity.Enabled = true;

            return await _userRepository.AddUserAsync(entity);
        }

        public async Task<OkResponseModel> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            var entity = await _userRepository.GetUserByIdAsync(request.Id);

            if (entity == null)
            {
                throw new NotFoundException(ExceptionsMessages.NullEntity);
            }

            request.Model.PasswordHash = entity.PasswordHash;

            _mapper.Map(request.Model, entity);
            
            return await _userRepository.UpdateUserAsync(entity);
        }

        public async Task<OkResponseModel> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            //TODO: controlar Si quiere elimeinar la cuenta 
            var entity = await _userRepository.GetUserByIdAsync(request.Id) ?? throw new NotFoundException(ExceptionsMessages.NullEntity);
                        
            entity.Enabled = false;            

            return await _userRepository.DeleteUserAsync(entity, true);
        }

        public async Task<OkResponseModel> Handle(ChangeUserPasswordCommand request, CancellationToken cancellationToken)
        {
            var entity = await _userRepository.GetUserByIdAsync(request.Id) ?? throw new NotFoundException(ExceptionsMessages.NullEntity);

            entity.PasswordHash = request.newPassword;

            return await _userRepository.UpdateUserAsync(entity);
        }

    }
}
