using Microsoft.Extensions.Options;
using MongoDB.Driver;
using ProductCatalogService.ProductModels;
using ProductCatalogServiceRamos.ProductModels;

namespace ProductCatalogServiceRamos.Services;

public class ProductsService
{
    private readonly IMongoCollection<Products> _productsCollection;

    public ProductsService(
        IOptions<ProductsDatabaseSettings> productsDatabaseSettings)
    {
        var mongoClient = new MongoClient(
            productsDatabaseSettings.Value.ConnectionString);

        var mongoDatabase = mongoClient.GetDatabase(
            productsDatabaseSettings.Value.DatabaseName);

        _productsCollection = mongoDatabase.GetCollection<Products>(
            productsDatabaseSettings.Value.ProductsCollectionName);
    }

    public async Task<List<Products>> GetAsync() =>
     await _productsCollection.Find(_ => true).ToListAsync();

    public async Task<Products?> GetAsync(string id) =>
        await _productsCollection.Find(x => x.Id == id).FirstOrDefaultAsync();

    public async Task CreateAsync(Products newProducts) =>
        await _productsCollection.InsertOneAsync(newProducts);

    public async Task UpdateAsync(string id, Products updatedProducts) =>
        await _productsCollection.ReplaceOneAsync(x => x.Id == id, updatedProducts);

    public async Task RemoveAsync(string id) =>
        await _productsCollection.DeleteOneAsync(x => x.Id == id);
}