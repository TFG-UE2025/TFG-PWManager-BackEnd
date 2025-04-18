using Microsoft.EntityFrameworkCore;
using TFG.PWManager.BackEnd.Domain.Contracts.Persistence;
using TFG.PWManager.BackEnd.Domain.Entities;
using TFG.PWManager.BackEnd.Domain.Models;
using TFG.PWManager.BackEnd.Infrastructure.Context;

namespace TFG.PWManager.BackEnd.Infrastructure.Persistence
{
    public class UserRepository : IUserRepository
    {
        protected readonly PWManagerDbContext _context;

        public UserRepository(PWManagerDbContext context)
        {
            _context = context;
        }

        public async Task<OkResponseModel> AddUserAsync(User user)
        {
            _context.Set<User>().Add(user);
            await _context.SaveChangesAsync();

            var response = new OkResponseModel()
            {
                Id = user.Id,
                Message = "successful update"
            };
            return response;
        }

        public async Task<OkResponseModel> DeleteUserAsync(User user, bool logical)
        {
            if (logical)
            {
                user.Enabled = false;
                await UpdateUserAsync(user);
            }
            else
            {
                _context.Set<User>().Remove(user);
                await _context.SaveChangesAsync();
            }

            return new OkResponseModel()
            {
                Id = user.Id,
                Message = "successful delete"
            };
        }

        public async Task<User?> GetUserByEmailAsync(string email)
        {
            return await _context.User!
                .Include(l => l.Language)
                .Where(x => x.Email == email && x.Enabled && x.ActiveChk).FirstOrDefaultAsync();
        }

        public async Task<User?> GetUserByIdAsync(int id)
        {
            return await _context.User!
                .Include(l => l.Language)
                .Where(x => x.Id == id && x.Enabled && x.ActiveChk).FirstOrDefaultAsync();
        }

        public async Task<OkResponseModel> UpdateUserAsync(User user)
        {
            _context.Set<User>().Attach(user);
            _context.Entry(user).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            var response = new OkResponseModel()
            {
                Id = user.Id,
                Message = "successful update"
            };
            return response;
        }
    }
}
