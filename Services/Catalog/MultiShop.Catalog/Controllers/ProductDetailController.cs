using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Catalog.Dtos.ProductDetailDtos;
using MultiShop.Catalog.Services.ProductDetailServices;

namespace MultiShop.Catalog.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductDetailController : ControllerBase
    {
        private readonly IProductDetailService _productService;

        public ProductDetailController(IProductDetailService productService)
        {
            _productService = productService;
        }
        [HttpGet]
        public async Task<IActionResult> ProductDetailList()
        {
            var result = _productService.GetAllProductDetailAsync();
            return Ok(result);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductDetailById(string id)
        {
            var result = _productService.GetByIdProductDetailAsync(id);
            return Ok(result);
        }
        [HttpPost]
        public async Task<IActionResult> CreateProductDetail(CreateProductDetailDto createProductDetailDto)
        {
            var result = _productService.CreateProductDetailAsync(createProductDetailDto);
            return Ok("Ürün Detay Başarı İle Eklendi");
        }
        [HttpPost]
        public async Task<IActionResult> UpdateProductDetail(UpdateProductDetailDto updateProductDetailDto)
        {
            var result = _productService.UpdateProductDetailAsync(updateProductDetailDto);
            return Ok("Ürün Detay Başarı İle Güncellendi");
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteProductDetail(string id)
        {
            var result = _productService.DeleteProductDetailAsync(id);
            return Ok("Ürün Detay Başarı İle Silindi");
        }
    }
}
