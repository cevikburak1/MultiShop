using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Catalog.Dtos.ProductImagesDtos;
using MultiShop.Catalog.Services.ProductImagesServices;


namespace MultiShop.Catalog.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductImageController : ControllerBase
    {
        private readonly IProductImageService _productImageService;

        public ProductImageController(IProductImageService productImageService)
        {
            _productImageService = productImageService;
        }
        [HttpGet]
        public async Task<IActionResult> ProductImageList()
        {
            var result = _productImageService.GetAllProductImageAsync();
            return Ok(result);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductImageById(string id)
        {
            var result = _productImageService.GetByIdProductImageAsync(id);
            return Ok(result);
        }
        [HttpPost]
        public async Task<IActionResult> CreateProductImage(CreateProductImageDto createProductImageDto)
        {
            var result = _productImageService.CreateProductImageAsync(createProductImageDto);
            return Ok("Ürün Resmi Başarı İle Eklendi");
        }
        [HttpPost]
        public async Task<IActionResult> UpdateProductImage(UpdateProductImageDto updateProductImageDto)
        {
            var result = _productImageService.UpdateProductImageAsync(updateProductImageDto);
            return Ok("Ürün Resmi Başarı İle Güncellendi");
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteProductImage(string id)
        {
            var result = _productImageService.DeleteProductImageAsync(id);
            return Ok("Ürün Resmi Başarı İle Silindi");
        }
    }
}
