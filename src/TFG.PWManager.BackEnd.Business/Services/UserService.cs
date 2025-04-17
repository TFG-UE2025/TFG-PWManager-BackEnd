using TFG.PWManager.BackEnd.Domain.Contracts.Services;
using TFG.PWManager.BackEnd.Domain.Models;

namespace TFG.PWManager.BackEnd.Business.Services
{
    public class UserService : IUserService
    {
        public Task<OkResponseModel> ChangeUserPassword(string newPasswordHash, string useremail)
        {
            throw new NotImplementedException();
        }

        public Task<OkResponseModel> ChangeUserPassword(string oldPasswordHash, string newPasswordHash, string useremail)
        {
            throw new NotImplementedException();
        }

        public Task<OkResponseModel> CreateUser(UserModel model)
        {
            throw new NotImplementedException();
        }

        public Task<OkResponseModel> DeleteUser(int id)
        {
            throw new NotImplementedException();
        }

        public Task<UserModel> GetUserByEmail(string email)
        {
            throw new NotImplementedException();
        }

        public Task<UserModel> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<OkResponseModel> UpdateUser(int id, UserModel model)
        {
            throw new NotImplementedException();
        }
    }
}
