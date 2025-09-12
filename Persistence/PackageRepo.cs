using dive_deep.Data;
using dive_deep.Models;

namespace dive_deep.Persistence
{
    public class PackageRepo : IRepository<Package>
    {
        private readonly DiveDeepContext _context;
        public PackageRepo(DiveDeepContext context)
        {
            _context = context;
        }
        public void Add(Package entity)
        {
            
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<Package> GetAll()
        {
            throw new NotImplementedException();
        }

        public Package? GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Package entity)
        {
            throw new NotImplementedException();
        }

        public List<Package> GetProductsByCategory(int id)
        {
            throw new NotImplementedException();
        }

        public List<Package> SearchProducts(string? searchTerm)
        {
            throw new NotImplementedException();
        }
    }
}
