namespace MarketApi.Models
{
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Linq;

    public class MarketContext : DbContext
    {
        public MarketContext(DbContextOptions<MarketContext> options) : base(options)
        {

        }

        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().ToTable("Product");
        }

        public void EnsureSeedData()
        {
            if(!this.Products.Any())
            {
                this.Products.Add(new Product
                {
                    Name = "Mercado",
                    IsBasic = true,
                    PeriodDuration = 1,
                    QuantityInStock = 1,
                    BuyDate = DateTime.Now,
                    UnitPrice = 250000,
                    UpdatedAt = DateTime.Now
                });

                this.SaveChanges();
            }
        }
    }
}
