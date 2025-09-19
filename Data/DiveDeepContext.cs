using dive_deep.Models;
using dive_deep.Persistence;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
namespace dive_deep.Data
{
    public class DiveDeepContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Package> Packages { get; set; }
        public DbSet<CartBooking> CartBookings { get; set; }

        public DiveDeepContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Product>().HasData(
                new Product
                {
                    Id = 1,
                    Brand = "Scubapro",
                    Name = "Navigator Lite BCD",
                    PricePerDay = 125,
                    Size = "M",
                    Thickness = "2mm",
                    Gender = "Unisex",
                    CategoryType = Category.BCD
                },
                new Product
                {
                    Id = 2,
                    Brand = "Scubapro",
                    Name = "BCD Glide",
                    PricePerDay = 100,
                    Size = "S",
                    Thickness = "4mm",
                    Gender = "Unisex",
                    CategoryType = Category.BCD
                },
                new Product
                {
                    Id = 3,
                    Brand = "Scubapro",
                    Name = "Definition",
                    PricePerDay = 100,
                    Size = "L",
                    Thickness = "5mm",
                    Gender = "Unisex",
                    CategoryType = Category.Våddragt
                },
                new Product
                {
                    Id = 4,
                    Brand = "Scubapro",
                    Name = "5 liter tank",
                    PricePerDay = 150,
                    Size = "M",
                    Thickness = "2mm",
                    Gender = "Unisex",
                    CategoryType = Category.Tank
                },
                new Product
                {
                    Id = 5,
                    Brand = "Subapro",
                    Name = "MK25EVO",
                    PricePerDay = 125,
                    Size = "M",
                    Thickness = "2mm",
                    Gender = "Unisex",
                    CategoryType = Category.Regulator
                },
                new Product
                {
                    Id = 6,
                    Brand = "Scubapro",
                    Name = "Ghost",
                    PricePerDay = 50,
                    Size = "M",
                    Thickness = "2mm",
                    Gender = "Unisex",
                    CategoryType = Category.Våddragt
                },
                new Product
                {
                    Id = 7,
                    Brand = "Seac",
                    Name = "ALA",
                    PricePerDay = 50,
                    Size = "M",
                    Thickness = "2mm",
                    Gender = "Unisex",
                    CategoryType = Category.Finn
                },
                new Product
                {
                    Id = 8,
                    Brand = "Cressi",
                    Name = "F1",
                    PricePerDay = 50,
                    Size = "M",
                    Thickness = "2mm",
                    Gender = "Unisex",
                    CategoryType = Category.Maske
                },
                new Product
                {
                    Id = 9,
                    Brand = "Cressi",
                    Name = "Snorkel",
                    PricePerDay = 25,
                    Size = "M",
                    Thickness = "2mm",
                    Gender = "Unisex",
                    CategoryType = Category.Snorkel
                }
            );

            modelBuilder.Entity<Package>().HasData(
                new Package { Id = 1, Name = "Komplet Dykkersæt", PricePerDay = 900 },
                new Package { Id = 2, Name = "Snorkelsæt", PricePerDay = 300 }
            );

            modelBuilder.Entity<BookingItem>()
                .HasOne(b => b.User)
                .WithMany(u => u.Bookings)
                .HasForeignKey(b => b.UserId);

            modelBuilder.Entity<Package>()
                .HasMany(p => p.products)
                .WithMany(p => p.packages)
                .UsingEntity<Dictionary<string, object>>(
                "PackageProduct",
            right => right
                .HasOne<Product>()
                .WithMany()
                .HasForeignKey("ProductId")
                .HasConstraintName("FK_PackageProduct_Product_ProductId"),
            left => left
                .HasOne<Package>()
                .WithMany()
                .HasForeignKey("PackageId")
                .HasConstraintName("FK_PackageProduct_Package_PackageId"),
            join =>
        {
            join.HasKey("PackageId", "ProductId");


            join.HasData(
                new { PackageId = 1, ProductId = 1 },
                new { PackageId = 1, ProductId = 2 },
                new { PackageId = 2, ProductId = 8 },
                new { PackageId = 2, ProductId = 9 }
            );
        });

            base.OnModelCreating(modelBuilder);
        }
    }
}
