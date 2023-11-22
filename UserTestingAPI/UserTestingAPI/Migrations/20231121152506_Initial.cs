using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace UserTestingAPI.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Test",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Title = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Test", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: false),
                    PasswordHash = table.Column<string>(type: "text", nullable: false),
                    PasswordSalt = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Question",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Text = table.Column<string>(type: "text", nullable: false),
                    TestId = table.Column<Guid>(type: "uuid", nullable: false),
                    CorrectOptionId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Question", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Question_Test_TestId",
                        column: x => x.TestId,
                        principalTable: "Test",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CompletedTest",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    TestId = table.Column<Guid>(type: "uuid", nullable: false),
                    Mark = table.Column<int>(type: "integer", nullable: false),
                    CompletionDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompletedTest", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CompletedTest_Test_TestId",
                        column: x => x.TestId,
                        principalTable: "Test",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CompletedTest_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Option",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    QuestionId = table.Column<Guid>(type: "uuid", nullable: false),
                    Text = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Option", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Option_Question_QuestionId",
                        column: x => x.QuestionId,
                        principalTable: "Question",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Test",
                columns: new[] { "Id", "Title" },
                values: new object[,]
                {
                    { new Guid("1d1ea193-3cec-4667-be08-ec03520de019"), "Test 1" },
                    { new Guid("37dab780-61e0-4be5-bb65-0ddf97b5b425"), "Test 2" }
                });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "Email", "PasswordHash", "PasswordSalt" },
                values: new object[] { new Guid("2566b911-4aec-46f5-ba91-e7510e217c76"), "default@mail.com", "beb9d63a3d6695b8bbeee366486e39f0e34dab9c04917091baab33c37ca1f9d7", "mjJRzM0yozbH3ERejBCxKw==" });

            migrationBuilder.InsertData(
                table: "CompletedTest",
                columns: new[] { "Id", "CompletionDate", "Mark", "TestId", "UserId" },
                values: new object[] { new Guid("fd35fb11-30f9-4d41-ad01-5c8bd4a14ce9"), new DateTime(2023, 11, 21, 15, 25, 6, 38, DateTimeKind.Utc).AddTicks(1169), 100, new Guid("1d1ea193-3cec-4667-be08-ec03520de019"), new Guid("2566b911-4aec-46f5-ba91-e7510e217c76") });

            migrationBuilder.InsertData(
                table: "Question",
                columns: new[] { "Id", "CorrectOptionId", "TestId", "Text" },
                values: new object[,]
                {
                    { new Guid("88794d65-d82d-4148-827e-e26891781fbd"), new Guid("96de87a4-1f6f-450c-ab81-77ac066ca3d5"), new Guid("1d1ea193-3cec-4667-be08-ec03520de019"), "Question 1" },
                    { new Guid("e8c9507c-935c-48eb-9c80-84934b5e24d1"), new Guid("00000000-0000-0000-0000-000000000000"), new Guid("1d1ea193-3cec-4667-be08-ec03520de019"), "Question 2" }
                });

            migrationBuilder.InsertData(
                table: "Option",
                columns: new[] { "Id", "QuestionId", "Text" },
                values: new object[,]
                {
                    { new Guid("96de87a4-1f6f-450c-ab81-77ac066ca3d5"), new Guid("88794d65-d82d-4148-827e-e26891781fbd"), "Option 1" },
                    { new Guid("b67985bd-3b9d-4bcb-85e0-bf715514a726"), new Guid("88794d65-d82d-4148-827e-e26891781fbd"), "Option 2" },
                    { new Guid("d2955876-01d6-4fce-ae1c-d12839342c93"), new Guid("88794d65-d82d-4148-827e-e26891781fbd"), "Option 3" },
                    { new Guid("fd6f9d21-076e-4133-82bd-456a7975782e"), new Guid("88794d65-d82d-4148-827e-e26891781fbd"), "Option 4" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_CompletedTest_TestId",
                table: "CompletedTest",
                column: "TestId");

            migrationBuilder.CreateIndex(
                name: "IX_CompletedTest_UserId",
                table: "CompletedTest",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Option_QuestionId",
                table: "Option",
                column: "QuestionId");

            migrationBuilder.CreateIndex(
                name: "IX_Question_TestId",
                table: "Question",
                column: "TestId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CompletedTest");

            migrationBuilder.DropTable(
                name: "Option");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "Question");

            migrationBuilder.DropTable(
                name: "Test");
        }
    }
}
