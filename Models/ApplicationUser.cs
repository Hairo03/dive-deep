using Microsoft.AspNetCore.Identity;

namespace dive_deep.Models
{
    public class ApplicationUser : IdentityUser
    {
        public List<Booking>? Bookings { get; set; } = new List<Booking>();
    }
}
