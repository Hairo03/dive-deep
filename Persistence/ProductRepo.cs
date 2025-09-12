using dive_deep.Data;
using dive_deep.Models;
using Microsoft.EntityFrameworkCore;

namespace dive_deep.Persistence
{
    public class ProductRepo : IRepository<Product>
    {
        private readonly DiveDeepContext _context;
        public ProductRepo(DiveDeepContext context)
        {
            _context = context;
        }
        public void Add(Product entity)
        {
            _context.Add(entity);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var product = GetById(id);
            if (product is null) return;
            _context.Products.Remove(product);
            _context.SaveChanges();
        }

        public List<Product> GetAll()
        {
            return _context.Products.AsNoTracking().Include(p => p.packages).ToList();
        }

        public Product? GetById(int id)
        {
            return _context.Products.AsNoTracking()
                     .Include(p=>p.packages)
                     .FirstOrDefault(p => p.Id == id);
        }

        public void Update(Product entity)
        {
            _context.Products.Update(entity);
            _context.SaveChanges();
        }

        public List<Product> GetProductsByCategory(int id)
        {
            throw new NotImplementedException();
        }
        public List<Product> SearchProducts(string? searchTerm)
        {
            searchTerm = searchTerm.ToLower();

            List<Product> filteredProducts = _context.Products
                .Where(p =>
                    (!string.IsNullOrEmpty(p.Name) && p.Name.ToLower().Contains(searchTerm)) ||
                    (!string.IsNullOrEmpty(p.Brand) && p.Brand.ToLower().Contains(searchTerm)) ||
                    (!string.IsNullOrEmpty(p.Size) && p.Size.ToLower().Contains(searchTerm)) ||
                    (!string.IsNullOrEmpty(p.Thickness) && p.Thickness.ToLower().Contains(searchTerm)) ||
                    (!string.IsNullOrEmpty(p.Gender) && p.Gender.ToLower().Contains(searchTerm)) ||
                    p.CategoryType.ToString().ToLower().Contains(searchTerm)
                )
                .ToList();
            return filteredProducts;
        }
    }
}





