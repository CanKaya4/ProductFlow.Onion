using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProductFlow.OnionTest.Server.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProductFlow.OnionTest.Server.Infrastructure.Configuration
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasData(new Category
            {
                Id = new Guid("888D8FCC-01C9-44E9-BA3F-E7D40E925677"),
                Name = "Teknoloji > Laptoplar",
            },
            new Category
            {
                Id = new Guid("C1CC4AA4-34CD-4521-B556-B0BDA41A6FC4"),
                Name = "Erkek Giyim",
            },
            new Category
            {
                Id = new Guid("8F75B3B7-1B11-464D-B156-CC85BFD5827B"),
                Name = "Araç Aksesuar",
            });
        }
    }
}
