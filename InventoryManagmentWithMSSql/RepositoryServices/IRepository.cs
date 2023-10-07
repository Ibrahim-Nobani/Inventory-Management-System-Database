using Models;
namespace RepositoryServices
{
    public interface IRepository
    {
        void AddProduct(Product product);
        List<Product> GetAllProducts();
        bool EditProduct(Product product);
        bool DeleteProduct(int productId);
        Product GetProductById(int productId);
    }
}