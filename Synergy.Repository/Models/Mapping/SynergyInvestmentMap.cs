using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Synergy.Repository.Models.Mapping
{
    public class SynergyInvestmentMap : IEntityTypeConfiguration<SynergyInvestment>
    {
        public void Configure(EntityTypeBuilder<SynergyInvestment> builder)
        {
            builder.ToTable("SynergyInvestment");

            #region
            builder.HasKey(a => a.Id);

            builder.Property(a => a.Id)
                .HasColumnName("Id")
                .IsRequired();

            builder.Property(a => a.Name)
                .HasColumnName("Title")
                .IsRequired();

            builder.Property(a => a.Description)
                .HasColumnName("Description")
                .IsRequired();

            builder.Property(a => a.Thumbnail)
                .HasColumnName("Thumbnail")
                .IsRequired();

            builder.Property(a => a.InterestRate)
                .HasColumnName("InterestRate")
                .IsRequired();

            builder.Property(a => a.Duration)
                .HasColumnName("Duration")
                .IsRequired();

            builder.Property(a => a.AvailableSlot)
                .HasColumnName("AvailableSlot")
                .IsRequired();

            builder.Property(a => a.SoldOutSlot)
                .HasColumnName("SolOutSlot")
                .IsRequired();

            builder.Property(a => a.Location)
                .HasColumnName("Location")
                .IsRequired();

            builder.Property(a => a.CatergoryId)
                .HasColumnName("CategoryId")
                .IsRequired();

            builder.Property(a => a.CreatedBy)
                 .HasColumnName("CreatedBy")
                 .IsRequired();

            builder.Property(a => a.CreatedDate)
                .HasColumnName("CreatedDate")
                .HasDefaultValue(DateTime.UtcNow)
                .IsRequired();
            #endregion


            builder.HasOne(t => t.InvestmentCategory)
                  .WithMany(t => t.SynergyInvestments)
                  .HasForeignKey(t => t.CatergoryId);
        }
    }
}
