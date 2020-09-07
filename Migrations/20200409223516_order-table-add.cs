using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BookStore.Migrations
{
    public partial class ordertableadd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(nullable: false),
                    BookTitle = table.Column<string>(maxLength: 350, nullable: true),
                    BookAuthor = table.Column<string>(maxLength: 250, nullable: true),
                    BookCountry = table.Column<string>(maxLength: 250, nullable: true),
                    BookPublisher = table.Column<string>(maxLength: 250, nullable: true),
                    BookCategory = table.Column<string>(maxLength: 150, nullable: true),
                    BookType = table.Column<string>(maxLength: 150, nullable: true),
                    BookDimensions = table.Column<string>(maxLength: 250, nullable: true),
                    BookWeight = table.Column<string>(maxLength: 250, nullable: true),
                    Quantity = table.Column<int>(nullable: false),
                    OrderDate = table.Column<DateTime>(nullable: false),
                    ShippedDate = table.Column<DateTime>(nullable: false),
                    RequiredDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b4280b6a-0613-4cbd-a9e6-f1701e926e73",
                column: "ConcurrencyStamp",
                value: "5610b8a1-50ad-4e5d-a60c-0ca65ef0b8b8");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b4280b6a-0613-4cbd-a9e6-f1701e926e74",
                column: "ConcurrencyStamp",
                value: "aa009482-1e0e-44a7-8d51-c599575e6d19");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b4280b6a-0613-4cbd-a9e6-f1701e926e75",
                column: "ConcurrencyStamp",
                value: "c4097e8a-cc39-4907-b4c0-1ba31b81ab36");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b4280b6a-0613-4cbd-a9e6-f1701e926e73",
                column: "PasswordHash",
                value: "AQAAAAEAACcQAAAAEBSAdhndm61A3KnFp75eRAWHkzo8HL/X9dULsbvRSQtZVfkJ6vBcWoLGJ9nOsrM4zw==");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b4280b6a-0613-4cbd-a9e6-f1701e926e73",
                column: "ConcurrencyStamp",
                value: "e68cf817-add2-4884-b5d3-d461cf9ecb47");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b4280b6a-0613-4cbd-a9e6-f1701e926e74",
                column: "ConcurrencyStamp",
                value: "872d6a55-6f68-4488-935c-429bf853346b");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b4280b6a-0613-4cbd-a9e6-f1701e926e75",
                column: "ConcurrencyStamp",
                value: "420d3529-c81f-49f0-a75c-81ecd83a7832");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b4280b6a-0613-4cbd-a9e6-f1701e926e73",
                column: "PasswordHash",
                value: "AQAAAAEAACcQAAAAEBuObZwJ9dmMi8dzrxA4r8+nebpP6H6b2N3XIVx8ialAjcxJJfiPEjKrZ5a9Sp+LVQ==");
        }
    }
}
