namespace dive_deep.Models
{
    public class CartBooking
    {
        public int Id { get; set; }



        public List<BookingItem> BookingItems { get; set; } = new List<BookingItem>();



        public string? UserId { get; set; }
        public ApplicationUser? User { get; set; }



    }
}
