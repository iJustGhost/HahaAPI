using HahaAPI.Entities;

namespace HahaAPI.Repositories
{
    public class ProductRepositories
    {
        public static List<Product> products = new List<Product>();

        public List<Product> GetAllProducts()
        {
            return products;
        }

        public void AddProduct(Product product)
        {
            products.Add(product);
        }

        public void DeleteProduct(int id)
        {
            var product = products.FirstOrDefault(p => p.id == id);
            if (products != null)
            {
                products.Remove(product);
            }
        }
    }
}
