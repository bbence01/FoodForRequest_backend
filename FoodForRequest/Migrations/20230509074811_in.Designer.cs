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
    [Migration("20230509074811_in")]
    partial class @in
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

                    b.Property<string>("ProductId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ContractorId");

                    b.HasIndex("ProductId");

                    b.ToTable("Comments");

                    b.HasData(
                        new
                        {
                            Id = "cbe49fcb-7565-45e1-b90b-b0366b491e67",
                            ContractorId = "1ae07ef3-0a12-43b4-98a2-313b4b43801f",
                            ProductId = "3",
                            Text = "Hi"
                        },
                        new
                        {
                            Id = "becce080-6fe2-4e30-bd9e-adf11d899376",
                            ContractorId = "1ae07ef3-0a12-43b4-98a2-313b4b43801f",
                            ProductId = "4",
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
                            Id = "ac50a43b-71ac-4ac0-878b-8d69a2f2c0c7",
                            Description = "Nyers hal",
                            IsDone = false,
                            Name = "Susi",
                            PictureContentType = "Image/jpeg",
                            RequestorId = "c596566e-0c34-4065-a8f6-3284a80979d1"
                        },
                        new
                        {
                            Id = "0d4fa37b-ad82-437f-9fad-e275fa3ac850",
                            Description = "Sülthus",
                            IsDone = false,
                            Name = "Stake",
                            PictureContentType = "Image/jpeg",
                            RequestorId = "c596566e-0c34-4065-a8f6-3284a80979d1"
                        },
                        new
                        {
                            Id = "3",
                            Description = "Tosted.",
                            IsDone = false,
                            Name = "Toast",
                            PictureContentType = "Image/jpeg",
                            RequestorId = "6b522d5a-5622-4f00-9ba0-371834a33b73"
                        },
                        new
                        {
                            Id = "4",
                            Description = "All the chocklate",
                            IsDone = false,
                            Name = "Chocklate ckae",
                            PictureContentType = "Image/png",
                            RequestorId = "6b522d5a-5622-4f00-9ba0-371834a33b73"
                        },
                        new
                        {
                            Id = "5",
                            Description = "I want to see myself eating",
                            IsDone = false,
                            Name = "Mirror ckae",
                            PictureContentType = "Image/jpeg",
                            RequestorId = "6b522d5a-5622-4f00-9ba0-371834a33b73"
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
                            Id = "31db8461-aa89-44cf-9278-1a5d9aa0df56",
                            Choosen = false,
                            ContractorId = "c596566e-0c34-4065-a8f6-3284a80979d1",
                            ProductId = "3"
                        },
                        new
                        {
                            Id = "6cc3b63d-a154-442c-9984-bd3721e250c5",
                            Choosen = false,
                            ContractorId = "1ae07ef3-0a12-43b4-98a2-313b4b43801f",
                            ProductId = "3"
                        },
                        new
                        {
                            Id = "e2993cd0-9d5c-43a0-bf82-b8356ba94b1a",
                            Choosen = false,
                            ContractorId = "1ae07ef3-0a12-43b4-98a2-313b4b43801f",
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
                            Id = "c596566e-0c34-4065-a8f6-3284a80979d1",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "96fb9efa-935f-47e2-a0a0-c4f90d49a871",
                            EmailConfirmed = true,
                            LockoutEnabled = false,
                            NormalizedUserName = "KISBELA@GMAIL.COM",
                            PasswordHash = "AQAAAAEAACcQAAAAEGOyA6FccOgMY/sRE2/lROx5fb37jKUg+Evkwk88XXAm4Knt3ll4MBzuQpKMBFZ9vA==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "946b77a8-d044-47d2-ae99-62000981d041",
                            TwoFactorEnabled = false,
                            UserName = "kisbela@gmail.com",
                            FirstName = "Béla",
                            LastName = "Kiss"
                        },
                        new
                        {
                            Id = "6b522d5a-5622-4f00-9ba0-371834a33b73",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "2951da1f-e7e7-4e1b-8d85-994a57ad0e27",
                            EmailConfirmed = true,
                            LockoutEnabled = false,
                            NormalizedUserName = "JOZSEFJOZSIKA@GMAIL.COM",
                            PasswordHash = "AQAAAAEAACcQAAAAEHrrMH1F2FhXyXFcYChaSGOqtYOWNZG3KAR6lfYk9k3DOCbAWhRnXH1kEn3VxxHNrw==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "beafe1c2-38dc-4d3d-96ec-63df96f4feb7",
                            TwoFactorEnabled = false,
                            UserName = "jozsefjozsika@gmail.com",
                            FirstName = "József",
                            LastName = "Kelemen"
                        },
                        new
                        {
                            Id = "1ae07ef3-0a12-43b4-98a2-313b4b43801f",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "35c16322-cf90-4d9a-85ae-d0029684b3c2",
                            EmailConfirmed = true,
                            LockoutEnabled = false,
                            NormalizedUserName = "FERKOBERKO@GMAIL.COM",
                            PasswordHash = "AQAAAAEAACcQAAAAEG67eb+k+2WA1tr8tLUWYJ/sadCGsQcDMm4WtEoQ2E11Li8h1Iksfd7hVS4+r786MQ==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "7811dae7-7eb5-4fdd-a80f-01c2c4574044",
                            TwoFactorEnabled = false,
                            UserName = "ferkoberko@gmail.com",
                            FirstName = "Ferenc",
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

                    b.HasOne("FoodForRequest.Models.FoodRequest", "Product")
                        .WithMany("Comments")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");

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
                    b.Navigation("Comments");

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