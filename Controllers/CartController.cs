using dive_deep.Models;
using dive_deep.Persistence;
using Microsoft.AspNetCore.Mvc;

namespace dive_deep.Controllers
{
	public class CartController : Controller
	{
		private readonly IBookingItemRepository _bookingItemRepository;
		List<BookingItem> Items { get; set; }

		public CartController(IBookingItemRepository bookingItemRepository)
		{
			_bookingItemRepository = bookingItemRepository;
		}
		public IActionResult Index()
		{
			Items = _bookingItemRepository.GetAll();
			return View(Items);
		}
	}
}
