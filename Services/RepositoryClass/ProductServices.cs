using Practical_11.Data;
using Practical_11.Models;
using Practical_11.Services.Interfaces;

namespace Practical_11.Services.RepositoryClass
{
    public class ProductServices : IProduct
    {
        public void AddOrUpdateProduct(int id, Product productData)
        {
            var data = GetSingleProduct(id);
            if (data != null)
            {
                data.Name = productData.Name;
                data.Description = productData.Description;
                data.Price = productData.Price;
                data.PurchaseDate = productData.PurchaseDate;
            }
            else
                GetProduct.Products.Add(productData);
        }

        public List<Product> GetProducts()
        {
            var data = GetProduct.Products;
            return data;
        }

        public int GetProductsCount()
        {
            int count = GetProduct.Products.Count;
            return count;
        }

        public Product GetSingleProduct(int id)
        {
            var data = GetProduct.Products.Find(x => x.Id == id);
            return data;
        }

        public void RemoveProduct(int id)
        {
            var data = GetSingleProduct(id);
            GetProduct.Products.Remove(data);
        }
    }
}
