using Practical_11.Models;

namespace Practical_11.Data
{
    public class GetProduct
    {
        public static List<Product> Products = new List<Product>();
        static GetProduct()
        {
            Products.Add(new Product()
            {
                Id = 1,
                Name = "Test",
                Description = "Test",
                Price = 1000,
                PurchaseDate = Convert.ToDateTime("03/03/2003")
            });
            Products.Add(new Product()
            {
                Id = 2,
                Name = "Test2",
                Description = "Test2",
                Price = 2000,
                PurchaseDate = Convert.ToDateTime("03/03/2003")
            });
            Products.Add(new Product()
            {
                Id = 3,
                Name = "Test3",
                Price = 3000,
                Description = "Test3",
                PurchaseDate = Convert.ToDateTime("03/03/2003")
            });
        }
    }
}
