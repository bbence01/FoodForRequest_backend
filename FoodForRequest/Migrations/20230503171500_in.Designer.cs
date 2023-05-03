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
    [Migration("20230503171500_in")]
    partial class @in
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.16")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

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
                            Id = "539e0f73-4441-40df-9245-4ceac92446b4",
                            Description = "My old Samsung Galaxy S6 in good condition, barely touched",
                            IsDone = false,
                            Name = "My old phone",
                            PictureContentType = "Image/jpeg",
                            RequestorId = "04c25340-74dd-424f-b919-d3cbf2e1c130"
                        },
                        new
                        {
                            Id = "0b903017-4cc1-4d97-87cf-ce90ce91eba6",
                            Description = "New mountain bike for sale, I accept trade for PlayStation 5.",
                            IsDone = false,
                            Name = "Brand new bike",
                            PictureContentType = "Image/jpeg",
                            RequestorId = "04c25340-74dd-424f-b919-d3cbf2e1c130"
                        },
                        new
                        {
                            Id = "3",
                            Description = "Brand new toaster for sale, don't worry it's not on fire anymore. I threw it into the bathtub. Will trade for coffin.",
                            IsDone = false,
                            Name = "Toaster",
                            PictureContentType = "Image/jpeg",
                            RequestorId = "b1010805-86b0-4496-8860-83587efd90ac"
                        },
                        new
                        {
                            Id = "4",
                            Description = "I'm replacing my old laptop, works perfectly, comes with cracked windows.",
                            IsDone = false,
                            Name = "Laptop",
                            PictureContentType = "Image/png",
                            RequestorId = "b1010805-86b0-4496-8860-83587efd90ac"
                        },
                        new
                        {
                            Id = "5",
                            Description = "Mirror for sale. Dog NOT included, STOP ASKING!",
                            IsDone = false,
                            Name = "Vintage Mirror",
                            PictureContentType = "Image/jpeg",
                            RequestorId = "b1010805-86b0-4496-8860-83587efd90ac"
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

                    b.Property<string>("ProductId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("ContractorId");

                    b.HasIndex("ProductId");

                    b.ToTable("Offers");

                    b.HasData(
                        new
                        {
                            Id = "1216b567-09e9-4c68-a3b6-14dec86ff5fe",
                            Choosen = false,
                            ContractorId = "04c25340-74dd-424f-b919-d3cbf2e1c130",
                            ProductId = "3"
                        },
                        new
                        {
                            Id = "b1478c26-6ef7-4894-b6a8-cf08747f0638",
                            Choosen = false,
                            ContractorId = "5c232873-a758-4fc0-8cd5-bb55b500ac41",
                            ProductId = "3"
                        },
                        new
                        {
                            Id = "0aa928ec-c378-49ce-9b8b-4938a9faca09",
                            Choosen = false,
                            ContractorId = "5c232873-a758-4fc0-8cd5-bb55b500ac41",
                            ProductId = "4"
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
                            Name = "Player",
                            NormalizedName = "PLAYER"
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

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasDiscriminator().HasValue("FoodUser");

                    b.HasData(
                        new
                        {
                            Id = "04c25340-74dd-424f-b919-d3cbf2e1c130",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "c9a73b03-b0d3-4115-8101-a48d809d2408",
                            EmailConfirmed = false,
                            LockoutEnabled = false,
                            NormalizedUserName = "KISBELA@GMAIL.COM",
                            PasswordHash = "AQAAAAEAACcQAAAAEF36ssg/EUGyjDaDrgZjqUDbdXGSpWHxzghiithAS5BO0HcjzJ/yi3UIQjvqm4Z3HQ==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "9cd46cf9-334b-4ef4-bbf4-90be5d16abe3",
                            TwoFactorEnabled = false,
                            UserName = "kisbela@gmail.com",
                            FirstName = "Béla",
                            LastName = "Kiss"
                        },
                        new
                        {
                            Id = "b1010805-86b0-4496-8860-83587efd90ac",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "8361a4cc-62ae-40f3-b6b4-b06c2d71f253",
                            EmailConfirmed = false,
                            LockoutEnabled = false,
                            NormalizedUserName = "JOZSEFJOZSIKA@GMAIL.COM",
                            PasswordHash = "AQAAAAEAACcQAAAAEI6nTj6IsMQ5CWWvzYyUelfrdRgIjrv2HQLUR1aeSDbX/7Vm/Tzju7p1F+QKzqagGg==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "c125ac6b-0129-4587-80be-d412439783fb",
                            TwoFactorEnabled = false,
                            UserName = "jozsefjozsika@gmail.com",
                            FirstName = "József",
                            LastName = "Kelemen"
                        },
                        new
                        {
                            Id = "5c232873-a758-4fc0-8cd5-bb55b500ac41",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "a6a368cd-d2aa-4ca5-82ad-c573105596ce",
                            EmailConfirmed = false,
                            LockoutEnabled = false,
                            NormalizedUserName = "FERKOBERKO@GMAIL.COM",
                            PasswordHash = "AQAAAAEAACcQAAAAEBooc4FLEwB4U4v4xN2mR5OvtZiiOIYwsjfN/c10aqcwjYLRqRk4jxYUtbWMIvS5BA==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "9e4b63ce-aefb-446c-9231-5aff16b6b8bf",
                            TwoFactorEnabled = false,
                            UserName = "ferkoberko@gmail.com",
                            FirstName = "Ferenc",
                            LastName = "Kovács"
                        });
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

            modelBuilder.Entity("FoodForRequest.Models.Offer", b =>
                {
                    b.HasOne("FoodForRequest.Models.FoodUser", "User")
                        .WithMany("Offers")
                        .HasForeignKey("ContractorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FoodForRequest.Models.FoodRequest", "Product")
                        .WithMany("Offers")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");

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
                    b.Navigation("Offers");
                });

            modelBuilder.Entity("FoodForRequest.Models.FoodUser", b =>
                {
                    b.Navigation("FoodRequests");

                    b.Navigation("Offers");
                });
#pragma warning restore 612, 618
        }
    }
}
