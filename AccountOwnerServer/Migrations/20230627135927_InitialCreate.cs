using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace AccountOwnerServer.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "owner",
                columns: table => new
                {
                    OwnerId = table.Column<Guid>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", maxLength: 60, nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Address = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_owner", x => x.OwnerId);
                });

            migrationBuilder.CreateTable(
                name: "account",
                columns: table => new
                {
                    AccountId = table.Column<Guid>(type: "TEXT", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "TEXT", nullable: false),
                    AccountType = table.Column<string>(type: "TEXT", nullable: false),
                    OwnerId = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_account", x => x.AccountId);
                    table.ForeignKey(
                        name: "FK_account_owner_OwnerId",
                        column: x => x.OwnerId,
                        principalTable: "owner",
                        principalColumn: "OwnerId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "owner",
                columns: new[] { "OwnerId", "Address", "DateOfBirth", "Name" },
                values: new object[,]
                {
                    { new Guid("63cb2e8d-109e-4f64-bf17-4e4de01bf841"), "1234 Gravel Road Kingston, Ontario K0H 1J0", new DateTime(1980, 6, 27, 9, 59, 27, 239, DateTimeKind.Local).AddTicks(3159), "Dave jones" },
                    { new Guid("f845d6a5-8858-4c0f-a918-4ea7f18870e9"), "1234 Paved Road Kingston, Ontario K0H 1X0", new DateTime(1998, 6, 27, 9, 59, 27, 239, DateTimeKind.Local).AddTicks(3106), "George Smith" }
                });

            migrationBuilder.InsertData(
                table: "account",
                columns: new[] { "AccountId", "AccountType", "DateCreated", "OwnerId" },
                values: new object[,]
                {
                    { new Guid("31d36ccb-672c-4d82-83f4-e18e54a33675"), "Admin", new DateTime(2023, 6, 27, 9, 59, 27, 239, DateTimeKind.Local).AddTicks(3282), new Guid("f845d6a5-8858-4c0f-a918-4ea7f18870e9") },
                    { new Guid("4eb135de-f3b2-4aa3-ae57-22c9350ad948"), "User", new DateTime(2023, 6, 27, 9, 59, 27, 239, DateTimeKind.Local).AddTicks(3286), new Guid("63cb2e8d-109e-4f64-bf17-4e4de01bf841") }
                });

            migrationBuilder.CreateIndex(
                name: "IX_account_OwnerId",
                table: "account",
                column: "OwnerId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "account");

            migrationBuilder.DropTable(
                name: "owner");
        }
    }
}
