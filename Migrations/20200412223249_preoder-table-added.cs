using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BookStore.Migrations
{
    public partial class preodertableadded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PreOrders",
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
                    table.PrimaryKey("PK_PreOrders", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b4280b6a-0613-4cbd-a9e6-f1701e926e73",
                column: "ConcurrencyStamp",
                value: "e2830733-5e4e-4684-84ed-aae18eb0f45d");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b4280b6a-0613-4cbd-a9e6-f1701e926e74",
                column: "ConcurrencyStamp",
                value: "187e441d-9d17-4ad7-91df-a29e3533e151");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b4280b6a-0613-4cbd-a9e6-f1701e926e75",
                column: "ConcurrencyStamp",
                value: "0edf5ded-3b68-4203-a330-86d455ee5529");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b4280b6a-0613-4cbd-a9e6-f1701e926e73",
                column: "PasswordHash",
                value: "AQAAAAEAACcQAAAAEFtHXXbxwJpHU46hfjDpcVnwe58JL3p6ba5TUgjl3h28/aqI2KCOcWWUVK5KmnK+ow==");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PreOrders");

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
    }
}
