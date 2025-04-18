using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using TFG.PWManager.BackEnd.Domain.Entities;

namespace TFG.PWManager.BackEnd.Infrastructure.Context.Mappings
{
    public class TokenMapper : IEntityTypeConfiguration<Token>
    {
        public void Configure(EntityTypeBuilder<Token> builder)
        {
            builder.ToTable("Token");
            builder.HasKey(e => new { e.Id });
            builder.Property(e => e.Id).HasColumnName("TokenId");
            builder.Property(e => e.AccessToken).HasColumnName("AccessToken");
            builder.Property(e => e.Email).HasColumnName("Email");
            builder.Property(e => e.ExpiredDate).HasColumnName("ExpiredDate");
        }
    }
}
