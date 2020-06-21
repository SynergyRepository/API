﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Synergy.Repository.Models.Mapping
{
   public  class CountryMap : IEntityTypeConfiguration<Country>
    {
        public void Configure(EntityTypeBuilder<Country> builder)
        {
            builder.ToTable("Country");

            #region
            builder.HasKey(t => t.Id);

            builder.Property(t => t.Id)
                .ValueGeneratedNever()
                .HasColumnName("Id")
                .IsRequired();

            builder.Property(t => t.CountryName)
                .HasColumnName("CountryName")
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(t => t.CountryImageName)
                .HasColumnName("CountryImageName")
                .HasMaxLength(100);

            builder.Property(t => t.CountryShortCode)
                .HasColumnName("CountryShortCode")
                .IsRequired()
                .HasMaxLength(5);

            builder.Property(t => t.DailingCode)
               .HasColumnName("DailingCode")
               .HasMaxLength(5);



            #endregion

            builder.HasIndex(t => new
            {
                t.DailingCode,
                t.CountryName,
                t.CountryShortCode
            }).HasName("IX_phoneNumbers_UniqueIndex").IsUnique();
        }
    }
}