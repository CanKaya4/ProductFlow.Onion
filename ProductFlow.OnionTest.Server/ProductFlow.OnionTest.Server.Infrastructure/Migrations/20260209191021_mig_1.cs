using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ProductFlow.OnionTest.Server.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class mig_1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    FirstName = table.Column<string>(type: "text", nullable: false),
                    LastName = table.Column<string>(type: "text", nullable: false),
                    UserName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "boolean", nullable: false),
                    PasswordHash = table.Column<string>(type: "text", nullable: true),
                    SecurityStamp = table.Column<string>(type: "text", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "text", nullable: true),
                    PhoneNumber = table.Column<string>(type: "text", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "boolean", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "boolean", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "boolean", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    RoleId = table.Column<Guid>(type: "uuid", nullable: false),
                    ClaimType = table.Column<string>(type: "text", nullable: true),
                    ClaimValue = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    ClaimType = table.Column<string>(type: "text", nullable: true),
                    ClaimValue = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "text", nullable: false),
                    ProviderKey = table.Column<string>(type: "text", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "text", nullable: true),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    RoleId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    LoginProvider = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Value = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    Slug = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    Price = table.Column<decimal>(type: "numeric", nullable: false),
                    Stock = table.Column<int>(type: "integer", nullable: false),
                    ImageUrl = table.Column<string>(type: "text", nullable: false),
                    CategoryId = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("888d8fcc-01c9-44e9-ba3f-e7d40e925677"), "Teknoloji > Laptoplar" },
                    { new Guid("8f75b3b7-1b11-464d-b156-cc85bfd5827b"), "Araç Aksesuar" },
                    { new Guid("c1cc4aa4-34cd-4521-b556-b0bda41a6fc4"), "Erkek Giyim" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "CreatedDate", "Description", "ImageUrl", "Name", "Price", "Slug", "Stock" },
                values: new object[,]
                {
                    { new Guid("2ce54963-16b0-4782-8ad0-f0eb3932a2d7"), new Guid("8f75b3b7-1b11-464d-b156-cc85bfd5827b"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Universal uyumlu, yıkanabilir", "https://images.pexels.com/photos/5625479/pexels-photo-5625479.jpeg", "Oto Koltuk Kılıfı Seti", 1599m, "oto-koltuk-kilifi-seti", 15 },
                    { new Guid("3a9b38aa-b14c-4395-827e-840d8a8f035b"), new Guid("8f75b3b7-1b11-464d-b156-cc85bfd5827b"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Havalandırma ızgarasına takılabilir", "https://images.pexels.com/photos/1708769/pexels-photo-1708769.jpeg", "Araç İçi Telefon Tutucu", 249m, "arac-ici-telefon-tutucu", 40 },
                    { new Guid("49ff6714-386c-42d9-8742-15dce7d38833"), new Guid("888d8fcc-01c9-44e9-ba3f-e7d40e925677"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Intel® Raptor Lake Core™ i7-13620H 10C/16T; 24MB L3; E-CORE Max 3.60GHZ P-CORE Max 4.90 GHZ; 45W", "https://images.pexels.com/photos/33125275/pexels-photo-33125275.jpeg", "Monster Notebook 16 GB RAM RTX 3050 8GM DDR6", 39.99m, "monster-notebook-16-gb-ram-rtx-3050-8gb-ddr6", 10 },
                    { new Guid("5c1181b1-1f59-44f9-934c-04fa5b3ea21e"), new Guid("888d8fcc-01c9-44e9-ba3f-e7d40e925677"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Apple M1 işlemci, 8 GB RAM, 256 GB SSD", "https://images.pexels.com/photos/19012037/pexels-photo-19012037.jpeg", "MacBook Air M1", 34999m, "macbook-air-m1", 5 },
                    { new Guid("6bb1b2f2-b3cd-4728-bb5e-e5466f2cf28d"), new Guid("c1cc4aa4-34cd-4521-b556-b0bda41a6fc4"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Slim fit, %100 pamuk, günlük kullanım", "https://images.pexels.com/photos/12446409/pexels-photo-12446409.jpeg", "Erkek Basic Pamuk Tişört", 299m, "erkek-basic-pamuk-tisort", 50 },
                    { new Guid("6d5700f9-19df-4edf-bbf3-0ff6c49086a1"), new Guid("c1cc4aa4-34cd-4521-b556-b0bda41a6fc4"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Regular fit, esnek kumaş", "https://images.pexels.com/photos/2897533/pexels-photo-2897533.jpeg", "Erkek Kot Pantolon", 899m, "erkek-kot-pantolon", 30 },
                    { new Guid("83814b22-8da8-49be-892b-d87a72676788"), new Guid("888d8fcc-01c9-44e9-ba3f-e7d40e925677"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Intel Core i5, 16 GB RAM, RTX 3050 Ti", "https://images.pexels.com/photos/19012051/pexels-photo-19012051.jpeg", "ASUS TUF Gaming F15", 32999m, "asus-tuf-gaming-f15", 6 },
                    { new Guid("8cd2beb1-bfca-4656-858d-d1b9183042ef"), new Guid("8f75b3b7-1b11-464d-b156-cc85bfd5827b"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Katlanabilir, çok gözlü", "https://images.pexels.com/photos/29807866/pexels-photo-29807866.jpeg", "Araç Bagaj Organizer", 499m, "arac-bagaj-organizer", 25 },
                    { new Guid("be3f0b53-e83e-42e6-b67e-f2175f2ed0b9"), new Guid("c1cc4aa4-34cd-4521-b556-b0bda41a6fc4"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Kışlık, polar iç astar", "https://images.pexels.com/photos/15213206/pexels-photo-15213206.jpeg", "Erkek Kapüşonlu Sweatshirt", 1199m, "erkek-kapusonlu-sweatshirt", 20 },
                    { new Guid("c76a0448-81fe-4640-8c1f-a9ead417aa7c"), new Guid("888d8fcc-01c9-44e9-ba3f-e7d40e925677"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Intel Core i5, 8 GB RAM, 512 GB SSD", "https://images.pexels.com/photos/19012056/pexels-photo-19012056.jpeg", "Lenovo IdeaPad 3", 21999m, "lenovo-ideapad-3", 12 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryId",
                table: "Products",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_Slug",
                table: "Products",
                column: "Slug",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
