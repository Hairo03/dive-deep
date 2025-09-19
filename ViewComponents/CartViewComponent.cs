using Microsoft.AspNetCore.Mvc;
using dive_deep.Persistence;

namespace dive_deep.ViewComponents
{
    public class CartViewComponent : ViewComponent
    {
        private readonly IBookingItemRepository _bookingItemRepo;

        public CartViewComponent(IBookingItemRepository bookingItemRepo)
        {
            _bookingItemRepo = bookingItemRepo;
        }

        public IViewComponentResult Invoke()
        {
            var items = _bookingItemRepo.GetAll();
            return View(items);
        }
    }
}
