﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Catalog.Dtos.CategoryDtos;
using MultiShop.Catalog.Services.CategoryServices;

namespace MultiShop.Catalog.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet]
        public async Task<IActionResult> CategoryList() 
        {
            var result = await _categoryService.GetAllCategoriesAsync();
            return Ok(result);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCategoriesById(string id)
        {
            var result = await _categoryService.GetByIdCategoryAsync(id);
            return Ok(result);
        }
        [HttpPost]
        public async Task<IActionResult> CreateCategories(CreateCategoryDto createCategoryDto)
        {
            await _categoryService.CreateCategoryAsync(createCategoryDto);
            return Ok("Kategori Başarı İle Eklendi");
        }
        [HttpPut]
        public async Task<IActionResult> UpdateCategories(UpdateCategoryDto updateCategoryDto)
        {
            await _categoryService.UpdateCategoryAsync(updateCategoryDto);
            return Ok("Kategori Başarı İle Güncellendi");
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteCategories(string id)
        {
            await _categoryService.DeleteCategoryAsync(id);
            return Ok("Kategori Başarı İle Silindi");
        }
    }
}
