using Microsoft.AspNetCore.Identity;

namespace dive_deep.Models
{
    public class ApplicationUser : IdentityUser
    {
        public List<BookingItem>? Bookings { get; set; } = new List<BookingItem>();
    }
}
