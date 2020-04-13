using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebShop.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cards",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Holder = table.Column<string>(nullable: true),
                    Number = table.Column<string>(nullable: true),
                    Cvv = table.Column<int>(nullable: false),
                    ExpirationDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cards", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Carts",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SubTotal = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Carts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    IsActive = table.Column<bool>(nullable: false),
                    ParentId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Categories_Categories_ParentId",
                        column: x => x.ParentId,
                        principalTable: "Categories",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Geos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    County = table.Column<string>(nullable: true),
                    Locality = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Geos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Keyword",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KeyWord = table.Column<string>(nullable: true),
                    KeywordProductId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Keyword", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    BuyPrice = table.Column<double>(nullable: false),
                    SalePrice = table.Column<double>(nullable: false),
                    ProductCode = table.Column<string>(nullable: true),
                    ImportCountryCode = table.Column<string>(nullable: true),
                    OrderLink = table.Column<string>(nullable: true),
                    Stock = table.Column<int>(nullable: false),
                    ShortDescription = table.Column<string>(nullable: true),
                    LongDescription = table.Column<string>(nullable: true),
                    Type = table.Column<string>(nullable: true),
                    CategoryId = table.Column<int>(nullable: false),
                    ParentId = table.Column<int>(nullable: true)
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
                    table.ForeignKey(
                        name: "FK_Products_Products_ParentId",
                        column: x => x.ParentId,
                        principalTable: "Products",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "CartProduct",
                columns: table => new
                {
                    CartId = table.Column<int>(nullable: false),
                    ProductId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CartProduct", x => new { x.CartId, x.ProductId });
                    table.ForeignKey(
                        name: "FK_CartProduct_Carts_CartId",
                        column: x => x.CartId,
                        principalTable: "Carts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CartProduct_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Images",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Path = table.Column<string>(nullable: true),
                    FileName = table.Column<string>(nullable: true),
                    Alt = table.Column<string>(nullable: true),
                    ProductId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Images", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Images_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "KeywordProduct",
                columns: table => new
                {
                    KeywordId = table.Column<int>(nullable: false),
                    ProductId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KeywordProduct", x => new { x.KeywordId, x.ProductId });
                    table.ForeignKey(
                        name: "FK_KeywordProduct_Keyword_KeywordId",
                        column: x => x.KeywordId,
                        principalTable: "Keyword",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_KeywordProduct_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Reviews",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ReviewText = table.Column<string>(nullable: true),
                    Stars = table.Column<int>(nullable: false),
                    ProductId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reviews", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Reviews_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Address = table.Column<string>(nullable: true),
                    PasswordHash = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    OrdersCount = table.Column<int>(nullable: false),
                    GeoId = table.Column<int>(nullable: false),
                    CardId = table.Column<int>(nullable: false),
                    CartId = table.Column<int>(nullable: false),
                    ReviewId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_Cards_CardId",
                        column: x => x.CardId,
                        principalTable: "Cards",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Users_Carts_CartId",
                        column: x => x.CartId,
                        principalTable: "Carts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Users_Geos_GeoId",
                        column: x => x.GeoId,
                        principalTable: "Geos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Users_Reviews_ReviewId",
                        column: x => x.ReviewId,
                        principalTable: "Reviews",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Cards",
                columns: new[] { "Id", "Cvv", "ExpirationDate", "Holder", "Number" },
                values: new object[,]
                {
                    { 1, 0, new DateTime(11, 1, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "Kiscsillag", "hahahaha" },
                    { 2, 0, new DateTime(6, 1, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "Pikans", "hahahaha" }
                });

            migrationBuilder.InsertData(
                table: "Carts",
                columns: new[] { "Id", "SubTotal" },
                values: new object[,]
                {
                    { 1, 123.0 },
                    { 2, 123.0 }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "IsActive", "Name", "ParentId" },
                values: new object[] { 1, true, "alma", null });

            migrationBuilder.InsertData(
                table: "Geos",
                columns: new[] { "Id", "County", "Locality" },
                values: new object[,]
                {
                    { 1, "Bihor", "Oradea" },
                    { 2, "Harghita", "Gheorgeni" }
                });

            migrationBuilder.InsertData(
                table: "Keyword",
                columns: new[] { "Id", "KeyWord", "KeywordProductId" },
                values: new object[,]
                {
                    { 1, "bicska", 1 },
                    { 2, "bicskav2", 2 }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "IsActive", "Name", "ParentId" },
                values: new object[] { 2, true, "alma", 1 });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "BuyPrice", "CategoryId", "ImportCountryCode", "LongDescription", "Name", "OrderLink", "ParentId", "ProductCode", "SalePrice", "ShortDescription", "Stock", "Type" },
                values: new object[] { 1, 12.0, 1, "JPN", "aaaaa", "Csavarhuzo", "hosszu", 1, "asd", 10.0, "a", 10, "kesztyu" });

            migrationBuilder.InsertData(
                table: "CartProduct",
                columns: new[] { "CartId", "ProductId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 1 }
                });

            migrationBuilder.InsertData(
                table: "Images",
                columns: new[] { "Id", "Alt", "FileName", "Path", "ProductId" },
                values: new object[,]
                {
                    { 1, "asd", "long", "bumm", 1 },
                    { 2, "asd", "long", "bumm", 1 }
                });

            migrationBuilder.InsertData(
                table: "KeywordProduct",
                columns: new[] { "KeywordId", "ProductId" },
                values: new object[] { 1, 1 });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "BuyPrice", "CategoryId", "ImportCountryCode", "LongDescription", "Name", "OrderLink", "ParentId", "ProductCode", "SalePrice", "ShortDescription", "Stock", "Type" },
                values: new object[] { 2, 12.0, 2, "JPNA", "aaaaa", "Csavarhuszo", "hosszu", 2, "assssd", 10.0, "a", 10, "kesztyu" });

            migrationBuilder.InsertData(
                table: "Reviews",
                columns: new[] { "Id", "ProductId", "ReviewText", "Stars" },
                values: new object[] { 1, 1, "blablA", 3 });

            migrationBuilder.InsertData(
                table: "KeywordProduct",
                columns: new[] { "KeywordId", "ProductId" },
                values: new object[] { 1, 2 });

            migrationBuilder.InsertData(
                table: "Reviews",
                columns: new[] { "Id", "ProductId", "ReviewText", "Stars" },
                values: new object[] { 2, 2, "blasblA", 3 });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Address", "CardId", "CartId", "Email", "FirstName", "GeoId", "LastName", "OrdersCount", "PasswordHash", "PhoneNumber", "ReviewId" },
                values: new object[] { 1, "WTF", 1, 1, "asd@asd.com", "Farkas", 1, "Zsombor", 0, "ZSFSAFASFS", "nincs", 1 });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Address", "CardId", "CartId", "Email", "FirstName", "GeoId", "LastName", "OrdersCount", "PasswordHash", "PhoneNumber", "ReviewId" },
                values: new object[] { 2, "WTF", 2, 2, "asd@asd.com", "Rapa", 2, "Erik", 0, "ZSFSAFASFS", "nincs", 2 });

            migrationBuilder.CreateIndex(
                name: "IX_CartProduct_ProductId",
                table: "CartProduct",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Categories_ParentId",
                table: "Categories",
                column: "ParentId",
                unique: true,
                filter: "[ParentId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Images_ProductId",
                table: "Images",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_KeywordProduct_ProductId",
                table: "KeywordProduct",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryId",
                table: "Products",
                column: "CategoryId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Products_ParentId",
                table: "Products",
                column: "ParentId",
                unique: true,
                filter: "[ParentId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_ProductId",
                table: "Reviews",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_CardId",
                table: "Users",
                column: "CardId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_CartId",
                table: "Users",
                column: "CartId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_GeoId",
                table: "Users",
                column: "GeoId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_ReviewId",
                table: "Users",
                column: "ReviewId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CartProduct");

            migrationBuilder.DropTable(
                name: "Images");

            migrationBuilder.DropTable(
                name: "KeywordProduct");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Keyword");

            migrationBuilder.DropTable(
                name: "Cards");

            migrationBuilder.DropTable(
                name: "Carts");

            migrationBuilder.DropTable(
                name: "Geos");

            migrationBuilder.DropTable(
                name: "Reviews");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
