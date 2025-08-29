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


            },

            new Product
            {
                Brand = "Scubapro",
                Name = "BCD Glide",
                PricePerDay = 100,
            },
            new Product
            {
                Brand = "Scubapro",
                Name = " Definition",
                PricePerDay = 100,
            },
            new Product
            {
                Brand = "Scubapro",
                Name = "5 liter tank",
                PricePerDay = 150,
            },
            new Product
            {
                Brand = "Subapro",
                Name = "MK25EVO",
                PricePerDay = 125,
            },
            new Product
            {
                Brand = "Scubapro",
                Name = "Ghost",
                PricePerDay = 50,
            },
            new Product
            {
                Brand = "Seac",
                Name = "ALA",
                PricePerDay = 50
            }
        };
        public static List<Product> GetAllProducts()
        {
            return products;
        }
    }
}





