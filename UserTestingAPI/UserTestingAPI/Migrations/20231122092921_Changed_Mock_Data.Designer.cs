﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using UserTestingAPI.Database;

#nullable disable

namespace UserTestingAPI.Migrations
{
    [DbContext(typeof(UserTestingDbContext))]
    [Migration("20231122092921_Changed_Mock_Data")]
    partial class Changed_Mock_Data
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
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
                            Id = new Guid("896e4ce7-19d3-4100-a485-fbfd6c191b12"),
                            QuestionId = new Guid("b5f43cfc-a77b-4f34-8db2-84a384718c91"),
                            Text = "Option 1"
                        },
                        new
                        {
                            Id = new Guid("533c1d65-3f48-4db6-aa1a-b6a0b2ad6f00"),
                            QuestionId = new Guid("b5f43cfc-a77b-4f34-8db2-84a384718c91"),
                            Text = "Option 2"
                        },
                        new
                        {
                            Id = new Guid("24873f98-8306-4194-ba1b-5b54addf30fc"),
                            QuestionId = new Guid("b5f43cfc-a77b-4f34-8db2-84a384718c91"),
                            Text = "Option 3"
                        },
                        new
                        {
                            Id = new Guid("6089cf92-9bee-4739-a542-a8e9f3bea78b"),
                            QuestionId = new Guid("b5f43cfc-a77b-4f34-8db2-84a384718c91"),
                            Text = "Option 4"
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
                            Id = new Guid("b5f43cfc-a77b-4f34-8db2-84a384718c91"),
                            CorrectOptionId = new Guid("896e4ce7-19d3-4100-a485-fbfd6c191b12"),
                            TestId = new Guid("50a6153b-4ed6-4988-9b20-1671964c1488"),
                            Text = "Question 1"
                        },
                        new
                        {
                            Id = new Guid("6723ae21-eded-49b2-baa8-dc7e95aec82b"),
                            CorrectOptionId = new Guid("00000000-0000-0000-0000-000000000000"),
                            TestId = new Guid("50a6153b-4ed6-4988-9b20-1671964c1488"),
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
                            Id = new Guid("50a6153b-4ed6-4988-9b20-1671964c1488"),
                            Title = "Test 1"
                        },
                        new
                        {
                            Id = new Guid("ebb94653-617f-4c78-954f-8355bdfa8f01"),
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
                            Id = new Guid("8fbc49b4-4fec-43e8-8ebb-7b0fccc772a4"),
                            Email = "default@mail.com",
                            PasswordHash = "5bfa41d4714d376efba08eca33bde4ad31f45e56f9aaaeb65b87a0c22feeb354",
                            PasswordSalt = "8PHRnjCmihU8dLaoqwNhMQ=="
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
                            Id = new Guid("d100d644-b4e9-441a-bc28-88dcedbb3f90"),
                            CompletionDate = new DateTime(2023, 11, 22, 9, 29, 21, 463, DateTimeKind.Utc).AddTicks(119),
                            Mark = 100,
                            TestId = new Guid("50a6153b-4ed6-4988-9b20-1671964c1488"),
                            UserId = new Guid("8fbc49b4-4fec-43e8-8ebb-7b0fccc772a4")
                        },
                        new
                        {
                            Id = new Guid("21ba5312-5e37-4b0c-a717-2e0b3a40382a"),
                            CompletionDate = new DateTime(2023, 11, 22, 9, 29, 21, 463, DateTimeKind.Utc).AddTicks(126),
                            TestId = new Guid("ebb94653-617f-4c78-954f-8355bdfa8f01"),
                            UserId = new Guid("8fbc49b4-4fec-43e8-8ebb-7b0fccc772a4")
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
