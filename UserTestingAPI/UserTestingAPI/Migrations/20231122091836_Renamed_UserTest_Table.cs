using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace UserTestingAPI.Migrations
{
    /// <inheritdoc />
    public partial class Renamed_UserTest_Table : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CompletedTest");

            migrationBuilder.DeleteData(
                table: "Option",
                keyColumn: "Id",
                keyValue: new Guid("96de87a4-1f6f-450c-ab81-77ac066ca3d5"));

            migrationBuilder.DeleteData(
                table: "Option",
                keyColumn: "Id",
                keyValue: new Guid("b67985bd-3b9d-4bcb-85e0-bf715514a726"));

            migrationBuilder.DeleteData(
                table: "Option",
                keyColumn: "Id",
                keyValue: new Guid("d2955876-01d6-4fce-ae1c-d12839342c93"));

            migrationBuilder.DeleteData(
                table: "Option",
                keyColumn: "Id",
                keyValue: new Guid("fd6f9d21-076e-4133-82bd-456a7975782e"));

            migrationBuilder.DeleteData(
                table: "Question",
                keyColumn: "Id",
                keyValue: new Guid("e8c9507c-935c-48eb-9c80-84934b5e24d1"));

            migrationBuilder.DeleteData(
                table: "Test",
                keyColumn: "Id",
                keyValue: new Guid("37dab780-61e0-4be5-bb65-0ddf97b5b425"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("2566b911-4aec-46f5-ba91-e7510e217c76"));

            migrationBuilder.DeleteData(
                table: "Question",
                keyColumn: "Id",
                keyValue: new Guid("88794d65-d82d-4148-827e-e26891781fbd"));

            migrationBuilder.DeleteData(
                table: "Test",
                keyColumn: "Id",
                keyValue: new Guid("1d1ea193-3cec-4667-be08-ec03520de019"));

            migrationBuilder.CreateTable(
                name: "UserTests",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    TestId = table.Column<Guid>(type: "uuid", nullable: false),
                    Mark = table.Column<int>(type: "integer", nullable: true),
                    CompletionDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserTests", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserTests_Test_TestId",
                        column: x => x.TestId,
                        principalTable: "Test",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserTests_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Test",
                columns: new[] { "Id", "Title" },
                values: new object[,]
                {
                    { new Guid("43e316f5-d1ef-4f1f-b220-cc997dbbeb36"), "Test 1" },
                    { new Guid("b5900132-d8f4-4478-b8e0-f8a8fafb4aad"), "Test 2" }
                });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "Email", "PasswordHash", "PasswordSalt" },
                values: new object[] { new Guid("347a2cb7-d97b-4321-a4e9-f87331dc9405"), "default@mail.com", "4d8b951b4f5d4624298e324528ce77169c8f5a9ca0a38a246f9620ce93e222e1", "Gn6/PkAcfNlj1cha49O4Nw==" });

            migrationBuilder.InsertData(
                table: "Question",
                columns: new[] { "Id", "CorrectOptionId", "TestId", "Text" },
                values: new object[,]
                {
                    { new Guid("470013ef-6651-47e8-8531-0c0fb479bf88"), new Guid("75a5dce6-e6d8-4f96-92ac-7445fda87fd7"), new Guid("43e316f5-d1ef-4f1f-b220-cc997dbbeb36"), "Question 1" },
                    { new Guid("470151a4-4309-4deb-ae96-66f59a829407"), new Guid("00000000-0000-0000-0000-000000000000"), new Guid("43e316f5-d1ef-4f1f-b220-cc997dbbeb36"), "Question 2" }
                });

            migrationBuilder.InsertData(
                table: "UserTests",
                columns: new[] { "Id", "CompletionDate", "Mark", "TestId", "UserId" },
                values: new object[] { new Guid("f5a02c9b-8ade-41b3-8785-60ca2d8a7839"), new DateTime(2023, 11, 22, 9, 18, 36, 39, DateTimeKind.Utc).AddTicks(6284), 100, new Guid("43e316f5-d1ef-4f1f-b220-cc997dbbeb36"), new Guid("347a2cb7-d97b-4321-a4e9-f87331dc9405") });

            migrationBuilder.InsertData(
                table: "Option",
                columns: new[] { "Id", "QuestionId", "Text" },
                values: new object[,]
                {
                    { new Guid("21a643ab-8995-4585-9c0b-8bb86c2a7be6"), new Guid("470013ef-6651-47e8-8531-0c0fb479bf88"), "Option 2" },
                    { new Guid("3a4fd33b-d51d-4334-a4e6-10b35bee7d57"), new Guid("470013ef-6651-47e8-8531-0c0fb479bf88"), "Option 3" },
                    { new Guid("75a5dce6-e6d8-4f96-92ac-7445fda87fd7"), new Guid("470013ef-6651-47e8-8531-0c0fb479bf88"), "Option 1" },
                    { new Guid("b6ba0e08-fd51-40a2-8917-c6cf1aff0d17"), new Guid("470013ef-6651-47e8-8531-0c0fb479bf88"), "Option 4" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserTests_TestId",
                table: "UserTests",
                column: "TestId");

            migrationBuilder.CreateIndex(
                name: "IX_UserTests_UserId",
                table: "UserTests",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserTests");

            migrationBuilder.DeleteData(
                table: "Option",
                keyColumn: "Id",
                keyValue: new Guid("21a643ab-8995-4585-9c0b-8bb86c2a7be6"));

            migrationBuilder.DeleteData(
                table: "Option",
                keyColumn: "Id",
                keyValue: new Guid("3a4fd33b-d51d-4334-a4e6-10b35bee7d57"));

            migrationBuilder.DeleteData(
                table: "Option",
                keyColumn: "Id",
                keyValue: new Guid("75a5dce6-e6d8-4f96-92ac-7445fda87fd7"));

            migrationBuilder.DeleteData(
                table: "Option",
                keyColumn: "Id",
                keyValue: new Guid("b6ba0e08-fd51-40a2-8917-c6cf1aff0d17"));

            migrationBuilder.DeleteData(
                table: "Question",
                keyColumn: "Id",
                keyValue: new Guid("470151a4-4309-4deb-ae96-66f59a829407"));

            migrationBuilder.DeleteData(
                table: "Test",
                keyColumn: "Id",
                keyValue: new Guid("b5900132-d8f4-4478-b8e0-f8a8fafb4aad"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("347a2cb7-d97b-4321-a4e9-f87331dc9405"));

            migrationBuilder.DeleteData(
                table: "Question",
                keyColumn: "Id",
                keyValue: new Guid("470013ef-6651-47e8-8531-0c0fb479bf88"));

            migrationBuilder.DeleteData(
                table: "Test",
                keyColumn: "Id",
                keyValue: new Guid("43e316f5-d1ef-4f1f-b220-cc997dbbeb36"));

            migrationBuilder.CreateTable(
                name: "CompletedTest",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    TestId = table.Column<Guid>(type: "uuid", nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    CompletionDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    Mark = table.Column<int>(type: "integer", nullable: false)
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
        }
    }
}
