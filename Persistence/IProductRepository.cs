using dive_deep.Models;

namespace dive_deep.Persistence
{
    public interface IProductRepository : IRepository<Product>
    {
        List<Product> SearchProducts(string? searchTerm);
        List<Product> GetProductsByCategory(int id);

    }
}
