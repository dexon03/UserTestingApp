using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace UserTestingAPI.Migrations
{
    /// <inheritdoc />
    public partial class Added_More_Question_And_Options : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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
                    { new Guid("36efe904-f259-450f-87c4-ac31007dd413"), "Test 2" },
                    { new Guid("d6e6ad44-363f-4078-8ae6-bcb7c20d29bc"), "Test 1" }
                });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "Email", "PasswordHash", "PasswordSalt" },
                values: new object[] { new Guid("ce508cc7-d46f-4bf4-9bf9-0e5bb06194a5"), "default@mail.com", "60e87e841e9b0edb251f9954556e39e73ea51990ec5488f746daa41e304643fd", "E6ys/lDbNzROnSEhf7SyCg==" });

            migrationBuilder.InsertData(
                table: "Question",
                columns: new[] { "Id", "CorrectOptionId", "TestId", "Text" },
                values: new object[,]
                {
                    { new Guid("6d1d1926-0444-4753-912a-ae6d26910fac"), new Guid("44e5c955-2afe-4d7e-8565-7c501a79a522"), new Guid("d6e6ad44-363f-4078-8ae6-bcb7c20d29bc"), "Question 2" },
                    { new Guid("b0a17d33-b227-458e-939c-cc9415dca297"), new Guid("f78e3fbb-af67-410f-a2af-ae2e2db6529f"), new Guid("36efe904-f259-450f-87c4-ac31007dd413"), "Question 2" },
                    { new Guid("d359df48-5784-40f9-bf5f-2a249a301d88"), new Guid("91f37e92-16ba-44f4-a92b-3bd36937dddc"), new Guid("36efe904-f259-450f-87c4-ac31007dd413"), "Question 1" },
                    { new Guid("fd523bbd-d9cd-42d0-8bc5-b06660103fa2"), new Guid("d95caec4-cb62-4f2b-8d47-9f381e649bd4"), new Guid("d6e6ad44-363f-4078-8ae6-bcb7c20d29bc"), "Question 1" }
                });

            migrationBuilder.InsertData(
                table: "UserTests",
                columns: new[] { "Id", "CompletionDate", "Mark", "TestId", "UserId" },
                values: new object[,]
                {
                    { new Guid("3617154a-ab5f-43f9-85cf-3143bcd5e048"), new DateTime(2023, 11, 22, 10, 51, 26, 737, DateTimeKind.Utc).AddTicks(1953), null, new Guid("36efe904-f259-450f-87c4-ac31007dd413"), new Guid("ce508cc7-d46f-4bf4-9bf9-0e5bb06194a5") },
                    { new Guid("ba70f171-9d7a-4e52-a2cd-49b9447bb853"), new DateTime(2023, 11, 22, 10, 51, 26, 737, DateTimeKind.Utc).AddTicks(1943), 100, new Guid("d6e6ad44-363f-4078-8ae6-bcb7c20d29bc"), new Guid("ce508cc7-d46f-4bf4-9bf9-0e5bb06194a5") }
                });

            migrationBuilder.InsertData(
                table: "Option",
                columns: new[] { "Id", "QuestionId", "Text" },
                values: new object[,]
                {
                    { new Guid("44e5c955-2afe-4d7e-8565-7c501a79a522"), new Guid("fd523bbd-d9cd-42d0-8bc5-b06660103fa2"), "Option 2" },
                    { new Guid("54c8ee08-3cd8-480c-9a66-8c4a92db8aa0"), new Guid("6d1d1926-0444-4753-912a-ae6d26910fac"), "Option 1" },
                    { new Guid("91f37e92-16ba-44f4-a92b-3bd36937dddc"), new Guid("b0a17d33-b227-458e-939c-cc9415dca297"), "Option 1" },
                    { new Guid("a3142274-3894-4d7f-8221-405192a96f2e"), new Guid("6d1d1926-0444-4753-912a-ae6d26910fac"), "Option 2" },
                    { new Guid("d95caec4-cb62-4f2b-8d47-9f381e649bd4"), new Guid("fd523bbd-d9cd-42d0-8bc5-b06660103fa2"), "Option 1" },
                    { new Guid("e0fe9eab-ca4e-4292-a14b-1c6f87e325a4"), new Guid("d359df48-5784-40f9-bf5f-2a249a301d88"), "Option 1" },
                    { new Guid("f78e3fbb-af67-410f-a2af-ae2e2db6529f"), new Guid("b0a17d33-b227-458e-939c-cc9415dca297"), "Option 2" },
                    { new Guid("fba0f34c-aeb0-492f-bd44-ced36726be60"), new Guid("d359df48-5784-40f9-bf5f-2a249a301d88"), "Option 2" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Option",
                keyColumn: "Id",
                keyValue: new Guid("44e5c955-2afe-4d7e-8565-7c501a79a522"));

            migrationBuilder.DeleteData(
                table: "Option",
                keyColumn: "Id",
                keyValue: new Guid("54c8ee08-3cd8-480c-9a66-8c4a92db8aa0"));

            migrationBuilder.DeleteData(
                table: "Option",
                keyColumn: "Id",
                keyValue: new Guid("91f37e92-16ba-44f4-a92b-3bd36937dddc"));

            migrationBuilder.DeleteData(
                table: "Option",
                keyColumn: "Id",
                keyValue: new Guid("a3142274-3894-4d7f-8221-405192a96f2e"));

            migrationBuilder.DeleteData(
                table: "Option",
                keyColumn: "Id",
                keyValue: new Guid("d95caec4-cb62-4f2b-8d47-9f381e649bd4"));

            migrationBuilder.DeleteData(
                table: "Option",
                keyColumn: "Id",
                keyValue: new Guid("e0fe9eab-ca4e-4292-a14b-1c6f87e325a4"));

            migrationBuilder.DeleteData(
                table: "Option",
                keyColumn: "Id",
                keyValue: new Guid("f78e3fbb-af67-410f-a2af-ae2e2db6529f"));

            migrationBuilder.DeleteData(
                table: "Option",
                keyColumn: "Id",
                keyValue: new Guid("fba0f34c-aeb0-492f-bd44-ced36726be60"));

            migrationBuilder.DeleteData(
                table: "UserTests",
                keyColumn: "Id",
                keyValue: new Guid("3617154a-ab5f-43f9-85cf-3143bcd5e048"));

            migrationBuilder.DeleteData(
                table: "UserTests",
                keyColumn: "Id",
                keyValue: new Guid("ba70f171-9d7a-4e52-a2cd-49b9447bb853"));

            migrationBuilder.DeleteData(
                table: "Question",
                keyColumn: "Id",
                keyValue: new Guid("6d1d1926-0444-4753-912a-ae6d26910fac"));

            migrationBuilder.DeleteData(
                table: "Question",
                keyColumn: "Id",
                keyValue: new Guid("b0a17d33-b227-458e-939c-cc9415dca297"));

            migrationBuilder.DeleteData(
                table: "Question",
                keyColumn: "Id",
                keyValue: new Guid("d359df48-5784-40f9-bf5f-2a249a301d88"));

            migrationBuilder.DeleteData(
                table: "Question",
                keyColumn: "Id",
                keyValue: new Guid("fd523bbd-d9cd-42d0-8bc5-b06660103fa2"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("ce508cc7-d46f-4bf4-9bf9-0e5bb06194a5"));

            migrationBuilder.DeleteData(
                table: "Test",
                keyColumn: "Id",
                keyValue: new Guid("36efe904-f259-450f-87c4-ac31007dd413"));

            migrationBuilder.DeleteData(
                table: "Test",
                keyColumn: "Id",
                keyValue: new Guid("d6e6ad44-363f-4078-8ae6-bcb7c20d29bc"));

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
    }
}
