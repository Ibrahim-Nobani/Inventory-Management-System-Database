using Models;
namespace RepositoryServices
{
    public interface IRepository
    {
        void AddProduct(Product product);
        List<Product> GetAllProducts();
        bool EditProduct(Product product);
        bool DeleteProduct(string productId);
        Product GetProductById(string productId);
        Product GetProductByName(string productName);
    }
}