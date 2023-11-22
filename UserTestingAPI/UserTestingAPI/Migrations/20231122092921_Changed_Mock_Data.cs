using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace UserTestingAPI.Migrations
{
    /// <inheritdoc />
    public partial class Changed_Mock_Data : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                table: "UserTests",
                keyColumn: "Id",
                keyValue: new Guid("f5a02c9b-8ade-41b3-8785-60ca2d8a7839"));

            migrationBuilder.DeleteData(
                table: "Question",
                keyColumn: "Id",
                keyValue: new Guid("470013ef-6651-47e8-8531-0c0fb479bf88"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("347a2cb7-d97b-4321-a4e9-f87331dc9405"));

            migrationBuilder.DeleteData(
                table: "Test",
                keyColumn: "Id",
                keyValue: new Guid("43e316f5-d1ef-4f1f-b220-cc997dbbeb36"));

            migrationBuilder.InsertData(
                table: "Test",
                columns: new[] { "Id", "Title" },
                values: new object[,]
                {
                    { new Guid("50a6153b-4ed6-4988-9b20-1671964c1488"), "Test 1" },
                    { new Guid("ebb94653-617f-4c78-954f-8355bdfa8f01"), "Test 2" }
                });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "Email", "PasswordHash", "PasswordSalt" },
                values: new object[] { new Guid("8fbc49b4-4fec-43e8-8ebb-7b0fccc772a4"), "default@mail.com", "5bfa41d4714d376efba08eca33bde4ad31f45e56f9aaaeb65b87a0c22feeb354", "8PHRnjCmihU8dLaoqwNhMQ==" });

            migrationBuilder.InsertData(
                table: "Question",
                columns: new[] { "Id", "CorrectOptionId", "TestId", "Text" },
                values: new object[,]
                {
                    { new Guid("6723ae21-eded-49b2-baa8-dc7e95aec82b"), new Guid("00000000-0000-0000-0000-000000000000"), new Guid("50a6153b-4ed6-4988-9b20-1671964c1488"), "Question 2" },
                    { new Guid("b5f43cfc-a77b-4f34-8db2-84a384718c91"), new Guid("896e4ce7-19d3-4100-a485-fbfd6c191b12"), new Guid("50a6153b-4ed6-4988-9b20-1671964c1488"), "Question 1" }
                });

            migrationBuilder.InsertData(
                table: "UserTests",
                columns: new[] { "Id", "CompletionDate", "Mark", "TestId", "UserId" },
                values: new object[,]
                {
                    { new Guid("21ba5312-5e37-4b0c-a717-2e0b3a40382a"), new DateTime(2023, 11, 22, 9, 29, 21, 463, DateTimeKind.Utc).AddTicks(126), null, new Guid("ebb94653-617f-4c78-954f-8355bdfa8f01"), new Guid("8fbc49b4-4fec-43e8-8ebb-7b0fccc772a4") },
                    { new Guid("d100d644-b4e9-441a-bc28-88dcedbb3f90"), new DateTime(2023, 11, 22, 9, 29, 21, 463, DateTimeKind.Utc).AddTicks(119), 100, new Guid("50a6153b-4ed6-4988-9b20-1671964c1488"), new Guid("8fbc49b4-4fec-43e8-8ebb-7b0fccc772a4") }
                });

            migrationBuilder.InsertData(
                table: "Option",
                columns: new[] { "Id", "QuestionId", "Text" },
                values: new object[,]
                {
                    { new Guid("24873f98-8306-4194-ba1b-5b54addf30fc"), new Guid("b5f43cfc-a77b-4f34-8db2-84a384718c91"), "Option 3" },
                    { new Guid("533c1d65-3f48-4db6-aa1a-b6a0b2ad6f00"), new Guid("b5f43cfc-a77b-4f34-8db2-84a384718c91"), "Option 2" },
                    { new Guid("6089cf92-9bee-4739-a542-a8e9f3bea78b"), new Guid("b5f43cfc-a77b-4f34-8db2-84a384718c91"), "Option 4" },
                    { new Guid("896e4ce7-19d3-4100-a485-fbfd6c191b12"), new Guid("b5f43cfc-a77b-4f34-8db2-84a384718c91"), "Option 1" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Option",
                keyColumn: "Id",
                keyValue: new Guid("24873f98-8306-4194-ba1b-5b54addf30fc"));

            migrationBuilder.DeleteData(
                table: "Option",
                keyColumn: "Id",
                keyValue: new Guid("533c1d65-3f48-4db6-aa1a-b6a0b2ad6f00"));

            migrationBuilder.DeleteData(
                table: "Option",
                keyColumn: "Id",
                keyValue: new Guid("6089cf92-9bee-4739-a542-a8e9f3bea78b"));

            migrationBuilder.DeleteData(
                table: "Option",
                keyColumn: "Id",
                keyValue: new Guid("896e4ce7-19d3-4100-a485-fbfd6c191b12"));

            migrationBuilder.DeleteData(
                table: "Question",
                keyColumn: "Id",
                keyValue: new Guid("6723ae21-eded-49b2-baa8-dc7e95aec82b"));

            migrationBuilder.DeleteData(
                table: "UserTests",
                keyColumn: "Id",
                keyValue: new Guid("21ba5312-5e37-4b0c-a717-2e0b3a40382a"));

            migrationBuilder.DeleteData(
                table: "UserTests",
                keyColumn: "Id",
                keyValue: new Guid("d100d644-b4e9-441a-bc28-88dcedbb3f90"));

            migrationBuilder.DeleteData(
                table: "Question",
                keyColumn: "Id",
                keyValue: new Guid("b5f43cfc-a77b-4f34-8db2-84a384718c91"));

            migrationBuilder.DeleteData(
                table: "Test",
                keyColumn: "Id",
                keyValue: new Guid("ebb94653-617f-4c78-954f-8355bdfa8f01"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("8fbc49b4-4fec-43e8-8ebb-7b0fccc772a4"));

            migrationBuilder.DeleteData(
                table: "Test",
                keyColumn: "Id",
                keyValue: new Guid("50a6153b-4ed6-4988-9b20-1671964c1488"));

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
        }
    }
}
