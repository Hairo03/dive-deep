namespace dive_deep.Models
{
    public class CartBooking
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public List<BookingItem>? BookingItems { get; set; } = new List<BookingItem>();
        
    }
}
