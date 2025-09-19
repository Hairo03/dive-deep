using dive_deep.Models;

namespace dive_deep.Persistence
{
    public class InMemoryBookingItemRepo : IBookingItemRepository
    {
        public static readonly List<BookingItem> bookingItems = new List<BookingItem>();
        public void Add(BookingItem item)
        {
            bookingItems.Add(item);
        }

        public void Delete(int id)
        {
            var item = GetById(id);

            bookingItems.Remove(item);

        }

        public List<BookingItem> GetAll()
        {
            return bookingItems;
        }

        public BookingItem? GetById(int id)
        {
            return bookingItems.Where(b => b.Id == id).FirstOrDefault();
        }
    }
}
