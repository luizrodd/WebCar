using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WebCar.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BodyType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BodyType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Brands",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Brands", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ConditionType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConditionType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FuelType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FuelType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Optionals",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Optionals", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PostStatus",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PostStatus", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TransmissionType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TransmissionType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    Contact = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsAdmin = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Models",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    BrandId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Models", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Brand_Model",
                        column: x => x.BrandId,
                        principalTable: "Brands",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Versions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ModelId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Versions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Model_Version",
                        column: x => x.ModelId,
                        principalTable: "Models",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Car",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Kilometer = table.Column<long>(type: "bigint", nullable: false),
                    YearOfManufacture = table.Column<int>(type: "int", nullable: false),
                    YearOfModel = table.Column<int>(type: "int", nullable: false),
                    IsEnabled = table.Column<bool>(type: "bit", nullable: false),
                    IsArmored = table.Column<bool>(type: "bit", nullable: false),
                    IsLicensed = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ConditionTypeId = table.Column<int>(type: "int", nullable: false),
                    TransmissionTypeId = table.Column<int>(type: "int", nullable: false),
                    FuelTypeId = table.Column<int>(type: "int", nullable: false),
                    BodyTypeId = table.Column<int>(type: "int", nullable: false),
                    VersionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Car", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Post_BodyType",
                        column: x => x.BodyTypeId,
                        principalTable: "BodyType",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Post_CarConditionType",
                        column: x => x.ConditionTypeId,
                        principalTable: "ConditionType",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Post_FuelType",
                        column: x => x.FuelTypeId,
                        principalTable: "FuelType",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Post_TransmissionType",
                        column: x => x.TransmissionTypeId,
                        principalTable: "TransmissionType",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Post_Version",
                        column: x => x.VersionId,
                        principalTable: "Versions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CarOptionals",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CarOptionalTypeId = table.Column<int>(type: "int", nullable: false),
                    CarId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarOptionals", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CarOptional_Car",
                        column: x => x.CarId,
                        principalTable: "Car",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CarOptional_CarOptionalType",
                        column: x => x.CarOptionalTypeId,
                        principalTable: "Optionals",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Posts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Localization = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    AcceptTrade = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CarId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PostStatusId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Posts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Post_Car",
                        column: x => x.CarId,
                        principalTable: "Car",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Post_PostStatus",
                        column: x => x.PostStatusId,
                        principalTable: "PostStatus",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "PostHistories",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    PostId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PostHistories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PostHistory_Post",
                        column: x => x.PostId,
                        principalTable: "Posts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PostStorage",
                columns: table => new
                {
                    PostId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Filename = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    ScannedFileId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PostStorage", x => new { x.PostId, x.Id });
                    table.ForeignKey(
                        name: "FK_PostStorage_Posts_PostId",
                        column: x => x.PostId,
                        principalTable: "Posts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "BodyType",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 0, "Hatchback" },
                    { 1, "Sedan" },
                    { 2, "SUV" },
                    { 3, "Pickup" },
                    { 4, "Coupe" },
                    { 5, "Convertible" },
                    { 6, "Minivan" },
                    { 7, "Van" }
                });

            migrationBuilder.InsertData(
                table: "ConditionType",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 0, "New" },
                    { 1, "Used" },
                    { 2, "SemiNew" }
                });

            migrationBuilder.InsertData(
                table: "FuelType",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 0, "Gasoline" },
                    { 1, "Alcohol" },
                    { 2, "Flex" },
                    { 3, "Diesel" },
                    { 4, "Electric" },
                    { 5, "Hybrid" }
                });

            migrationBuilder.InsertData(
                table: "Optionals",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 0, "Air Conditioning" },
                    { 1, "Power Steering" },
                    { 2, "Power Windows" },
                    { 3, "Power Locks" },
                    { 4, "Airbag" },
                    { 5, "ABS Brakes" },
                    { 6, "Leather Seats" },
                    { 7, "Parking Sensors" },
                    { 8, "Rear Camera" },
                    { 9, "Sunroof" },
                    { 10, "Onboard Computer" },
                    { 11, "Stability Control" },
                    { 12, "Traction Control" },
                    { 13, "Fog Lights" },
                    { 14, "Alloy Wheels" },
                    { 15, "Cruise Control" },
                    { 16, "Rain Sensor" },
                    { 17, "Alarm System" },
                    { 18, "Multimedia System" },
                    { 19, "Multifunction Steering Wheel" },
                    { 20, "Power Mirrors" },
                    { 21, "Keyless Entry" },
                    { 22, "Hill Start Assist" },
                    { 23, "Isofix Anchors" },
                    { 24, "Xenon Headlights" },
                    { 25, "Heated Seats" },
                    { 26, "Speed Limiter" }
                });

            migrationBuilder.InsertData(
                table: "TransmissionType",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 0, "Manual" },
                    { 1, "Automatic" },
                    { 2, "Semi-Automatic" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Car_BodyTypeId",
                table: "Car",
                column: "BodyTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Car_ConditionTypeId",
                table: "Car",
                column: "ConditionTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Car_FuelTypeId",
                table: "Car",
                column: "FuelTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Car_TransmissionTypeId",
                table: "Car",
                column: "TransmissionTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Car_VersionId",
                table: "Car",
                column: "VersionId");

            migrationBuilder.CreateIndex(
                name: "IX_CarOptionals_CarId",
                table: "CarOptionals",
                column: "CarId");

            migrationBuilder.CreateIndex(
                name: "IX_CarOptionals_CarOptionalTypeId",
                table: "CarOptionals",
                column: "CarOptionalTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Models_BrandId",
                table: "Models",
                column: "BrandId");

            migrationBuilder.CreateIndex(
                name: "IX_PostHistories_PostId",
                table: "PostHistories",
                column: "PostId");

            migrationBuilder.CreateIndex(
                name: "IX_Posts_CarId",
                table: "Posts",
                column: "CarId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Posts_PostStatusId",
                table: "Posts",
                column: "PostStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Versions_ModelId",
                table: "Versions",
                column: "ModelId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CarOptionals");

            migrationBuilder.DropTable(
                name: "PostHistories");

            migrationBuilder.DropTable(
                name: "PostStorage");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Optionals");

            migrationBuilder.DropTable(
                name: "Posts");

            migrationBuilder.DropTable(
                name: "Car");

            migrationBuilder.DropTable(
                name: "PostStatus");

            migrationBuilder.DropTable(
                name: "BodyType");

            migrationBuilder.DropTable(
                name: "ConditionType");

            migrationBuilder.DropTable(
                name: "FuelType");

            migrationBuilder.DropTable(
                name: "TransmissionType");

            migrationBuilder.DropTable(
                name: "Versions");

            migrationBuilder.DropTable(
                name: "Models");

            migrationBuilder.DropTable(
                name: "Brands");
        }
    }
}
