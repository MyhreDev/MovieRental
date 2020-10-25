using Microsoft.AspNetCore.Identity;

namespace MovieRental.Data
{
    public class ApplicationUser : IdentityUser
    {
        public string AuctionKey { get; set; }
        public string AuctionRefreshToken { get; set; }
    }
}
