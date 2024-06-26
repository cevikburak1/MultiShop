﻿using Microsoft.AspNetCore.Http;
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
            var result = await _productService.GetAllProductDetailAsync();
            return Ok(result);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductDetailById(string id)
        {
            var result = await _productService.GetByIdProductDetailAsync(id);
            return Ok(result);
        }
        [HttpPost]
        public async Task<IActionResult> CreateProductDetail(CreateProductDetailDto createProductDetailDto)
        {
            await _productService.CreateProductDetailAsync(createProductDetailDto);
            return Ok("Ürün Detay Başarı İle Eklendi");
        }
        [HttpPut]
        public async Task<IActionResult> UpdateProductDetail(UpdateProductDetailDto updateProductDetailDto)
        {
            await _productService.UpdateProductDetailAsync(updateProductDetailDto);
            return Ok("Ürün Detay Başarı İle Güncellendi");
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteProductDetail(string id)
        {
            await _productService.DeleteProductDetailAsync(id);
            return Ok("Ürün Detay Başarı İle Silindi");
        }
    }
}
