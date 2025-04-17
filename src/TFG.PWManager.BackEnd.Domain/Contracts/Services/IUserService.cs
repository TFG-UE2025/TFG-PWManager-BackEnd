using TFG.PWManager.BackEnd.Domain.Models;

namespace TFG.PWManager.BackEnd.Domain.Contracts.Services
{
    public interface IUserService
    {
        Task<UserModel> GetUserByEmail(string email);

        Task<UserModel> GetByIdAsync(int id);

        Task<OkResponseModel> CreateUser(UserModel model);

        Task<OkResponseModel> UpdateUser(int id, UserModel model);

        Task<OkResponseModel> ChangeUserPassword(string newPasswordHash, string useremail);

        Task<OkResponseModel> ChangeUserPassword(string oldPasswordHash, string newPasswordHash, string useremail);

        Task<OkResponseModel> DeleteUser(int id);
    }
}
