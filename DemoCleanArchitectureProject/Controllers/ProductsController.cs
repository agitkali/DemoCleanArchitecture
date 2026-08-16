using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductManagement.Application.Interfaces;
using ProductManagement.Application.DTOs;

namespace DemoCleanArchitectureProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;
        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var Products =await _productService.GetAllAsync();
            return Ok(Products);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var product = await _productService.GetByIdAsync(id);
            return Ok(product);
        }

        [HttpPost]
        public async Task<IActionResult> Create(ProductCreateDto dto)
        {
            
            var product = await _productService.CreateAsync(dto);
            return CreatedAtAction(nameof(GetById), new {id = product.Id} , product);
        }

        [HttpPut]
        public async Task<IActionResult> UPdate(int id, ProductUpdateDto dto)
        {
            var product = await _productService.UpdateAsync(id, dto);
            return Ok(product);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var product = await _productService.DeleteAsync(id);
            return Ok(product);
        }

        [HttpGet("GetProductCategory")]
        public async Task<IActionResult> GetProductsByCategoryAsync(string category)
        {
            var result = await _productService.GetProductsByCategoryAsync(category);
            return Ok(result);
        }
    }
}
