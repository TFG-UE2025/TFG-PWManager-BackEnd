using FluentValidation.Results;
using System.Text.RegularExpressions;
using System.Text;
using TFG.PWManager.BackEnd.Domain.Contracts.Services;
using TFG.PWManager.BackEnd.Domain.Exceptions;
using TFG.PWManager.BackEnd.Domain.Models;
using TFG.PWManager.BackEnd.Application.Registration;
using TFG.PWManager.BackEnd.Application.Features.User.Queries;
using MediatR;
using TFG.PWManager.BackEnd.Application.Features.User.Commands;
using TFG.PWManager.BackEnd.Hash.Contracts;
using TFG.PWManager.BackEnd.Domain.Resources.User;

namespace TFG.PWManager.BackEnd.Business.Services
{
    public class UserService : IUserService
    {
        protected readonly IMediator _mediator;
        private readonly IHashService _hashService;
        private readonly ITokenService _tokenService;

        public UserService(IMediator mediator, IHashService hashService, ITokenService tokenService)
        {
            _mediator = mediator;
            _hashService = hashService;
            _tokenService = tokenService;
        }

        public async Task<OkResponseModel> CreateUser(UserModel model)
        {
            var user = await GetUserByEmail(model.Email!);

            if (user != null)
            {
                if (user.ActiveChk)
                    throw new BadRequestException($"El email: {model.Email} ya pertenece a otro Usuario activo");

                model.ActiveChk = true;
                model.Id = user.Id;
                var Updatecommand = new UpdateUserCommand(user.Id, model);

                var UpdateResp = await _mediator.Send(Updatecommand);
                UpdateResp.Message = "Usuario reactivado";
                return UpdateResp;
            }

            if (!CheckUserKey(model.PasswordHash!))
                throw new ValidationException(new List<ValidationFailure>() { new(nameof(RoleModel.Id), UserModelResources.NOTSECUREFORMATPASSWORD) });

            model.PasswordHash = GeneratePasswordHash(model.PasswordHash!);

            var command = new CreateUserCommand(model);

            var resp = await _mediator.Send(command);
            resp.Message = "Usuario creado con exito";

            return resp;
        }

        public async Task<UserModel> GetUserByEmail(string email)
        {
            var queryUser = new GetUserByEmailQuery(email);
            var user = await _mediator.Send(queryUser);

            return user;
        }

        public async Task<OkResponseModel> ChangeUserPassword(string newPasswordHash, string useremail)
        {
            var user = await GetUserByEmail(useremail) ?? throw new BadRequestException($"El email: {useremail} no pertenece a ningun usuario");

            if (!CheckUserKey(newPasswordHash))
                throw new ValidationException(new List<ValidationFailure>() { new(nameof(RoleModel.Id), UserModelResources.NOTSECUREFORMATPASSWORD) });

            if (await CheckIfKeyIsUsedAsync(user.Id, newPasswordHash))
                throw new ValidationException(new List<ValidationFailure>() { new(nameof(RoleModel.Id), UserModelResources.PASSWORDUSEDRECENTLY) });

            user.PasswordHash = GeneratePasswordHash(newPasswordHash);

            var command = new ChangeUserPasswordCommand(user.Id, user.PasswordHash);

            return await _mediator.Send(command);
        }

        public async Task<OkResponseModel> ChangeUserPassword(string oldPasswordHash, string newPasswordHash, string useremail)
        {
            var user = await GetUserByEmail(useremail) ?? throw new BadRequestException($"El email: {useremail} no pertenece a ningun usuario");

            if (!_hashService.VerifyHashedPassword(user.PasswordHash, Encoding.UTF8.GetString(Convert.FromBase64String(oldPasswordHash))))
                throw new BadRequestException($"El password no corresponde con el del usurio {useremail}");

            if (!CheckUserKey(newPasswordHash))
                throw new ValidationException(new List<ValidationFailure>() { new(nameof(RoleModel.Id), UserModelResources.NOTSECUREFORMATPASSWORD) });

            if (await CheckIfKeyIsUsedAsync(user.Id, newPasswordHash))
                throw new ValidationException(new List<ValidationFailure>() { new(nameof(RoleModel.Id), UserModelResources.PASSWORDUSEDRECENTLY) });

            user.PasswordHash = GeneratePasswordHash(newPasswordHash);
            var command = new ChangeUserPasswordCommand(user.Id, user.PasswordHash!);

            return await _mediator.Send(command);
        }

