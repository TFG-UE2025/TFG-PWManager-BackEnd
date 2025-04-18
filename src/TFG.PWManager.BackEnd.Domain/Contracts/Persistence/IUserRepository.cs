using TFG.PWManager.BackEnd.Domain.Entities;
using TFG.PWManager.BackEnd.Domain.Models;

namespace TFG.PWManager.BackEnd.Domain.Contracts.Persistence
{
    public interface IUserRepository
    {
        Task<User?> GetUserByEmailAsync(string email);

        Task<User?> GetUserByIdAsync(int id);

        Task<OkResponseModel> AddUserAsync(User user);

        Task<OkResponseModel> UpdateUserAsync(User user);

        Task<OkResponseModel> DeleteUserAsync(User user, bool logical);
    }
}
