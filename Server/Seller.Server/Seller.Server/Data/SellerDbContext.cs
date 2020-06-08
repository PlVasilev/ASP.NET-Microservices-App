namespace Seller.Server.Data
{
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;
    using Models;

    public class SellerDbContext : IdentityDbContext<User>
    {
        public SellerDbContext(DbContextOptions<SellerDbContext> options)
            : base(options)
        {
        }
    }
}
