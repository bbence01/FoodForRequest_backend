using FoodForRequest.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Numerics;
using System.Reflection.Emit;

namespace FoodForRequest.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public DbSet<FoodUser> Users { get; set; }
        public DbSet<FoodRequest> Foodrequests { get; set; }
        public DbSet<Offer> Offers { get; set; }

        public DbSet<Comment> Comments { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            // Connections
            builder.Entity<FoodRequest>().HasOne(p => p.Requestor)
                .WithMany(u => u.FoodRequests)
                .HasForeignKey(p => p.RequestorId)
                .OnDelete(DeleteBehavior.NoAction);


            builder.Entity<Offer>().HasOne(p => p.Product)
                    .WithMany(u => u.Offers)
                    .HasForeignKey(p => p.ProductId)
                    .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<Offer>().HasOne(p => p.User)
                    .WithMany(u => u.Offers)
                    .HasForeignKey(p => p.ContractorId)
                    .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<Comment>().HasOne(p => p.Product)
                  .WithMany(u => u.Comments)
                  .HasForeignKey(p => p.ProductId)
                  .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<Comment>().HasOne(p => p.User)
                   .WithMany(u => u.Comments)
                   .HasForeignKey(p => p.ContractorId)
                   .OnDelete(DeleteBehavior.Cascade);


            builder.Entity<IdentityRole>().HasData(
                 new { Id = "1", Name = "Admin", NormalizedName = "ADMIN" },
                 new { Id = "2", Name = "User", NormalizedName = "USER" }
            );

            PasswordHasher<FoodUser> ph = new PasswordHasher<FoodUser>();
            FoodUser seed = new FoodUser
            {
                Id = Guid.NewGuid().ToString(),
                Email = "seedplayer@gmail.com",
                EmailConfirmed = true,
                UserName = "seedplayer@gmail.com",                
                FoodUserName = "SeedPlayer",
                NormalizedUserName = "SEEDPLAYER@gmail.com"
            };
            seed.PasswordHash = ph.HashPassword(seed, "almafa123");
            var hasher = new PasswordHasher<FoodUser>();

            var bela = new FoodUser()
            {
                Id = Guid.NewGuid().ToString(),
                EmailConfirmed = true,
                UserName = "kisbela@gmail.com",
                NormalizedUserName = "KISBELA@GMAIL.COM",
                FoodUserName = "kisbela@gmail.com",
                FirstName = "Béla",
                LastName = "Kiss",
                PasswordHash = hasher.HashPassword(null, "Pa$$w0rd")
            };

            var jozsi = new FoodUser()
            {
                Id = Guid.NewGuid().ToString(),
                UserName = "jozsefjozsika@gmail.com",
                EmailConfirmed = true,
                NormalizedUserName = "JOZSEFJOZSIKA@GMAIL.COM",
                FoodUserName = "jozsefjozsika@gmail.com",
                FirstName = "József",
                LastName = "Kelemen",
                PasswordHash = hasher.HashPassword(null, "password")
            };

            var ferko = new FoodUser()
            {

                Id = Guid.NewGuid().ToString(),
                UserName = "ferkoberko@gmail.com",
                EmailConfirmed = true,
                NormalizedUserName = "FERKOBERKO@GMAIL.COM",
                FoodUserName = "ferkoberko@gmail.com",

                FirstName = "Ferenc",
                LastName = "Kovács",
                PasswordHash = hasher.HashPassword(null, "password")
            };

            //Seeding the FoodUser to AspNetUsers table
            builder.Entity<FoodUser>().HasData(bela, jozsi, ferko);

            FoodRequest p = new FoodRequest()
            {
                Id = Guid.NewGuid().ToString(),
                Name = "Susi",
                Description = "Nyers hal",
                RequestorId = bela.Id,
                Picture = this.LoadSeedPicture("Seed/oldphone.jpg"),
                PictureContentType = "Image/jpeg"
            };

            FoodRequest p2 = new FoodRequest()
            {
                Id = Guid.NewGuid().ToString(),

                Name = "Stake",
                Description = "Sülthus",
                RequestorId = bela.Id,
                Picture = this.LoadSeedPicture("Seed/oldbike.jpg"),
                PictureContentType = "Image/jpeg"
            };

            FoodRequest p3 = new FoodRequest()
            {Id = "3",

                Name = "Toast",
                Description = "Tosted.",
                RequestorId = jozsi.Id,
                Picture = this.LoadSeedPicture("Seed/oldtoaster.jpg"),
                PictureContentType = "Image/jpeg"
            };

            FoodRequest p4 = new FoodRequest()
            {Id = "4",

                Name = "Chocklate ckae",
                Description = "All the chocklate",
                RequestorId = jozsi.Id,
                Picture = this.LoadSeedPicture("Seed/oldlaptop.jpg"),
                PictureContentType = "Image/png"
            };

            FoodRequest p5 = new FoodRequest()
            {Id = "5",

                Name = "Mirror ckae",
                Description = "I want to see myself eating",
                RequestorId = jozsi.Id,
                Picture = this.LoadSeedPicture("Seed/mirrorforsale.jpg"),
                PictureContentType = "Image/jpeg"
            };

            builder.Entity<FoodRequest>().HasData(p, p2, p3, p4, p5);

            Offer b1 = new Offer()
            {
                
                ProductId = p3.Id,
                ContractorId = bela.Id
            };

            Offer b2 = new Offer()
            {
                
                ProductId = p3.Id,
                ContractorId = ferko.Id
            };

            Offer b3 = new Offer()
            {

                ProductId = p4.Id,
                ContractorId = ferko.Id
            };



            Comment c1 = new Comment()
            {
                Text="Hi",
                ProductId = p3.Id,
                ContractorId = ferko.Id
            };

            Comment c2 = new Comment()
            {
                Text = "Hello",
                ProductId = p4.Id,
                ContractorId = ferko.Id
            };


            builder.Entity<Offer>().HasData(b1, b2, b3);



            builder.Entity<Comment>().HasData(c1, c2);

            base.OnModelCreating(builder);
        }

        private byte[] LoadSeedPicture(string path)
        {
            return File.ReadAllBytes(path);
        }
    }
}