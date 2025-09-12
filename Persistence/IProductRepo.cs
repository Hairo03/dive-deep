using dive_deep.Models;

namespace dive_deep.Persistence
{
    public interface IProductRepo
    {
        IEnumerable<Product> GetAllProducts();
        IEnumerable<Product> GetProductsByCategory(int id);
        Product GetProductById(int id);
        IEnumerable<Product> SearchProducts(string? searchTerm);
    }
}
