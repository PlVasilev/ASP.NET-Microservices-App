using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Seller.Offers.Data.Models;
using Seller.Shared.Data;

namespace Seller.Offers.Data
{
    public class OffersDbContext : DbContext
    {
        public DbSet<Offer> Offers { get; set; }

        public OffersDbContext(DbContextOptions<OffersDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
        }
    }
}
