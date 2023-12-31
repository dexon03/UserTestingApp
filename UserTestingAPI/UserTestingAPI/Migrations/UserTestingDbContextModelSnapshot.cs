﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using UserTestingAPI.Database;

#nullable disable

namespace UserTestingAPI.Migrations
{
    [DbContext(typeof(UserTestingDbContext))]
    partial class UserTestingDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.14")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("UserTestingAPI.Domain.Entities.Option", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("QuestionId")
                        .HasColumnType("uuid");

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("QuestionId");

                    b.ToTable("Option");

                    b.HasData(
                        new
                        {
                            Id = new Guid("7c569bcc-8283-4cf8-8438-1f47cd041493"),
                            QuestionId = new Guid("2fa5ecab-4550-45d5-929d-3ef37f8d615d"),
                            Text = "Option 1"
                        },
                        new
                        {
                            Id = new Guid("56b9c150-dd72-4385-a355-fbdbd2d1048d"),
                            QuestionId = new Guid("2fa5ecab-4550-45d5-929d-3ef37f8d615d"),
                            Text = "Option 2"
                        },
                        new
                        {
                            Id = new Guid("17057f9b-4bdd-444d-85cb-139e8aaf281e"),
                            QuestionId = new Guid("0cdf732f-1973-4dab-b5d3-61e6c2a2b2d9"),
                            Text = "Option 1"
                        },
                        new
                        {
                            Id = new Guid("d541ecfe-bbc8-4edf-a017-a2aea7275114"),
                            QuestionId = new Guid("0cdf732f-1973-4dab-b5d3-61e6c2a2b2d9"),
                            Text = "Option 2"
                        },
                        new
                        {
                            Id = new Guid("1672287d-ce9f-45ac-be99-9bce2188c567"),
                            QuestionId = new Guid("a95c3edc-8604-4312-b984-456c4b9df800"),
                            Text = "Option 1"
                        },
                        new
                        {
                            Id = new Guid("87500b28-baf1-4eec-aa83-97c6c5ad9bd3"),
                            QuestionId = new Guid("a95c3edc-8604-4312-b984-456c4b9df800"),
                            Text = "Option 2"
                        },
                        new
                        {
                            Id = new Guid("191260ec-7c98-4abc-bec0-cde94cc898f6"),
                            QuestionId = new Guid("09a916d4-f559-4145-a370-aef2160cd10a"),
                            Text = "Option 1"
                        },
                        new
                        {
                            Id = new Guid("5d084518-dc52-4b87-b0f4-53bd93cf0029"),
                            QuestionId = new Guid("09a916d4-f559-4145-a370-aef2160cd10a"),
                            Text = "Option 2"
                        });
                });

            modelBuilder.Entity("UserTestingAPI.Domain.Entities.Question", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("CorrectOptionId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("TestId")
                        .HasColumnType("uuid");

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("TestId");

                    b.ToTable("Question");

                    b.HasData(
                        new
                        {
                            Id = new Guid("2fa5ecab-4550-45d5-929d-3ef37f8d615d"),
                            CorrectOptionId = new Guid("7c569bcc-8283-4cf8-8438-1f47cd041493"),
                            TestId = new Guid("dd5c8e5c-2e40-4b1a-a2b7-1f447b75daa1"),
                            Text = "Question 1"
                        },
                        new
                        {
                            Id = new Guid("0cdf732f-1973-4dab-b5d3-61e6c2a2b2d9"),
                            CorrectOptionId = new Guid("17057f9b-4bdd-444d-85cb-139e8aaf281e"),
                            TestId = new Guid("dd5c8e5c-2e40-4b1a-a2b7-1f447b75daa1"),
                            Text = "Question 2"
                        },
                        new
                        {
                            Id = new Guid("a95c3edc-8604-4312-b984-456c4b9df800"),
                            CorrectOptionId = new Guid("1672287d-ce9f-45ac-be99-9bce2188c567"),
                            TestId = new Guid("787fda42-c5a0-4329-8974-4858ef81017b"),
                            Text = "Question 1"
                        },
                        new
                        {
                            Id = new Guid("09a916d4-f559-4145-a370-aef2160cd10a"),
                            CorrectOptionId = new Guid("191260ec-7c98-4abc-bec0-cde94cc898f6"),
                            TestId = new Guid("787fda42-c5a0-4329-8974-4858ef81017b"),
                            Text = "Question 2"
                        });
                });

            modelBuilder.Entity("UserTestingAPI.Domain.Entities.Test", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Test");

                    b.HasData(
                        new
                        {
                            Id = new Guid("dd5c8e5c-2e40-4b1a-a2b7-1f447b75daa1"),
                            Title = "Test 1"
                        },
                        new
                        {
                            Id = new Guid("787fda42-c5a0-4329-8974-4858ef81017b"),
                            Title = "Test 2"
                        });
                });

            modelBuilder.Entity("UserTestingAPI.Domain.Entities.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("PasswordSalt")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("User");

                    b.HasData(
                        new
                        {
                            Id = new Guid("c35519b7-d4ed-46b3-96bf-80759eaed814"),
                            Email = "default@mail.com",
                            PasswordHash = "cdc5f15fb920216cb6ad5a8a6220bfda87a23857b73cd542f04a88ad0741cf12",
                            PasswordSalt = "f6Vl9+/W9lQqIOqakhFtuQ=="
                        });
                });

            modelBuilder.Entity("UserTestingAPI.Domain.Entities.UserTests", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime?>("CompletionDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<int?>("Mark")
                        .HasColumnType("integer");

                    b.Property<Guid>("TestId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("TestId");

                    b.HasIndex("UserId");

                    b.ToTable("UserTests");

                    b.HasData(
                        new
                        {
                            Id = new Guid("e73575eb-9816-446d-a2d8-0ba4de7867d6"),
                            CompletionDate = new DateTime(2023, 11, 22, 11, 3, 34, 716, DateTimeKind.Utc).AddTicks(3876),
                            Mark = 100,
                            TestId = new Guid("dd5c8e5c-2e40-4b1a-a2b7-1f447b75daa1"),
                            UserId = new Guid("c35519b7-d4ed-46b3-96bf-80759eaed814")
                        },
                        new
                        {
                            Id = new Guid("b7daa0d7-b0e8-42e8-9ffb-ee7292ba4991"),
                            TestId = new Guid("787fda42-c5a0-4329-8974-4858ef81017b"),
                            UserId = new Guid("c35519b7-d4ed-46b3-96bf-80759eaed814")
                        });
                });

            modelBuilder.Entity("UserTestingAPI.Domain.Entities.Option", b =>
                {
                    b.HasOne("UserTestingAPI.Domain.Entities.Question", "Question")
                        .WithMany("Options")
                        .HasForeignKey("QuestionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Question");
                });

            modelBuilder.Entity("UserTestingAPI.Domain.Entities.Question", b =>
                {
                    b.HasOne("UserTestingAPI.Domain.Entities.Test", "Test")
                        .WithMany("Questions")
                        .HasForeignKey("TestId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Test");
                });

            modelBuilder.Entity("UserTestingAPI.Domain.Entities.UserTests", b =>
                {
                    b.HasOne("UserTestingAPI.Domain.Entities.Test", "Test")
                        .WithMany("CompletedTests")
                        .HasForeignKey("TestId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("UserTestingAPI.Domain.Entities.User", "User")
                        .WithMany("CompletedTests")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Test");

                    b.Navigation("User");
                });

            modelBuilder.Entity("UserTestingAPI.Domain.Entities.Question", b =>
                {
                    b.Navigation("Options");
                });

            modelBuilder.Entity("UserTestingAPI.Domain.Entities.Test", b =>
                {
                    b.Navigation("CompletedTests");

                    b.Navigation("Questions");
                });

            modelBuilder.Entity("UserTestingAPI.Domain.Entities.User", b =>
                {
                    b.Navigation("CompletedTests");
                });
#pragma warning restore 612, 618
        }
    }
}
