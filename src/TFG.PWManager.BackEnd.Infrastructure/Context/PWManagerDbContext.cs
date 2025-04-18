using Microsoft.EntityFrameworkCore;
using TFG.PWManager.BackEnd.Application.Registration;

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
        }

    }
}