        public async Task<OkResponseModel> DeleteUser(int id)
        {
            var command = new DeleteUserCommand(id);
            return await _mediator.Send(command);
        }       

        public async Task<UserModel> GetByIdAsync(int id)
        {
            var query = new GetUserByIdQuery(id);
            return await _mediator.Send(query);
        }

        public async Task<OkResponseModel> UpdateUser(int id, UserModel model)
        {
            var queryUser = new GetUserByEmailQuery(model.Email!);
            var user = await _mediator.Send(queryUser);

            if (user != null && user.Id != model.Id)
            {
                throw new BadRequestException($"El email: {model.Email} ya pertenece a otro Usuario");
            }

            var current = await GetByIdAsync(model.Id);
            var validTokenInfo = await CheckTokenInfo(current!, model);

            if (current != null && !validTokenInfo)
            {
                await _tokenService.InvalidateTokenByEmail(current.Email!);
            }

            var command = new UpdateUserCommand(id, model);
            return await _mediator.Send(command);
        }

        private string GeneratePasswordHash(string passwordHash)
        {
            var password = Encoding.UTF8.GetString(Convert.FromBase64String(passwordHash));
            return _hashService.HashPassword(password);
        }

        private async Task<bool> CheckTokenInfo(UserModel current, UserModel model)
        {
            var validTokenInfo = true;

            if (current != null)
            {
                var hasToken = await _tokenService.GetEnabledToken(current.Email!);

                if (hasToken)
                {
                    if (current.Email != model.Email || current.LanguageId != model.LanguageId)
                    {
                        validTokenInfo = false;
                    }
                    else
                    {
                        var roles = new List<RoleModel> { new RoleModel { Id = 1, Description = "Administrador", Name = "Admin" } };

                        foreach (var role in roles)
                        {
                            var exists = model.Roles!.FirstOrDefault(x => x.Id == role.Id);
                            validTokenInfo = exists != null;

                            if (!validTokenInfo)
                            {
                                break;
                            }
                        }

                        if (validTokenInfo)
                        {
                            foreach (var role in model.Roles!)
                            {
                                var exists = roles.FirstOrDefault(x => x.Id == role.Id);
                                validTokenInfo = exists != null;

                                if (!validTokenInfo)
                                {
                                    break;
                                }
                            }
                        }
                    }
                }
            }

            return validTokenInfo;
        }

        private static bool CheckUserKey(string passwordHash)
        {
            if (ConfigurationManager.ConfigAuditUserKey == null || ConfigurationManager.ConfigAuditUserKey.UseRegex)
                return true;

            var password = Encoding.UTF8.GetString(Convert.FromBase64String(passwordHash));

            var hasNumber = new Regex(@"[0-9]+");
            var hasUpperChar = new Regex(@"[A-Z]+");
            var hasLowerChar = new Regex(@"[a-z]+");
            var hasMinimum8Chars = new Regex(@".{7,}");
            var noHasSpecialCharacter = new Regex("^[a-zA-Z0-9 ]*$");

            var isValidated = hasNumber.IsMatch(password)
                && hasUpperChar.IsMatch(password)
                && hasLowerChar.IsMatch(password)
                && hasMinimum8Chars.IsMatch(password)
                && !noHasSpecialCharacter.IsMatch(password);

            return isValidated;
        }

        private async Task<bool> CheckIfKeyIsUsedAsync(int idUser, string newPasswordHash)
        {
            if (ConfigurationManager.ConfigAuditUserKey == null || ConfigurationManager.ConfigAuditUserKey.ExpiredKeyInDays == 0)
                return false;

            var queryUser = new GetThreeLastsUserKeysByUserIdQuery(idUser, 3);
            var userkey = await _mediator.Send(queryUser);

            foreach (var key in userkey)
            {
                if (!_hashService.VerifyHashedPassword(key.PasswordHash!, Encoding.UTF8.GetString(Convert.FromBase64String(newPasswordHash))))
                    continue;

                return true;
            }

            return false;
        }
    }
}
