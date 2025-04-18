using Microsoft.AspNetCore.Identity;
using TFG.PWManager.BackEnd.Hash.Contracts;

namespace TFG.PWManager.BackEnd.Hash.Services
{
    public class HashService : IHashService
    {
        public string HashPassword(string password)
        {
            var hasher = new PasswordHasher<IdentityUser>();
            return hasher.HashPassword(new IdentityUser(), password);
        }

        public bool VerifyHashedPassword(string? passwordHash, string password)
        {
            var hasher = new PasswordHasher<IdentityUser>();
            return hasher.VerifyHashedPassword(new IdentityUser(), passwordHash, password) != PasswordVerificationResult.Failed;
        }
    }
}
