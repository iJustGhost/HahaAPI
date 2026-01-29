using HahaAPI.Entities;
using HahaAPI.Repositories;

namespace HahaAPI.Services
{
    public class ProductServices
    {
        public ProductRepositories _productRepositories = new ProductRepositories();

        public List<Product> GetAllProducts()
        {
            return _productRepositories.GetAllProducts();
        }
        public void AddProduct(Product product)
        {
            _productRepositories.AddProduct(product);

            Console.WriteLine($"ID:     {product.id}");
            Console.WriteLine($"Name:   {product.name}");
            Console.WriteLine($"Price:  {product.price}");
        }
        public void DeleteProduct(int id)
        {
            _productRepositories.DeleteProduct(id);
            Console.WriteLine("Product Deleted");
        }
    }
}
