namespace dive_deep.Models
{
    public class Booking
    {
        public int Id { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public double PricePerDay { get; set; }
        public Package? Package { get; set; }
        public Product? Product { get; set; }
    }
}
