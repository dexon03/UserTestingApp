using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace UserTestingAPI.Migrations
{
    /// <inheritdoc />
    public partial class Fixed_Mocked_Data : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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
                    { new Guid("787fda42-c5a0-4329-8974-4858ef81017b"), "Test 2" },
                    { new Guid("dd5c8e5c-2e40-4b1a-a2b7-1f447b75daa1"), "Test 1" }
                });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "Email", "PasswordHash", "PasswordSalt" },
                values: new object[] { new Guid("c35519b7-d4ed-46b3-96bf-80759eaed814"), "default@mail.com", "cdc5f15fb920216cb6ad5a8a6220bfda87a23857b73cd542f04a88ad0741cf12", "f6Vl9+/W9lQqIOqakhFtuQ==" });

            migrationBuilder.InsertData(
                table: "Question",
                columns: new[] { "Id", "CorrectOptionId", "TestId", "Text" },
                values: new object[,]
                {
                    { new Guid("09a916d4-f559-4145-a370-aef2160cd10a"), new Guid("191260ec-7c98-4abc-bec0-cde94cc898f6"), new Guid("787fda42-c5a0-4329-8974-4858ef81017b"), "Question 2" },
                    { new Guid("0cdf732f-1973-4dab-b5d3-61e6c2a2b2d9"), new Guid("17057f9b-4bdd-444d-85cb-139e8aaf281e"), new Guid("dd5c8e5c-2e40-4b1a-a2b7-1f447b75daa1"), "Question 2" },
                    { new Guid("2fa5ecab-4550-45d5-929d-3ef37f8d615d"), new Guid("7c569bcc-8283-4cf8-8438-1f47cd041493"), new Guid("dd5c8e5c-2e40-4b1a-a2b7-1f447b75daa1"), "Question 1" },
                    { new Guid("a95c3edc-8604-4312-b984-456c4b9df800"), new Guid("1672287d-ce9f-45ac-be99-9bce2188c567"), new Guid("787fda42-c5a0-4329-8974-4858ef81017b"), "Question 1" }
                });

            migrationBuilder.InsertData(
                table: "UserTests",
                columns: new[] { "Id", "CompletionDate", "Mark", "TestId", "UserId" },
                values: new object[,]
                {
                    { new Guid("b7daa0d7-b0e8-42e8-9ffb-ee7292ba4991"), null, null, new Guid("787fda42-c5a0-4329-8974-4858ef81017b"), new Guid("c35519b7-d4ed-46b3-96bf-80759eaed814") },
                    { new Guid("e73575eb-9816-446d-a2d8-0ba4de7867d6"), new DateTime(2023, 11, 22, 11, 3, 34, 716, DateTimeKind.Utc).AddTicks(3876), 100, new Guid("dd5c8e5c-2e40-4b1a-a2b7-1f447b75daa1"), new Guid("c35519b7-d4ed-46b3-96bf-80759eaed814") }
                });

            migrationBuilder.InsertData(
                table: "Option",
                columns: new[] { "Id", "QuestionId", "Text" },
                values: new object[,]
                {
                    { new Guid("1672287d-ce9f-45ac-be99-9bce2188c567"), new Guid("a95c3edc-8604-4312-b984-456c4b9df800"), "Option 1" },
                    { new Guid("17057f9b-4bdd-444d-85cb-139e8aaf281e"), new Guid("0cdf732f-1973-4dab-b5d3-61e6c2a2b2d9"), "Option 1" },
                    { new Guid("191260ec-7c98-4abc-bec0-cde94cc898f6"), new Guid("09a916d4-f559-4145-a370-aef2160cd10a"), "Option 1" },
                    { new Guid("56b9c150-dd72-4385-a355-fbdbd2d1048d"), new Guid("2fa5ecab-4550-45d5-929d-3ef37f8d615d"), "Option 2" },
                    { new Guid("5d084518-dc52-4b87-b0f4-53bd93cf0029"), new Guid("09a916d4-f559-4145-a370-aef2160cd10a"), "Option 2" },
                    { new Guid("7c569bcc-8283-4cf8-8438-1f47cd041493"), new Guid("2fa5ecab-4550-45d5-929d-3ef37f8d615d"), "Option 1" },
                    { new Guid("87500b28-baf1-4eec-aa83-97c6c5ad9bd3"), new Guid("a95c3edc-8604-4312-b984-456c4b9df800"), "Option 2" },
                    { new Guid("d541ecfe-bbc8-4edf-a017-a2aea7275114"), new Guid("0cdf732f-1973-4dab-b5d3-61e6c2a2b2d9"), "Option 2" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Option",
                keyColumn: "Id",
                keyValue: new Guid("1672287d-ce9f-45ac-be99-9bce2188c567"));

            migrationBuilder.DeleteData(
                table: "Option",
                keyColumn: "Id",
                keyValue: new Guid("17057f9b-4bdd-444d-85cb-139e8aaf281e"));

            migrationBuilder.DeleteData(
                table: "Option",
                keyColumn: "Id",
                keyValue: new Guid("191260ec-7c98-4abc-bec0-cde94cc898f6"));

            migrationBuilder.DeleteData(
                table: "Option",
                keyColumn: "Id",
                keyValue: new Guid("56b9c150-dd72-4385-a355-fbdbd2d1048d"));

            migrationBuilder.DeleteData(
                table: "Option",
                keyColumn: "Id",
                keyValue: new Guid("5d084518-dc52-4b87-b0f4-53bd93cf0029"));

            migrationBuilder.DeleteData(
                table: "Option",
                keyColumn: "Id",
                keyValue: new Guid("7c569bcc-8283-4cf8-8438-1f47cd041493"));

            migrationBuilder.DeleteData(
                table: "Option",
                keyColumn: "Id",
                keyValue: new Guid("87500b28-baf1-4eec-aa83-97c6c5ad9bd3"));

            migrationBuilder.DeleteData(
                table: "Option",
                keyColumn: "Id",
                keyValue: new Guid("d541ecfe-bbc8-4edf-a017-a2aea7275114"));

            migrationBuilder.DeleteData(
                table: "UserTests",
                keyColumn: "Id",
                keyValue: new Guid("b7daa0d7-b0e8-42e8-9ffb-ee7292ba4991"));

            migrationBuilder.DeleteData(
                table: "UserTests",
                keyColumn: "Id",
                keyValue: new Guid("e73575eb-9816-446d-a2d8-0ba4de7867d6"));

            migrationBuilder.DeleteData(
                table: "Question",
                keyColumn: "Id",
                keyValue: new Guid("09a916d4-f559-4145-a370-aef2160cd10a"));

            migrationBuilder.DeleteData(
                table: "Question",
                keyColumn: "Id",
                keyValue: new Guid("0cdf732f-1973-4dab-b5d3-61e6c2a2b2d9"));

            migrationBuilder.DeleteData(
                table: "Question",
                keyColumn: "Id",
                keyValue: new Guid("2fa5ecab-4550-45d5-929d-3ef37f8d615d"));

            migrationBuilder.DeleteData(
                table: "Question",
                keyColumn: "Id",
                keyValue: new Guid("a95c3edc-8604-4312-b984-456c4b9df800"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("c35519b7-d4ed-46b3-96bf-80759eaed814"));

            migrationBuilder.DeleteData(
                table: "Test",
                keyColumn: "Id",
                keyValue: new Guid("787fda42-c5a0-4329-8974-4858ef81017b"));

            migrationBuilder.DeleteData(
                table: "Test",
                keyColumn: "Id",
                keyValue: new Guid("dd5c8e5c-2e40-4b1a-a2b7-1f447b75daa1"));

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
    }
}
