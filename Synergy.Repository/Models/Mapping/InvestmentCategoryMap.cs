using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Synergy.Repository.Models.Mapping
{
    public class InvestmentCategoryMap : IEntityTypeConfiguration<InvestmentCategory>
    {
        public void Configure(EntityTypeBuilder<InvestmentCategory> builder)
        {
            builder.ToTable("InvestmnetCategory");

            #region
            builder.HasKey(a => a.Id);

            builder.Property(a => a.Id)
                .HasColumnName("CategoryId")
                .IsRequired();

            builder.Property(a => a.CategoryName)
                .HasColumnName("CategoryName")
                .IsRequired();

            builder.Property(a => a.CreatedBy)
                .HasColumnName("CreatedBy")
                .IsRequired();

            builder.Property(a => a.CreatedDate)
                .HasColumnName("CreatedDate")
                .HasDefaultValue(DateTime.UtcNow)
                .IsRequired();
            #endregion
        }
    }
}
