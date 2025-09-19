using System.ComponentModel.DataAnnotations;

namespace dive_deep.Models
{
    public class BookingItem
    {
        
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public double PricePerDay { get; set; }
        public double TotalPrice { get; set; }
        public int? ProductId { get; set; }
        public int? PackageId { get; set; }
        public Package Package { get; set; }
        public Product? Product { get; set; }

        public BookingItem()
        {
            StartDate = DateTime.Now;
        }

        public double CalculateTotalPrice()
        {
            if (EndDate < StartDate)
                EndDate = StartDate;


            var days = (EndDate.Date - StartDate.Date).Days;

            if (days == 0) TotalPrice = Product.PricePerDay;
            else TotalPrice = days * Product.PricePerDay;


            return TotalPrice;
        }

    }
}
