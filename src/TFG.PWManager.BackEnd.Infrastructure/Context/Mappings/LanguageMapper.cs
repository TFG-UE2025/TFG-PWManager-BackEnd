﻿using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using TFG.PWManager.BackEnd.Domain.Entities;

namespace TFG.PWManager.BackEnd.Infrastructure.Context.Mappings
{
    public class LanguageMapper : IEntityTypeConfiguration<Language>
    {
        public void Configure(EntityTypeBuilder<Language> builder)
        {
            builder.ToTable("Language");
            builder.HasKey(e => new { e.Id });
            builder.Property(e => e.Id).HasColumnName("LanguageId");
            builder.Property(e => e.Name).HasColumnName("Name");
            builder.Property(e => e.Code).HasColumnName("Code");
            builder.Property(e => e.Description).HasColumnName("Description");
        }
    }
}
