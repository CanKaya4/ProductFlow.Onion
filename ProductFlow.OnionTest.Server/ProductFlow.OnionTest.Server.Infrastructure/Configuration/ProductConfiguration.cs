using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProductFlow.OnionTest.Server.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProductFlow.OnionTest.Server.Infrastructure.Configuration
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasIndex(p => p.Slug)
           .IsUnique();

            builder.Property(p => p.Slug)
           .IsRequired()
           .HasMaxLength(200);

            builder.HasData(new Product
            {
                Id = new Guid("49FF6714-386C-42D9-8742-15DCE7D38833"),
                Name = "Monster Notebook 16 GB RAM RTX 3050 8GM DDR6",
                Description = "Intel® Raptor Lake Core™ i7-13620H 10C/16T; 24MB L3; E-CORE Max 3.60GHZ P-CORE Max 4.90 GHZ; 45W",
                Slug = "monster-notebook-16-gb-ram-rtx-3050-8gb-ddr6",
                CategoryId = new Guid("888D8FCC-01C9-44E9-BA3F-E7D40E925677"),
                ImageUrl = "https://images.pexels.com/photos/33125275/pexels-photo-33125275.jpeg",
                CreatedDate = new DateTime(2024, 1, 1, 0, 0, 0, DateTimeKind.Utc),
                Price = 39.99m,
                Stock = 10
            },
                
                new Product
                {
                    Id = new Guid("83814B22-8DA8-49BE-892B-D87A72676788"),
                    Name = "ASUS TUF Gaming F15",
                    Description = "Intel Core i5, 16 GB RAM, RTX 3050 Ti",
                    Slug = "asus-tuf-gaming-f15",
                    CategoryId = new Guid("888D8FCC-01C9-44E9-BA3F-E7D40E925677"),
                    ImageUrl = "https://images.pexels.com/photos/19012051/pexels-photo-19012051.jpeg",
                    CreatedDate = new DateTime(2024, 1, 1, 0, 0, 0, DateTimeKind.Utc),
                    Price = 32999m,
                    Stock = 6
                },
                new Product
                {
                    Id = new Guid("C76A0448-81FE-4640-8C1F-A9EAD417AA7C"),
                    Name = "Lenovo IdeaPad 3",
                    Description = "Intel Core i5, 8 GB RAM, 512 GB SSD",
                    Slug = "lenovo-ideapad-3",
                    CategoryId = new Guid("888D8FCC-01C9-44E9-BA3F-E7D40E925677"),
                    ImageUrl = "https://images.pexels.com/photos/19012056/pexels-photo-19012056.jpeg",
                    CreatedDate = new DateTime(2024, 1, 1, 0, 0, 0, DateTimeKind.Utc),
                    Price = 21999m,
                    Stock = 12
                },
                new Product
                {
                    Id = new Guid("5C1181B1-1F59-44F9-934C-04FA5B3EA21E"),
                    Name = "MacBook Air M1",
                    Description = "Apple M1 işlemci, 8 GB RAM, 256 GB SSD",
                    Slug = "macbook-air-m1",
                    CategoryId = new Guid("888D8FCC-01C9-44E9-BA3F-E7D40E925677"),
                    ImageUrl = "https://images.pexels.com/photos/19012037/pexels-photo-19012037.jpeg",
                    CreatedDate = new DateTime(2024, 1, 1, 0, 0, 0, DateTimeKind.Utc),
                    Price = 34999m,
                    Stock = 5
                },
                new Product
                {
                    Id = new Guid("6BB1B2F2-B3CD-4728-BB5E-E5466F2CF28D"),
                    Name = "Erkek Basic Pamuk Tişört",
                    Description = "Slim fit, %100 pamuk, günlük kullanım",
                    Slug = "erkek-basic-pamuk-tisort",
                    CategoryId = new Guid("C1CC4AA4-34CD-4521-B556-B0BDA41A6FC4"),
                    ImageUrl = "https://images.pexels.com/photos/12446409/pexels-photo-12446409.jpeg",
                    CreatedDate = new DateTime(2024, 1, 1, 0, 0, 0, DateTimeKind.Utc),
                    Price = 299m,
                    Stock = 50
                },
                new Product
                {
                    Id = new Guid("6D5700F9-19DF-4EDF-BBF3-0FF6C49086A1"),
                    Name = "Erkek Kot Pantolon",
                    Description = "Regular fit, esnek kumaş",
                    Slug = "erkek-kot-pantolon",
                    CategoryId = new Guid("C1CC4AA4-34CD-4521-B556-B0BDA41A6FC4"),
                    ImageUrl = "https://images.pexels.com/photos/2897533/pexels-photo-2897533.jpeg",
                    CreatedDate = new DateTime(2024, 1, 1, 0, 0, 0, DateTimeKind.Utc),
                    Price = 899m,
                    Stock = 30
                },
                new Product
                {
                    Id = new Guid("BE3F0B53-E83E-42E6-B67E-F2175F2ED0B9"),
                    Name = "Erkek Kapüşonlu Sweatshirt",
                    Description = "Kışlık, polar iç astar",
                    Slug = "erkek-kapusonlu-sweatshirt",
                    CategoryId = new Guid("C1CC4AA4-34CD-4521-B556-B0BDA41A6FC4"),
                    ImageUrl = "https://images.pexels.com/photos/15213206/pexels-photo-15213206.jpeg",
                    CreatedDate = new DateTime(2024, 1, 1, 0, 0, 0, DateTimeKind.Utc),
                    Price = 1199m,
                    Stock = 20
                },
                new Product
                {
                    Id = new Guid("3A9B38AA-B14C-4395-827E-840D8A8F035B"),
                    Name = "Araç İçi Telefon Tutucu",
                    Description = "Havalandırma ızgarasına takılabilir",
                    Slug = "arac-ici-telefon-tutucu",
                    CategoryId = new Guid("8F75B3B7-1B11-464D-B156-CC85BFD5827B"),
                    ImageUrl = "https://images.pexels.com/photos/1708769/pexels-photo-1708769.jpeg",
                    CreatedDate = new DateTime(2024, 1, 1, 0, 0, 0, DateTimeKind.Utc),
                    Price = 249m,
                    Stock = 40
                },
                new Product
                {
                    Id = new Guid("2CE54963-16B0-4782-8AD0-F0EB3932A2D7"),
                    Name = "Oto Koltuk Kılıfı Seti",
                    Description = "Universal uyumlu, yıkanabilir",
                    Slug = "oto-koltuk-kilifi-seti",
                    CategoryId = new Guid("8F75B3B7-1B11-464D-B156-CC85BFD5827B"),
                    ImageUrl = "https://images.pexels.com/photos/5625479/pexels-photo-5625479.jpeg",
                    CreatedDate = new DateTime(2024, 1, 1, 0, 0, 0, DateTimeKind.Utc),
                    Price = 1599m,
                    Stock = 15
                },
                new Product
                {
                    Id = new Guid("8CD2BEB1-BFCA-4656-858D-D1B9183042EF"),
                    Name = "Araç Bagaj Organizer",
                    Description = "Katlanabilir, çok gözlü",
                    Slug = "arac-bagaj-organizer",
                    CategoryId = new Guid("8F75B3B7-1B11-464D-B156-CC85BFD5827B"),
                    ImageUrl = "https://images.pexels.com/photos/29807866/pexels-photo-29807866.jpeg",
                    CreatedDate = new DateTime(2024, 1, 1, 0, 0, 0, DateTimeKind.Utc),
                    Price = 499m,
                    Stock = 25
                });
        }
    }
}
