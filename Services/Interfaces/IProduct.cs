using Practical_11.Models;

namespace Practical_11.Services.Interfaces
{
    public interface IProduct
    {
        Product GetSingleProduct(int id);
        List<Product> GetProducts();
        int GetProductsCount();
        void AddOrUpdateProduct(int id, Product productData);
        void RemoveProduct(int id);
    }
}
