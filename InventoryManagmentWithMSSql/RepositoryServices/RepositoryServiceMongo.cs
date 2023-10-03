using Models;
using RepositoryServices;
using MongoDB.Driver;

public class RepositoryServiceMongo : IRepository
{
    private readonly IMongoCollection<Product> _productsCollection;

    public RepositoryServiceMongo(IMongoCollection<Product> productsCollection)
    {
        _productsCollection = productsCollection;
    }

    public void AddProduct(Product product)
    {
        _productsCollection.InsertOne(product);
    }

    public bool DeleteProduct(int productId)
    {
        var filteredProduct = Builders<Product>.Filter.Eq(p => p.ProductId, productId);
        var deletedProduct = _productsCollection.DeleteOne(filteredProduct);
        return deletedProduct.DeletedCount > 0;
    }

    public bool EditProduct(Product product)
    {
        var filteredProduct = Builders<Product>.Filter.Eq(p => p.ProductId, product.ProductId);
        var updatedProduct = Builders<Product>.Update
            .Set(p => p.Name, product.Name)
            .Set(p => p.Price, product.Price)
            .Set(p => p.Quantity, product.Quantity);

        var finalProduct = _productsCollection.UpdateOne(filteredProduct, updatedProduct);
        return finalProduct.ModifiedCount > 0;
    }

    public List<Product> GetAllProducts()
    {
        return _productsCollection.Find(_ => true).ToList();
    }

    public Product GetProductById(int productId)
    {
        var filteredProduct = Builders<Product>.Filter.Eq(p => p.ProductId, productId);
        return _productsCollection.Find(filteredProduct).FirstOrDefault();
    }
}