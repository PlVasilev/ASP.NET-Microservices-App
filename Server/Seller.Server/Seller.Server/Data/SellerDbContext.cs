namespace Seller.Server.Data
{
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;
    using Models;

    public class SellerDbContext : IdentityDbContext<User>
    {
        public DbSet<Listing> Listings { get; set; }
        public DbSet<Offer> Offers { get; set; }
        public DbSet<Deal> Deals { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<UserSS> UserSSes { get; set; }

        public SellerDbContext(DbContextOptions<SellerDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Listing>()
                .HasOne<Deal>(a => a.Deal)
                .WithOne(b => b.Listing)
                .HasForeignKey<Deal>(a => a.ListingId);

            builder.Entity<Deal>()
                .HasOne(u => u.Seller)
                .WithMany(s => s.SaleDeals)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Deal>()
                .HasOne(u => u.Buyer)
                .WithMany(s => s.BuyDeals)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Offer>()
                .HasOne(u => u.Listing)
                .WithMany(s => s.Offers)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<UserSS>()
                .HasOne(d => d.User)
                .WithOne(u => u.UserSS)
                .HasForeignKey<UserSS>(u => u.UserId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);

            base.OnModelCreating(builder);
        }
    }
}
