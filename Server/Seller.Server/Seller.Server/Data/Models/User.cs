

using Microsoft.AspNetCore.Identity;

namespace Seller.Server.Data.Models
{
    public class User : IdentityUser
    {
        public UserSeller UserSeller { get; set; }
    }
}
