using dive_deep.Models;
using dive_deep.Persistence;
using Microsoft.AspNetCore.Mvc;

namespace dive_deep.Controllers
{
    public class BookingController : Controller
    {
        public IActionResult Index(int? id)
        {
            Booking booking = new Booking() { Product = ProductRepo.GetProductById(id.HasValue ? id.Value : 0) };
            return View(booking);
        }
    }
}
