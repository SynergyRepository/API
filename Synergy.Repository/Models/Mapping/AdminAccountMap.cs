using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Synergy.Repository.Models.Mapping
{
    public class AdminAccountMap : IEntityTypeConfiguration<AdminAccount>
    {
        public void Configure(EntityTypeBuilder<AdminAccount> builder)
        {
            builder.ToTable("AdminUser");

            builder.HasKey(a => a.AccountId);

            builder.Property(a => a.AccountId)
                .HasColumnName("Id")
                .IsRequired();

            builder.Property(t => t.FirstName)
                    .HasColumnName("FirstName")
                    .IsRequired();

            builder.Property(t => t.LastName)
                    .HasColumnName("LastName")
                    .IsRequired();
            builder.Property(a => a.EmailAddress)
                .HasColumnName("Username")
                .IsRequired();

           builder.Property(a => a.PasswordKey)
                .HasColumnName("PasswordKey")
                .IsRequired();

            builder.Property(a => a.Password)
                .HasColumnName("Password")
                .IsRequired();

            builder.Property(a => a.Role)
               .HasColumnName("Role")
               .IsRequired();

        }
    }
}
