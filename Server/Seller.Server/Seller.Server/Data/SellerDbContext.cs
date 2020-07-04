﻿namespace Seller.Server.Data
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
        public DbSet<UserSeller> UserSellers { get; set; }

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

            builder.Entity<UserSeller>()
                .HasOne(d => d.User)
                .WithOne(u => u.UserSeller)
                .HasForeignKey<UserSeller>(u => u.UserId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);

            base.OnModelCreating(builder);
        }
    }
}
