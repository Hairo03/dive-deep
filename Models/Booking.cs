using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace dive_deep.Models
{
    public class Booking
    {
        public Booking()
        {
            StartDate = DateTime.Now;
        }

        public int Id { get; set; }

        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public double PricePerDay { get; set; }
        public Package Package { get; set; }
        public Product? Product { get; set; }

        [Required]
        public string UserId { get; set; }

        [ValidateNever]
        [BindNever]
        public ApplicationUser User { get; set; } = null!;
    }
}
