using System.Security.Cryptography;

namespace dive_deep.Models
{
    public enum Category
    {
        BCD,
        Regulator,
        Våddragt,
        Finn,
        Maske,
        Snorkel,
		Tank,
		DykkerComputer,
        Tilbehør,
        
    }
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double PricePerDay { get; set; }
        public string Brand { get; set; }
        public string Size { get; set; }
        public string Thickness { get; set; }
        public string Gender { get; set; }
        public Category CategoryType { get; set; }

        public ICollection<Package> packages { get; set; } = new List<Package>();

    }
}
