using dive_deep.Models;
using System.Xml.Linq;

namespace dive_deep.Persistence
{
    public interface IBookingItemRepository
    {
        public void Add(BookingItem item);

        public void Delete(int id);


        public List<BookingItem> GetAll();


        public BookingItem? GetById(int id);

    }
}
