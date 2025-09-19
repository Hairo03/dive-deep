using dive_deep.Data;
using dive_deep.Models;
using Microsoft.EntityFrameworkCore;

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
            _context.Packages.Add(entity);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var package = GetById(id);
            if (package is null) return;
            _context.Packages.Remove(package);
            _context.SaveChanges();
        }

        public List<Package> GetAll()
        {
            return _context.Packages.AsNoTracking().Include(p => p.products).ToList();
        }

        public Package? GetById(int id)
        {
            return _context.Packages.AsNoTracking()
                .Include(p => p.products)
                .FirstOrDefault(p => p.Id == id);
        }

        public void Update(Package entity)
        {
            _context.Packages.Update(entity);
            _context.SaveChanges();
        }
    }
}
