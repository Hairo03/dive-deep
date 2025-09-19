using dive_deep.Models;
using dive_deep.Persistence;
using Microsoft.AspNetCore.Mvc;

namespace dive_deep.Controllers
{
    public class BookingController : Controller
    {
        private readonly IProductRepository _productRepository;
        private readonly IRepository<Package> _packageRepository;
        private readonly IBookingItemRepository _bookingItemRepository;

        public BookingController(IProductRepository productRepository, IRepository<Package> packageRepository, IBookingItemRepository bookingItemRepository)
        {
            _productRepository = productRepository;
            _packageRepository = packageRepository;
            _bookingItemRepository = bookingItemRepository;
        }
        public IActionResult Index(int? id)
        {
            BookingItem bookingItem = new BookingItem() { Product = _productRepository.GetById(id.HasValue ? id.Value : 0) };
            return View(bookingItem);
        }

        [HttpPost] // Metoden der bliver kaldt når vi trykker submit ved formen i booking vinduet.
        public IActionResult Index(BookingItem bookingItem)
        {
            if (bookingItem.ProductId.HasValue)
            {
                bookingItem.Product = _productRepository.GetById(bookingItem.ProductId.Value);
                bookingItem.Name = bookingItem.Product.Name;
                bookingItem.TotalPrice = bookingItem.CalculateTotalPrice();
            }

            _bookingItemRepository.Add(bookingItem);
            return RedirectToAction("Index", "Products");
        }
    }
}
