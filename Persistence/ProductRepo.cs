using dive_deep.Models;

namespace dive_deep.Persistence
{
    public static class ProductRepo
    {
        private static List<Product> products = new List<Product>()
        {
            new Product
            {
                Brand = "Scubapro",
                Name = "Navigator Lite BCD",
                PricePerDay = 125,
                CategoryType = Category.BCD
            },
            new Product
            {
                Brand = "Scubapro",
                Name = "BCD Glide",
                PricePerDay = 100,
                CategoryType = Category.BCD
            },
            new Product
            {
                Brand = "Scubapro",
                Name = " Definition",
                PricePerDay = 100,
                CategoryType = Category.Wetsuit
            },
            new Product
            {
                Brand = "Scubapro",
                Name = "5 liter tank",
                PricePerDay = 150,
                CategoryType = Category.Tank
            },
            new Product
            {
                Brand = "Subapro",
                Name = "MK25EVO",
                PricePerDay = 125,
                CategoryType = Category.Regulator
            },
            new Product
            {
                Brand = "Scubapro",
                Name = "Ghost",
                PricePerDay = 50,
                CategoryType = Category.Wetsuit
            },
            new Product
            {
                Brand = "Seac",
                Name = "ALA",
                PricePerDay = 50,
                CategoryType = Category.Fins
            }

           

        };
        public static IEnumerable<Product> GetAllProducts()
        {
            return products;
        }

        public static IEnumerable<Product> GetProductsByCategory(int id)
        {
            return products.Where(p => p.CategoryType == (Category)id);
        }

        public static Product GetProductById(int id)
        {
            Product product;
            foreach(Product p in products)
            {
                if(p.Id == id)
                {
                    product = p;
                    return product;
                }
            }
            return null;
        }
    }
}





