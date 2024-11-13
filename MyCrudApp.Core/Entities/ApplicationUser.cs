using Microsoft.AspNetCore.Identity;

namespace MyCrudApp.Core.Entities
{ 
    public class ApplicationUser : IdentityUser
    {
        public string? RefreshToken { get; set; }
        public string? ImageLink { get; set; }
        public DateTime RefreshTokenExpiryTime { get; set; }
    }
}
