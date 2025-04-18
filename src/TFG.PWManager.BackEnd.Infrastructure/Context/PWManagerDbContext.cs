using Microsoft.EntityFrameworkCore;
using TFG.PWManager.BackEnd.Application.Registration;
using TFG.PWManager.BackEnd.Domain.Entities;
using TFG.PWManager.BackEnd.Infrastructure.Context.Mappings;

namespace TFG.PWManager.BackEnd.Infrastructure.Context
{
    public class PWManagerDbContext : DbContext
    {
        public PWManagerDbContext()
        {
        }

        public PWManagerDbContext(DbContextOptions<PWManagerDbContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(ConfigurationManager.CurrentDB);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.HasDefaultSchema(ConfigurationManager.SchemaDB);

            modelBuilder.ApplyConfiguration(new TokenMapper());
            modelBuilder.ApplyConfiguration(new UserMapper());
            modelBuilder.ApplyConfiguration(new LanguageMapper());
        }

        public DbSet<Token>? Token { get; set; }

        public DbSet<TokenConfig>? TokenConfig { get; set; }

        public DbSet<User>? User { get; set; }

        public DbSet<Language>? Language { get; set; }
    }
}
