using Microsoft.EntityFrameworkCore;
using AddToCartApi.Models;

namespace AddToCartApi.Data
{
    public class AppDbContext : DbContext
    {
        public virtual DbSet<CheckoutModel>? Checkout_Details { get; set; }


        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CheckoutModel>()
                .HasKey(u => u.email);

        }
    }
}