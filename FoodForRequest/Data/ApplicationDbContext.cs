using FoodForRequest.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;

namespace FoodForRequest.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<FoodRequest> Foodrequests { get; set; }
        public DbSet<Offer> Offers { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            // Connections
            builder.Entity<FoodRequest>().HasOne(p => p.Seller)
                .WithMany(u => u.FoodRequests)
                .HasForeignKey(p => p.SellerId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.Entity<Offer>().HasOne(p => p.Product)
                    .WithMany(u => u.Bids)
                    .HasForeignKey(p => p.ProductId)
                    .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<Offer>().HasOne(p => p.User)
                    .WithMany(u => u.Offers)
                    .HasForeignKey(p => p.UserId)
                    .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<IdentityRole>().HasData(new { Id = "1", Name = "Admin", NormalizedName = "ADMIN" });

            var hasher = new PasswordHasher<User>();

            var bela = new User()
            {
                UserName = "kisbela@gmail.com",
                NormalizedUserName = "KISBELA@GMAIL.COM",
                FirstName = "Béla",
                LastName = "Kiss",
                PasswordHash = hasher.HashPassword(null, "Pa$$w0rd")
            };

            var jozsi = new User()
            {
                UserName = "jozsefjozsika@gmail.com",
                NormalizedUserName = "JOZSEFJOZSIKA@GMAIL.COM",
                FirstName = "József",
                LastName = "Kelemen",
                PasswordHash = hasher.HashPassword(null, "password")
            };

            var ferko = new User()
            {
                UserName = "ferkoberko@gmail.com",
                NormalizedUserName = "FERKOBERKO@GMAIL.COM",
                FirstName = "Ferenc",
                LastName = "Kovács",
                PasswordHash = hasher.HashPassword(null, "password")
            };

            //Seeding the User to AspNetUsers table
            builder.Entity<User>().HasData(bela, jozsi, ferko);

            FoodRequest p = new FoodRequest()
            {
                Name = "My old phone",
                Description = "My old Samsung Galaxy S6 in good condition, barely touched",
                SellerId = bela.Id,
                Picture = this.LoadSeedPicture("Seed/oldphone.jpg"),
                PictureContentType = "Image/jpeg"
            };

            FoodRequest p2 = new FoodRequest()
            {
                Name = "Brand new bike",
                Description = "New mountain bike for sale, I accept trade for PlayStation 5.",
                SellerId = bela.Id,
                Picture = this.LoadSeedPicture("Seed/oldbike.jpg"),
                PictureContentType = "Image/jpeg"
            };

            FoodRequest p3 = new FoodRequest()
            {
                Name = "Toaster",
                Description = "Brand new toaster for sale, don't worry it's not on fire anymore. I threw it into the bathtub. Will trade for coffin.",
                SellerId = jozsi.Id,
                Picture = this.LoadSeedPicture("Seed/oldtoaster.jpg"),
                PictureContentType = "Image/jpeg"
            };

            FoodRequest p4 = new FoodRequest()
            {
                Name = "Laptop",
                Description = "I'm replacing my old laptop, works perfectly, comes with cracked windows.",
                SellerId = jozsi.Id,
                Picture = this.LoadSeedPicture("Seed/oldlaptop.jpg"),
                PictureContentType = "Image/png"
            };

            FoodRequest p5 = new FoodRequest()
            {
                Name = "Vintage Mirror",
                Description = "Mirror for sale. Dog NOT included, STOP ASKING!",
                SellerId = jozsi.Id,
                Picture = this.LoadSeedPicture("Seed/mirrorforsale.jpg"),
                PictureContentType = "Image/jpeg"
            };

            builder.Entity<FoodRequest>().HasData(p, p2, p3, p4, p5);

            Offer b1 = new Offer()
            {
                Value = 1900,
                ProductId = p3.Id,
                UserId = bela.Id
            };

            Offer b2 = new Offer()
            {
                Value = 2500,
                ProductId = p3.Id,
                UserId = ferko.Id
            };

            Offer b3 = new Offer()
            {
                Value = 5910,
                ProductId = p4.Id,
                UserId = ferko.Id
            };

            builder.Entity<Offer>().HasData(b1, b2, b3);

            base.OnModelCreating(builder);
        }

        private byte[] LoadSeedPicture(string path)
        {
            return File.ReadAllBytes(path);
        }
    }
}