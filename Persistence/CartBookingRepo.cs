using dive_deep.Data;
using dive_deep.Models;
using Microsoft.EntityFrameworkCore;

namespace dive_deep.Persistence
{
    public class CartBookingRepo : IRepository<CartBooking>
    {
        private DiveDeepContext _context { get; set; }
        public CartBookingRepo(DiveDeepContext context) {
            _context = context;
        }
        public void Add(CartBooking cartBooking)
        {
            _context.CartBookings.Add(cartBooking);
            _context.SaveChanges();
        }
        public void Delete(int id)
        {
            var cartBooking = GetById(id);
            if (cartBooking is null) return;
            _context.CartBookings.Remove(cartBooking);
            _context.SaveChanges();
        }

        public List<CartBooking> GetAll()
        {
            return _context.CartBookings.AsNoTracking().Include(b => b.BookingItems).ToList();
        }

        public CartBooking? GetById(int id)
        {
            return _context.CartBookings.AsNoTracking()
          .Include(b => b.BookingItems)
          .FirstOrDefault(b => b.Id == id);
        }

        public void Update(CartBooking cartBooking)
        {
            _context.CartBookings.Update(cartBooking);
            _context.SaveChanges();
        }
    }
}
