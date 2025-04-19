using Microsoft.EntityFrameworkCore;
using TFG.PWManager.BackEnd.Domain.Contracts.Persistence;
using TFG.PWManager.BackEnd.Domain.Entities;
using TFG.PWManager.BackEnd.Domain.Extensions;
using TFG.PWManager.BackEnd.Domain.Models;
using TFG.PWManager.BackEnd.Infrastructure.Context;

namespace TFG.PWManager.BackEnd.Infrastructure.Persistence
{
    public class TokenRepository : ITokenRepository
    {
        protected readonly PWManagerDbContext _context;

        public TokenRepository(PWManagerDbContext context)
        {
            _context = context;
        }

        public async Task<Token?> GetRefeshTokenByEmailAsync(string email)
        {
            var currentDt = DateTime.UtcNow.ConvertDateTime();
            return await _context.Token!.Where(x => x.Email == email && x.ExpiredDate >= currentDt && x.Enabled && x.IsRefreshToken)
                .OrderByDescending(x => x.ExpiredDate).FirstOrDefaultAsync();
        }

        public async Task<List<Token>> GetTokenByEmailAsync(List<string> listEmail)
        {
            var currentDt = DateTime.UtcNow.ConvertDateTime();
            return await _context.Token!.Where(x => listEmail.Contains(x.Email!) && x.ExpiredDate >= currentDt && x.Enabled && !x.IsRefreshToken)
                .OrderByDescending(x => x.ExpiredDate).ToListAsync();
        }

        public async Task<TokenConfig?> GetTokenConfigAsync()
        {
            return await _context.TokenConfig!.FirstOrDefaultAsync();
        }

        public async Task<OkResponseModel> AddTokenAsync(Token token)
        {
            _context.Set<Token>().Add(token);
            await _context.SaveChangesAsync();

            var response = new OkResponseModel()
            {
                Id = token.Id,
                Message = "successful update"
            };
            return response;
        }

        public async Task<OkResponseModel> UpdateTokenAsync(Token token)
        {
            _context.Set<Token>().Attach(token);
            _context.Entry(token).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            var response = new OkResponseModel()
            {
                Id = token.Id,
                Message = "successful update"
            };
            return response;
        }
    }
}
