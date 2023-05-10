﻿// <auto-generated />
using System;
using FoodForRequest.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace FoodForRequest.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20230510182653_offer")]
    partial class offer
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.16")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("FoodForRequest.Models.Comment", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ContractorId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RequestId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ContractorId");

                    b.HasIndex("RequestId");

                    b.ToTable("Comments");

                    b.HasData(
                        new
                        {
                            Id = "c8e4e52c-a582-467f-958a-0612429d7ffc",
                            ContractorId = "c80c45df-eb32-416d-acf4-95175e87daa2",
                            RequestId = "3",
                            Text = "Hi"
                        },
                        new
                        {
                            Id = "c4a3cf4e-0621-4611-bf0a-f46b82411cae",
                            ContractorId = "c80c45df-eb32-416d-acf4-95175e87daa2",
                            RequestId = "4",
                            Text = "Hello"
                        });
                });

            modelBuilder.Entity("FoodForRequest.Models.FoodRequest", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(1000)
                        .HasColumnType("nvarchar(1000)");

                    b.Property<bool>("IsDone")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("PictureContentType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RequestorId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RequestorId");

                    b.ToTable("Foodrequests");

                    b.HasData(
                        new
                        {
                            Id = "6d589dfb-82cd-4235-885b-d96ad4cd3b2f",
                            Description = "Nyers hal",
                            IsDone = false,
                            Name = "Susi",
                            PictureContentType = "Image/jpeg",
                            RequestorId = "1b33d921-a653-46b4-b554-2fcf44b074b8"
                        },
                        new
                        {
                            Id = "43c89048-798b-44d3-8bfd-bc8d4475757f",
                            Description = "Sülthus",
                            IsDone = false,
                            Name = "Stake",
                            PictureContentType = "Image/jpeg",
                            RequestorId = "1b33d921-a653-46b4-b554-2fcf44b074b8"
                        },
                        new
                        {
                            Id = "3",
                            Description = "Tosted.",
                            IsDone = false,
                            Name = "Toast",
                            PictureContentType = "Image/jpeg",
                            RequestorId = "6ec16e3b-9a5e-49cd-a243-c2468de5f853"
                        },
                        new
                        {
                            Id = "4",
                            Description = "All the chocklate",
                            IsDone = false,
                            Name = "Chocklate ckae",
                            PictureContentType = "Image/png",
                            RequestorId = "6ec16e3b-9a5e-49cd-a243-c2468de5f853"
                        },
                        new
                        {
                            Id = "5",
                            Description = "I want to see myself eating",
                            IsDone = false,
                            Name = "Mirror ckae",
                            PictureContentType = "Image/jpeg",
                            RequestorId = "6ec16e3b-9a5e-49cd-a243-c2468de5f853"
                        });
                });

            modelBuilder.Entity("FoodForRequest.Models.Ingredient", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FoodId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("FoodId");

                    b.ToTable("Ingredients");

                    b.HasData(
                        new
                        {
                            Id = "c38dfa96-0938-405b-9fd6-26fa30b533f5",
                            Description = "Tuna",
                            FoodId = "6d589dfb-82cd-4235-885b-d96ad4cd3b2f",
                            Name = "Hal"
                        },
                        new
                        {
                            Id = "d8e2bfa6-f27b-46f9-8fab-d94c7c3fa302",
                            Description = "Rizs",
                            FoodId = "6d589dfb-82cd-4235-885b-d96ad4cd3b2f",
                            Name = "Rizs"
                        },
                        new
                        {
                            Id = "dfc9ad00-2a5c-48b5-9ec8-23f0decc21a7",
                            Description = "Dark",
                            FoodId = "4",
                            Name = "Choko"
                        });
                });

            modelBuilder.Entity("FoodForRequest.Models.Offer", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(450)");

                    b.Property<bool>("Choosen")
                        .HasColumnType("bit");

                    b.Property<string>("ContractorId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("FoodId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("ContractorId");

                    b.HasIndex("FoodId");

                    b.ToTable("Offers");

                    b.HasData(
                        new
                        {
                            Id = "217755f8-f4ec-40f5-b4ae-21794c1d0226",
                            Choosen = false,
                            ContractorId = "1b33d921-a653-46b4-b554-2fcf44b074b8",
                            FoodId = "3"
                        },
                        new
                        {
                            Id = "d1eca9b3-b27c-4ef8-b0d1-192217ec269d",
                            Choosen = false,
                            ContractorId = "c80c45df-eb32-416d-acf4-95175e87daa2",
                            FoodId = "3"
                        },
                        new
                        {
                            Id = "5e39dd77-7695-43c3-aefd-f74176f52e22",
                            Choosen = false,
                            ContractorId = "c80c45df-eb32-416d-acf4-95175e87daa2",
                            FoodId = "4"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);

                    b.HasData(
                        new
                        {
                            Id = "1",
                            Name = "Admin",
                            NormalizedName = "ADMIN"
                        },
                        new
                        {
                            Id = "2",
                            Name = "User",
                            NormalizedName = "USER"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);

                    b.HasDiscriminator<string>("Discriminator").HasValue("IdentityUser");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderKey")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Name")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("FoodForRequest.Models.FoodUser", b =>
                {
                    b.HasBaseType("Microsoft.AspNetCore.Identity.IdentityUser");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FoodUserName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasDiscriminator().HasValue("FoodUser");

                    b.HasData(
                        new
                        {
                            Id = "1b33d921-a653-46b4-b554-2fcf44b074b8",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "462d34c2-f059-49ef-92a0-69603d8f2eed",
                            EmailConfirmed = true,
                            LockoutEnabled = false,
                            NormalizedUserName = "KISBELA@GMAIL.COM",
                            PasswordHash = "AQAAAAEAACcQAAAAEN3Y5PJxbDjJUl+zYggtrRmuT3LxwWZDfpkgrfCuEMv5sgJmrPvbk7oVkOmxIX+vJA==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "4e0fa68f-a601-4e20-bd80-613ec5380d8a",
                            TwoFactorEnabled = false,
                            UserName = "kisbela@gmail.com",
                            FirstName = "Béla",
                            FoodUserName = "kisbela@gmail.com",
                            LastName = "Kiss"
                        },
                        new
                        {
                            Id = "6ec16e3b-9a5e-49cd-a243-c2468de5f853",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "1318a0c5-4ca2-4bbc-ba02-9c54ba51ab96",
                            EmailConfirmed = true,
                            LockoutEnabled = false,
                            NormalizedUserName = "JOZSEFJOZSIKA@GMAIL.COM",
                            PasswordHash = "AQAAAAEAACcQAAAAEGlmZkJkgxGqFEvQoB7IqQms5UlDcQCf1ObSipdFI1/g2TbiHl3AknvBIYwAme0JZA==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "facd9f9e-ef6c-4a42-b68d-12f2998d8f8a",
                            TwoFactorEnabled = false,
                            UserName = "jozsefjozsika@gmail.com",
                            FirstName = "József",
                            FoodUserName = "jozsefjozsika@gmail.com",
                            LastName = "Kelemen"
                        },
                        new
                        {
                            Id = "c80c45df-eb32-416d-acf4-95175e87daa2",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "32475cfc-6d12-401c-a4f0-8ead39c895d6",
                            EmailConfirmed = true,
                            LockoutEnabled = false,
                            NormalizedUserName = "FERKOBERKO@GMAIL.COM",
                            PasswordHash = "AQAAAAEAACcQAAAAEIWtLNtd3KMaG63JjPfKTdSV94DMqnuOdwbaJV2t9N2pCh+gdaOd8YJK+QgOlsOcpw==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "b7683179-f9df-4479-bac7-753ab8c0280e",
                            TwoFactorEnabled = false,
                            UserName = "ferkoberko@gmail.com",
                            FirstName = "Ferenc",
                            FoodUserName = "ferkoberko@gmail.com",
                            LastName = "Kovács"
                        });
                });

            modelBuilder.Entity("FoodForRequest.Models.Comment", b =>
                {
                    b.HasOne("FoodForRequest.Models.FoodUser", "User")
                        .WithMany("Comments")
                        .HasForeignKey("ContractorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FoodForRequest.Models.FoodRequest", "Request")
                        .WithMany("Comments")
                        .HasForeignKey("RequestId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Request");

                    b.Navigation("User");
                });

            modelBuilder.Entity("FoodForRequest.Models.FoodRequest", b =>
                {
                    b.HasOne("FoodForRequest.Models.FoodUser", "Requestor")
                        .WithMany("FoodRequests")
                        .HasForeignKey("RequestorId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Requestor");
                });

            modelBuilder.Entity("FoodForRequest.Models.Ingredient", b =>
                {
                    b.HasOne("FoodForRequest.Models.FoodRequest", "Requests")
                        .WithMany("Ingridients")
                        .HasForeignKey("FoodId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Requests");
                });

            modelBuilder.Entity("FoodForRequest.Models.Offer", b =>
                {
                    b.HasOne("FoodForRequest.Models.FoodUser", "User")
                        .WithMany("Offers")
                        .HasForeignKey("ContractorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FoodForRequest.Models.FoodRequest", "Request")
                        .WithMany("Offers")
                        .HasForeignKey("FoodId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Request");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("FoodForRequest.Models.FoodRequest", b =>
                {
                    b.Navigation("Comments");

                    b.Navigation("Ingridients");

                    b.Navigation("Offers");
                });

            modelBuilder.Entity("FoodForRequest.Models.FoodUser", b =>
                {
                    b.Navigation("Comments");

                    b.Navigation("FoodRequests");

                    b.Navigation("Offers");
                });
#pragma warning restore 612, 618
        }
    }
}
