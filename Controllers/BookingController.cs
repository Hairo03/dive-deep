using dive_deep.Models;
using dive_deep.Persistence;
using Microsoft.AspNetCore.Mvc;

namespace dive_deep.Controllers
{
    public class BookingController : Controller
    {
        private readonly IRepository<Product> _productRepository;
        private readonly IRepository<Package> _packageRepository;

        public BookingController(IRepository<Product> productRepository, IRepository<Package> packageRepository)
        {
            _productRepository = productRepository;
            _packageRepository = packageRepository;

        }
        public IActionResult Index(int? id)
        {
            Booking booking = new Booking() { Product = _productRepository.GetById(id.HasValue ? id.Value : 0) };
            return View(booking);
        }

        [HttpPost] // Metoden der bliver kaldt når vi trykker submit ved formen i booking vinduet.
        public IActionResult Index(Booking booking)
        {
      
           return View(booking); //Temp for nu. Mangler yderligere logik.
        }
    }
}
