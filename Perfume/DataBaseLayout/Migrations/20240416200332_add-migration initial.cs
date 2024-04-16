using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataBaseLayout.Migrations
{
    /// <inheritdoc />
    public partial class addmigrationinitial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Brands",
                columns: table => new
                {
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Brands", x => x.Name);
                });

            migrationBuilder.CreateTable(
                name: "Deliveries",
                columns: table => new
                {
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Deliveries", x => x.Name);
                });

            migrationBuilder.CreateTable(
                name: "Features",
                columns: table => new
                {
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    HTMLFlag = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Features", x => x.Name);
                });

            migrationBuilder.CreateTable(
                name: "PerfumeCategories",
                columns: table => new
                {
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PerfumeCategories", x => x.Name);
                });

            migrationBuilder.CreateTable(
                name: "Promotions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Promotions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Name);
                });

            migrationBuilder.CreateTable(
                name: "Perfumes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Rating = table.Column<double>(type: "float", nullable: false),
                    Stock = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<int>(type: "int", nullable: false),
                    Currency = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RatingAppearance = table.Column<double>(type: "float", nullable: false),
                    RatingIntension = table.Column<double>(type: "float", nullable: false),
                    RatingPersistence = table.Column<double>(type: "float", nullable: false),
                    ProfileImage = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BrandName = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    PerfumeCategoryName = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Perfumes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Perfumes_Brands_BrandName",
                        column: x => x.BrandName,
                        principalTable: "Brands",
                        principalColumn: "Name",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Perfumes_PerfumeCategories_PerfumeCategoryName",
                        column: x => x.PerfumeCategoryName,
                        principalTable: "PerfumeCategories",
                        principalColumn: "Name",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FeatureRole",
                columns: table => new
                {
                    FeaturesName = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RolesName = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FeatureRole", x => new { x.FeaturesName, x.RolesName });
                    table.ForeignKey(
                        name: "FK_FeatureRole_Features_FeaturesName",
                        column: x => x.FeaturesName,
                        principalTable: "Features",
                        principalColumn: "Name",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FeatureRole_Roles_RolesName",
                        column: x => x.RolesName,
                        principalTable: "Roles",
                        principalColumn: "Name",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RoleName = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_Roles_RoleName",
                        column: x => x.RoleName,
                        principalTable: "Roles",
                        principalColumn: "Name",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DeliveryPerfume",
                columns: table => new
                {
                    DeliveriesName = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    PerfumesId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeliveryPerfume", x => new { x.DeliveriesName, x.PerfumesId });
                    table.ForeignKey(
                        name: "FK_DeliveryPerfume_Deliveries_DeliveriesName",
                        column: x => x.DeliveriesName,
                        principalTable: "Deliveries",
                        principalColumn: "Name",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DeliveryPerfume_Perfumes_PerfumesId",
                        column: x => x.PerfumesId,
                        principalTable: "Perfumes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PerfumeImages",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PerfumeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PerfumeImages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PerfumeImages_Perfumes_PerfumeId",
                        column: x => x.PerfumeId,
                        principalTable: "Perfumes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Reviews",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PerfumeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reviews", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Reviews_Perfumes_PerfumeId",
                        column: x => x.PerfumeId,
                        principalTable: "Perfumes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Reviews_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ShoppingCartPerfumes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PerfumeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShoppingCartPerfumes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ShoppingCartPerfumes_Perfumes_PerfumeId",
                        column: x => x.PerfumeId,
                        principalTable: "Perfumes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ShoppingCartPerfumes_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WishList",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PerfumeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WishList", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WishList_Perfumes_PerfumeId",
                        column: x => x.PerfumeId,
                        principalTable: "Perfumes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WishList_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ReviewConversations",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ReviewId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReviewConversations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ReviewConversations_Reviews_ReviewId",
                        column: x => x.ReviewId,
                        principalTable: "Reviews",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ReviewConversations_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DeliveryPerfume_PerfumesId",
                table: "DeliveryPerfume",
                column: "PerfumesId");

            migrationBuilder.CreateIndex(
                name: "IX_FeatureRole_RolesName",
                table: "FeatureRole",
                column: "RolesName");

            migrationBuilder.CreateIndex(
                name: "IX_PerfumeImages_PerfumeId",
                table: "PerfumeImages",
                column: "PerfumeId");

            migrationBuilder.CreateIndex(
                name: "IX_Perfumes_BrandName",
                table: "Perfumes",
                column: "BrandName");

            migrationBuilder.CreateIndex(
                name: "IX_Perfumes_PerfumeCategoryName",
                table: "Perfumes",
                column: "PerfumeCategoryName");

            migrationBuilder.CreateIndex(
                name: "IX_ReviewConversations_ReviewId",
                table: "ReviewConversations",
                column: "ReviewId");

            migrationBuilder.CreateIndex(
                name: "IX_ReviewConversations_UserId",
                table: "ReviewConversations",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_PerfumeId",
                table: "Reviews",
                column: "PerfumeId");

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_UserId",
                table: "Reviews",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_ShoppingCartPerfumes_PerfumeId",
                table: "ShoppingCartPerfumes",
                column: "PerfumeId");

            migrationBuilder.CreateIndex(
                name: "IX_ShoppingCartPerfumes_UserId",
                table: "ShoppingCartPerfumes",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_RoleName",
                table: "Users",
                column: "RoleName");

            migrationBuilder.CreateIndex(
                name: "IX_WishList_PerfumeId",
                table: "WishList",
                column: "PerfumeId");

            migrationBuilder.CreateIndex(
                name: "IX_WishList_UserId",
                table: "WishList",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DeliveryPerfume");

            migrationBuilder.DropTable(
                name: "FeatureRole");

            migrationBuilder.DropTable(
                name: "PerfumeImages");

            migrationBuilder.DropTable(
                name: "Promotions");

            migrationBuilder.DropTable(
                name: "ReviewConversations");

            migrationBuilder.DropTable(
                name: "ShoppingCartPerfumes");

            migrationBuilder.DropTable(
                name: "WishList");

            migrationBuilder.DropTable(
                name: "Deliveries");

            migrationBuilder.DropTable(
                name: "Features");

            migrationBuilder.DropTable(
                name: "Reviews");

            migrationBuilder.DropTable(
                name: "Perfumes");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Brands");

            migrationBuilder.DropTable(
                name: "PerfumeCategories");

            migrationBuilder.DropTable(
                name: "Roles");
        }
    }
}
