using AutoMapper;
using MongoDB.Driver;
using MultiShop.Catalog.Dtos.CategoryDtos;
using MultiShop.Catalog.Dtos.ProductDtos;
using MultiShop.Catalog.Entities;
using MultiShop.Catalog.Settings;

namespace MultiShop.Catalog.Services.ProductServices
{
    public class ProductService : IProductService
    {
        private readonly IMongoCollection<Product> _productCollection;
        private readonly IMapper _mapper;

        public ProductService(IMapper mapper, IDatabaseSettings _databaseSettings)
        {
            _mapper = mapper;
            var client = new MongoClient(_databaseSettings.ConnectionString);
            var database = client.GetDatabase(_databaseSettings.DatabaseName);
            _productCollection = database.GetCollection<Product>(_databaseSettings.ProductCollectionName);
        }

        public async Task CreateProductAsync(CreateProductDto createProductDto)
        {
            var result = _mapper.Map<Product>(createProductDto);
            await _productCollection.InsertOneAsync(result);
        }

        public async Task DeleteProductAsync(string id)
        {
            await _productCollection.DeleteOneAsync(x => x.ProductId == id);
        }

        public async Task<List<ResultProductDto>> GetAllProductAsync()
        {
            var result = await _productCollection.Find(x => true).ToListAsync();
            return (_mapper.Map<List<ResultProductDto>>(result));
        }

        public async Task<GetByIdProductDto> GetByIdProductAsync(string id)
        {
            var result = await _productCollection.Find<Product>(x => x.ProductId == id).FirstOrDefaultAsync();
            return (_mapper.Map<GetByIdProductDto>(result));
        }

        public async Task UpdateProductAsync(UpdateProductDto updateProductDto)
        {
            var result = _mapper.Map<Product>(updateProductDto);
            await _productCollection.FindOneAndReplaceAsync(x => x.ProductId == updateProductDto.ProductId, result);
        }
    }
}
