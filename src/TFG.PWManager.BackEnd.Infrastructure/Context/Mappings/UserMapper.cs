using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using TFG.PWManager.BackEnd.Domain.Entities;

namespace TFG.PWManager.BackEnd.Infrastructure.Context.Mappings
{
    public class UserMapper : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("User");
            builder.HasKey(e => new { e.Id });
            builder.Property(e => e.Id).HasColumnName("UserId");
            builder.Property(e => e.DisplayName).HasColumnName("DisplayName");
            builder.Property(e => e.Name).HasColumnName("Name");
            builder.Property(e => e.Surname).HasColumnName("Surname");
            builder.Property(e => e.PhoneNumber).HasColumnName("PhoneNumber");
            builder.Property(e => e.Email).HasColumnName("Email");
            builder.Property(e => e.PasswordHash).HasColumnName("PasswordHash");
            builder.Property(e => e.ActiveChk).HasColumnName("ActiveChk");
            builder.Property(e => e.LanguageId).HasColumnName("LanguageId");
            builder.HasOne(l => l.Language).WithMany().HasForeignKey(k => k.LanguageId);
        }
    }
}
