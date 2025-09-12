using dive_deep.Models;
using dive_deep.Persistence;
using Microsoft.AspNetCore.Mvc;

namespace dive_deep.Controllers
{
    public class BookingController : Controller
    {
        private readonly IProductRepo productRepo;
        public BookingController(IProductRepo productRepo)
        {
            this.productRepo = productRepo;
        }
        public IActionResult Index(int? id)
        {
            Booking booking = new Booking() { Product = productRepo.GetProductById(id.HasValue ? id.Value : 0) };
            return View(booking);
        }

        [HttpPost] // Metoden der bliver kaldt når vi trykker submit ved formen i booking vinduet.
        public IActionResult Index(Booking booking)
        {
      
           return View(booking); //Temp for nu. Mangler yderligere logik.
        }
    }
}
