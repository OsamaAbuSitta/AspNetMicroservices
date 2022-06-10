using Catalog.Api.Data;
using Catalog.Api.Entities;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog.Api.Repositories;

public interface IProductRepository
{
    Task<List<Product>> GetProducts();
    Task<Product> GetProduct(string id);
    Task<List<Product>> GetProductByName(string productName);
    Task<List<Product>> GetProductByCategory(string categoryName);

    Task CreateProduct(Product product);
    Task<bool> UpdateProduct(Product product);
    Task<bool> DeleteProduct(string id);

}

public class ProductRepository : IProductRepository
{
    private readonly ICatalogContext _catalogContext;

    public ProductRepository(ICatalogContext catalogContext)
    {
        _catalogContext = catalogContext ?? throw new ArgumentNullException(nameof(catalogContext));
    }

    public async Task CreateProduct(Product product)
    {
        await _catalogContext.Products.InsertOneAsync(product);
    }

    public async Task<bool> DeleteProduct(string id)
    {
       var result = await _catalogContext.Products.DeleteOneAsync(p=> p.Id == id);
        return result.IsAcknowledged && result.DeletedCount > 0;
    }

    public async Task<Product> GetProduct(string id)
    {
        var product = await _catalogContext.Products.Find(p => p.Id == id).FirstOrDefaultAsync();
        return product;
    }

    public async Task<List<Product>> GetProductByCategory(string categoryName)
    {
        FilterDefinition<Product> filter = Builders<Product>.Filter.Eq(p => p.Category, categoryName);
        var products = await _catalogContext
                                .Products
                                .Find(filter)
                                .ToListAsync();
        return products;
    }

    public async Task<List<Product>> GetProductByName(string productName)
    {
        FilterDefinition<Product> filter = Builders<Product>.Filter.Eq(p => p.Name , productName);
        var product = await _catalogContext.Products.Find(filter).ToListAsync();
        return product;
    }

    public async Task<List<Product>> GetProducts()
    {
        var products = await _catalogContext
                            .Products
                            .Find(p => true)
                            .ToListAsync();
        return products;
    }

    public async Task<bool> UpdateProduct(Product product)
    {
        var result = await _catalogContext.Products.ReplaceOneAsync(filter: p=> p.Id == product.Id, replacement: product );

        return true;
    }
}