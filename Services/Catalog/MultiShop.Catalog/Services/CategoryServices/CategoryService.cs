using AutoMapper;
using MongoDB.Driver;
using MultiShop.Catalog.Dtos.CategoryDtos;
using MultiShop.Catalog.Entities;
using MultiShop.Catalog.Settings;
using System.Collections.Generic;

namespace MultiShop.Catalog.Services.CategoryServices
{
    public class CategoryService : ICategoryService
    {
        private readonly IMongoCollection<Category> _categoryCollection;
        private readonly IMapper _mapper;

        public CategoryService(IDatabaseSettings _databaseSettings, IMapper mapper)
        {
          var client = new MongoClient(_databaseSettings.ConnectionString);
          var database = client.GetDatabase(_databaseSettings.DatabaseName);
          _categoryCollection = database.GetCollection<Category>(_databaseSettings.CategoryCollectionName);
          _mapper = mapper;
        }

        public async Task CreateCategoryAsync(CreateCategoryDto createCategoryDto)
        {
            var result = _mapper.Map<Category>(createCategoryDto);
            await _categoryCollection.InsertOneAsync(result);
        }

        public async Task DeleteCategoryAsync(string id)
        {
           await _categoryCollection.DeleteOneAsync(x=>x.CategetoryId==id);

        }

        public async Task<List<ResultCategoryDto>> GetAllCategoriesAsync()
        {
            var result =await _categoryCollection.Find(x=>true).ToListAsync();
            return (_mapper.Map<List<ResultCategoryDto>>(result));
        }

        public async Task<GetByIdCategoryDto> GetByIdCategoryAsync(string id)
        {
            var result = await _categoryCollection.Find<Category>(x=>x.CategetoryId==id).FirstOrDefaultAsync();
            return (_mapper.Map<GetByIdCategoryDto>(result));
        }

        public async Task UpdateCategoryAsync(UpdateCategoryDto updateCategoryDto)
        {
            var result = _mapper.Map<Category>(updateCategoryDto);
            await _categoryCollection.FindOneAndReplaceAsync(x=>x.CategetoryId==updateCategoryDto.CategetoryId,result);
        }
    }
}
