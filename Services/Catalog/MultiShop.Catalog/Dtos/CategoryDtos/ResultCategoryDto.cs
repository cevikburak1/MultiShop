using MongoDB.Bson.Serialization.Attributes;

namespace MultiShop.Catalog.Dtos.CategoryDtos
{
    public class ResultCategoryDto
    {
        public string CategetoryId { get; set; }

        public string CategetoryName { get; set; }
    }
}
