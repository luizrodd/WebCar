using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WebCar.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddSeedPostStatus : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "PostStatus",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 0, "Pendent" },
                    { 1, "Available" },
                    { 2, "Sold" },
                    { 3, "Canceled" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "PostStatus",
                keyColumn: "Id",
                keyValue: 0);

            migrationBuilder.DeleteData(
                table: "PostStatus",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "PostStatus",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "PostStatus",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
